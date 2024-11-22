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
using System.Windows.Input;
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
            this.id = id;
            dueDate = DateTime.Now.AddDays(10);
            timer1.Tick += timer1_Tick;
            timer1.Start();
            this.WindowState = FormWindowState.Maximized;
            originalImage = iconCurrentChildForm.Image;
            DisplayAdminProfilePic();
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

        private void DisplayAdminProfilePic()
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

        private void lblPresentForToday_Click(object sender, EventArgs e)
        {

        }
    }
}
