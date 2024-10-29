using OfficeOpenXml.VBA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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

                    if (timeInStatus == "Late")
                        employeeAttendanceCard.btnStatus.Text = "LATE";

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

            string sqlCountAttendance = $"SELECT s.emp_id, s.start_time, s.end_time, s.work_days, a.time_in, a.time_out FROM tbl_schedule s " +
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

                if (workDays.Contains(currentDate.DayOfWeek.ToString()))
                {
                    if (timeIn.HasValue)
                    {
                        countWorkingPresent++;

                        DateTime workingShiftStart = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, startTime.Hours, startTime.Minutes, 0);
                        DateTime gracePeriodEnd = workingShiftStart.AddMinutes(15);
                        DateTime workingShiftEnd = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, endTime.Hours, endTime.Minutes, 0);

                        if (timeIn <= gracePeriodEnd)
                        {
                            countWorkingOnTime++;
                        }
                        else if (timeIn > gracePeriodEnd && timeIn <= workingShiftEnd)
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
            btnTotalAttendance.Text = "Total Attendance: " + countWorkingPresent.ToString();
            btnAbsent.Text = countAbsent.ToString();
        }

        private void EmployeeAttendance_Load(object sender, EventArgs e)
        {
            LoadAndRetrieveEmployeeAttendanceData();
            CountAttendance();
            flowLayoutPanel2.SuspendLayout();
            PopulateEmployeeList();
            flowLayoutPanel2.ResumeLayout();
            timer1.Start();
        }

        private async void PopulateEmployeeList()
        {
            string sql = @"SELECT tbl_employee.emp_id, emp_ProfilePic, f_name, m_name, l_name, position_desc, work_days, start_time, end_time
                           FROM tbl_employee
                           INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                           INNER JOIN tbl_schedule ON tbl_employee.emp_id = tbl_schedule.emp_id
                           WHERE is_deleted = 0";

            try
            {
                flowLayoutPanel2.Controls.Clear();

                DataTable dt = await Task.Run(() => DB_OperationHelperClass.QueryData(sql));

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
                        WorkDays = row["work_days"].ToString()
                        .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(day => day.Trim())
                        .ToArray(),
                        ScheduleWorkingHours = scheduleWorkingHours,
                    };

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
            if (!dtpEmpSelectDate.Visible)
            {
                LoadAndRetrieveEmployeeAttendanceData();
                CountAttendance();
            }
        }

        private void EmployeeAttendance_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }

        private void btnViewPastAttendanceRecord_Click(object sender, EventArgs e)
        {
            dtpEmpSelectDate.Visible = true;
        }

        private async void dtpEmpSelectDate_ValueChanged(object sender, EventArgs e)
        {
            await LoadAttendanceDataForSelectedDate();
            CountAttendanceForSelectedDate();
        }

        private async Task LoadAttendanceDataForSelectedDate()
        {
            DateTime selectedDate = dtpEmpSelectDate.Value;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");
            string displayDate = selectedDate.ToString("dddd, MMM. dd, yyyy");

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
                                tbl_attendance ON tbl_employee.emp_id = tbl_attendance.emp_id AND DATE(time_in) = '{formattedDate}'
                            LEFT JOIN 
                                tbl_schedule ON tbl_employee.emp_id = tbl_schedule.emp_id AND 
                                FIND_IN_SET(DAYNAME('{formattedDate}'), tbl_schedule.work_days) > 0
                            WHERE 
                                tbl_employee.is_deleted = 0";

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

                HashSet<string> presentEmployeeIds = new HashSet<string>();

                foreach (DataRow row in dt.Rows)
                {
                    string empId = row["emp_id"].ToString();
                    presentEmployeeIds.Add(empId);

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
                        EmployeeProfilePic = Image.FromFile(imagePath),
                        EmployeeName = name,
                        ClockInTime = timeInFormatted,
                        Status = timeInStatus,
                        ClockOutTime = timeOutFormatted,
                    };

                    if (timeInStatus == "Late")
                        employeeAttendanceCard.btnStatus.Text = "LATE";

                    employeeAttendanceCard.btnAttendanceStatus.Visible = true;
                    employeeAttendanceCard.btnAttendanceStatus.Text = (timeInStatus == "On Time" || timeInStatus == "Late") ? "Present" : "Absent";

                    if (timeInStatus == "--")
                        employeeAttendanceCard.btnAttendanceStatus.FillColor = Color.FromArgb(255, 107, 107);

                    flowLayoutPanel1.Controls.Add(employeeAttendanceCard);
                }

                foreach (DataRow row in dt.Rows)
                {
                    string empId = row["emp_id"].ToString();
                    if (!presentEmployeeIds.Contains(empId))
                    {
                        EmployeeAttendanceCard absentCard = new EmployeeAttendanceCard(this)
                        {
                            CurrentDate = displayDate,
                            _id = empId,
                            EmployeeProfilePic = File.Exists(row["emp_profilePic"].ToString()) ? Image.FromFile(row["emp_profilePic"].ToString()) : null,
                            EmployeeName = $"{row["f_name"]} {row["m_name"]} {row["l_name"]}",
                            ClockInTime = "--",
                            Status = "--",
                            ClockOutTime = "--"
                        };

                        flowLayoutPanel1.Controls.Add(absentCard);
                    }
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

            int countPresent = 0;
            int countOnTime = 0;
            int countLate = 0;
            int countClockedOut = 0;
            int countAbsent = 0;

            string sqlCountAttendance = $@"SELECT a.emp_id, a.time_in, a.time_out, s.start_time, s.end_time, s.work_days 
                                           FROM tbl_attendance a 
                                           INNER JOIN tbl_schedule s ON a.emp_id = s.emp_id 
                                           WHERE DATE(a.time_in) = '{selectedDate:yyyy-MM-dd}'";

            DataTable dtAttendance = DB_OperationHelperClass.QueryData(sqlCountAttendance);

            HashSet<string> presentEmployeeIds = new HashSet<string>();

            foreach (DataRow row in dtAttendance.Rows)
            {
                string empId = row["emp_id"].ToString();
                presentEmployeeIds.Add(empId);

                DateTime timeIn = (DateTime)row["time_in"];
                DateTime? timeOut = row["time_out"] as DateTime?;
                TimeSpan startTime = TimeSpan.Parse(row["start_time"].ToString());
                TimeSpan endTime = TimeSpan.Parse(row["end_time"].ToString());
                string workDays = row["work_days"].ToString();
                string currentDay = selectedDate.DayOfWeek.ToString();

                if (workDays.Contains(currentDay))
                {
                    countPresent++;

                    DateTime workingShiftStart = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, startTime.Hours, startTime.Minutes, 0);
                    DateTime gracePeriodEnd = workingShiftStart.AddMinutes(15);
                    DateTime workingShiftEnd = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, endTime.Hours, endTime.Minutes, 0);

                    if (timeIn <= gracePeriodEnd)
                    {
                        countOnTime++;
                    }
                    else if (timeIn > gracePeriodEnd && timeIn <= workingShiftEnd)
                    {
                        countLate++;
                    }

                    if (timeOut.HasValue)
                    {
                        countClockedOut++;
                    }
                }
            }

            string sqlScheduledEmployees = $@"SELECT emp_id, work_days 
                                              FROM tbl_schedule 
                                              WHERE FIND_IN_SET(DAYNAME('{selectedDate:yyyy-MM-dd}'), work_days) > 0";

            DataTable dtScheduledEmployees = DB_OperationHelperClass.QueryData(sqlScheduledEmployees);

            foreach (DataRow row in dtScheduledEmployees.Rows)
            {
                string empId = row["emp_id"].ToString();

                if (!presentEmployeeIds.Contains(empId))
                {
                    countAbsent++;
                }
            }

            int totalAttendance = countOnTime + countLate;

            btnClockIn.Text = countPresent.ToString();
            btnClockOut.Text = countClockedOut.ToString();
            btnTotalAttendance.Text = "Total Attendance: " + totalAttendance.ToString();
            btnAbsent.Text = countAbsent.ToString();
        }
        private void btnViewEmployeeList_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = true;
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.SuspendLayout();
            PopulateEmployeeList();
            flowLayoutPanel2.ResumeLayout();
        }
    }
}
