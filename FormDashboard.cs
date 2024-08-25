using FontAwesome.Sharp;
using GUTZ_Capstone_Project.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media.Media3D;

namespace GUTZ_Capstone_Project
{
    public partial class FormDashboard : Form
    {
        private Guna.UI2.WinForms.Guna2Button currentBtn;
        private Image originalImage;
        private Form currentChildForm;
        private int id;
        public FormDashboard(int id)
        {
            InitializeComponent();
            CountAttendanceStatuses();
            this.WindowState = FormWindowState.Maximized;
            originalImage = iconCurrentChildForm.Image; //get the original image icon of the title child form

            // Initialize the timer
            timer2.Interval = 10;
            timer2.Tick += timer2_Tick;
            timer2.Start();
            this.id = id;
        }

        /*private void chartData()
        {
            // Clear previous series points
            chart1.Series["Employees"].Points.Clear();

            // Add the data points with proper labels
            chart1.Series["Employees"].Points.AddXY("130", 130);
            chart1.Series["Employees"].Points.AddXY("70", 70);

            // Customize the chart appearance
            chart1.ChartAreas[0].Area3DStyle.Enable3D = true;

            // Set the legend text
            chart1.Series["Employees"].Legend = "Legend";
            chart1.Series["Employees"].Points[0].LegendText = "BPO";
            chart1.Series["Employees"].Points[1].LegendText = "ESL";
        }*/

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

        private void ActivateButton(object senderBtn)
        {
            DisableButton();
            if (senderBtn is Guna.UI2.WinForms.Guna2Button btn)
            {
                currentBtn = btn;
                currentBtn.FillColor = Color.FromArgb(0, 62, 41);
                currentBtn.ForeColor = Color.White;
                iconCurrentChildForm.Image = currentBtn.Image;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.FillColor = Color.FromArgb(12, 90, 37);
                currentBtn.ForeColor = Color.White;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            SuspendLayout();

            // open only form
            if (currentChildForm != null && !currentChildForm.IsDisposed)
                currentChildForm.Close();

            // Set the new child form as the current one
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
            OpenChildForm(new FormEmployeeManagement());
        }

        private void btnAttendanceMonitoring_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormAttendanceManagement());
        }

        private void btnPayrollManagement_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormPayrollManagement());
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
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            // Show the login form
            //FormLogin formLogin = new FormLogin();
            //formLogin.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateDateTimeLabel();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            UpdateDateTimeLabel();
            timer1.Start();
            label3.Text = "Orlando";
            string sql = "SELECT emp_profilePic FROM tbl_employee WHERE emp_id = @id";
            var parameters = new Dictionary<string, object> { { "@id", id } };

            try
            {
                DataTable dt = DB_OperationHelperClass.ParameterizedQueryData(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    string adminProfilePath = dt.Rows[0]["emp_profilePic"].ToString();

                    try
                    {
                        roundedPictureBoxControl1.Image = Image.FromFile(adminProfilePath);
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
                else
                {
                    MessageBox.Show("No profile picture found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void CountAttendanceStatuses()
        {
            // Get the current date
            DateTime currentDate = DateTime.Today;

            // Define the time ranges for the morning and evening shifts
            DateTime morningShiftStart = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 6, 0, 0); // 6:00 AM
            DateTime morningShiftEnd = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 14, 0, 0); // 2:00 PM
            DateTime eveningShiftStart = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 18, 0, 0); // 6:00 PM
            DateTime eveningShiftEnd = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day + 1, 6, 0, 0); // 6:00 AM (next day)

            // Add grace period of 15 minutes
            DateTime morningGracePeriodEnd = morningShiftStart.AddMinutes(15);
            DateTime eveningGracePeriodEnd = eveningShiftStart.AddMinutes(15);

            int countMorningPresent = 0;
            int countMorningOnTime = 0;
            int countMorningLate = 0;

            int countEveningPresent = 0;
            int countEveningOnTime = 0;
            int countEveningLate = 0;

            // Retrieve all records for the current day
            string sqlCountAttendance = $"SELECT * FROM tbl_attendance WHERE DATE(time_in) = '{currentDate.Date.ToString("yyyy-MM-dd")}'";
            DataTable dtAttendance = DB_OperationHelperClass.QueryData(sqlCountAttendance);

            foreach (DataRow row in dtAttendance.Rows)
            {
                DateTime timeIn = (DateTime)row["time_in"];

                // Check if the time-in is within the morning shift range
                if (timeIn >= morningShiftStart && timeIn <= morningShiftEnd)
                {
                    countMorningPresent++;
                    shiftLabelStatus.Text = "Today, Morning Shift";

                    if (timeIn <= morningGracePeriodEnd)
                    {
                        countMorningOnTime++;
                    }
                    else
                    {
                        countMorningLate++;
                    }
                    // Update the button texts for morning shift count
                    btnPresent.Text = countMorningPresent.ToString();
                    btnOnTime.Text = countMorningOnTime.ToString();
                    btnLate.Text = countMorningLate.ToString();
                }
                // Check if the time-in is within the evening shift range
                else if (timeIn >= eveningShiftStart || timeIn <= eveningShiftEnd)
                {
                    countEveningPresent++;
                    shiftLabelStatus.Text = "Today, Evening Shift";

                    if (timeIn <= eveningGracePeriodEnd)
                    {
                        countEveningOnTime++;
                    }
                    else
                    {
                        countEveningLate++;
                    }

                    // Update the button texts for evening shift count
                    btnPresent.Text = countEveningPresent.ToString();
                    btnOnTime.Text = countEveningOnTime.ToString();
                    btnLate.Text = countEveningLate.ToString();
                }
            }
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
            // Calculate the week number within the current month
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            DateTime lastDayOfMonth = new DateTime(date.Year, date.Month, daysInMonth);

            // Get the week number of the first day of the month
            int firstWeekNumberOfMonth = GetWeekNumber(firstDayOfMonth);

            // Adjust the week number based on the day of the month
            int weekNumberInMonth = ((date.Day - 1) / 7) + 1;

            // If the last day of the month is in the first week of the next month, use the week number of the last day of the previous month
            if (GetWeekNumber(lastDayOfMonth) == 1 && firstWeekNumberOfMonth > 1)
                weekNumberInMonth = firstWeekNumberOfMonth;

            return weekNumberInMonth;
        }

        private int GetWeekNumber(DateTime date)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
                date = date.AddDays(3);

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            CountAttendanceStatuses();
        }

        private void FormDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Dispose();
            timer2.Dispose();
        }
    }
}
