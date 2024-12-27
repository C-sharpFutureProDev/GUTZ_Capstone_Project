using K4os.Compression.LZ4.Internal;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    public partial class EmployeeAttendance : Form
    {
        public int id;

        private const string sql = @"SELECT attendance_id, tbl_employee.emp_id, emp_profilePic, tbl_employee.f_name, tbl_employee.m_name, tbl_employee.l_name, 
                                            CONCAT(tbl_employee.f_name, ' ', LEFT(tbl_employee.m_name, 1), '. ', tbl_employee.l_name) AS FullName, 
                                            working_hours, time_in_status, DATE_FORMAT(time_in, '%h:%i %p') AS time_in_formatted,
                                            DATE_FORMAT(time_out, '%h:%i %p') AS time_out_formatted, time_in, time_out
                                     FROM tbl_employee
                                     INNER JOIN tbl_attendance ON tbl_employee.emp_id = tbl_attendance.emp_id
                                     WHERE is_deleted = 0 AND DATE(time_in) = CURDATE()
                                     ORDER BY time_in ASC";

        private bool IsReportForToday = false; // Flag to determine if the selected date is today
        private bool isUserInteracting = false; // Flag to track user interaction
        private DateTime previousDatePickerValue = DateTime.Today; // Holds the previous value
        private bool isEmployeeListViewActive = false; // Tracks whether the Employee List view is active

        public EmployeeAttendance()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
        }

        private void EmployeeAttendance_Load(object sender, EventArgs e)
        {
            //cboFilter.SelectedIndex = 0;
            LoadAndRetrieveEmployeeAttendanceData();
            CountAttendance();
            CountForRealTimeOnLeave();
            PopulateEmployeeList();
            timer1.Start();
            lblAttendanceSummaryDate.Text = "Real-Time Attendance Summary Today - " + DateTime.Now.ToString("dddd MMMM dd, yyyy");
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnViewAnDownloadReport, "View and Download Report");
        }

        /// <summary>
        /// Asynchronously retrieves and displays employee real-time attendance data.
        /// </summary>
        /// <remarks>
        /// This method queries the database for employee attendance records,
        /// constructs attendance cards for each employee, and adds them to the
        /// flow layout panel. It handles potential errors and displays a message
        /// box if an exception occurs during the retrieval process.
        /// </remarks>
        private async void LoadAndRetrieveEmployeeAttendanceData()
        {
            try
            {
                DataTable dt = await Task.Run(() => DB_OperationHelperClass.QueryData(sql));

                flowLayoutPanel1.Controls.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    int id = int.Parse(row["emp_id"].ToString());
                    string firstName = row["f_name"].ToString();
                    string middleName = row["m_name"].ToString();
                    string lastName = row["l_name"].ToString();
                    string name = string.IsNullOrEmpty(middleName) || middleName == "N/A"
                                  ? $"{firstName} {lastName}"
                                  : $"{firstName} {middleName[0]}. {lastName}";

                    string imagePath = row["emp_profilePic"].ToString();
                    string timeInFormatted = row["time_in_formatted"].ToString();
                    string timeInStatus = row["time_in_status"].ToString();
                    string timeOutFormatted = row["time_out_formatted"] != DBNull.Value ? row["time_out_formatted"].ToString() : "Pending";

                    EmployeeAttendanceCard employeeAttendanceCard = new EmployeeAttendanceCard(this)
                    {
                        _id = id.ToString(),
                        CurrentDate = DateTime.Now.ToString("dddd, MMM. dd, yyyy"),
                        EmployeeProfilePic = Image.FromFile(imagePath),
                        EmployeeName = name,
                        ClockInTime = timeInFormatted,
                        Status = timeInStatus,
                        ClockOutTime = timeOutFormatted,
                    };

                    if (timeInStatus == "On Time" || timeInStatus == "Late")
                        employeeAttendanceCard.btnPresentMark.Visible = true;
                    else
                        employeeAttendanceCard.btnAbsentMark.Visible = true;

                    flowLayoutPanel1.Controls.Add(employeeAttendanceCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving employee attendance records: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Counts and displays the real-time attendance of employees for the current day.
        /// </summary>
        /// <remarks>
        /// This method retrieves attendance data from the database, counts the number of employees
        /// who are present, on time, late, clocked out, and absent. It updates the UI elements
        /// to reflect these counts. The method checks employee work schedules and attendance status
        /// based on the current date.
        /// </remarks>
        private void CountAttendance()
        {
            DateTime currentDate = DateTime.Today;
            int countWorkingPresent = 0;
            int countWorkingClockedOut = 0;
            int countAbsent = 0;
            int countOnTime = 0;
            int countLate = 0;
            TimeSpan totalWorkingHours = TimeSpan.Zero;

            // Get total scheduled employees for today
            int totalScheduledEmployees = CountScheduledEmployeesForToday();

            /*string sqlCountAttendance = $"SELECT s.emp_id, s.start_time, s.end_time, s.work_days, a.time_in, a.time_out, a.time_in_status, a.working_hours " +
                                          $"FROM tbl_schedule s " +
                                          $"LEFT JOIN tbl_attendance a ON a.emp_id = s.emp_id AND DATE(a.time_in) = '{currentDate:yyyy-MM-dd}' " +
                                          $"WHERE s.work_days LIKE '%{currentDate.DayOfWeek}%'";*/

            string sqlCountAttendance = $@"SELECT 
                                                s.emp_id, 
                                                s.start_time, 
                                                s.end_time, 
                                                s.work_days, 
                                                a.time_in, 
                                                a.time_out, 
                                                a.time_in_status, 
                                                a.working_hours 
                                            FROM 
                                                tbl_schedule s
                                            LEFT JOIN 
                                                tbl_attendance a 
                                                ON a.emp_id = s.emp_id 
                                                AND DATE(a.time_in) = '{currentDate:yyyy-MM-dd}'
                                            LEFT JOIN 
                                                tbl_leave l
                                                ON l.emp_id = s.emp_id
                                                AND l.leave_status = 'Active'
                                                AND '{currentDate:yyyy-MM-dd}' BETWEEN l.start_date AND l.end_date
                                            WHERE 
                                                s.work_days LIKE '%{currentDate.DayOfWeek}%'
                                                AND l.emp_id IS NULL";

            DataTable dtAttendance = DB_OperationHelperClass.QueryData(sqlCountAttendance);

            foreach (DataRow row in dtAttendance.Rows)
            {
                string empId = row["emp_id"].ToString();
                TimeSpan startTime = TimeSpan.Parse(row["start_time"].ToString());
                TimeSpan endTime = TimeSpan.Parse(row["end_time"].ToString());
                string workDays = row["work_days"].ToString();
                DateTime? timeIn = row["time_in"] as DateTime?;
                DateTime? timeOut = row["time_out"] as DateTime?;
                string timeInStatus = row["time_in_status"]?.ToString();
                TimeSpan workingHours = row["working_hours"] != DBNull.Value ? TimeSpan.Parse(row["working_hours"].ToString()) : TimeSpan.Zero;

                if (workDays.Contains(currentDate.DayOfWeek.ToString()))
                {
                    if (timeIn.HasValue)
                    {
                        countWorkingPresent++;
                        totalWorkingHours += workingHours; // Accumulate working hours

                        if (timeOut.HasValue)
                        {
                            countWorkingClockedOut++;
                        }

                        // Increment on-time or late counters based on timeInStatus
                        if (timeInStatus == "On Time")
                        {
                            countOnTime++;
                        }
                        else if (timeInStatus == "Late")
                        {
                            countLate++;
                        }
                    }
                    else
                    {
                        DateTime workingShiftEnd = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, endTime.Hours, endTime.Minutes, 0);
                        if (DateTime.Now > workingShiftEnd)
                        {
                            countAbsent++;
                        }
                    }
                }
            }

            // Calculate attendance percentage
            double attendancePercentage = totalScheduledEmployees > 0 ? (double)countWorkingPresent / totalScheduledEmployees * 100 : 0;

            // Display results
            dateOfCurrentAttendanceRecord.Text = "Real-Time Attendance Today - " + currentDate.ToString("dddd MMMM dd, yyyy");
            btnClockIn.Text = countWorkingPresent.ToString();
            btnClockOut.Text = countWorkingClockedOut.ToString();
            btnTotalAttendance.Text = "Total Attendance: " + countWorkingPresent.ToString();
            btnAbsent.Text = countAbsent.ToString();
            lblScheduledEmployee.Text = "Expected (Today): " + totalScheduledEmployees.ToString();
            lblOnTimeEmployee.Text = "On-Time (Today): " + countOnTime.ToString();
            lblLateEmployee.Text = "Late (Today): " + countLate.ToString();

            lblScheduledEmployeeToday.Text = countWorkingPresent.ToString() + "/" + totalScheduledEmployees.ToString();

            // Display attendance percentage
            lblAttendancePercentage.Text = $"{attendancePercentage:F0}%";

            // Display accumulated working hours
            lblTutoringHours.Text = $"{totalWorkingHours.Hours}h : {totalWorkingHours.Minutes}m";
        }

        // Method to count scheduled employees for today
        private int CountScheduledEmployeesForToday()
        {
            string countScheduledEmployee = @"SELECT COUNT(*) FROM tbl_employee e
                                              INNER JOIN tbl_schedule s ON e.emp_id = s.emp_id
                                              LEFT JOIN tbl_leave l ON e.emp_id = l.emp_id AND l.leave_status = 'Active'
                                              WHERE FIND_IN_SET(DAYNAME(CURDATE()), s.work_days) > 0
                                              AND (l.leave_status IS NULL OR l.leave_status <> 'Active')
                                              AND e.is_deleted = 0
                                              AND e.start_date <= CURDATE()"; // Added condition to check start_date

            DataTable dt = DB_OperationHelperClass.QueryData(countScheduledEmployee);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;
        }

        // Method to count employees who are currently on active leave
        private void CountForRealTimeOnLeave()
        {
            string leaveStatus = "Active";
            string sqlCountActiveLeave = "SELECT COUNT(*) FROM tbl_leave WHERE leave_status = '" + leaveStatus + "'";
            DataTable countActiveLeave = DB_OperationHelperClass.QueryData(sqlCountActiveLeave);

            if (countActiveLeave.Rows.Count > 0)
            {
                int countTotalActiveLeave = countActiveLeave.Rows.Count > 0 ? Convert.ToInt32(countActiveLeave.Rows[0][0]) : 0;
                btnOnLeave.Text = countTotalActiveLeave.ToString();
            }
            else
            {
                btnOnLeave.Text = "0";
            }
        }

        /// <summary>
        /// Asynchronously retrieves and displays a list of active employees.
        /// </summary>
        /// <remarks>
        /// This method queries the database for employee records, including their 
        /// profile pictures, job roles, work schedules, and leave status. It populates 
        /// a flow layout panel with employee cards. If no records are found, it displays 
        /// an informational message. It also updates the appearance of the leave schedule 
        /// button for employees currently on leave.
        /// </remarks>
        public async void PopulateEmployeeList()
        {
            string sql = @"SELECT tbl_employee.emp_id, emp_ProfilePic, f_name, m_name, l_name, position_desc, work_days, start_time, end_time,
                                  tbl_leave.leave_status, tbl_leave.start_date AS leave_start_date, tbl_leave.end_date AS leave_end_date, tbl_leave.date_requested, 
                                  tbl_leave.date_approved 
                           FROM tbl_employee
                           INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                           INNER JOIN tbl_schedule ON tbl_employee.emp_id = tbl_schedule.emp_id
                           LEFT JOIN tbl_leave ON tbl_employee.emp_id = tbl_leave.emp_id AND tbl_leave.end_date >= @today
                           WHERE tbl_employee.is_deleted = 0
                           ORDER BY tbl_employee.emp_id ASC";

            var parameterCheckActiveLeave = new Dictionary<string, object>
            {
                { "@today", DateTime.Now.Date }
            };

            try
            {
                flowLayoutPanel2.Controls.Clear();

                DataTable dt = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(sql, parameterCheckActiveLeave));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No employee records found.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (DataRow row in dt.Rows)
                {
                    int id = int.Parse(row["emp_id"].ToString());
                    string firstName = row["f_name"].ToString();
                    string middleName = row["m_name"].ToString();
                    string lastName = row["l_name"].ToString();
                    string name = string.IsNullOrEmpty(middleName) || middleName == "N/A"
                        ? $"{firstName} {lastName}"
                        : $"{firstName} {middleName[0]}. {lastName}";

                    string imagePath = row["emp_ProfilePic"].ToString();
                    string jobRole = row["position_desc"].ToString();
                    string workDaysString = row["work_days"].ToString();
                    TimeSpan startTime = TimeSpan.Parse(row["start_time"].ToString());
                    TimeSpan endTime = TimeSpan.Parse(row["end_time"].ToString());
                    string leaveStatus = row["leave_status"].ToString();

                    string scheduleWorkingHours = $"{FormatTime(startTime)} - {FormatTime(endTime)}";

                    EmployeeListCardForAttendanceHistory employeeListCardForAttendanceHistory = new EmployeeListCardForAttendanceHistory(this)
                    {
                        EmployeeName = name,
                        ID = id.ToString(),
                        EmployeeProfilePic = await LoadImageAsync(imagePath),
                        JobRole = jobRole,
                        WorkDays = workDaysString
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(day => day.Trim())
                        .ToArray(),
                        ScheduleWorkingHours = scheduleWorkingHours,
                    };

                    if (jobRole == "Administrator")
                    {
                        employeeListCardForAttendanceHistory.lblJobRole.Text = "ESL Admin";
                    }

                    // Check if the employee is on leave
                    if (leaveStatus == "Active")
                    {
                        employeeListCardForAttendanceHistory.toolTip1.SetToolTip(employeeListCardForAttendanceHistory.btnAddEmployeeLeaveSchedule, "View Active Leave Schedule");
                        employeeListCardForAttendanceHistory.btnAddEmployeeLeaveSchedule.BorderColor = Color.FromArgb(0, 122, 255);
                        employeeListCardForAttendanceHistory.btnAddEmployeeLeaveSchedule.FillColor = Color.FromArgb(0, 122, 255);
                        employeeListCardForAttendanceHistory.btnAddEmployeeLeaveSchedule.HoverState.FillColor = Color.FromArgb(0, 91, 181);
                        employeeListCardForAttendanceHistory.btnAddEmployeeLeaveSchedule.HoverState.BorderColor = Color.FromArgb(0, 91, 181);
                        employeeListCardForAttendanceHistory.btnAddEmployeeLeaveSchedule.Image = Image.FromFile("C:/GUTZ/Icons/icons8-leave-24.png");
                    }

                    flowLayoutPanel2.Controls.Add(employeeListCardForAttendanceHistory);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving employee data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Asynchronously loads an image from the specified file path.
        /// </summary>
        /// <param name="imagePath">The path to the image file.</param>
        /// <returns>A Task that represents the asynchronous operation. The Task result contains the loaded Image, or null if the file path is invalid or if an error occurs while loading the image.</returns>
        /// <remarks>
        /// This method checks if the provided image path is valid and if the file exists.
        /// If the file is successfully loaded, it returns the Image; otherwise, it returns null.
        /// </remarks>
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

        /// <summary>
        /// Formats a TimeSpan into a 12-hour clock string with AM/PM notation.
        /// </summary>
        /// <param name="time">The TimeSpan representing the time to format.</param>
        /// <returns>A string representing the formatted time in 12-hour format, e.g., "2:30 PM".</returns>
        /// <remarks>
        /// The method converts the time to a 12-hour format, ensuring that the hour is displayed as 
        /// 12 instead of 0 for midnight. It appends the appropriate AM or PM designation based on 
        /// the hour value.
        /// </remarks>
        private string FormatTime(TimeSpan time)
        {
            string period = time.Hours < 12 ? "AM" : "PM";

            int hour = time.Hours % 12;
            hour = hour == 0 ? 12 : hour;

            return $"{hour}:{time.Minutes:D2} {period}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadAndRetrieveEmployeeAttendanceData();
            CountAttendance();
            CountForRealTimeOnLeave();
        }

        private void EmployeeAttendance_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }

        private async void dtpEmpSelectDate_ValueChanged(object sender, EventArgs e)
        {
            btnViewEmployeeList.Enabled = false;

            // Mark that the user has interacted with the DateTimePicker
            if (!isUserInteracting)
            {
                isUserInteracting = true;
            }

            // Update the previous value to the current value before any further changes
            previousDatePickerValue = dtpEmpSelectDate.Value;

            // Check if the selected date is today and update flags accordingly
            if (IsToday(dtpEmpSelectDate.Value))
            {
                timer1.Start();
                IsReportForToday = true; // Set the report flag to today
            }
            else
            {
                timer1.Stop();
                IsReportForToday = false; // Set the report flag to a date other than today
            }

            // Update UI visibility and load data for the selected date
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = false;

            // Asynchronous call to load attendance data and count
            await LoadAttendanceDataForSelectedDate();
            CountAttendanceForSelectedDate();
        }

        private void SwitchToAttendanceView()
        {
            // Switch back to Attendance View
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = false;

            // Reset the Employee List view flag
            isEmployeeListViewActive = false;
        }

        /// <summary>
        /// Checks if the specified date is today.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <returns>True if the specified date is today; otherwise, false.</returns>
        /// <remarks>
        /// This method compares the given date with the current date and returns 
        /// a boolean value indicating whether they are the same, ignoring the time component.
        /// </remarks>
        private bool IsToday(DateTime date)
        {
            return date.Date == DateTime.Today;
        }

        /// <summary>
        /// Counts and displays the attendance record for a selected past date.
        /// </summary>
        /// <remarks>
        /// This method retrieves attendance data for employees based on the selected date,
        /// ensuring that the date is in the past. It counts the number of employees present,
        /// on time, late, clocked out, and absent. The results are displayed in the UI. 
        /// If the selected date is in the future, an informational message is shown.
        /// </remarks>
        private async Task LoadAttendanceDataForSelectedDate()
        {
            DateTime selectedDate = dtpEmpSelectDate.Value;
            lblAttendanceSummaryDate.Text = "Attendance Summary - " + selectedDate.ToString("dddd MMMM dd, yyyy");
            lblExpectedClockIn.Text = "Clocked-In (Total)";
            lblAttendancePercent.Text = "Attendance % (Total)";
            lblAccumulatedTutoringHours.Text = "Tutoring Hours (Accum.)";

            string formattedDate = selectedDate.ToString("yyyy-MM-dd");
            string displayDate = "Attendance Record - " + selectedDate.ToString("dddd MMMM dd, yyyy");

            DateTime today = DateTime.Today;
            if (selectedDate.Date > today)
            {
                dateOfCurrentAttendanceRecord.Text = displayDate;
                ResetAttendanceDisplay();
                return;
            }

            // Check for non-working days
            if (selectedDate.DayOfWeek == DayOfWeek.Saturday || selectedDate.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show(this, "Attendance records are only available for weekdays (Monday to Friday).", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset all attendance UI elements
                ResetAttendanceDisplay();
                return;
            }

            string sql = $@"SELECT tbl_employee.emp_id, emp_profilePic, f_name, m_name, l_name, 
                                   CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS FullName, 
                                   time_in_status, DATE_FORMAT(time_in, '%h:%i %p') AS time_in_formatted, 
                                   DATE_FORMAT(time_out, '%h:%i %p') AS time_out_formatted,
                                   tbl_schedule.emp_id AS scheduled_emp_id,
                                   tbl_leave.leave_status, tbl_leave.start_date AS leave_start_date, 
                                   tbl_leave.end_date AS leave_end_date
                            FROM tbl_employee
                            LEFT JOIN tbl_attendance ON tbl_employee.emp_id = tbl_attendance.emp_id AND DATE(time_in) = '{formattedDate}' 
                            LEFT JOIN tbl_schedule ON tbl_employee.emp_id = tbl_schedule.emp_id AND FIND_IN_SET(DAYNAME('{formattedDate}'), tbl_schedule.work_days) > 0
                            LEFT JOIN tbl_leave ON tbl_employee.emp_id = tbl_leave.emp_id AND tbl_leave.start_date <= '{formattedDate}' 
                                AND tbl_leave.end_date >= '{formattedDate}' 
                                AND (tbl_leave.leave_status = 'Active' OR tbl_leave.leave_status = 'Completed')
                            WHERE tbl_employee.is_deleted = 0 AND tbl_employee.start_date <= '{formattedDate}'
                            ORDER BY time_in ASC";

            try
            {
                DataTable dt = await Task.Run(() => DB_OperationHelperClass.QueryData(sql));
                dateOfCurrentAttendanceRecord.Text = displayDate;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(this, "No attendance records found for the selected date.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetAttendanceDisplay();
                    return;
                }

                flowLayoutPanel1.Controls.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    string empId = row["emp_id"].ToString();
                    string firstName = row["f_name"].ToString();
                    string middleName = row["m_name"].ToString();
                    string lastName = row["l_name"].ToString();
                    string name = string.IsNullOrEmpty(middleName) || middleName == "N/A"
                        ? $"{firstName} {lastName}"
                        : $"{firstName} {middleName[0]}. {lastName}";

                    string imagePath = row["emp_profilePic"].ToString();
                    string timeInFormatted = row["time_in_formatted"] != DBNull.Value ? row["time_in_formatted"].ToString() : "--";
                    string timeInStatus = row["time_in_status"] != DBNull.Value ? row["time_in_status"].ToString() : "--";
                    string timeOutFormatted = row["time_out_formatted"] != DBNull.Value ? row["time_out_formatted"].ToString() : "--";
                    string leaveStartDateStr = row["leave_start_date"].ToString();
                    string leaveEndDateStr = row["leave_end_date"].ToString();
                    string leaveStatus = row["leave_status"].ToString();
                    bool isScheduled = row["scheduled_emp_id"] != DBNull.Value;

                    DateTime leaveStartDate;
                    DateTime leaveEndDate;

                    string formattedLeaveStartDate = DateTime.TryParse(leaveStartDateStr, out leaveStartDate)
                        ? leaveStartDate.ToString("MMM dd, yyyy")
                        : "--";

                    string formattedLeaveEndDate = DateTime.TryParse(leaveEndDateStr, out leaveEndDate)
                        ? leaveEndDate.ToString("MMM dd, yyyy")
                        : "--";

                    EmployeeAttendanceCard employeeAttendanceCard = new EmployeeAttendanceCard(this)
                    {
                        CurrentDate = selectedDate.ToString("dddd MMMM dd, yyyy"),
                        _id = empId,
                        EmployeeProfilePic = File.Exists(imagePath) ? Image.FromFile(imagePath) : null,
                        EmployeeName = name,
                        ClockInTime = timeInFormatted,
                        Status = timeInStatus,
                        ClockOutTime = timeOutFormatted,
                    };

                    bool isOnLeave = leaveStatus == "Active" || leaveStatus == "Completed";

                    // Adjust attendance status based on leave status
                    if (isOnLeave)
                    {
                        employeeAttendanceCard.EmployeeLeaveDetails.Visible = true;
                        employeeAttendanceCard.btnAbsentMark.Visible = false;
                        employeeAttendanceCard.btnLeaveMark.Visible = true;
                        employeeAttendanceCard.lblLeaveStartDate.Text = leaveStartDate.ToString("MMM. dd, yyyy");
                        employeeAttendanceCard.lblEndDate.Text = leaveEndDate.ToString("MMM. dd, yyyy");
                        employeeAttendanceCard.lblLeaveStatus.Text = leaveStatus;
                    }
                    else if (isScheduled)
                    {
                        // Only mark as absent if the employee is scheduled to work
                        if (timeInStatus == "On Time" || timeInStatus == "Late")
                            employeeAttendanceCard.btnPresentMark.Visible = true;
                        else
                            employeeAttendanceCard.btnPresentMark.Visible = false;

                        if (timeInStatus == "--")
                        {
                            employeeAttendanceCard.btnAbsentMark.Visible = true;
                            employeeAttendanceCard.btnStatus.Text = "Absent";
                        }
                    }
                    else
                    {
                        // Employee was not scheduled, do not display or mark as absent
                        continue; // Skip adding this employee card
                    }

                    flowLayoutPanel1.Controls.Add(employeeAttendanceCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving employee attendance records: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to reset attendance display
        private void ResetAttendanceDisplay()
        {
            btnClockIn.Text = "0";
            btnClockOut.Text = "0";
            //lblTotalOnTimeForToday.Text = "On-Time: 0";
            //lblTotalLateForToday.Text = "Late: 0";
            btnTotalAttendance.Text = "Total Attendance: 0";
            btnAbsent.Text = "0";
            btnOnLeave.Text = "0";
            flowLayoutPanel1.Controls.Clear();
        }

        /// <summary>
        /// Counts and displays the attendance record for a selected past date.
        /// </summary>
        /// <remarks>
        /// This method retrieves attendance data for employees based on the selected date, 
        /// ensuring that the date is in the past. It counts the number of employees present, 
        /// on time, late, clocked out, and absent. The results are displayed in the UI. 
        /// If the selected date is in the future, an informational message is shown.
        /// </remarks>
        private void CountAttendanceForSelectedDate()
        {
            DateTime selectedDate = dtpEmpSelectDate.Value;
            DateTime today = DateTime.Today;

            // Ensure the selected date is in the past
            if (selectedDate.Date >= today)
            {
                MessageBox.Show(this, "Attendance counts are only available for past dates.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Check for non-working days
            if (selectedDate.DayOfWeek == DayOfWeek.Saturday || selectedDate.DayOfWeek == DayOfWeek.Sunday)
            {
                ResetAttendanceCounts();
                return;
            }

            int countWorkingPresent = 0;
            int countWorkingClockedOut = 0;
            int countAbsent = 0;
            int countOnLeave = 0;
            int countOnTime = 0;
            int countLate = 0;
            TimeSpan totalWorkingHours = TimeSpan.Zero;
            int totalScheduledEmployees = 0;

            // SQL query to count scheduled employees for the selected date
            string sqlCountScheduledEmployees = $@"SELECT COUNT(*) FROM tbl_employee e
                                                   INNER JOIN tbl_schedule s ON e.emp_id = s.emp_id
                                                   WHERE FIND_IN_SET('{selectedDate:dddd}', s.work_days) > 0
                                                   AND e.is_deleted = 0
                                                   AND e.start_date <= '{selectedDate:yyyy-MM-dd}'";

            // SQL query to retrieve past attendance records, considering employee start_date
            string sqlCountAttendance = $@"SELECT s.emp_id, s.start_time, s.end_time, s.work_days, a.time_in, a.time_out, a.time_in_status, a.working_hours, e.start_date
                                           FROM tbl_schedule s
                                           LEFT JOIN tbl_attendance a ON a.emp_id = s.emp_id AND DATE(a.time_in) = '{selectedDate:yyyy-MM-dd}'
                                           INNER JOIN tbl_employee e ON s.emp_id = e.emp_id
                                           WHERE FIND_IN_SET('{selectedDate:dddd}', s.work_days) > 0
                                           AND e.is_deleted = 0
                                           AND e.start_date <= '{selectedDate:yyyy-MM-dd}'";

            // SQL query to count on-leave employees for the selected date
            string sqlCountOnLeave = $@"SELECT COUNT(*) FROM tbl_leave 
                                        WHERE (leave_status = 'Active' OR leave_status = 'Completed') 
                                        AND (start_date <= '{selectedDate:yyyy-MM-dd}' AND end_date >= '{selectedDate:yyyy-MM-dd}')";

            try
            {
                // Count scheduled employees
                DataTable dtScheduledEmployees = DB_OperationHelperClass.QueryData(sqlCountScheduledEmployees);
                totalScheduledEmployees = dtScheduledEmployees.Rows.Count > 0 ? Convert.ToInt32(dtScheduledEmployees.Rows[0][0]) : 0;

                // Count on-leave employees
                DataTable dtOnLeave = DB_OperationHelperClass.QueryData(sqlCountOnLeave);
                countOnLeave = dtOnLeave.Rows.Count > 0 ? Convert.ToInt32(dtOnLeave.Rows[0][0]) : 0;

                // Get attendance records
                DataTable dtAttendance = DB_OperationHelperClass.QueryData(sqlCountAttendance);

                foreach (DataRow row in dtAttendance.Rows)
                {
                    string empId = row["emp_id"].ToString();
                    DateTime? timeIn = row["time_in"] as DateTime?;
                    TimeSpan workingHours = row["working_hours"] != DBNull.Value ? TimeSpan.Parse(row["working_hours"].ToString()) : TimeSpan.Zero;
                    string timeInStatus = row["time_in_status"]?.ToString();

                    // Count attendance for employees whose start date is on or before the selected date
                    if (Convert.ToDateTime(row["start_date"]) <= selectedDate)
                    {
                        if (timeIn.HasValue)
                        {
                            countWorkingPresent++;
                            totalWorkingHours += workingHours; // Accumulate working hours

                            // Check if the employee clocked out
                            if (row["time_out"] != DBNull.Value)
                            {
                                countWorkingClockedOut++;
                            }

                            // Increment on-time or late counters based on timeInStatus
                            if (timeInStatus == "On Time")
                            {
                                countOnTime++;
                            }
                            else if (timeInStatus == "Late")
                            {
                                countLate++;
                            }
                        }
                    }
                }

                // Calculate absent employees
                countAbsent = totalScheduledEmployees - countWorkingPresent - countOnLeave;

                // Calculate attendance percentage
                double attendancePercentage = totalScheduledEmployees > 0 ? (double)countWorkingPresent / totalScheduledEmployees * 100 : 0;

                // Display attendance count
                btnClockIn.Text = countWorkingPresent.ToString();
                btnClockOut.Text = countWorkingClockedOut.ToString();
                btnTotalAttendance.Text = "Total Attendance: " + countWorkingPresent.ToString();
                btnAbsent.Text = countAbsent.ToString();
                btnOnLeave.Text = countOnLeave.ToString();
                lblOnTimeEmployee.Text = "On-Time: " + countOnTime.ToString();
                lblLateEmployee.Text = "Late: " + countLate.ToString();
                lblScheduledEmployee.Text = "Expected: " + (totalScheduledEmployees - countOnLeave).ToString();

                // Display scheduled employees minus on leave
                lblScheduledEmployeeToday.Text = countWorkingPresent + "/" + (totalScheduledEmployees - countOnLeave).ToString();

                // Display attendance percentage
                lblAttendancePercentage.Text = $"{attendancePercentage:F0}%";

                // Display accumulated working hours
                lblTutoringHours.Text = $"{totalWorkingHours.Hours}h : {totalWorkingHours.Minutes}m";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating attendance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to reset attendance counts
        private void ResetAttendanceCounts()
        {
            btnClockIn.Text = "0";
            btnClockOut.Text = "0";
            btnTotalAttendance.Text = "Total Attendance: 0";
            btnAbsent.Text = "0";
            btnOnLeave.Text = "0";
            lblScheduledEmployeeToday.Text = "0/0";
            lblAttendancePercentage.Text = "0%";
            lblTutoringHours.Text = "0";
            lblScheduledEmployee.Text = "Expected: 0";
            lblOnTimeEmployee.Text = "On-Time: 0";
            lblLateEmployee.Text = "Late: 0";
        }

        private void btnViewEmployeeList_Click_1(object sender, EventArgs e)
        {
            dtpEmpSelectDate.Enabled = false;
            lblSelectDate.Enabled = false;
            pastdtpBottomBorder.FillColor = Color.Gainsboro;

            // Switch to Employee List view
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = true;
            flowLayoutPanel2.Dock = DockStyle.Fill;

            // Track that the Employee List view is active
            isEmployeeListViewActive = true;

            // Populate the Employee List
            PopulateEmployeeList();
        }

        private void RefreshUI()
        {
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = false;
            lblAttendanceSummaryDate.Text = "Real-Time Attendance Summary Today - " + DateTime.Now.ToString("dddd MMMM dd, yyyy");
            lblExpectedClockIn.Text = "Clocked-In (Today)";
            lblAttendancePercent.Text = "Attendance % (Today)";
            lblAccumulatedTutoringHours.Text = "Tutoring Hours (Today)";
            LoadAndRetrieveEmployeeAttendanceData();
            CountAttendance();
            CountForRealTimeOnLeave();
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*timer1.Stop();
            try
            {
                string query = "";
                DateTime currentAttendanceDate = DateTime.Today; // Use today's date for filtering

                switch (cboFilter.SelectedIndex)
                {
                    case 0: // On-Time
                        query = @"SELECT attendance_id, tbl_employee.emp_id, emp_profilePic, tbl_employee.f_name, 
                                         tbl_employee.m_name, tbl_employee.l_name, leave_status, 
                                         tbl_leave.start_date AS leave_start_date, tbl_leave.end_date AS leave_end_date,
                                         CONCAT(tbl_employee.f_name, ' ', LEFT(tbl_employee.m_name, 1), '. ', tbl_employee.l_name) AS FullName, 
                                         working_hours, time_in_status, 
                                         DATE_FORMAT(time_in, '%h:%i %p') AS time_in_formatted,
                                         DATE_FORMAT(time_out, '%h:%i %p') AS time_out_formatted, 
                                         time_in, time_out
                                  FROM tbl_employee
                                  INNER JOIN tbl_attendance ON tbl_employee.emp_id = tbl_attendance.emp_id
                                  LEFT JOIN tbl_leave ON tbl_employee.emp_id = tbl_leave.emp_id
                                  WHERE tbl_employee.is_deleted = 0 AND DATE(tbl_attendance.time_in) = CURDATE() AND tbl_attendance.time_in_status = 'On Time'
                                  ORDER BY time_in ASC";
                        break;

                    case 1: // Late
                        query = @"SELECT attendance_id, tbl_employee.emp_id, emp_profilePic, tbl_employee.f_name, 
                                         tbl_employee.m_name, tbl_employee.l_name, leave_status, 
                                         tbl_leave.start_date AS leave_start_date, tbl_leave.end_date AS leave_end_date,
                                         CONCAT(tbl_employee.f_name, ' ', LEFT(tbl_employee.m_name, 1), '. ', tbl_employee.l_name) AS FullName, 
                                         working_hours, time_in_status, 
                                         DATE_FORMAT(time_in, '%h:%i %p') AS time_in_formatted,
                                         DATE_FORMAT(time_out, '%h:%i %p') AS time_out_formatted, 
                                         time_in, time_out
                                  FROM tbl_employee
                                  INNER JOIN tbl_attendance ON tbl_employee.emp_id = tbl_attendance.emp_id
                                  LEFT JOIN tbl_leave ON tbl_employee.emp_id = tbl_leave.emp_id
                                  WHERE tbl_employee.is_deleted = 0 AND DATE(tbl_attendance.time_in) = CURDATE() AND tbl_attendance.time_in_status = 'Late'
                                  ORDER BY time_in ASC";
                        break;

                    case 2: // Absent
                        query = @"SELECT tbl_employee.emp_id, emp_profilePic, tbl_employee.f_name, 
                                         tbl_employee.m_name, tbl_employee.l_name, leave_status, 
                                         tbl_leave.start_date AS leave_start_date, tbl_leave.end_date AS leave_end_date,
                                         CONCAT(tbl_employee.f_name, ' ', LEFT(tbl_employee.m_name, 1), '. ', tbl_employee.l_name) AS FullName, 
                                         NULL AS time_in_formatted,
                                         NULL AS time_in_status,
                                         NULL AS time_out_formatted, 
                                         NULL AS time_in, NULL AS time_out
                                  FROM tbl_employee
                                  LEFT JOIN tbl_leave ON tbl_employee.emp_id = tbl_leave.emp_id
                                  LEFT JOIN tbl_attendance ON tbl_employee.emp_id = tbl_attendance.emp_id AND DATE(tbl_attendance.time_in) = CURDATE()
                                  LEFT JOIN tbl_schedule ON tbl_employee.emp_id = tbl_schedule.emp_id
                                  WHERE tbl_employee.is_deleted = 0 AND tbl_attendance.time_in IS NULL AND TIME(NOW()) > tbl_schedule.end_time
                                  ORDER BY tbl_employee.f_name ASC";
                        break;

                    case 3: // On Leave
                        query = @"SELECT DISTINCT tbl_employee.emp_id, emp_profilePic, tbl_employee.f_name, 
                                                  tbl_employee.m_name, tbl_employee.l_name, 
                                                  CONCAT(tbl_employee.f_name, ' ', LEFT(tbl_employee.m_name, 1), '. ', tbl_employee.l_name) AS FullName, 
                                                  l.start_date AS leave_start_date, 
                                                  l.end_date AS leave_end_date, 
                                                  l.leave_status,
                                                  NULL AS time_in_formatted, -- Placeholder for consistency
                                                  'On Leave' AS time_in_status, -- Explicit status
                                                  NULL AS time_out_formatted, 
                                                  NULL AS time_in, NULL AS time_out
                                  FROM tbl_employee
                                  INNER JOIN tbl_leave AS l ON tbl_employee.emp_id = l.emp_id
                                  WHERE tbl_employee.is_deleted = 0 AND l.leave_status = 'Active' AND l.start_date <= CURDATE() AND l.end_date >= CURDATE()
                                  ORDER BY tbl_employee.f_name ASC";
                        break;

                    default:
                        MessageBox.Show("Please select a valid filter criterion.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

                DataTable dt = DB_OperationHelperClass.QueryData(query);
                flowLayoutPanel1.Controls.Clear();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string empId = row["emp_id"].ToString();
                        string firstName = row["f_name"].ToString();
                        string middleName = row["m_name"].ToString();
                        string lastName = row["l_name"].ToString();
                        string name = string.IsNullOrEmpty(middleName) || middleName == "N/A"
                            ? $"{firstName} {lastName}"
                            : $"{firstName} {middleName[0]}. {lastName}";

                        string imagePath = row["emp_profilePic"].ToString();
                        string timeInFormatted = row.Table.Columns.Contains("time_in_formatted") && row["time_in_formatted"] != DBNull.Value
                            ? row["time_in_formatted"].ToString()
                            : "--";
                        string timeInStatus = row.Table.Columns.Contains("time_in_status") && row["time_in_status"] != DBNull.Value
                            ? row["time_in_status"].ToString()
                            : "Absent";
                        string timeOutFormatted = row.Table.Columns.Contains("time_out_formatted") && row["time_out_formatted"] != DBNull.Value
                            ? row["time_out_formatted"].ToString()
                            : "--";

                        string leaveStartDateStr = row["leave_start_date"] != DBNull.Value
                            ? row["leave_start_date"].ToString()
                            : "--";
                        string leaveEndDateStr = row["leave_end_date"] != DBNull.Value
                            ? row["leave_end_date"].ToString()
                            : "--";
                        string leaveStatus = row.Table.Columns.Contains("leave_status") && row["leave_status"] != DBNull.Value
                            ? row["leave_status"].ToString()
                            : "";

                        DateTime leaveStartDate;
                        DateTime leaveEndDate;

                        string formattedLeaveStartDate = DateTime.TryParse(leaveStartDateStr, out leaveStartDate)
                            ? leaveStartDate.ToString("MMM dd, yyyy")
                            : "--";

                        string formattedLeaveEndDate = DateTime.TryParse(leaveEndDateStr, out leaveEndDate)
                            ? leaveEndDate.ToString("MMM dd, yyyy")
                            : "--";

                        // Create attendance card
                        EmployeeAttendanceCard employeeAttendanceCard = new EmployeeAttendanceCard(this)
                        {
                            CurrentDate = currentAttendanceDate.ToString("dddd, MMM. dd, yyyy"),
                            _id = empId,
                            EmployeeProfilePic = File.Exists(imagePath) ? Image.FromFile(imagePath) : null,
                            EmployeeName = name,
                            ClockInTime = timeInFormatted,
                            Status = timeInStatus,
                            ClockOutTime = timeOutFormatted,
                        };

                        if (timeInStatus == "On Time")
                        {
                            if (timeOutFormatted == "--")
                                employeeAttendanceCard.btnClockOut.Text = "Pending";
                            else
                                employeeAttendanceCard.btnClockOut.Text = timeOutFormatted;

                            employeeAttendanceCard.btnPresentMark.Visible = true;
                        }
                        else if (timeInStatus == "Late")
                        {
                            if (timeOutFormatted == "--")
                                employeeAttendanceCard.btnClockOut.Text = "Pending";
                            else
                                employeeAttendanceCard.btnClockOut.Text = timeOutFormatted;

                            employeeAttendanceCard.btnPresentMark.Visible = true;
                        }
                        else
                        {
                            employeeAttendanceCard.btnAbsentMark.Visible = true;
                            employeeAttendanceCard.btnClockIn.Text = timeInFormatted;
                            employeeAttendanceCard.btnClockOut.Text = timeInFormatted;
                        }

                        if (timeInStatus == "On Leave")
                        {
                            employeeAttendanceCard.btnAbsentMark.Visible = false;
                            employeeAttendanceCard.btnLeaveMark.Visible = true;
                            employeeAttendanceCard.EmployeeLeaveDetails.Visible = true;
                            employeeAttendanceCard.lblLeaveStartDate.Text = formattedLeaveStartDate;
                            employeeAttendanceCard.lblEndDate.Text = formattedLeaveEndDate;
                            employeeAttendanceCard.lblLeaveStatus.Text = leaveStatus;
                        }

                        flowLayoutPanel1.Controls.Add(employeeAttendanceCard);
                    }
                }
                else
                {
                    MessageBox.Show("No employees found based on the selected filter.", "Result",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while filtering attendance records: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

            timer1.Stop();
            try
            {
                string query = "";
                DateTime currentAttendanceDate = DateTime.Today; // Use today's date for filtering

                switch (cboFilter.SelectedIndex)
                {
                    case 0: // On-Time
                        query = @"SELECT attendance_id, tbl_employee.emp_id, emp_profilePic, tbl_employee.f_name, 
                                 tbl_employee.m_name, tbl_employee.l_name, leave_status, 
                                 tbl_leave.start_date AS leave_start_date, tbl_leave.end_date AS leave_end_date,
                                 CONCAT(tbl_employee.f_name, ' ', LEFT(tbl_employee.m_name, 1), '. ', tbl_employee.l_name) AS FullName, 
                                 working_hours, time_in_status, 
                                 DATE_FORMAT(time_in, '%h:%i %p') AS time_in_formatted,
                                 DATE_FORMAT(time_out, '%h:%i %p') AS time_out_formatted, 
                                 time_in, time_out
                          FROM tbl_employee
                          INNER JOIN tbl_attendance ON tbl_employee.emp_id = tbl_attendance.emp_id
                          LEFT JOIN tbl_leave ON tbl_employee.emp_id = tbl_leave.emp_id
                          WHERE tbl_employee.is_deleted = 0 AND DATE(tbl_attendance.time_in) = CURDATE() AND tbl_attendance.time_in_status = 'On Time'
                          ORDER BY time_in ASC";
                        break;

                    case 1: // Late
                        query = @"SELECT attendance_id, tbl_employee.emp_id, emp_profilePic, tbl_employee.f_name, 
                                 tbl_employee.m_name, tbl_employee.l_name, leave_status, 
                                 tbl_leave.start_date AS leave_start_date, tbl_leave.end_date AS leave_end_date,
                                 CONCAT(tbl_employee.f_name, ' ', LEFT(tbl_employee.m_name, 1), '. ', tbl_employee.l_name) AS FullName, 
                                 working_hours, time_in_status, 
                                 DATE_FORMAT(time_in, '%h:%i %p') AS time_in_formatted,
                                 DATE_FORMAT(time_out, '%h:%i %p') AS time_out_formatted, 
                                 time_in, time_out
                          FROM tbl_employee
                          INNER JOIN tbl_attendance ON tbl_employee.emp_id = tbl_attendance.emp_id
                          LEFT JOIN tbl_leave ON tbl_employee.emp_id = tbl_leave.emp_id
                          WHERE tbl_employee.is_deleted = 0 AND DATE(tbl_attendance.time_in) = CURDATE() AND tbl_attendance.time_in_status = 'Late'
                          ORDER BY time_in ASC";
                        break;

                    case 2: // Absent
                        query = @"SELECT tbl_employee.emp_id, emp_profilePic, tbl_employee.f_name, 
                                 tbl_employee.m_name, tbl_employee.l_name, leave_status, 
                                 tbl_leave.start_date AS leave_start_date, tbl_leave.end_date AS leave_end_date,
                                 CONCAT(tbl_employee.f_name, ' ', LEFT(tbl_employee.m_name, 1), '. ', tbl_employee.l_name) AS FullName, 
                                 NULL AS time_in_formatted,
                                 NULL AS time_in_status,
                                 NULL AS time_out_formatted, 
                                 NULL AS time_in, NULL AS time_out
                          FROM tbl_employee
                          LEFT JOIN tbl_leave ON tbl_employee.emp_id = tbl_leave.emp_id
                          LEFT JOIN tbl_attendance ON tbl_employee.emp_id = tbl_attendance.emp_id AND DATE(tbl_attendance.time_in) = CURDATE()
                          LEFT JOIN tbl_schedule ON tbl_employee.emp_id = tbl_schedule.emp_id
                          WHERE tbl_employee.is_deleted = 0 
                                AND tbl_attendance.time_in IS NULL 
                                AND TIME(NOW()) > tbl_schedule.end_time 
                                AND (tbl_leave.leave_status IS NULL OR tbl_leave.leave_status != 'Active') -- Exclude active leaves
                          ORDER BY tbl_employee.f_name ASC";
                        break;

                    case 3: // On Leave
                        query = @"SELECT DISTINCT tbl_employee.emp_id, emp_profilePic, tbl_employee.f_name, 
                                          tbl_employee.m_name, tbl_employee.l_name, 
                                          CONCAT(tbl_employee.f_name, ' ', LEFT(tbl_employee.m_name, 1), '. ', tbl_employee.l_name) AS FullName, 
                                          l.start_date AS leave_start_date, 
                                          l.end_date AS leave_end_date, 
                                          l.leave_status,
                                          NULL AS time_in_formatted, -- Placeholder for consistency
                                          'On Leave' AS time_in_status, -- Explicit status
                                          NULL AS time_out_formatted, 
                                          NULL AS time_in, NULL AS time_out
                          FROM tbl_employee
                          INNER JOIN tbl_leave AS l ON tbl_employee.emp_id = l.emp_id
                          WHERE tbl_employee.is_deleted = 0 AND l.leave_status = 'Active' AND l.start_date <= CURDATE() AND l.end_date >= CURDATE()
                          ORDER BY tbl_employee.f_name ASC";
                        break;

                    default:
                        MessageBox.Show("Please select a valid filter criterion.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

                DataTable dt = DB_OperationHelperClass.QueryData(query);
                flowLayoutPanel1.Controls.Clear();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string empId = row["emp_id"].ToString();
                        string firstName = row["f_name"].ToString();
                        string middleName = row["m_name"].ToString();
                        string lastName = row["l_name"].ToString();
                        string name = string.IsNullOrEmpty(middleName) || middleName == "N/A"
                            ? $"{firstName} {lastName}"
                            : $"{firstName} {middleName[0]}. {lastName}";

                        string imagePath = row["emp_profilePic"].ToString();
                        string timeInFormatted = row.Table.Columns.Contains("time_in_formatted") && row["time_in_formatted"] != DBNull.Value
                            ? row["time_in_formatted"].ToString()
                            : "--";
                        string timeInStatus = row.Table.Columns.Contains("time_in_status") && row["time_in_status"] != DBNull.Value
                            ? row["time_in_status"].ToString()
                            : "Absent";
                        string timeOutFormatted = row.Table.Columns.Contains("time_out_formatted") && row["time_out_formatted"] != DBNull.Value
                            ? row["time_out_formatted"].ToString()
                            : "--";

                        string leaveStartDateStr = row["leave_start_date"] != DBNull.Value
                            ? row["leave_start_date"].ToString()
                            : "--";
                        string leaveEndDateStr = row["leave_end_date"] != DBNull.Value
                            ? row["leave_end_date"].ToString()
                            : "--";
                        string leaveStatus = row.Table.Columns.Contains("leave_status") && row["leave_status"] != DBNull.Value
                            ? row["leave_status"].ToString()
                            : "";

                        DateTime leaveStartDate;
                        DateTime leaveEndDate;

                        string formattedLeaveStartDate = DateTime.TryParse(leaveStartDateStr, out leaveStartDate)
                            ? leaveStartDate.ToString("MMM dd, yyyy")
                            : "--";

                        string formattedLeaveEndDate = DateTime.TryParse(leaveEndDateStr, out leaveEndDate)
                            ? leaveEndDate.ToString("MMM dd, yyyy")
                            : "--";

                        // Create attendance card
                        EmployeeAttendanceCard employeeAttendanceCard = new EmployeeAttendanceCard(this)
                        {
                            CurrentDate = currentAttendanceDate.ToString("dddd, MMM. dd, yyyy"),
                            _id = empId,
                            EmployeeProfilePic = File.Exists(imagePath) ? Image.FromFile(imagePath) : null,
                            EmployeeName = name,
                            ClockInTime = timeInFormatted,
                            Status = timeInStatus,
                            ClockOutTime = timeOutFormatted,
                        };

                        if (timeInStatus == "On Time")
                        {
                            employeeAttendanceCard.btnClockOut.Text = timeOutFormatted == "--" ? "Pending" : timeOutFormatted;
                            employeeAttendanceCard.btnPresentMark.Visible = true;
                        }
                        else if (timeInStatus == "Late")
                        {
                            employeeAttendanceCard.btnClockOut.Text = timeOutFormatted == "--" ? "Pending" : timeOutFormatted;
                            employeeAttendanceCard.btnPresentMark.Visible = true;
                        }
                        else
                        {
                            employeeAttendanceCard.btnAbsentMark.Visible = true;
                            employeeAttendanceCard.btnClockIn.Text = timeInFormatted;
                            employeeAttendanceCard.btnClockOut.Text = timeOutFormatted;
                        }

                        if (timeInStatus == "On Leave")
                        {
                            employeeAttendanceCard.btnAbsentMark.Visible = false;
                            employeeAttendanceCard.btnLeaveMark.Visible = true;
                            employeeAttendanceCard.EmployeeLeaveDetails.Visible = true;
                            employeeAttendanceCard.lblLeaveStartDate.Text = formattedLeaveStartDate;
                            employeeAttendanceCard.lblEndDate.Text = formattedLeaveEndDate;
                            employeeAttendanceCard.lblLeaveStatus.Text = leaveStatus;
                        }

                        flowLayoutPanel1.Controls.Add(employeeAttendanceCard);
                    }
                }
                else
                {
                    MessageBox.Show("No employees found based on the selected filter.", "Result",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while filtering attendance records: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            btnViewEmployeeList.Enabled = true;
            dtpEmpSelectDate.Enabled = true;
            pastdtpBottomBorder.FillColor = Color.FromArgb(64, 64, 64);

            // If the Employee List view is active, simply refresh the Employee List UI
            if (isEmployeeListViewActive)
            {
                SwitchToAttendanceView();
                return;
            }

            // If the user interacted with the DateTimePicker, reset it to the previous value
            if (isUserInteracting)
            {
                dtpEmpSelectDate.Value = previousDatePickerValue;
            }

            // Reset flags if refreshing based on the previous date
            IsReportForToday = IsToday(previousDatePickerValue); // Check if the previous value is today
            isUserInteracting = false;

            // Refresh the user interface
            RefreshUI();

            // Reload attendance data for the previous date
            LoadAndRetrieveEmployeeAttendanceData();

            // Reset the filter combo box to its default value
            //cboFilter.SelectedIndex = 0;

            // Update the visibility of UI elements
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = false;
        }

        private void btnViewAnDownloadReport_Click(object sender, EventArgs e)
        {
            DateTime dateToDisplay = isUserInteracting ? previousDatePickerValue : DateTime.Today;

            FormReport formReport = new FormReport(dateToDisplay);
            formReport.ShowDialog();
        }
    }
}
