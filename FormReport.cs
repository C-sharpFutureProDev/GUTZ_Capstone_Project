﻿using OfficeOpenXml;
using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnDownLoadAttendanceReport, "Download Attendance Report");
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

        private void ComputeAverageTimeOut()
        {
            string averageTimeOut = string.Empty;

            string averageTimeOutQuery = $@"SELECT SEC_TO_TIME(AVG(TIME_TO_SEC(TIME(time_out)))) AS AverageTime
                                            FROM tbl_attendance
                                            WHERE DATE(time_out) = '{_reportDate:yyyy-MM-dd}'";

            try
            {
                DataTable dt = DB_OperationHelperClass.QueryData(averageTimeOutQuery);

                if (dt.Rows.Count > 0 && dt.Rows[0]["AverageTime"] != DBNull.Value)
                {
                    string avgTimeString = dt.Rows[0]["AverageTime"].ToString();

                    if (TimeSpan.TryParse(avgTimeString, out TimeSpan avgTimeSpan))
                    {
                        DateTime avgTime = DateTime.Today.Add(avgTimeSpan);
                        averageTimeOut = avgTime.ToString("hh:mm tt").ToUpper();
                    }
                    else
                    {
                        averageTimeOut = "Invalid time format";
                    }
                }
                else
                {
                    averageTimeOut = "No Data";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error computing average time_out: {ex.Message}");
            }

            lblAverageTimeOut.Text = averageTimeOut;
        }

        private void ComputeAverageTimeIn()
        {
            string averageTimeIn = string.Empty;
            string averageTimeInQuery = $@"SELECT SEC_TO_TIME(AVG(TIME_TO_SEC(TIME(time_in)))) AS AverageTime
                                           FROM tbl_attendance
                                           WHERE DATE(time_in) = '{_reportDate:yyyy-MM-dd}'";

            try
            {
                DataTable dt = DB_OperationHelperClass.QueryData(averageTimeInQuery);

                if (dt.Rows.Count > 0 && dt.Rows[0]["AverageTime"] != DBNull.Value)
                {
                    string avgTimeString = dt.Rows[0]["AverageTime"].ToString();

                    if (TimeSpan.TryParse(avgTimeString, out TimeSpan avgTimeSpan))
                    {
                        DateTime avgTime = DateTime.Today.Add(avgTimeSpan);
                        averageTimeIn = avgTime.ToString("hh:mm tt").ToUpper();
                    }
                    else
                    {
                        averageTimeIn = "Invalid time format";
                    }
                }
                else
                {
                    averageTimeIn = "No Data";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(($"Error computing average time_in: {ex.Message}"));
            }

            lblAverageTimeIn.Text = averageTimeIn;
        }

        private void CountLate()
        {
            int count = 0;

            string countLateEmployee = $@"SELECT COUNT(*) FROM tbl_attendance
                                          WHERE time_in_status = 'Late'
                                          AND DATE(time_in) = '{_reportDate:yyyy-MM-dd}'";
            try
            {
                DataTable dt = DB_OperationHelperClass.QueryData(countLateEmployee);

                if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                {
                    count = Convert.ToInt32(dt.Rows[0][0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(($"Error displaying late employee count: {ex.Message}"));
            }

            lblLateEmployee.Text = count.ToString();
        }

        private void CountOnTime()
        {
            int count = 0;

            string countOnTimeEmployee = $@"SELECT COUNT(*) FROM tbl_attendance
                                            WHERE time_in_status = 'On Time'
                                            AND DATE(time_in) = '{_reportDate:yyyy-MM-dd}'";

            try
            {
                DataTable dt = DB_OperationHelperClass.QueryData(countOnTimeEmployee);

                if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                {
                    count = Convert.ToInt32(dt.Rows[0][0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying on-time employee count: {ex.Message}");
            }

            lblOnTimeEmployee.Text = count.ToString();
        }

        private void CountScheduledToWorkEmployee()
        {
            int scheduledCount = 0;
            int onLeaveCount = 0;

            string countScheduledEmployee = $@"SELECT COUNT(*) 
                                               FROM tbl_employee e
                                               INNER JOIN tbl_schedule s ON e.emp_id = s.emp_id
                                               INNER JOIN tbl_position p ON e.position_id = p.position_id
                                               WHERE FIND_IN_SET(DAYNAME('{_reportDate:yyyy-MM-dd}'), s.work_days) > 0
                                               AND e.is_deleted = 0
                                               AND e.start_date <= '{_reportDate:yyyy-MM-dd}'
                                               AND p.position_desc != 'Administrator'";

            // Count employees on leave based on _reportDate
            string countOnLeave = $@"SELECT COUNT(*) 
                                     FROM tbl_employee e
                                     INNER JOIN tbl_leave l ON e.emp_id = l.emp_id 
                                     WHERE l.leave_status IN ('Active', 'Completed')
                                     AND '{_reportDate:yyyy-MM-dd}' BETWEEN l.start_date AND l.end_date
                                     AND e.is_deleted = 0";

            try
            {
                // Get scheduled employee count
                DataTable dtScheduled = DB_OperationHelperClass.QueryData(countScheduledEmployee);
                if (dtScheduled.Rows.Count > 0 && dtScheduled.Rows[0][0] != DBNull.Value)
                {
                    scheduledCount = Convert.ToInt32(dtScheduled.Rows[0][0]);
                }

                // Get on leave employee count
                DataTable dtOnLeave = DB_OperationHelperClass.QueryData(countOnLeave);
                if (dtOnLeave.Rows.Count > 0 && dtOnLeave.Rows[0][0] != DBNull.Value)
                {
                    onLeaveCount = Convert.ToInt32(dtOnLeave.Rows[0][0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying scheduled employee count: {ex.Message}");
                return; // Exit early if there's an error
            }

            // Calculate expected employees scheduled to work
            int expectedEmployees = scheduledCount - onLeaveCount;
            lblExpectedEmployee.Text = expectedEmployees.ToString();
        }

        private int CountScheduledEmployeesForDate(DateTime date)
        {
            string countScheduledEmployee = $@"SELECT COUNT(*) FROM tbl_employee e
                                               INNER JOIN tbl_schedule s ON e.emp_id = s.emp_id
                                               LEFT JOIN tbl_leave l ON e.emp_id = l.emp_id 
                                               AND '{date:yyyy-MM-dd}' BETWEEN l.start_date AND l.end_date
                                               INNER JOIN tbl_position p ON e.position_id = p.position_id
                                               WHERE FIND_IN_SET(DAYNAME('{date:yyyy-MM-dd}'), s.work_days) > 0
                                               AND (l.leave_status IS NULL OR l.leave_status NOT IN ('Active', 'Completed'))
                                               AND e.is_deleted = 0
                                               AND e.start_date <= '{date:yyyy-MM-dd}'
                                               AND p.position_desc != 'Administrator'";

            DataTable dt = DB_OperationHelperClass.QueryData(countScheduledEmployee);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }

        private void ComputeAverageTutoringHoursForSelectedDate()
        {
            try
            {
                TimeSpan totalWorkingHours = TimeSpan.Zero;
                int totalPresentEmployees = 0;

                string sqlPresentEmployees = $@"SELECT (SELECT COUNT(*) FROM tbl_attendance 
                                                WHERE DATE(time_out) = '{_reportDate:yyyy-MM-dd}' 
                                                AND time_out IS NOT NULL) AS ClockedOutCount,
                                                (SELECT COUNT(*) FROM tbl_attendance 
                                                WHERE DATE(time_in) = '{_reportDate:yyyy-MM-dd}' 
                                                AND (time_in_status = 'On Time' OR time_in_status = 'Late')) AS PresentCount";

                string sqlTotalWorkingHours = $@"SELECT SUM(TIME_TO_SEC(a.working_hours)) AS TotalWorkingSeconds
                                                 FROM tbl_attendance a
                                                 INNER JOIN tbl_employee e ON a.emp_id = e.emp_id
                                                 WHERE DATE(a.time_in) = '{_reportDate:yyyy-MM-dd}'
                                                 AND e.is_deleted = 0
                                                 AND e.start_date <= '{_reportDate:yyyy-MM-dd}'";

                DataTable dtPresentEmployees = DB_OperationHelperClass.QueryData(sqlPresentEmployees);
                if (dtPresentEmployees.Rows.Count > 0)
                {
                    totalPresentEmployees = Convert.ToInt32(dtPresentEmployees.Rows[0]["PresentCount"]);
                }

                DataTable dtTotalWorkingHours = DB_OperationHelperClass.QueryData(sqlTotalWorkingHours);
                if (dtTotalWorkingHours.Rows.Count > 0 && dtTotalWorkingHours.Rows[0]["TotalWorkingSeconds"] != DBNull.Value)
                {
                    int totalWorkingSeconds = Convert.ToInt32(dtTotalWorkingHours.Rows[0]["TotalWorkingSeconds"]);
                    totalWorkingHours = TimeSpan.FromSeconds(totalWorkingSeconds);
                }

                TimeSpan averageWorkingHours = totalPresentEmployees > 0
                    ? TimeSpan.FromSeconds(totalWorkingHours.TotalSeconds / totalPresentEmployees)
                    : TimeSpan.Zero;

                lblAverageTutoringHours.Text = $"{averageWorkingHours.Hours}h : {averageWorkingHours.Minutes}m";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating average tutoring hours: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComputeTutoringHoursForSelectedDate()
        {
            long totalSeconds = 0;

            string sqlCountAttendance = $@"SELECT s.emp_id, s.start_time, s.end_time, s.work_days, 
                                         a.time_in, a.time_out, a.time_in_status, 
                                         IFNULL(a.working_hours, '00:00:00') AS working_hours, 
                                         e.start_date
                                         FROM tbl_schedule s
                                         LEFT JOIN tbl_attendance a ON a.emp_id = s.emp_id 
                                         AND DATE(a.time_in) = '{_reportDate:yyyy-MM-dd}'
                                         INNER JOIN tbl_employee e ON s.emp_id = e.emp_id
                                         WHERE FIND_IN_SET('{_reportDate:dddd}', s.work_days) > 0
                                         AND e.is_deleted = 0
                                         AND e.start_date <= '{_reportDate:yyyy-MM-dd}'";

            try
            {
                DataTable dtAttendance = DB_OperationHelperClass.QueryData(sqlCountAttendance);

                foreach (DataRow row in dtAttendance.Rows)
                {
                    DateTime? timeIn = row["time_in"] as DateTime?;
                    DateTime? timeOut = row["time_out"] as DateTime?;
                    string timeInStatus = row["time_in_status"]?.ToString();

                    // Check if the employee clocked in and clocked out
                    if (timeIn.HasValue && timeOut.HasValue)
                    {
                        TimeSpan workingHours = timeOut.Value - timeIn.Value;
                        totalSeconds += (long)workingHours.TotalSeconds; // Accumulate total seconds
                    }
                }

                // Convert total seconds to hours and minutes
                long hours = totalSeconds / 3600;
                long minutes = (totalSeconds % 3600) / 60;

                lblComputedTutoringHoursForDateSelected.Text = $"{hours}h : {minutes}m";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating tutoring hours: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CountAttendancePercentage(DateTime _reportDate)
        {
            DateTime reportDate = _reportDate;

            int totalScheduledEmployees = CountScheduledEmployeesForDate(reportDate);

            string sqlCountAttendance = $@"SELECT COUNT(*) AS PresentCount FROM tbl_schedule s 
                                           LEFT JOIN tbl_attendance a ON a.emp_id = s.emp_id AND DATE(a.time_in) = '{reportDate:yyyy-MM-dd}' 
                                           WHERE s.work_days LIKE '%{reportDate.DayOfWeek}%' AND a.time_in IS NOT NULL";

            DataTable dtAttendance = DB_OperationHelperClass.QueryData(sqlCountAttendance);
            int countWorkingPresent = dtAttendance.Rows.Count > 0 ? Convert.ToInt32(dtAttendance.Rows[0]["PresentCount"]) : 0;

            double attendancePercentage = totalScheduledEmployees > 0 ? (double)countWorkingPresent / totalScheduledEmployees * 100 : 0;

            lblAttendancePercentage.Text = $"{attendancePercentage:F0}%";
        }

        private void ComputeTotalLateTime()
        {
            string totalLateTime = string.Empty;

            string totalLateTimeQuery = $@"SELECT SEC_TO_TIME(SUM(TIME_TO_SEC(late_time))) AS TotalLateTime
                                           FROM tbl_attendance
                                           WHERE DATE(time_in) = '{_reportDate:yyyy-MM-dd}' AND late_time IS NOT NULL";

            try
            {
                DataTable dt = DB_OperationHelperClass.QueryData(totalLateTimeQuery);

                if (dt.Rows.Count > 0 && dt.Rows[0]["TotalLateTime"] != DBNull.Value)
                {
                    totalLateTime = dt.Rows[0]["TotalLateTime"].ToString();
                }
                else
                {
                    totalLateTime = "00:00:00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error computing total late time: {ex.Message}");
                totalLateTime = "Error occurred";
            }

            lblComputedLateTime.Text = totalLateTime;
        }

        private void CountOnLeave()
        {
            string sql = $@"SELECT COUNT(*) 
                            FROM tbl_employee e
                            INNER JOIN tbl_leave l ON e.emp_id = l.emp_id 
                            WHERE l.leave_status IN ('Active', 'Completed')
                            AND '{_reportDate:yyyy-MM-dd}' BETWEEN l.start_date AND l.end_date
                            AND e.is_deleted = 0";

            try
            {
                DataTable dt = DB_OperationHelperClass.QueryData(sql);
                if (dt.Rows.Count > 0)
                {
                    int countOnLeave = Convert.ToInt32(dt.Rows[0][0]);
                    lblOnLeaveCount.Text = countOnLeave.ToString();
                }
                else
                {
                    string message = $"NO Employees On Leave Available for {_reportDate:MMMM dd, yyyy - dddd}";
                    string caption = "Leave Report";

                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CountAbsentEmployees()
        {
            string sql = $@"SELECT COUNT(e.emp_id) 
                            FROM tbl_employee e
                            LEFT JOIN tbl_schedule s ON e.emp_id = s.emp_id
                            INNER JOIN tbl_position p ON e.position_id = p.position_id
                            WHERE e.is_deleted = 0
                            AND e.start_date <= CURDATE()
                            AND FIND_IN_SET(DAYNAME('{_reportDate:yyyy-MM-dd}'), s.work_days) > 0
                            AND NOT EXISTS (
                                SELECT 1 
                                FROM tbl_attendance a 
                                WHERE a.emp_id = e.emp_id 
                                AND DATE(a.time_in) = '{_reportDate:yyyy-MM-dd}'
                            )
                            AND NOT EXISTS (
                                SELECT 1 
                                FROM tbl_leave l 
                                WHERE l.emp_id = e.emp_id 
                                AND '{_reportDate:yyyy-MM-dd}' BETWEEN l.start_date AND l.end_date 
                                AND l.leave_status IN ('Active', 'Completed')
                            )
                            AND p.position_desc != 'Administrator'";

            try
            {
                DataTable dt = DB_OperationHelperClass.QueryData(sql);
                if (dt.Rows.Count > 0)
                {
                    int countAbsent = Convert.ToInt32(dt.Rows[0][0]);
                    lblAbsentCount.Text = countAbsent.ToString();
                }
                else
                {
                    string message = $"NO Absent Count Available for {_reportDate:MMMM dd, yyyy - dddd}";
                    string caption = "Attendance Report";

                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CountPresent()
        {
            string sql = $@"SELECT 
                        (SELECT COUNT(*) FROM tbl_attendance 
                         WHERE DATE(time_out) = '{_reportDate:yyyy-MM-dd}' 
                         AND time_out IS NOT NULL) AS ClockedOutCount,
                        (SELECT COUNT(*) FROM tbl_attendance 
                         WHERE DATE(time_in) = '{_reportDate:yyyy-MM-dd}' 
                         AND (time_in_status = 'On Time' OR time_in_status = 'Late')) AS PresentCount";

            try
            {
                DataTable dt = DB_OperationHelperClass.QueryData(sql);
                if (dt.Rows.Count > 0)
                {
                    int countClockedOut = Convert.ToInt32(dt.Rows[0]["ClockedOutCount"]);
                    int countPresent = Convert.ToInt32(dt.Rows[0]["PresentCount"]);

                    // Assuming lblClockedOutCount is for displaying Clocked Out count
                    lblPresentCount.Text = countClockedOut.ToString();

                    // Display Present count in lblPresentCount
                    lblPresentCount.Text = countPresent.ToString();
                }
                else
                {
                    string message = $"NO Attendance Data Available for {_reportDate:MMMM dd, yyyy - dddd}";
                    string caption = "Attendance Report";

                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            CountScheduledToWorkEmployee();
            CountOnTime();
            CountLate();
            ComputeAverageTimeIn();
            ComputeAverageTimeOut();
            CountPresent();
            CountAbsentEmployees();
            CountOnLeave();
            ComputeTotalLateTime();
            CountAttendancePercentage(_reportDate);
            ComputeAverageTutoringHoursForSelectedDate();
            ComputeTutoringHoursForSelectedDate();

            lblAttendanceDate.Text = "DATE: " + _reportDate.ToString("MMMM dd, yyyy - dddd");

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
                             position_desc,
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
                         INNER JOIN tbl_position ON e.position_id = tbl_position.position_id
                         LEFT JOIN 
                             tbl_attendance a ON e.emp_id = a.emp_id AND DATE(a.time_in) = '{_reportDate:yyyy-MM-dd}'
                         LEFT JOIN 
                             tbl_leave l ON e.emp_id = l.emp_id 
                             AND DATE('{_reportDate:yyyy-MM-dd}') BETWEEN l.start_date AND l.end_date
                         WHERE 
                             s.work_days LIKE '%{_reportDate:dddd}%' AND position_desc != 'Administrator'
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

                        flowLayoutPanel1.Controls.Add(sampleEmployeeAttendanceReportCard); // Add the ReportCard control to the FlowLayoutPanel
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

        private void btnDownLoadAttendanceReport_Click(object sender, EventArgs e)
        {
            string sql = $@"SELECT 
                                e.emp_id, 
                                e.f_name, 
                                e.m_name, 
                                e.l_name, 
                                a.time_in, 
                                a.time_out, 
                                a.time_in_status, 
                                a.late_time, 
                                position_desc,
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
                            INNER JOIN tbl_position ON e.position_id = tbl_position.position_id
                            LEFT JOIN 
                                 tbl_schedule s ON e.emp_id = s.emp_id
                            LEFT JOIN 
                                 tbl_attendance a ON e.emp_id = a.emp_id AND DATE(a.time_in) = '{_reportDate:yyyy-MM-dd}'
                            LEFT JOIN 
                                 tbl_leave l ON e.emp_id = l.emp_id 
                                 AND DATE('{_reportDate:yyyy-MM-dd}') BETWEEN l.start_date AND l.end_date
                            WHERE 
                                s.work_days LIKE '%{_reportDate:dddd}%' AND position_desc != 'Administrator'
                            ORDER BY 
                                e.emp_id";

            DataTable dt = DB_OperationHelperClass.QueryData(sql);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No data available to download.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                string formattedDate = _reportDate.ToString("yyyy-MM-dd");
                saveFileDialog.FileName = $"AttendanceReport_{formattedDate}.xlsx";
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog.Title = "Save an Attendance Report";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                        using (ExcelPackage package = new ExcelPackage())
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Attendance Report");

                            // Add title header
                            worksheet.Cells[1, 1].Value = "Attendance Report";
                            worksheet.Cells[1, 1, 1, 7].Merge = true; // Merge across columns
                            worksheet.Cells[1, 1].Style.Font.Bold = true;
                            worksheet.Cells[1, 1].Style.Font.Size = 16;
                            worksheet.Cells[1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                            // Add column headers
                            worksheet.Cells[2, 1].Value = "ID";
                            worksheet.Cells[2, 2].Value = "Full Name";
                            worksheet.Cells[2, 3].Value = "Time In";
                            worksheet.Cells[2, 4].Value = "Time Out";
                            worksheet.Cells[2, 5].Value = "Status";
                            worksheet.Cells[2, 6].Value = "Late Time";
                            worksheet.Cells[2, 7].Value = "Tutoring Hours";

                            // Style header row
                            using (var range = worksheet.Cells[2, 1, 2, 7])
                            {
                                range.Style.Font.Bold = true;
                                range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(0, 123, 255)); // Header background color
                                range.Style.Font.Color.SetColor(System.Drawing.Color.White); // Header text color
                            }

                            // Populate data
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                DataRow row = dt.Rows[i];
                                string middleName = row["m_name"].ToString();
                                string fullName = string.IsNullOrEmpty(middleName) || middleName == "N/A"
                                    ? $"{row["f_name"]} {row["l_name"]}"
                                    : $"{row["f_name"]} {middleName[0]}. {row["l_name"]}";

                                worksheet.Cells[i + 3, 1].Value = row["emp_id"].ToString();
                                worksheet.Cells[i + 3, 2].Value = fullName;
                                worksheet.Cells[i + 3, 3].Value = row["time_in_formatted"].ToString();
                                worksheet.Cells[i + 3, 4].Value = row["time_out_formatted"].ToString();
                                worksheet.Cells[i + 3, 5].Value = row["final_time_in_status"].ToString();
                                worksheet.Cells[i + 3, 6].Value = row["late_time"]?.ToString() ?? "--";
                                worksheet.Cells[i + 3, 7].Value = row["working_hours_formatted"]?.ToString() ?? "--";
                            }

                            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns(); // Auto-fit columns

                            FileInfo fi = new FileInfo(saveFileDialog.FileName);
                            package.SaveAs(fi);
                        }

                        MessageBox.Show("Attendance report downloaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving the file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
