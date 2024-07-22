using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUTZ_Capstone_Project
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            LoadChartData();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {

        }

        private void LoadChartData()
        {
            // Dummy data
            int totalEmployees = 5000000;
            int payrollProcessed = 24;
            double totalGrossPay = 2500000;
            double totalDeductions = 650000;
            double netPayroll = 1850000;
            int timeOffAccrued = 12000;

            int allAttendance = 500000;
            int present = 1000000;
            int absent = 1000000;
            int late = 700000;

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

            chart1.Series["Employee"].Points.AddXY("", totalEmployees);


            // Customize the chart
            //chart1.ChartAreas[0].AxisY.Title = "Amount";
            //chart1.ChartAreas[0].AxisY.LabelStyle.Format = "C0";
            chart1.Titles.Add("Attendance Monitoring and Payroll Management Overview");
        }

    }
}
