using FontAwesome.Sharp;
using GUTZ_Capstone_Project.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUTZ_Capstone_Project
{
    public partial class FormDashboard : Form
    {
        private Guna.UI2.WinForms.Guna2Button currentBtn;
        private Image originalImage;
        private Form currentChildForm;
        private PictureBox AdminRoundedPictureBox;
        public FormDashboard()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            originalImage = iconCurrentChildForm.Image; //get the original image icon of the title child form
        }

        // Fixed flicker user interface rendering
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
                currentBtn.FillColor = Color.FromArgb(0, 43, 35);
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
            OpenChildForm(new FormEmployeeProfiling());
        }

        private void btnAttendanceMonitoring_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new FormAttendanceMonitoring());
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
            {
                Reset();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            {
                weekNumberInMonth = firstWeekNumberOfMonth;
            }

            return weekNumberInMonth;
        }

        private int GetWeekNumber(DateTime date)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                date = date.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
