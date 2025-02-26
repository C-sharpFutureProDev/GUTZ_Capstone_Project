using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    public partial class EmployeePayrollHistory : UserControl
    {
        string _id_ = string.Empty;
        private FormEmployeePayrollManagement _employeePayrollManagement;

        public EmployeePayrollHistory(string id_, FormEmployeePayrollManagement employeePayrollManagement)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(id_))
            {
                _id_ = id_;
            }

            _employeePayrollManagement = employeePayrollManagement;
        }

        private async void EmployeePayrollHistory_Load(object sender, EventArgs e)
        {
            await LoadEmployeeDataAsync();
        }

        private async Task LoadEmployeeDataAsync()
        {
            try
            {
                string employeeSql = @"SELECT 
                                            emp_ProfilePic, 
                                            CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS FullName, 
                                            work_days, 
                                            start_time, 
                                            end_time, 
                                            position_desc, 
                                            start_date, 
                                            tbl_account.account_name, 
                                            employment_type, 
                                            tenured_rate, 
                                            non_tenured_rate
                                        FROM 
                                            tbl_employee
                                        INNER JOIN 
                                            tbl_account ON tbl_employee.account_id = tbl_account.account_id
                                        INNER JOIN 
                                            tbl_rates ON tbl_rates.account_id = tbl_account.account_id
                                        INNER JOIN 
                                            tbl_schedule ON tbl_employee.emp_id = tbl_schedule.emp_id
                                        INNER JOIN 
                                            tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                        WHERE 
                                            tbl_employee.emp_id = @empId";

                var paramID = new Dictionary<string, object> { { "@empId", _id_ } };

                DataTable employeeDt = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(employeeSql, paramID));

                if (employeeDt.Rows.Count > 0)
                {
                    // Load employee profile picture and basic information
                    string image_path = employeeDt.Rows[0]["emp_ProfilePic"].ToString();
                    employeeProfilePicture.Image = await LoadImageAsync(image_path);
                    lblEmployeeName.Text = employeeDt.Rows[0]["FullName"].ToString();
                    lblEmployeeJobRole.Text = employeeDt.Rows[0]["position_desc"].ToString();

                    // Get account name and format work days
                    string accountName = employeeDt.Rows[0]["account_name"].ToString();
                    lblRateName.Text = accountName;

                    string workDays = employeeDt.Rows[0]["work_days"]?.ToString() ?? "N/A";
                    // Convert work days to first letter format
                    var workDaysArray = workDays.Split(',').Select(day => day.Trim().Substring(0, 1).ToUpper());
                    string formattedWorkDays = string.Join(", ", workDaysArray);

                    // Format start_time and end_time to 12-hour format
                    DateTime startTime = DateTime.Parse(employeeDt.Rows[0]["start_time"].ToString());
                    DateTime endTime = DateTime.Parse(employeeDt.Rows[0]["end_time"].ToString());

                    string formattedStartTime = startTime.ToString("hh:mm tt");
                    string formattedEndTime = endTime.ToString("hh:mm tt");

                    // Calculate Required Tutoring Hours
                    TimeSpan tutoringDuration = endTime - startTime;
                    string requiredTutoringHours;

                    if (tutoringDuration.TotalMinutes > 0)
                    {
                        requiredTutoringHours = $"{(int)tutoringDuration.TotalHours} hour{(tutoringDuration.TotalHours == 1 ? "" : "s")}";

                        if (tutoringDuration.Minutes > 0)
                        {
                            requiredTutoringHours += $" {tutoringDuration.Minutes} minute{(tutoringDuration.Minutes == 1 ? "" : "s")}";
                        }
                    }
                    else
                    {
                        requiredTutoringHours = "0 hours"; // In case of zero duration
                    }

                    // Update the labels with the additional information
                    lblRequiredTutoringHours.Text = requiredTutoringHours;

                    // Calculate the rate per hour based on employment type
                    decimal ratePerHour = employeeDt.Rows[0]["employment_type"].ToString() == "Tenured"
                        ? Convert.ToDecimal(employeeDt.Rows[0]["tenured_rate"])
                        : Convert.ToDecimal(employeeDt.Rows[0]["non_tenured_rate"]);

                    lblRatePerHour.Text = ratePerHour.ToString("C");
                }
                else
                {
                    MessageBox.Show("No attendance records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<Image> LoadImageAsync(string imagePath)
        {
            return await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
                {
                    return null;
                }

                try
                {
                    using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        return Image.FromStream(stream);
                    }
                }
                catch
                {
                    return null;
                }
            });
        }

        private void btnDownloadPayrollHistoryRecords_Click(object sender, EventArgs e)
        {

        }

        private void btnBackToPayrollForm_Click(object sender, EventArgs e)
        {

        }
    }
}