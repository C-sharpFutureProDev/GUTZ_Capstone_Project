using GUTZ_Capstone_Project.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

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

            this.id = id;
            dueDate = DateTime.Now.AddDays(10);
            timer1.Tick += timer1_Tick;
            timer1.Start();
            this.WindowState = FormWindowState.Maximized;
            originalImage = iconCurrentChildForm.Image;
            DisplayAdminProfilePic();
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
            string leaveStatus = "Active";
            string sqlCountActiveLeave = "SELECT COUNT(*) FROM tbl_leave WHERE leave_status = '" + leaveStatus + "'";

            DataTable countActiveLeave = DB_OperationHelperClass.QueryData(sqlCountActiveLeave);

            if (countActiveLeave.Rows.Count > 0)
            {
                int countTotalActiveLeave = countActiveLeave.Rows.Count > 0 ? Convert.ToInt32(countActiveLeave.Rows[0][0]) : 0;
                lblOnLeave.Text = countTotalActiveLeave.ToString();
            }
            else
            {
                lblOnLeave.Text = "0";
            }
        }
    }
}