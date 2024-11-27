
using OfficeOpenXml.VBA;
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
        private const string sql = @"SELECT attendance_id, tbl_employee.emp_id, emp_profilePic, tbl_employee.f_name, 
                                            tbl_employee.m_name, tbl_employee.l_name, 
                                            CONCAT(tbl_employee.f_name, ' ', LEFT(tbl_employee.m_name, 1), '. ', tbl_employee.l_name) AS FullName, 
                                            working_hours, time_in_status, DATE_FORMAT(time_in, '%h:%i %p') AS time_in_formatted,
                                            DATE_FORMAT(time_out, '%h:%i %p') AS time_out_formatted, time_in, time_out
                                            FROM tbl_employee
                                            INNER JOIN tbl_attendance ON tbl_employee.emp_id = tbl_attendance.emp_id
                                            WHERE is_deleted = 0 AND DATE(time_in) = CURDATE()
                                            ORDER BY time_in ASC";

        public EmployeeAttendance()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
        }

        private void EmployeeAttendance_Load(object sender, EventArgs e)
        {
            cboSearch.SelectedIndex = 0;
            LoadAndRetrieveEmployeeAttendanceData();
            CountAttendance();
            flowLayoutPanel2.SuspendLayout();
            PopulateEmployeeList();
            flowLayoutPanel2.ResumeLayout();
            timer1.Start();
        }

        private async void LoadAndRetrieveEmployeeAttendanceData()
        {
            try
            {
                DataTable dt = await Task.Run(() => DB_OperationHelperClass.QueryData(sql));

                flowLayoutPanel1.Controls.Clear();

                flowLayoutPanel1.SuspendLayout();

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

                    employeeAttendanceCard.btnAttendanceStatus.Visible = true;
                    employeeAttendanceCard.btnAttendanceStatus.Text = (timeInStatus == "On Time" || timeInStatus == "Late") ? "Present" : "Absent";

                    flowLayoutPanel1.Controls.Add(employeeAttendanceCard);
                }
                flowLayoutPanel1.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving employee attendance records: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CountAttendance()
        {
            DateTime currentDate = DateTime.Today;
            int countWorkingPresent = 0;
            int countWorkingOnTime = 0;
            int countWorkingLate = 0;
            int countWorkingClockedOut = 0;
            int countAbsent = 0;

            string sqlCountAttendance = $"SELECT s.emp_id, s.start_time, s.end_time, s.work_days, a.time_in, a.time_out, a.time_in_status " +
                                        $"FROM tbl_schedule s " +
                                        $"LEFT JOIN tbl_attendance a ON a.emp_id = s.emp_id AND DATE(a.time_in) = '{currentDate:yyyy-MM-dd}' " +
                                        $"WHERE s.work_days LIKE '%{currentDate.DayOfWeek}%'";

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

                if (workDays.Contains(currentDate.DayOfWeek.ToString()))
                {
                    if (timeIn.HasValue)
                    {
                        countWorkingPresent++;

                        if (timeInStatus == "On Time")
                        {
                            countWorkingOnTime++;
                        }
                        else if (timeInStatus == "Late")
                        {
                            countWorkingLate++;
                        }

                        if (timeOut.HasValue)
                        {
                            countWorkingClockedOut++;
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

            dateOfCurrentAttendanceRecord.Text = currentDate.ToString("dddd, MMM. dd, yyyy");
            btnClockIn.Text = countWorkingPresent.ToString();
            btnClockOut.Text = countWorkingClockedOut.ToString();
            lblTotalOnTimeForToday.Text = "On-Time: " + countWorkingOnTime.ToString();
            lblTotalLateForToday.Text = "Late: " + countWorkingLate.ToString();
            btnTotalAttendance.Text = "Total Attendance: " + countWorkingPresent.ToString();
            btnAbsent.Text = countAbsent.ToString();
        }

        public async void PopulateEmployeeList()
        {
            string sql = @"
        SELECT 
            tbl_employee.emp_id, 
            emp_ProfilePic, 
            f_name, 
            m_name, 
            l_name, 
            position_desc, 
            work_days, 
            start_time, 
            end_time,
            tbl_leave.leave_type, 
            tbl_leave.start_date AS leave_start_date, 
            tbl_leave.end_date AS leave_end_date, 
            tbl_leave.date_requested, 
            tbl_leave.date_approved 
        FROM 
            tbl_employee
        INNER JOIN 
            tbl_position ON tbl_employee.position_id = tbl_position.position_id
        INNER JOIN 
            tbl_schedule ON tbl_employee.emp_id = tbl_schedule.emp_id
        LEFT JOIN 
            tbl_leave ON tbl_employee.emp_id = tbl_leave.emp_id 
            AND tbl_leave.end_date >= @today
        WHERE 
            tbl_employee.is_deleted = 0
        ORDER BY 
            tbl_employee.emp_id ASC";

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

                flowLayoutPanel2.SuspendLayout();

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
                        employeeListCardForAttendanceHistory.lblJobRole.Text = "ESL Head";
                    }

                    // Check if the employee is on leave
                    if (row["leave_type"] != DBNull.Value) // If there's leave info
                    {
                        employeeListCardForAttendanceHistory.toolTip1.SetToolTip(employeeListCardForAttendanceHistory.btnAddEmployeeLeaveSchedule, "View Active Leave Schedule");
                        employeeListCardForAttendanceHistory.btnAddEmployeeLeaveSchedule.BorderColor = Color.CornflowerBlue;
                        employeeListCardForAttendanceHistory.btnAddEmployeeLeaveSchedule.FillColor = Color.CornflowerBlue;
                        employeeListCardForAttendanceHistory.btnAddEmployeeLeaveSchedule.HoverState.FillColor = Color.DodgerBlue;
                        employeeListCardForAttendanceHistory.btnAddEmployeeLeaveSchedule.HoverState.BorderColor = Color.DodgerBlue;
                    }

                    flowLayoutPanel2.Controls.Add(employeeListCardForAttendanceHistory);
                }

                flowLayoutPanel2.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving employee data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
        }

        private void EmployeeAttendance_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }

        private async void dtpEmpSelectDate_ValueChanged(object sender, EventArgs e)
        {
            if (!IsToday(dtpEmpSelectDate.Value))
            {
                timer1.Stop();
            }
            else
            {
                timer1.Start();
            }

            await LoadAttendanceDataForSelectedDate();
            CountAttendanceForSelectedDate();
        }

        private bool IsToday(DateTime date)
        {
            return date.Date == DateTime.Today;
        }

        private async Task LoadAttendanceDataForSelectedDate()
        {
            DateTime selectedDate = dtpEmpSelectDate.Value;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");
            string displayDate = selectedDate.ToString("dddd, MMM. dd, yyyy");

            DateTime today = DateTime.Today;
            if (selectedDate.Date > today)
            {
                return;
            }

            if (selectedDate.DayOfWeek == DayOfWeek.Saturday || selectedDate.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show(this, "Attendance records are only available for weekdays (Monday to Friday).", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sql = $@"SELECT 
                                 tbl_employee.emp_id, 
                                 emp_profilePic, 
                                 f_name, 
                                 m_name, 
                                 l_name, 
                                 CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS FullName, 
                                 time_in_status, 
                                 DATE_FORMAT(time_in, '%h:%i %p') AS time_in_formatted,
                                 DATE_FORMAT(time_out, '%h:%i %p') AS time_out_formatted
                               FROM 
                                 tbl_employee
                               LEFT JOIN 
                                 tbl_attendance ON tbl_employee.emp_id = tbl_attendance.emp_id 
                                 AND DATE(time_in) = '{formattedDate}' 
                               LEFT JOIN 
                                 tbl_schedule ON tbl_employee.emp_id = tbl_schedule.emp_id 
                                 AND FIND_IN_SET(DAYNAME('{formattedDate}'), tbl_schedule.work_days) > 0
                               WHERE 
                                 tbl_employee.is_deleted = 0 
                                 AND tbl_employee.start_date <= '{formattedDate}'";

            try
            {
                DataTable dt = await Task.Run(() => DB_OperationHelperClass.QueryData(sql));
                dateOfCurrentAttendanceRecord.Text = displayDate;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(this, "No attendance records found for the selected date.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flowLayoutPanel1.Controls.Clear();
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

                    EmployeeAttendanceCard employeeAttendanceCard = new EmployeeAttendanceCard(this)
                    {
                        CurrentDate = displayDate,
                        _id = empId,
                        EmployeeProfilePic = File.Exists(imagePath) ? Image.FromFile(imagePath) : null,
                        EmployeeName = name,
                        ClockInTime = timeInFormatted,
                        Status = timeInStatus,
                        ClockOutTime = timeOutFormatted,
                    };

                    employeeAttendanceCard.btnAttendanceStatus.Visible = true;
                    employeeAttendanceCard.btnAttendanceStatus.Text = (timeInStatus == "On Time" || timeInStatus == "Late") ? "Present" : "Absent";

                    if (timeInStatus == "--")
                    {
                        employeeAttendanceCard.btnAttendanceStatus.FillColor = Color.FromArgb(255, 107, 107);
                        employeeAttendanceCard.btnAttendanceStatus.HoverState.FillColor = Color.FromArgb(255, 107, 107);
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

        private void CountAttendanceForSelectedDate()
        {
            DateTime selectedDate = dtpEmpSelectDate.Value;

            DateTime today = DateTime.Today;
            if (selectedDate.Date > today)
            {
                MessageBox.Show(this, "Attendance counts are only available for past dates.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string sqlCheckStartDate = @"SELECT MIN(start_date) AS MinStartDate FROM tbl_employee WHERE is_deleted = 0";
            DateTime minStartDate;

            try
            {
                DataTable dtStartDate = DB_OperationHelperClass.QueryData(sqlCheckStartDate);
                minStartDate = dtStartDate.Rows.Count > 0 ? Convert.ToDateTime(dtStartDate.Rows[0]["MinStartDate"]) : DateTime.MinValue;

                if (selectedDate < minStartDate)
                {
                    MessageBox.Show("No attendance counts available before the earliest employee start date: " + minStartDate.ToString("MMMM dd, yyyy"), "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnClockIn.Text = "0";
                    btnClockOut.Text = "0";
                    lblTotalOnTimeForToday.Text = "On-Time: 0";
                    lblTotalLateForToday.Text = "Late: 0";
                    btnTotalAttendance.Text = "Total Attendance: 0";
                    btnAbsent.Text = "0";

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking employee start date: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int countWorkingPresent = 0;
            int countWorkingOnTime = 0;
            int countWorkingLate = 0;
            int countWorkingClockedOut = 0;
            int countAbsent = 0;

            string sqlCountAttendance = $@"SELECT s.emp_id, s.start_time, s.end_time, s.work_days, a.time_in, a.time_out, a.time_in_status 
                                           FROM tbl_schedule s
                                           LEFT JOIN tbl_attendance a ON a.emp_id = s.emp_id AND DATE(a.time_in) = '{selectedDate:yyyy-MM-dd}'
                                           INNER JOIN tbl_employee e ON s.emp_id = e.emp_id
                                           WHERE FIND_IN_SET('{selectedDate:dddd}', s.work_days) > 0 
                                           AND e.is_deleted = 0";

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

                if (timeIn.HasValue)
                {
                    countWorkingPresent++;

                    if (timeInStatus == "On Time")
                    {
                        countWorkingOnTime++;
                    }
                    else if (timeInStatus == "Late")
                    {
                        countWorkingLate++;
                    }

                    if (timeOut.HasValue)
                    {
                        countWorkingClockedOut++;
                    }
                }
                else
                {
                    DateTime workingShiftEnd = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, endTime.Hours, endTime.Minutes, 0);
                    if (DateTime.Now > workingShiftEnd)
                    {
                        countAbsent++;
                    }
                }
            }

            int totalAttendance = countWorkingOnTime + countWorkingLate;

            btnClockIn.Text = countWorkingPresent.ToString();
            btnClockOut.Text = countWorkingClockedOut.ToString();
            lblTotalOnTimeForToday.Text = "On-Time: " + countWorkingOnTime.ToString();
            lblTotalLateForToday.Text = "Late: " + countWorkingLate.ToString();
            btnTotalAttendance.Text = "Total Attendance: " + totalAttendance.ToString();
            btnAbsent.Text = countAbsent.ToString();
        }

        private void btnViewEmployeeList_Click_1(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = true;
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.SuspendLayout();
            PopulateEmployeeList();
            flowLayoutPanel2.ResumeLayout();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAndRetrieveEmployeeAttendanceData();
            CountAttendance();
        }
    }
}
