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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
//using System.Windows.Media;

namespace GUTZ_Capstone_Project
{
    public partial class FormDashboard : Form
    {
        private Guna.UI2.WinForms.Guna2Button currentBtn;
        private Image originalImage;
        private Form currentChildForm;

        public FormDashboard()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Enable double buffering for the main form
            this.WindowState = FormWindowState.Maximized;
            LoadChartData();
            originalImage = iconCurrentChildForm.Image; //get the original image icon for the dashboard
        }

        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton();

                currentBtn = (Guna.UI2.WinForms.Guna2Button)senderBtn;

                // Current Child Form Icon
                iconCurrentChildForm.Image = currentBtn.Image;
                currentBtn.FillColor = Color.Ivory;
                currentBtn.ForeColor = Color.Black;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.FillColor = Color.FromArgb(6, 20, 27);
                currentBtn.ForeColor = Color.White;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            // Enable double buffering for the child form
            typeof(Form).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(childForm, true, null);
            // open only form
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }

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
        }

        private void LoadChartData()
        {
            // Dummy data
            int totalEmployees = 70;
            int payrollProcessed = 30;
            double totalGrossPay = 50000;
            double totalDeductions = 6500;
            double netPayroll = 45000;
            int timeOffAccrued = 1200;

            int allAttendance = 500;
            int present = 74;
            int absent = 1;
            int late = 7;

            // Add data to the chart
            chart1.Series["Payroll Management Overview"].Points.AddXY("", totalEmployees);
            chart1.Series["Payroll Management Overview"].Points.AddXY("", payrollProcessed);
            chart1.Series["Payroll Management Overview"].Points.AddXY("", totalGrossPay);
            chart1.Series["Payroll Management Overview"].Points.AddXY("", totalDeductions);
            chart1.Series["Payroll Management Overview"].Points.AddXY("", netPayroll);
            chart1.Series["Payroll Management Overview"].Points.AddXY("", timeOffAccrued);

            chart1.Series["Attendance Monitoring"].Points.AddXY("", allAttendance);
            chart1.Series["Attendance Monitoring"].Points.AddXY("", present);
            chart1.Series["Attendance Monitoring"].Points.AddXY("", absent);
            chart1.Series["Attendance Monitoring"].Points.AddXY("", late);

            //chart1.Series["Employee"].Points.AddXY("", totalEmployees);

            // Customize the chart
            //chart1.ChartAreas[0].AxisY.Title = "Amount";
            //chart1.ChartAreas[0].AxisY.LabelStyle.Format = "C0";
            chart1.Titles.Add("Attendance Monitoring and Payroll Management Overview");
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
            OpenChildForm(new FormPayrollManagemant());
        }

        private void btnGenerateReports_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
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

            if (lblTitleChildForm != null)
            {
                lblTitleChildForm.ForeColor = Color.White;
            }
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
