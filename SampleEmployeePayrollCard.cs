using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    public partial class SampleEmployeePayrollCard : UserControl
    {

        public string _id;
        private Image _image;
        private string _name;
        private string _tutoringHours;
        private string _lateTime;
        private string _deductions;
        private string _wage;
        private string _status;
        private string _payrollPeriod;

        public SampleEmployeePayrollCard()
        {
            InitializeComponent();
        }

        [Category("Custom Control")]
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                btnActivePayrollStatus.Text = value;
            }
        }

        [Category("Custom Control")]
        public string PayrollPeriod
        {
            get => _payrollPeriod;
            set
            {
                _payrollPeriod = value;
                btnPayrollPeriod.Text = value;
            }
        }

        [Category("Custom Control")]
        public string ID
        {
            get => _id;
            set
            {
                _id = value;
                lblID.Text = value;
            }
        }

        [Category("Custom Control")]
        public Image EmployeeProfilePic
        {
            get => _image;
            set
            {
                _image = value;
                employeeProfilePicture.Image = value;
            }
        }

        [Category("Custom Control")]
        public string EmployeeName
        {
            get => _name;
            set
            {
                _name = value;
                lblName.Text = value;
            }
        }


        [Category("Custom Control")]
        public string TutoringHours
        {
            get => _tutoringHours;
            set
            {
                _tutoringHours = value;
                lblComputedTutoringHours.Text = value;
            }
        }

        [Category("Custom Control")]
        public string LateTime
        {
            get => _lateTime;
            set
            {
                _lateTime = value;
                lblComputedLateTime.Text = value;
            }
        }

        [Category("Custom Control")]
        public string Deductions
        {
            get => _deductions;
            set
            {
                _deductions = value;
                lblComputedDeductions.Text = value;
            }
        }

        [Category("Custom Control")]
        public string Wage
        {
            get => _wage;
            set
            {
                _wage = value;
                lblComputedWage.Text = value;
            }
        }

        private async void btnCutPayroll_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the current payroll details
                string query = "SELECT * FROM tbl_payroll WHERE payroll_status = 'In-Progress'";
                DataTable dtPayroll = await Task.Run(() => DB_OperationHelperClass.QueryData(query));

                if (dtPayroll.Rows.Count == 0)
                {
                    MessageBox.Show("No active payroll found to cut.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataRow currentPayroll = dtPayroll.Rows[0];

                DateTime payStartDate = DateTime.Parse(currentPayroll["pay_start_date"].ToString());
                DateTime payEndDate = DateTime.Parse(currentPayroll["pay_end_date"].ToString());
                int payrollId = int.Parse(currentPayroll["payroll_id"].ToString());

                // Check if the end date has passed
                if (DateTime.Now < payEndDate)
                {
                    MessageBox.Show("The payroll period has not ended yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Use the _id property to identify the employee
                string empId = _id;

                // Query to retrieve the total attendance for the employee within the payroll period
                string getAttendanceQuery = @"SELECT COUNT(*) AS EmployeeTotalAttendance
                                              FROM tbl_attendance
                                              WHERE emp_id = @empId
                                              AND CAST(time_in AS DATE) >= @startDate
                                              AND CAST(time_in AS DATE) <= @endDate";

                var attendanceParameters = new Dictionary<string, object>
                {
                    { "@empId", empId },
                    { "@startDate", payStartDate.ToString("yyyy-MM-dd") },
                    { "@endDate", payEndDate.ToString("yyyy-MM-dd") }
                };

                DataTable dtAttendance = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(getAttendanceQuery, attendanceParameters));
                int empTotalAttendance = dtAttendance.Rows.Count > 0 ? Convert.ToInt32(dtAttendance.Rows[0]["EmployeeTotalAttendance"]) : 0;

                // Gather payroll details from the UI
                decimal tutoringHours = decimal.Parse(this.TutoringHours.Replace(" hours", ""));
                decimal lateTimeMinutes = decimal.Parse(this.LateTime.Replace("m", ""));
                TimeSpan lateTime = TimeSpan.FromMinutes((double)lateTimeMinutes);
                string lateTimeFormatted = lateTime.ToString(@"hh\:mm\:ss");

                decimal deduction = decimal.Parse(this.Deductions.Replace("₱", "").Replace(",", ""));
                decimal netPay = decimal.Parse(this.Wage.Replace("₱", "").Replace(",", ""));
                decimal grossPay = netPay + deduction;

                // Update existing employee payroll details in tbl_wage
                string updateWageQuery = @"UPDATE tbl_wage
                                           SET emp_total_attendance = @totalAttendance,
                                               gross_pay = @grossPay,
                                               tutoring_hours = @tutoringHours,
                                               late_time = @lateTime,
                                               deduction = @deduction,
                                               net_pay = @netPay,
                                               custom_cut_date = @customCutDate,
                                               status = 'Completed'
                                           WHERE payroll_id = @payrollId
                                             AND emp_id = @empId";

                var wageParameters = new Dictionary<string, object>
                {
                    { "@totalAttendance", empTotalAttendance },
                    { "@grossPay", grossPay },
                    { "@tutoringHours", tutoringHours },
                    { "@lateTime", lateTimeFormatted },
                    { "@deduction", deduction },
                    { "@netPay", netPay },
                    { "@customCutDate", DateTime.Now }, // Set custom_cut_date to the current date and time
                    { "@payrollId", payrollId },
                    { "@empId", empId }
                };

                await Task.Run(() => DB_OperationHelperClass.ExecuteCRUDSQLQuery(updateWageQuery, wageParameters));

                // Update UI elements after successful payroll cut
                btnActivePayrollStatus.Text = "Completed"; // Update status button text
                lblTextPendingPayrollSummary.ForeColor = Color.ForestGreen;
                lblTextPendingPayrollSummary.Text = "Completed Payroll Summary"; // Update summary label text
                lblTutoringHours.Text = "Tutoring Hours (Total):";
                lblLateTime.Text = "Late Time (Total):";
                lblDeductions.Text = "Deductions (Total):";
                lblNetWage.Text = "Net Wage (Total):";
                btnViewEmployeePayrollDetails.Visible = false; // Hide the Cut Payroll button
                btnViewProcessedPayrollDetails.Visible = true; // Show the View Processed Payroll Details button

                MessageBox.Show("Employee payroll has been successfully cut.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while cutting payroll for this employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewProcessedPayrollDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_id);
        }
    }
}