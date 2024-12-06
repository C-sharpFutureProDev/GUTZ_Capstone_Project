using OfficeOpenXml.Drawing.Slicer.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    public partial class SampleEmployeeDetailsCard : UserControl
    {
        private EmployeeList _employeeList;
        string _id = "";

        public SampleEmployeeDetailsCard(string _empID, EmployeeList employeeList)
        {
            InitializeComponent();
            if (_empID != null)
            {
                this._id = _empID;
                _employeeList = employeeList;
            }

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnMaximize, "Maximize View");
            toolTip.SetToolTip(btnMinimize, "Minimize View");
            toolTip.SetToolTip(btnDeactivateEmployee, "Deactivate Employee");
            toolTip.SetToolTip(btnDeleteProfile, "Delete Profile");
            btnMaximize.Click += btnMaximize_Click;
        }

        private void SampleEmployeeDetailsCard_Load(object sender, EventArgs e)
        {
            LoadEmployeeProfileDetails(_id);
        }

        private void LoadEmployeeProfileDetails(string empId)
        {
            string sql = @"SELECT emp_ProfilePic, f_name, m_name, l_name, is_deleted, tbl_employee.emp_id, email, phone, department_name, position_type, position_desc, 
                                  hired_date, start_date, end_date, employment_type, work_arrangement, work_days, start_time, end_time, account_name, 
                                  tbl_employee.account_id,
                                  tenured_rate, non_tenured_rate, duration
                          FROM tbl_employee
                          INNER JOIN tbl_department ON tbl_department.department_id = tbl_employee.department_id
                          INNER JOIN tbl_position ON tbl_position.position_id = tbl_employee.position_id
                          INNER JOIN tbl_schedule ON tbl_schedule.emp_id = tbl_employee.emp_id
                          INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
                          INNER JOIN tbl_rates ON tbl_rates.account_id = tbl_employee.account_id
                          INNER JOIN tbl_duration ON tbl_duration.account_id = tbl_employee.account_id
                          WHERE tbl_employee.emp_id = @empId";

            var parameterEmployeeProfile = new Dictionary<string, object>
            {
                {"@empId", empId }
            };

            try
            {
                DataTable dt = DB_OperationHelperClass.ParameterizedQueryData(sql, parameterEmployeeProfile);

                if (dt.Rows.Count > 0)
                {
                    string imagePath = dt.Rows[0]["emp_ProfilePic"].ToString();
                    employeeProfilePicture.Image = Image.FromFile(imagePath);
                    employeeProfileImage.Image = Image.FromFile(imagePath);

                    string firstName = dt.Rows[0]["f_name"].ToString();
                    string middleName = dt.Rows[0]["m_name"].ToString();
                    string lastName = dt.Rows[0]["l_name"].ToString();
                    string name = string.IsNullOrEmpty(middleName) || middleName == "N/A"
                        ? $"{firstName} {lastName}"
                        : $"{firstName} {middleName[0]}. {lastName}";

                    string email = dt.Rows[0]["email"].ToString();
                    string phone = dt.Rows[0]["phone"].ToString();
                    string department = dt.Rows[0]["department_name"].ToString();

                    string position = dt.Rows[0]["position_type"].ToString();
                    lblEmployeeRole.Text = position == "Administrator" ? "ESL ADMIN" : "ESL Employee";

                    string jobDesc = dt.Rows[0]["position_desc"].ToString();
                    lblEmployeeFullName.Text = name;
                    lblEmployeeID.Text = empId;
                    lblEmployeeEmail.Text = email;
                    lblEmployeePhoneNo.Text = phone;
                    lblEmployeeDepartment.Text = department;
                    lblEmployeeJobDescription.Text = jobDesc;

                    // Handle dates
                    string addedOn = dt.Rows[0]["hired_date"].ToString();
                    lblEmployeeOnboardingDate.Text = DateTime.TryParse(addedOn, out DateTime dateAdded)
                        ? dateAdded.ToString("MMMM dd, yyyy")
                        : "Date not available";

                    string hireDate = dt.Rows[0]["hired_date"].ToString();
                    lblEmployeeHireDate.Text = DateTime.TryParse(hireDate, out DateTime dateHired)
                        ? dateHired.ToString("MMMM dd, yyyy")
                        : "Date not available";

                    string startDate = dt.Rows[0]["start_date"].ToString();
                    lblEmployeeStartDate.Text = DateTime.TryParse(startDate, out DateTime dateStarted)
                        ? dateStarted.ToString("MMMM dd, yyyy")
                        : "Date not available";

                    string endDate = dt.Rows[0]["end_date"].ToString();
                    lblEmployeeEndDate.Text = DateTime.TryParse(endDate, out DateTime dateEnd)
                        ? dateEnd.ToString("MMMM dd, yyyy")
                        : "Date not available";

                    // Retrieve the administrator's name
                    string sqlAdmin = @"SELECT f_name, m_name, l_name 
                                FROM tbl_employee
                                INNER JOIN tbl_position ON tbl_position.position_id = tbl_employee.position_id
                                WHERE position_type = @administrator";

                    var adminParameters = new Dictionary<string, object>
                    {
                        {"@administrator", "Administrator"}
                    };

                    DataTable adminNameTable = DB_OperationHelperClass.ParameterizedQueryData(sqlAdmin, adminParameters);
                    if (adminNameTable.Rows.Count > 0)
                    {
                        string adminFirstName = adminNameTable.Rows[0]["f_name"].ToString();
                        string adminMiddleName = adminNameTable.Rows[0]["m_name"].ToString();
                        string adminLastName = adminNameTable.Rows[0]["l_name"].ToString();

                        // Construct and display the admin name
                        string adminName = string.IsNullOrEmpty(adminMiddleName) || adminMiddleName == "N/A"
                            ? $"{adminFirstName} {adminLastName}"
                            : $"{adminFirstName} {adminMiddleName[0]}. {adminLastName}";

                        lblOnboardingPersonel.Text = adminName;
                    }
                    else
                    {
                        lblOnboardingPersonel.Text = "No Administrator Found";
                    }

                    string employmentType = dt.Rows[0]["employment_type"].ToString();
                    lblEmployeeEmploymenType.Text = employmentType + " - " + "Inbound";

                    string work_arrangement = dt.Rows[0]["work_arrangement"].ToString();
                    lblEmployeeWorkingArrangement.Text = work_arrangement + " - " + "Inbound";

                    string workDaysString = dt.Rows[0]["work_days"].ToString();
                    if (!string.IsNullOrEmpty(workDaysString))
                    {
                        // Split the work days string into an array
                        string[] fullDayNames = workDaysString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        // Map full day names to abbreviated format
                        var dayAbbreviations = new Dictionary<string, string>
                        {
                            { "Monday", "Mon." },
                            { "Tuesday", "Tue." },
                            { "Wednesday", "Wed." },
                            { "Thursday", "Thu." },
                            { "Friday", "Fri." }
                            //{ "Saturday", "Sat." },
                            //{ "Sunday", "Sun." }
                        };

                        // Create a list to hold abbreviated day names
                        var abbreviatedDays = new List<string>();

                        foreach (var day in fullDayNames)
                        {
                            // Trim the day and check if it exists in the abbreviation dictionary
                            string trimmedDay = day.Trim();
                            if (dayAbbreviations.ContainsKey(trimmedDay))
                            {
                                abbreviatedDays.Add(dayAbbreviations[trimmedDay]);
                            }
                        }

                        // Join the abbreviated days with " - "
                        lblEmployeeWorkingDays.Text = string.Join(" - ", abbreviatedDays);

                        string accountName = dt.Rows[0]["account_name"].ToString();
                        lblEmployeeAccountName.Text = accountName;

                        if (employmentType == "Tenured")
                        {
                            double ratePerHour = double.Parse(dt.Rows[0]["tenured_rate"].ToString());
                            lblEmployeRatePerHour.Text = "₱ " + ratePerHour.ToString("n2");
                        }
                        else if (employmentType == "Non-Tenured")
                        {
                            double ratePerHour = double.Parse(dt.Rows[0]["non_tenured_rate"].ToString());
                            lblEmployeRatePerHour.Text = "₱ " + ratePerHour.ToString("n2");
                        }
                    }
                    else
                    {
                        lblEmployeeWorkingDays.Text = "No working days available"; // Handle case with no working days
                    }

                    // Retrieve start_time and end_time
                    string startTimeString = dt.Rows[0]["start_time"].ToString();
                    string endTimeString = dt.Rows[0]["end_time"].ToString();
                    DateTime startTime, endTime;

                    // Parsed retrieved start and end time values
                    if (DateTime.TryParse(startTimeString, out startTime) &&
                        DateTime.TryParse(endTimeString, out endTime))
                    {
                        // Format the working hours in AM/PM format
                        lblEmployeeWorkingHours.Text = $"{startTime:hh:mm tt}".ToUpper() + " - " + $"{endTime:hh:mm tt}".ToUpper();
                    }
                    else
                    {
                        lblEmployeeWorkingHours.Text = "Working hours not available";
                    }


                }
                else
                {
                    MessageBox.Show("No Employee Profile Details Found for this Employee", "No Details Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading employee profile details: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*private async Task<Image> LoadImageAsync(string imagePath)
        {
            return await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
                {
                    MessageBox.Show("No profile image found.", "Image Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
                }

                try
                {
                    using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        return Image.FromStream(stream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            });
        }*/

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (_employeeList != null)
            {
                // Disable auto-scrolling
                //_employeeList.flowLayoutPanel2.AutoScroll = false;

                // Hide the flow layout panel and the main panel
                _employeeList.flowLayoutPanel1.Visible = false;
                _employeeList.panelEmployeeListFeatures.Visible = false;

                // Make the minimize button visible and bring it to the front
                btnMinimize.Visible = true;
                //btnMinimize.BringToFront();
                btnMaximize.Visible = false;

                _employeeList.flowLayoutPanel1.PerformLayout();
                _employeeList.panelEmployeeListFeatures.PerformLayout();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            if (_employeeList != null)
            {
                // Enabled auto-scrolling
                _employeeList.flowLayoutPanel2.AutoScroll = true;

                //btnMinimize.Visible = false;
                btnMaximize.Visible = true;
                //_employeeList.txtSearch.Clear();
                _employeeList.flowLayoutPanel1.Visible = true;
                _employeeList.panelEmployeeListFeatures.Visible = true;
            }
        }
    }
}
