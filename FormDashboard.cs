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
        private System.Drawing.Color _originalIconColor;
        private DateTime dueDate;
        private int id;
        public FormDashboard(int id)
        {
            InitializeComponent();
            dueDate = DateTime.Now.AddDays(10);
            timer1.Tick += timer1_Tick;
            timer1.Start();
            this.WindowState = FormWindowState.Maximized;
            originalImage = iconCurrentChildForm.Image; //get the original image icon of the title child form
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
                currentBtn.FillColor = Color.FromArgb(12, 90, 37);
                currentBtn.ForeColor = Color.White;
                iconCurrentChildForm.Image = currentBtn.Image;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.FillColor = Color.FromArgb(0, 62, 41);
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

        private void FormDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Dispose();
            Application.Exit();
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            TimeSpan timeRemaining = dueDate - DateTime.Now;

            if (timeRemaining.TotalSeconds <= 0)
            {
                timer1.Stop();
                lblCountDown.Text = "Payroll is Due Today";
                iconPayrollPeriod.BackColor = Color.Red;
            }
            else
            {
                lblCountDown.Text = $"{timeRemaining.Days} days {timeRemaining.Hours} hrs {timeRemaining.Minutes} min's {timeRemaining.Seconds} sec's rem.";
            }
        }
    }
}
