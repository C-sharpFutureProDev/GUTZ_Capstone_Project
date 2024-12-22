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
    public partial class FormReport : Form
    {
        DateTime _reportDate;

        public FormReport(DateTime reportDate)
        {
            InitializeComponent();
            _reportDate = reportDate;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
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

        private void FormReport_Load(object sender, EventArgs e)
        {
            lblAttendanceDate.Text = "Date: " + _reportDate.ToString("MMMM dd, yyyy - dddd");

            string sql = $@"SELECT 
                 e.emp_id, 
                 e.f_name, 
                 e.m_name, 
                 e.l_name, 
                 s.work_days, 
                 a.time_in, 
                 a.time_out, 
                 a.time_in_status, 
                 a.late_time, 
                 CASE 
                     WHEN a.time_in IS NULL AND a.time_out IS NULL THEN '--'
                     ELSE a.working_hours 
                 END AS working_hours_formatted,
                 CASE 
                     WHEN a.time_in IS NULL THEN '--' 
                     ELSE DATE_FORMAT(a.time_in, '%h:%i %p') 
                 END AS time_in_formatted,
                 CASE 
                     WHEN a.time_out IS NULL THEN '--' 
                     ELSE DATE_FORMAT(a.time_out, '%h:%i %p') 
                 END AS time_out_formatted,
                 CASE 
                     WHEN a.time_in IS NULL THEN 'Absent' 
                     ELSE a.time_in_status
                 END AS final_time_in_status,
                 l.leave_status
             FROM 
                 tbl_employee e
             INNER JOIN 
                 tbl_schedule s ON e.emp_id = s.emp_id
             LEFT JOIN 
                 tbl_attendance a ON e.emp_id = a.emp_id AND DATE(a.time_in) = '{_reportDate:yyyy-MM-dd}'
             LEFT JOIN 
                 tbl_leave l ON e.emp_id = l.emp_id 
                 AND DATE('{_reportDate:yyyy-MM-dd}') BETWEEN l.start_date AND l.end_date
             WHERE 
                 s.work_days LIKE '%{_reportDate:dddd}%'
             ORDER BY 
                 e.emp_id";

            try
            {
                DataTable dt = DB_OperationHelperClass.QueryData(sql);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string id = row["emp_id"].ToString();
                        string firstName = row["f_name"].ToString();
                        string middleName = row["m_name"].ToString();
                        string lastName = row["l_name"].ToString();

                        string name = string.IsNullOrEmpty(middleName) || middleName == "N/A"
                            ? $"{firstName} {lastName}"
                            : $"{firstName} {middleName[0]}. {lastName}";

                        string timeInFormatted = row["time_in_formatted"].ToString();
                        string timeOutFormatted = row["time_out_formatted"].ToString();
                        string timeInStatus = row["final_time_in_status"].ToString();
                        string lateTime = row["late_time"]?.ToString() ?? "--";
                        string computedTutoringHours = row["working_hours_formatted"]?.ToString() ?? "--";
                        string leaveStatus = row["leave_status"]?.ToString();

                        // Adjust status for on time or late
                        if (timeInStatus == "On Time" || timeInStatus == "Late")
                        {
                            timeInStatus = "Present"; // Display "Present" instead of actual status
                        }

                        if (leaveStatus == "Active" || leaveStatus == "Completed")
                        {
                            timeInStatus = "On Leave";
                            timeInFormatted = "--";
                            timeOutFormatted = "--";
                            lateTime = "--";
                            computedTutoringHours = "--";
                        }
                        else if (string.IsNullOrEmpty(timeInFormatted) && string.IsNullOrEmpty(timeOutFormatted))
                        {
                            timeInStatus = "Absent"; // Only mark as absent if not on leave
                        }

                        if (timeInStatus == "Absent")
                        {
                            lateTime = "--";
                        }

                        // Create and populate a new ReportCard control
                        var sampleEmployeeAttendanceReportCard = new SampleEmployeeAttendanceReportCard()
                        {
                            ID = id,
                            EmployeeName = name,
                            TimeIn = timeInFormatted,
                            TimeOut = timeOutFormatted,
                            Status = timeInStatus,
                            LateTime = lateTime,
                            ComputedTutoringHours = computedTutoringHours,
                        };

                        // Set text color based on status
                        switch (timeInStatus)
                        {
                            case "Absent":
                                sampleEmployeeAttendanceReportCard.lblAttendanceStatus.ForeColor = Color.Red; // Red for Absent
                                sampleEmployeeAttendanceReportCard.lblTimeIn.TextAlign = ContentAlignment.MiddleCenter;
                                sampleEmployeeAttendanceReportCard.lblTimeOut.TextAlign = ContentAlignment.MiddleCenter;
                                sampleEmployeeAttendanceReportCard.lblLateTime.TextAlign = ContentAlignment.MiddleCenter;
                                sampleEmployeeAttendanceReportCard.lblComputedTutoringHours.TextAlign = ContentAlignment.MiddleCenter;
                                break;
                            case "On Leave":
                                sampleEmployeeAttendanceReportCard.lblAttendanceStatus.ForeColor = Color.FromArgb(33, 150, 243); // Specific blue for On Leave
                                sampleEmployeeAttendanceReportCard.lblTimeIn.TextAlign = ContentAlignment.MiddleCenter;
                                sampleEmployeeAttendanceReportCard.lblTimeOut.TextAlign = ContentAlignment.MiddleCenter;
                                sampleEmployeeAttendanceReportCard.lblLateTime.TextAlign = ContentAlignment.MiddleCenter;
                                sampleEmployeeAttendanceReportCard.lblComputedTutoringHours.TextAlign = ContentAlignment.MiddleCenter;
                                break;
                            default:
                                sampleEmployeeAttendanceReportCard.lblAttendanceStatus.ForeColor = Color.Green; // Green for Present
                                sampleEmployeeAttendanceReportCard.lblTimeIn.TextAlign = ContentAlignment.MiddleCenter;
                                sampleEmployeeAttendanceReportCard.lblTimeOut.TextAlign = ContentAlignment.MiddleCenter;
                                sampleEmployeeAttendanceReportCard.lblLateTime.TextAlign = ContentAlignment.MiddleCenter;
                                sampleEmployeeAttendanceReportCard.lblComputedTutoringHours.TextAlign = ContentAlignment.MiddleCenter;
                                break;
                        }

                        // Add the ReportCard control to the FlowLayoutPanel
                        flowLayoutPanel1.Controls.Add(sampleEmployeeAttendanceReportCard);
                    }
                }
                else
                {
                    MessageBox.Show($"No Attendance Record found for {_reportDate:dddd, MMMM dd, yyyy}",
                        "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
