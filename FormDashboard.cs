using GUTZ_Capstone_Project.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GUTZ_Capstone_Project
{
    public partial class FormDashboard : Form
    {
        private Guna.UI2.WinForms.Guna2Button currentBtn;
        private Image originalImage;
        private Form currentChildForm;
        private System.Drawing.Color _originalIconColor;
        private DateTime dueDate;
        private string id;

        public FormDashboard(string id)
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;

            this.id = id;
            dueDate = DateTime.Now.AddDays(10);
            timer1.Tick += timer1_Tick;
            timer1.Start();
            this.WindowState = FormWindowState.Maximized;
            originalImage = iconCurrentChildForm.Image;
            //DisplayAdminProfilePic();
            btnPayrollManagement.Click += btnPayrollManagement_Click;
        }

        // Fixed flicker issue on controls rendering
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void DisplayAdminProfilePic() // Set to actual administrator
        {
            string sql = "SELECT emp_profilePic FROM tbl_employee WHERE emp_id = @id";

            var parameters = new Dictionary<string, object> { { "@id", id } };
            try
            {
                DataTable dt = DB_OperationHelperClass.ParameterizedQueryData(sql, parameters);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No profile picture found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string adminProfilePath = dt.Rows[0]["emp_profilePic"].ToString();

                try
                {
                    iconCurrentLoginAdmin.SizeMode = PictureBoxSizeMode.StretchImage;
                    iconCurrentLoginAdmin.Image = Image.FromFile(adminProfilePath);
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Profile picture file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading profile picture: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ActivateButton(object senderBtn)
        {
            DisableButton();
            if (senderBtn is Guna.UI2.WinForms.Guna2Button btn)
            {
                currentBtn = btn;
                currentBtn.FillColor = Color.FromArgb(3, 58, 14);
                currentBtn.ForeColor = Color.White;
                iconCurrentChildForm.Image = currentBtn.Image;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.FillColor = Color.FromArgb(19, 92, 61);
                currentBtn.ForeColor = Color.White;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            SuspendLayout();

            if (currentChildForm != null && !currentChildForm.IsDisposed)
                currentChildForm.Close();

            currentChildForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            lblTitleChildForm.Text = childForm.Text;

            ResumeLayout(false);
        }

        private void Reset()
        {
            DisableButton();
            currentChildForm.Close();

            if (iconCurrentChildForm != null)
            {
                iconCurrentChildForm.Image = originalImage;
                lblTitleChildForm.Text = "Dashboard";
                lblTitleChildForm.ForeColor = Color.White;
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new EmployeeList());
        }

        private void btnAttendanceMonitoring_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new EmployeeAttendance());
        }

        private void btnPayrollManagement_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormEmployeePayrollManagement());
        }

        private void btnGenerateReports_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormGenerateReports());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
                Reset();

            CountTotalEmployee();
            CountAttendanceForToday();
            CountActiveEmployeeLeave();
            //SumTotalEmployeeNetWages();
            LoadAllAvailablePastPayrollPeriod();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateDateTimeLabel();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            UpdateDateTimeLabel();
            timer1.Start();
            CountTotalEmployee();
            CountAttendanceForToday();
            CountActiveEmployeeLeave();
            //SumTotalEmployeeNetWages();
            LoadAllAvailablePastPayrollPeriod();
        }

        private void UpdateDateTimeLabel()
        {
            DateTime currentDateTime = DateTime.Now;
            string timeString = currentDateTime.ToString("hh:mm tt");
            string dayOfWeekString = currentDateTime.ToString("dddd");
            string monthString = currentDateTime.ToString("MMMM");
            int dayOfMonth = currentDateTime.Day;
            int year = currentDateTime.Year;
            int weekNumberInMonth = GetWeekNumberInMonth(currentDateTime);
            label1.Text = $"{dayOfWeekString}, {monthString} {dayOfMonth}, {year} | Week {weekNumberInMonth} | {timeString}";
        }

        private int GetWeekNumberInMonth(DateTime date)
        {
            // Get the first day of the month
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);

            // Calculate the week number based on the first day of the month
            int weekNumberInMonth = ((date.Day - 1) / 7) + 1;

            // Check if the first day of the month is not in the first week
            if (firstDayOfMonth.DayOfWeek != DayOfWeek.Sunday && weekNumberInMonth > 1)
            {
                weekNumberInMonth--;
            }

            return weekNumberInMonth;
        }

        private void FormDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Dispose();
        }

        private void iconAdminNotification_MouseEnter(object sender, EventArgs e)
        {
            _originalIconColor = this.iconAdminNotification.IconColor;
            this.iconAdminNotification.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
        }

        private void iconAdminNotification_MouseLeave(object sender, EventArgs e)
        {
            this.iconAdminNotification.IconColor = _originalIconColor;
        }

        private void iconAdminNotification_Click(object sender, EventArgs e)
        {
            this.iconAdminNotification.FlatAppearance.BorderColor = Color.FromArgb(12, 90, 37);
        }

        private void iconAdminSubMenu_MouseEnter(object sender, EventArgs e)
        {
            _originalIconColor = this.iconAdminNotification.IconColor;
            this.iconAdminSubMenu.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
        }

        private void iconAdminSubMenu_MouseLeave(object sender, EventArgs e)
        {
            this.iconAdminSubMenu.IconColor = _originalIconColor;
        }

        private void iconAdminSubMenu_Click(object sender, EventArgs e)
        {
            this.iconAdminSubMenu.FlatAppearance.BorderColor = Color.FromArgb(12, 90, 37);
        }

        private void CountTotalEmployee()
        {
            // Count total active employees
            string countEmployeeQuery = @"SELECT COUNT(*) FROM tbl_employee WHERE is_deleted = 0";
            DataTable dtTotal = DB_OperationHelperClass.QueryData(countEmployeeQuery);

            int countTotalEmployee = dtTotal.Rows.Count > 0 ? Convert.ToInt32(dtTotal.Rows[0][0]) : 0;
            lblTotalEmployee.Text = countTotalEmployee.ToString();

            // Count new employees added in the current month using start_date
            string countNewEmployeesQuery = @"SELECT COUNT(*) 
                                              FROM tbl_employee 
                                              WHERE is_deleted = 0 
                                              AND MONTH(start_date) = MONTH(CURRENT_DATE()) 
                                              AND YEAR(start_date) = YEAR(CURRENT_DATE())";
            DataTable dtNew = DB_OperationHelperClass.QueryData(countNewEmployeesQuery);
            int countNewEmployees = dtNew.Rows.Count > 0 ? Convert.ToInt32(dtNew.Rows[0][0]) : 0;

            // Calculate the percentage of new employees
            double percentageNewEmployees = countTotalEmployee > 0 ? (double)countNewEmployees / countTotalEmployee * 100 : 0;
        }

        private void CountAttendanceForToday()
        {
            DateTime currentDate = DateTime.Today;
            int countWorkingPresent = 0;
            int countWorkingOnTime = 0;
            int countWorkingLate = 0;

            string sqlCountAttendance = $"SELECT s.emp_id, s.start_time, s.end_time, s.work_days, a.time_in, a.time_out, a.time_in_status " +
                                        $"FROM tbl_schedule s " +
                                        $"LEFT JOIN tbl_attendance a ON a.emp_id = s.emp_id AND DATE(a.time_in) = '{currentDate:yyyy-MM-dd}' " +
                                        $"WHERE s.work_days LIKE '%{currentDate.DayOfWeek}%'";

            DataTable dtAttendance = DB_OperationHelperClass.QueryData(sqlCountAttendance);

            HashSet<string> scheduledEmployeeIds = new HashSet<string>();

            foreach (DataRow row in dtAttendance.Rows)
            {
                string empId = row["emp_id"].ToString();
                scheduledEmployeeIds.Add(empId);

                DateTime? timeIn = row["time_in"] as DateTime?;
                if (timeIn.HasValue)
                {
                    countWorkingPresent++;

                    string timeInStatus = row["time_in_status"]?.ToString();
                    if (timeInStatus == "On Time")
                    {
                        countWorkingOnTime++;
                    }
                    else if (timeInStatus == "Late")
                    {
                        countWorkingLate++;
                    }
                }
            }

            int totalScheduledEmployees = scheduledEmployeeIds.Count;
            int totalAttendance = countWorkingOnTime + countWorkingLate;

            lblPresentForToday.Text = countWorkingPresent.ToString();

            double onTimePercentage = totalAttendance > 0 ? (countWorkingOnTime * 100.0) / totalAttendance : 0;
            double latePercentage = totalAttendance > 0 ? (countWorkingLate * 100.0) / totalAttendance : 0;
        }

        private void CountActiveEmployeeLeave()
        {
            try
            {
                string leaveStatus = "Active";
                DateTime today = DateTime.Today;

                // SQL query to count active leaves where today is between start_date and end_date
                string sqlCountActiveLeave = @"SELECT COUNT(*) 
                                               FROM tbl_leave 
                                               WHERE leave_status = @leaveStatus 
                                               AND @today >= start_date 
                                               AND @today <= end_date";

                var parameters = new Dictionary<string, object>
                {
                    { "@leaveStatus", leaveStatus },
                    { "@today", today }
                };

                DataTable countActiveLeave = DB_OperationHelperClass.ParameterizedQueryData(sqlCountActiveLeave, parameters);

                int countTotalActiveLeave = countActiveLeave.Rows.Count > 0 ? Convert.ToInt32(countActiveLeave.Rows[0][0]) : 0;
                lblOnLeave.Text = countTotalActiveLeave.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error counting active leaves: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AttendanceOverview(DateTime payStartDate, DateTime payEndDate)
        {
            try
            {
                string sqlAttendance = @"SELECT COUNT(*) AS TotalCount,
                                                SUM(CASE WHEN time_in_status = 'On Time' THEN 1 ELSE 0 END) AS OnTimeCount,
                                                SUM(CASE WHEN time_in_status = 'Late' THEN 1 ELSE 0 END) AS LateCount
                                         FROM tbl_attendance
                                         WHERE DATE(time_in) BETWEEN @payStartDate AND @payEndDate";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@payStartDate", payStartDate },
                    { "@payEndDate", payEndDate }
                };

                DataTable dtAttendance = DB_OperationHelperClass.ParameterizedQueryData(sqlAttendance, parameters);

                if (dtAttendance.Rows.Count > 0)
                {
                    int totalCount = dtAttendance.Rows[0]["TotalCount"] == DBNull.Value ? 0 : Convert.ToInt32(dtAttendance.Rows[0]["TotalCount"]);
                    int onTimeCount = dtAttendance.Rows[0]["OnTimeCount"] == DBNull.Value ? 0 : Convert.ToInt32(dtAttendance.Rows[0]["OnTimeCount"]);
                    int lateCount = dtAttendance.Rows[0]["LateCount"] == DBNull.Value ? 0 : Convert.ToInt32(dtAttendance.Rows[0]["LateCount"]);

                    lblTotalAttendance.Text = totalCount.ToString();

                    double onTimePercentage = totalCount > 0 ? (double)onTimeCount / totalCount * 100 : 0;
                    double latePercentage = totalCount > 0 ? (double)lateCount / totalCount * 100 : 0;

                    lblOnTimeArrivalPercentage.Text = $"{onTimePercentage:F2}%";
                    lblLateArrivalPercentage.Text = $"{latePercentage:F2}%";

                    // Calculate the total absent count for the period
                    CountAbsentForPeriod(payStartDate, payEndDate);
                    int totalAbsent = int.Parse(lblTotalAbsent.Text);

                    // Calculate the total expected attendance days
                    int totalExpectedAttendanceDays = totalCount + totalAbsent;

                    // Calculate the new overall attendance percentage
                    double overallAttendancePercentage = totalExpectedAttendanceDays > 0
                        ? ((double)totalCount / totalExpectedAttendanceDays) * 100
                        : 0;

                    lblOverallAttendancePercentage.Text = $"{overallAttendancePercentage:F2}%";
                }
                else
                {
                    lblTotalAttendance.Text = "0";
                    lblOnTimeArrivalPercentage.Text = "0%";
                    lblLateArrivalPercentage.Text = "0%";
                    lblOverallAttendancePercentage.Text = "0%";
                    lblTotalAbsent.Text = "0";
                }

                string sqlLeave = @"SELECT SUM(CASE 
                                                 WHEN leave_status = 'Completed' THEN DATEDIFF(end_date, start_date) + 1
                                                 WHEN leave_status = 'Active' AND start_date <= @payEndDate THEN DATEDIFF(@payEndDate, start_date) + 1
                                                 ELSE 0 
                                               END) AS TotalLeaveDays
                                    FROM tbl_leave
                                    WHERE 
                                         (leave_status = 'Completed' AND end_date < @payEndDate)
                                         OR 
                                         (leave_status = 'Active' AND start_date <= @payEndDate AND end_date >= @payStartDate)";

                DataTable dtLeave = DB_OperationHelperClass.ParameterizedQueryData(sqlLeave, parameters);

                if (dtLeave.Rows.Count > 0)
                {
                    int totalLeaveDays = dtLeave.Rows[0]["TotalLeaveDays"] == DBNull.Value ? 0 : Convert.ToInt32(dtLeave.Rows[0]["TotalLeaveDays"]);
                    lblTotalLeaveCount.Text = totalLeaveDays.ToString();
                }
                else
                {
                    lblTotalLeaveCount.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving attendance and leave data. Details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PayrollOverview(DateTime payStartDate, DateTime payEndDate)
        {
            try
            {
                string sqlPayroll = @"SELECT total_attendance AS TotalAttendance,
                                        gross_pay_total AS TotalGrossPay,
                                        deduction_total AS TotalDeductions,
                                        net_pay_total AS NetPay
                                      FROM tbl_payroll
                                      WHERE payroll_status = 'Completed'
                                      AND pay_start_date = @payStartDate
                                      AND pay_end_date = @payEndDate";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@payStartDate", payStartDate },
                    { "@payEndDate", payEndDate }
                };

                DataTable dtPayroll = DB_OperationHelperClass.ParameterizedQueryData(sqlPayroll, parameters);

                if (dtPayroll.Rows.Count > 0)
                {
                    DataRow payrollRow = dtPayroll.Rows[0];

                    int totalAttendance = Convert.ToInt32(payrollRow["TotalAttendance"]);
                    double totalGrossPay = Convert.ToDouble(payrollRow["TotalGrossPay"]);
                    double totalDeductions = Convert.ToDouble(payrollRow["TotalDeductions"]);
                    double totalNetPay = Convert.ToDouble(payrollRow["NetPay"]);

                    lblTotalGrossPay.Text = $"₱{totalGrossPay:n2}";
                    lblTotalDeductions.Text = $"₱{totalDeductions:n2}";
                    lblTotalNetPay.Text = $"₱{totalNetPay:n2}";

                    string sqlWage = @"SELECT 
                                            SUM(CASE WHEN tutoring_hours IS NOT NULL THEN CAST(tutoring_hours AS DECIMAL(10, 2)) ELSE 0 END) AS TotalTutoringHours,
                                            SUM(CASE WHEN late_time IS NOT NULL THEN TIME_TO_SEC(late_time) ELSE 0 END) AS TotalLateTime
                                       FROM tbl_wage
                                       WHERE payroll_id = (SELECT payroll_id FROM tbl_payroll WHERE pay_start_date = @payStartDate AND pay_end_date = @payEndDate LIMIT 1)";

                    DataTable dtWage = DB_OperationHelperClass.ParameterizedQueryData(sqlWage, parameters);

                    if (dtWage.Rows.Count > 0)
                    {
                        double totalTutoringHours = Convert.ToDouble(dtWage.Rows[0]["TotalTutoringHours"]);
                        double totalLateTimeInSeconds = Convert.ToDouble(dtWage.Rows[0]["TotalLateTime"]);

                        double totalLateTimeInHours = totalLateTimeInSeconds / 3600;
                        double grossTotalHours = totalTutoringHours + totalLateTimeInHours;

                        lblTotalTutoringHours.Text = $"{grossTotalHours:F2} hrs.";
                        lblNetTutoringHours.Text = $"{totalTutoringHours:F2} hrs.";

                        if (totalLateTimeInHours > 0)
                        {
                            lblTotalLateTime.Text = $"{totalLateTimeInHours:F2} hrs.";
                        }
                        else
                        {
                            lblTotalLateTime.Text = "0 hrs.";
                        }
                    }
                    else
                    {
                        lblTotalTutoringHours.Text = "0h";
                        lblNetTutoringHours.Text = "0h";
                        lblTotalLateTime.Text = "0h";
                    }
                }
                else
                {
                    lblTotalGrossPay.Text = "₱0.00";
                    lblTotalDeductions.Text = "₱0.00";
                    lblTotalNetPay.Text = "₱0.00";
                    lblTotalTutoringHours.Text = "0h";
                    lblNetTutoringHours.Text = "0";
                    lblTotalLateTime.Text = "0h";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving payroll data. Details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadAllAvailablePastPayrollPeriod()
        {
            try
            {
                string sql = @"SELECT pay_start_date, pay_end_date FROM tbl_payroll WHERE payroll_status = 'Completed'";
                DataTable dt = await Task.Run(() => DB_OperationHelperClass.QueryData(sql));

                flowLayoutPanelCompletedPeriods.Controls.Clear();

                bool isFirstPeriod = true;

                foreach (DataRow row in dt.Rows)
                {
                    DateTime payStartDate = Convert.ToDateTime(row["pay_start_date"]);
                    DateTime payEndDate = Convert.ToDateTime(row["pay_end_date"]);
                    string formattedPayrollPeriod = $"{payStartDate:MMMM d, yyyy} - {payEndDate:MMMM d, yyyy}";

                    // Create a checkbox for each payroll period
                    CheckBox chkPayrollPeriod = new CheckBox
                    {
                        Text = formattedPayrollPeriod,
                        AutoSize = true,
                        Font = new System.Drawing.Font("Bookman Old Style", 9),
                        Tag = new { StartDate = payStartDate, EndDate = payEndDate },
                        Checked = isFirstPeriod // Check the first period by default
                    };

                    // Add event handler for checkbox CheckedChanged event
                    chkPayrollPeriod.CheckedChanged += ChkPayrollPeriod_CheckedChanged;

                    flowLayoutPanelCompletedPeriods.Controls.Add(chkPayrollPeriod);

                    if (isFirstPeriod)
                    {
                        // Load data for the first payroll period
                        await LoadPayrollPeriodData(payStartDate, payEndDate);
                        isFirstPeriod = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading payroll periods: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ChkPayrollPeriod_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender is CheckBox checkBox && checkBox.Checked)
                {
                    // Uncheck all other checkboxes
                    foreach (Control control in flowLayoutPanelCompletedPeriods.Controls)
                    {
                        if (control is CheckBox chk && chk != checkBox)
                        {
                            chk.Checked = false;
                        }
                    }

                    // Retrieve the pay start and end dates from the checkbox's Tag property
                    var dates = (dynamic)checkBox.Tag;
                    DateTime payStartDate = dates.StartDate;
                    DateTime payEndDate = dates.EndDate;

                    // Load data for the selected payroll period
                    await LoadPayrollPeriodData(payStartDate, payEndDate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while selecting a payroll period: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadPayrollPeriodData(DateTime payStartDate, DateTime payEndDate)
        {
            AttendanceOverview(payStartDate, payEndDate);
            PayrollOverview(payStartDate, payEndDate);
            CountAbsentForPeriod(payStartDate, payEndDate);
            await DisplayTopAttendeesAsync(payStartDate, payEndDate);
            await DisplayTopAttendancePercentagesAsync(payStartDate, payEndDate);
            await DisplayTopEarnersAsync(payStartDate, payEndDate);
        }

        private void CountAbsentForPeriod(DateTime startDate, DateTime endDate)
        {
            int countAbsent = 0;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                // Count total scheduled employees for the current date
                int totalScheduledEmployees = CountScheduledEmployeesForDate(date);

                // Count present employees for the current date
                int countPresent = CountPresentEmployeesForDate(date);

                // Ensure that the total scheduled employees is not less than the number of present employees
                totalScheduledEmployees = Math.Max(totalScheduledEmployees, countPresent);

                // Calculate absent employees for the current date
                int absentForDay = totalScheduledEmployees - countPresent;
                countAbsent += absentForDay;
            }

            // Display the total absent count
            lblTotalAbsent.Text = countAbsent.ToString();
        }

        private int CountScheduledEmployeesForDate(DateTime date)
        {
            string countScheduledEmployee = $@"SELECT COUNT(DISTINCT e.emp_id) 
                                               FROM tbl_employee e
                                               INNER JOIN tbl_schedule s ON e.emp_id = s.emp_id
                                               LEFT JOIN tbl_leave l ON e.emp_id = l.emp_id 
                                                      AND l.leave_status = 'Active'
                                                      AND '{date:yyyy-MM-dd}' BETWEEN l.start_date AND l.end_date
                                               INNER JOIN tbl_position p ON e.position_id = p.position_id
                                               WHERE FIND_IN_SET(DAYNAME('{date:yyyy-MM-dd}'), s.work_days) > 0
                                                      AND l.emp_id IS NULL
                                                      AND e.is_deleted = 0
                                                      AND e.start_date <= '{date:yyyy-MM-dd}'
                                                      AND p.position_desc != 'Administrator'";

            DataTable dt = DB_OperationHelperClass.QueryData(countScheduledEmployee);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }

        private int CountPresentEmployeesForDate(DateTime date)
        {
            string sqlCountPresent = $@"SELECT COUNT(DISTINCT a.emp_id) 
                                        FROM tbl_attendance a
                                        WHERE DATE(a.time_in) = '{date:yyyy-MM-dd}'";

            DataTable dt = DB_OperationHelperClass.QueryData(sqlCountPresent);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }

        private async Task DisplayTopAttendeesAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                string sqlTopAttendees = @"SELECT e.emp_id, e.f_name, e.emp_ProfilePic, COUNT(*) AS attendance_count
                                           FROM tbl_employee e
                                           INNER JOIN tbl_attendance a ON e.emp_id = a.emp_id
                                           WHERE DATE(a.time_in) BETWEEN @startDate AND @endDate
                                           GROUP BY e.emp_id, e.f_name, e.emp_ProfilePic
                                           ORDER BY attendance_count DESC, e.emp_id
                                           LIMIT 5";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@startDate", startDate },
                    { "@endDate", endDate }
                };

                DataTable dtTopAttendees = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(sqlTopAttendees, parameters));

                for (int i = 0; i < 5; i++)
                {
                    Label attendanceLabel = (Label)Controls.Find($"lblTop{i + 1}Attendance", true).FirstOrDefault();
                    PictureBox profilePicture = (PictureBox)Controls.Find($"top{i + 1}ProfilePic", true).FirstOrDefault();
                    Label nameLabel = (Label)Controls.Find($"lblTop{i + 1}Name", true).FirstOrDefault();

                    if (attendanceLabel == null || profilePicture == null || nameLabel == null)
                    {
                        throw new Exception($"UI elements for top {i + 1} attendee not found.");
                    }

                    if (i < dtTopAttendees.Rows.Count)
                    {
                        DataRow row = dtTopAttendees.Rows[i];
                        int attendanceCount = Convert.ToInt32(row["attendance_count"]);
                        string fullName = row["f_name"].ToString();
                        string imagePath = row["emp_ProfilePic"].ToString();

                        attendanceLabel.Text = attendanceCount.ToString();
                        nameLabel.Text = fullName;

                        if (!string.IsNullOrEmpty(imagePath))
                        {
                            Image profileImage = await LoadImageAsync(imagePath);
                            profilePicture.Image = profileImage ?? null;
                        }
                        else
                        {
                            profilePicture.Image = null;
                        }
                    }
                    else
                    {
                        // Clear the UI elements for attendees beyond the top 5
                        attendanceLabel.Text = "0";
                        nameLabel.Text = "";
                        profilePicture.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving top attendees data. Details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DisplayTopAttendancePercentagesAsync(DateTime payStartDate, DateTime payEndDate)
        {
            try
            {
                // SQL query to get the top attendees
                string sqlTopAttendees = @"SELECT e.emp_id, e.f_name, COUNT(*) AS attendance_count
                                           FROM tbl_employee e
                                           INNER JOIN tbl_attendance a ON e.emp_id = a.emp_id
                                           WHERE DATE(a.time_in) BETWEEN @startDate AND @endDate
                                           GROUP BY e.emp_id, e.f_name
                                           ORDER BY attendance_count DESC
                                           LIMIT 5";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@startDate", payStartDate },
                    { "@endDate", payEndDate }
                };

                DataTable dtTopAttendees = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(sqlTopAttendees, parameters));

                for (int i = 0; i < 5; i++)
                {
                    Label percentageLabel = (Label)Controls.Find($"lblTop{i + 1}AttendancePercentage", true).FirstOrDefault();

                    if (percentageLabel == null)
                    {
                        throw new Exception($"UI element for top {i + 1} attendance percentage not found.");
                    }

                    if (i < dtTopAttendees.Rows.Count)
                    {
                        DataRow row = dtTopAttendees.Rows[i];
                        int empId = Convert.ToInt32(row["emp_id"]);
                        int attendanceCount = Convert.ToInt32(row["attendance_count"]);

                        // Calculate total scheduled days for the employee
                        int totalScheduledDays = CountScheduledDaysForEmployee(empId, payStartDate, payEndDate);

                        // Calculate absent days for the employee
                        int absentDays = totalScheduledDays - attendanceCount;

                        // Calculate attendance percentage
                        double attendancePercentage = totalScheduledDays > 0
                            ? ((double)attendanceCount / totalScheduledDays) * 100
                            : 0;

                        percentageLabel.Text = $"{attendancePercentage:F2}%";
                    }
                    else
                    {
                        // Clear the UI element for attendees beyond the top 5
                        percentageLabel.Text = "0.00%";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving top attendance percentages. Details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int CountScheduledDaysForEmployee(int empId, DateTime startDate, DateTime endDate)
        {
            int totalScheduledDays = 0;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (IsEmployeeScheduled(empId, date))
                {
                    totalScheduledDays++;
                }
            }

            return totalScheduledDays;
        }

        private bool IsEmployeeScheduled(int empId, DateTime date)
        {
            string sqlIsScheduled = $@"SELECT COUNT(*)
                                       FROM tbl_schedule s
                                       LEFT JOIN tbl_leave l ON s.emp_id = l.emp_id
                                            AND l.leave_status = 'Active'
                                            AND '{date:yyyy-MM-dd}' BETWEEN l.start_date AND l.end_date
                                       WHERE s.emp_id = {empId}
                                             AND FIND_IN_SET(DAYNAME('{date:yyyy-MM-dd}'), s.work_days) > 0
                                             AND l.emp_id IS NULL";

            DataTable dt = DB_OperationHelperClass.QueryData(sqlIsScheduled);
            return dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        private async Task DisplayTopEarnersAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                string sqlTopEarners = @"SELECT e.emp_ProfilePic, w.net_pay, w.gross_pay, e.f_name
                                         FROM tbl_wage w
                                         INNER JOIN tbl_employee e ON w.emp_id = e.emp_id
                                         INNER JOIN tbl_payroll p ON w.payroll_id = p.payroll_id
                                         WHERE p.pay_start_date >= @startDate AND p.pay_end_date <= @endDate
                                            AND w.net_pay != 0  -- Add this condition to exclude wages of 0
                                         ORDER BY w.net_pay DESC, e.emp_id
                                         LIMIT 5";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@startDate", startDate },
                    { "@endDate", endDate }
                };

                DataTable dtTopEarners = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(sqlTopEarners, parameters));

                // Clear all profile pictures and labels
                for (int j = 0; j < 5; j++)
                {
                    PictureBox earnerPicture = (PictureBox)Controls.Find($"top{j + 1}Earner", true).FirstOrDefault();
                    Label earnersGrossPay = (Label)Controls.Find($"lblTop{j + 1}EarnerGrossPay", true).FirstOrDefault();
                    Label earnersNetPay = (Label)Controls.Find($"lblTop{j + 1}EarnerNetPay", true).FirstOrDefault();

                    if (earnerPicture != null)
                    {
                        earnerPicture.Image = null; // Clear the image
                    }
                    if (earnersGrossPay != null)
                    {
                        earnersGrossPay.TextAlign = ContentAlignment.TopCenter;
                        earnersGrossPay.Text = "0"; // Set gross pay label to 0
                    }
                    if (earnersNetPay != null)
                    {
                        earnersNetPay.TextAlign = ContentAlignment.TopCenter;
                        earnersNetPay.Text = "0"; // Set net pay label to 0
                    }
                }

                // If there are no results, exit early
                if (dtTopEarners.Rows.Count == 0)
                {
                    return; // No data to display, all PictureBoxes and labels are already cleared
                }

                // If we reach here, there are wage records with non-zero values for the selected period
                for (int i = 0; i < dtTopEarners.Rows.Count && i < 5; i++)
                {
                    PictureBox earnerPicture = (PictureBox)Controls.Find($"top{i + 1}Earner", true).FirstOrDefault();
                    Label earnersName = (Label)Controls.Find($"lblTop{i + 1}EarnersName", true).FirstOrDefault();
                    Label earnersGrossPay = (Label)Controls.Find($"lblTop{i + 1}EarnerGrossPay", true).FirstOrDefault();
                    Label earnersNetPay = (Label)Controls.Find($"lblTop{i + 1}EarnerNetPay", true).FirstOrDefault();

                    if (earnerPicture == null || earnersName == null || earnersGrossPay == null || earnersNetPay == null)
                    {
                        throw new Exception($"UI element for top {i + 1} earner not found.");
                    }

                    DataRow row = dtTopEarners.Rows[i];
                    string imagePath = row["emp_ProfilePic"].ToString();
                    string f_name = row["f_name"].ToString();
                    double grossPay = Convert.ToDouble(row["gross_pay"]);
                    double netPay = Convert.ToDouble(row["net_pay"]);

                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        Image profileImage = await LoadImageAsync(imagePath);
                        earnerPicture.Image = profileImage;
                    }

                    // Ensure the name is displayed correctly, handling null or empty names
                    earnersName.Text = string.IsNullOrEmpty(f_name) ? "Unknown" : f_name;

                    // Display gross pay and net pay, ensuring they are displayed as 0 if they are 0
                    earnersGrossPay.Text = grossPay != 0 ? $"{grossPay:C}" : "0"; // Formats as currency or sets to 0
                    earnersNetPay.Text = netPay != 0 ? $"{netPay:C}" : "0";       // Formats as currency or sets to 0
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving top earners data. Details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}


