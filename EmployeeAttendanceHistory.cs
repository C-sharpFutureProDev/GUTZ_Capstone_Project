using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ZstdSharp.Unsafe;

namespace GUTZ_Capstone_Project
{
    public partial class EmployeeAttendanceHistory : UserControl
    {
        private string _id = string.Empty;
        private EmployeeAttendance _employeeAttendance;
        private Timer monthChangeTimer;
        private ToolTip ToolTip = new ToolTip();

        public EmployeeAttendanceHistory(string empID, EmployeeAttendance employeeAttendance)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(empID))
            {
                _id = empID;
            }
            _employeeAttendance = employeeAttendance;

            ToolTip.SetToolTip(btnBackToAttendanceForm, "Back To Employee List");
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

        private int CountWorkingDays(DateTime startDate, DateTime endDate, List<DayOfWeek> workingDays)
        {
            int workingDayCount = 0;

            // Iterate through each day in the date range
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (workingDays.Contains(date.DayOfWeek))
                {
                    workingDayCount++;
                }
            }

            return workingDayCount;
        }

        private void MonthChangeTimer_Tick(object sender, EventArgs e)
        {
            UpdateComboBoxToCurrentMonth();
        }

        private void UpdateComboBoxToCurrentMonth()
        {
            int currentMonth = DateTime.Now.Month;
            cboFilterMonth.SelectedIndex = currentMonth - 1;
        }

        private void ComputeTotalAttendanceMetrics(string id)
        {
            double attendancePercentage = 0.0;
            string averageTimeOut = string.Empty;
            string averageTimeIn = string.Empty;
            int totalAttendanceCount = 0;

            try
            {
                DateTime currentDate = DateTime.Now;

                // Step 1: Get the employee's start date
                string employeeSql = $"SELECT start_date FROM tbl_employee WHERE emp_id = '{id}'";
                DataTable employeeDt = DB_OperationHelperClass.QueryData(employeeSql);

                if (employeeDt.Rows.Count == 0)
                {
                    MessageBox.Show($"No employee found with ID: '{id}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime startDate = Convert.ToDateTime(employeeDt.Rows[0]["start_date"]);

                // Ensure startDate is not in the future
                if (startDate > currentDate)
                {
                    MessageBox.Show($"Employee start date is in the future: '{startDate:yyyy-MM-dd}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblEmployeeAttPerfPercemtage.Text = "0.00%";
                    return;
                }

                // Step 2: Get the employee's working days
                string workDaysSql = $"SELECT DISTINCT work_days FROM tbl_schedule WHERE emp_id = '{id}'";
                DataTable workDaysDt = DB_OperationHelperClass.QueryData(workDaysSql);

                if (workDaysDt.Rows.Count == 0)
                {
                    MessageBox.Show($"No work schedule found for employee ID: '{id}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblEmployeeAttPerfPercemtage.Text = "0.00%";
                    return;
                }

                List<DayOfWeek> workingDays = new List<DayOfWeek>();

                foreach (DataRow row in workDaysDt.Rows)
                {
                    string daysString = row["work_days"].ToString().Trim();
                    string[] daysArray = daysString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string day in daysArray)
                    {
                        if (Enum.TryParse(day.Trim(), true, out DayOfWeek dayOfWeek))
                        {
                            workingDays.Add(dayOfWeek);
                        }
                        else
                        {
                            MessageBox.Show($"Invalid working day found: '{day}'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                // Step 3: Calculate total working days from the start date to today
                int totalWorkingDays = CountWorkingDays(startDate, currentDate, workingDays);

                // Step 4: Get the count of attended days
                string attendanceSql = $@"SELECT COUNT(*) FROM tbl_attendance
                                          WHERE emp_id = '{id}' 
                                          AND (time_in_status = 'On Time' OR time_in_status = 'Late')";

                DataTable attendanceDt = DB_OperationHelperClass.QueryData(attendanceSql);

                int attendedDays = attendanceDt.Rows.Count > 0 ? Convert.ToInt32(attendanceDt.Rows[0][0]) : 0;

                // Step 5: Calculate attendance percentage
                if (totalWorkingDays > 0)
                {
                    attendancePercentage = (attendedDays / (double)totalWorkingDays) * 100;
                }

                lblEmployeeAttPerfPercemtage.Text = $"{attendancePercentage:F2}%";

                // Compute average time out
                string averageTimeOutQuery = $@"SELECT SEC_TO_TIME(AVG(TIME_TO_SEC(TIME(time_out)))) AS AverageTime
                                                FROM tbl_attendance
                                                WHERE emp_id = '{id}'";

                DataTable averageTimeOutDt = DB_OperationHelperClass.QueryData(averageTimeOutQuery);

                if (averageTimeOutDt.Rows.Count > 0 && averageTimeOutDt.Rows[0]["AverageTime"] != DBNull.Value)
                {
                    string avgTimeString = averageTimeOutDt.Rows[0]["AverageTime"].ToString();
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

                lblEmployeeAveTimeOut.Text = averageTimeOut;

                // Compute average time in
                string averageTimeInQuery = $@"SELECT SEC_TO_TIME(AVG(TIME_TO_SEC(TIME(time_in)))) AS AverageTime
                                               FROM tbl_attendance
                                               WHERE emp_id = '{id}'";

                DataTable averageTimeInDt = DB_OperationHelperClass.QueryData(averageTimeInQuery);

                if (averageTimeInDt.Rows.Count > 0 && averageTimeInDt.Rows[0]["AverageTime"] != DBNull.Value)
                {
                    string avgTimeString = averageTimeInDt.Rows[0]["AverageTime"].ToString();
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

                lblEmployeeAveTimeIn.Text = averageTimeIn;

                // Count total attendance
                totalAttendanceCount = attendedDays;

                lblEmployeeTotalAttendance.Text = totalAttendanceCount.ToString();
            }
            catch (Exception ex)
            {
                string msg = $"Error occurred while computing total attendance metrics for employee ID: '{id}': {ex.Message}";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EmployeeAttendanceHistory_Load(object sender, EventArgs e)
        {
            int currentYear = DateTime.Now.Year;
            for (int year = currentYear; year >= currentYear - 6; year--)
            {
                cboFilterYear.Items.Add(year);
            }

            cboFilterYear.SelectedItem = currentYear;
            UpdateComboBoxToCurrentMonth();

            monthChangeTimer = new Timer();
            monthChangeTimer.Interval = 3600000;
            monthChangeTimer.Tick += MonthChangeTimer_Tick;
            monthChangeTimer.Start();

            ComputeTotalAttendanceMetrics(_id);
            FilterAndDisplayEmployeeAttendanceHistory(_id, DateTime.Now.Month, currentYear);

            try
            {
                string employeeSql = @"SELECT emp_ProfilePic, CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS FullName, phone, email, position_desc, start_date
                                       FROM tbl_employee
                                       INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                       WHERE emp_id = @empId";

                var paramID = new Dictionary<string, object>
                {{ "@empId", _id }};

                DataTable employeeDt = DB_OperationHelperClass.ParameterizedQueryData(employeeSql, paramID);
                if (employeeDt.Rows.Count > 0)
                {
                    string image_path = employeeDt.Rows[0]["emp_ProfilePic"].ToString();
                    employeeProfilePicture.Image = System.Drawing.Image.FromFile(image_path);
                    lblEmployeeName.Text = employeeDt.Rows[0]["FullName"].ToString();
                    lblEmployeeJobRole.Text = employeeDt.Rows[0]["position_desc"].ToString();
                    lblEmployeePhoneNumber.Text = employeeDt.Rows[0]["phone"].ToString();
                    lblEmployeeEmail.Text = employeeDt.Rows[0]["email"].ToString();
                    DateTime startDate = Convert.ToDateTime(employeeDt.Rows[0]["start_date"]);
                    lblStartDate.Text = startDate.ToString("MMMM dd, yyyy");
                }
                else
                {
                    MessageBox.Show("No attendance records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDownloadAttendanceHistoryRecords_Click(object sender, EventArgs e)
        {
            // Prepare to retrieve attendance data
            StringBuilder csvData = new StringBuilder();
            csvData.AppendLine("Date,Clock In,Clock Out,Status"); // CSV File Header

            // Retrieve selected month and year from the combo boxes
            if (cboFilterMonth.SelectedItem == null || cboFilterYear.SelectedItem == null)
            {
                MessageBox.Show("Please select both month and year.", "Selection Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string month = cboFilterMonth.SelectedItem.ToString();
            int selectedMonth = DateTime.ParseExact(month, "MMMM", CultureInfo.InvariantCulture).Month;
            int selectedYear = (int)cboFilterYear.SelectedItem;

            string employeeSql = $"SELECT start_date FROM tbl_employee WHERE emp_id = '{_id}'";
            DateTime startDate;

            try
            {
                DataTable employeeDt = DB_OperationHelperClass.QueryData(employeeSql);
                if (employeeDt.Rows.Count > 0)
                {
                    startDate = Convert.ToDateTime(employeeDt.Rows[0]["start_date"]);
                }
                else
                {
                    MessageBox.Show($"No employee found with ID: {_id}", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving employee data.", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime currentDate = DateTime.Now;
            DateTime date = startDate;

            string scheduledSql = $"SELECT work_days FROM tbl_schedule WHERE emp_id = '{_id}'";
            DataTable scheduledDt = DB_OperationHelperClass.QueryData(scheduledSql);

            HashSet<string> workDaysSet = new HashSet<string>(scheduledDt.Rows[0]["work_days"].ToString().Split(','));

            string leaveSql = $"SELECT start_date, end_date FROM tbl_leave WHERE emp_id = '{_id}' AND (leave_status = 'Active' OR leave_status = 'Completed')";
            DataTable leaveDt = DB_OperationHelperClass.QueryData(leaveSql);

            List<(DateTime start, DateTime end)> leavePeriods = new List<(DateTime, DateTime)>();

            foreach (DataRow row in leaveDt.Rows)
            {
                DateTime leaveStart = Convert.ToDateTime(row["start_date"]);
                DateTime leaveEnd = Convert.ToDateTime(row["end_date"]);
                leavePeriods.Add((leaveStart, leaveEnd));
            }

            while (date <= currentDate)
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    date = date.AddDays(1);
                    continue;
                }

                bool isOnLeave = leavePeriods.Any(leave => date >= leave.start && date <= leave.end);

                string attendanceSql = $@"SELECT time_in, DATE_FORMAT(time_in, '%h:%i %p') as time_in_formatted, 
                                          time_out, DATE_FORMAT(time_out, '%h:%i %p') as time_out_formatted, 
                                          time_in_status 
                                          FROM tbl_attendance 
                                          WHERE emp_id = '{_id}' AND DATE(time_in) = DATE('{date:yyyy-MM-dd}')";

                DataTable attendanceDt = DB_OperationHelperClass.QueryData(attendanceSql);

                string clockIn = "--";
                string clockOut = "--";
                string status = "--";

                if (attendanceDt.Rows.Count > 0)
                {
                    clockIn = attendanceDt.Rows[0]["time_in_formatted"].ToString();
                    clockOut = attendanceDt.Rows[0]["time_out_formatted"].ToString();
                    status = attendanceDt.Rows[0]["time_in_status"].ToString();
                }
                else if (isOnLeave)
                {
                    var leavePeriod = leavePeriods.FirstOrDefault(leave => date >= leave.start && date <= leave.end);
                    clockIn = leavePeriod.start.ToString("M/dd/yyyy");
                    clockOut = leavePeriod.end.ToString("M/dd/yyyy");
                    status = "On Leave";
                }
                else if (workDaysSet.Contains(date.DayOfWeek.ToString()))
                {
                    status = "Absent";
                }

                // Append the attendance record to the CSV data
                csvData.AppendLine($"{date:yyyy-MM-dd},{clockIn},{clockOut},{status}");

                date = date.AddDays(1);
            }

            // Show confirmation before downloading
            DialogResult result = MessageBox.Show($"Do you want to download the attendance history for employee with ID: {_id}?", "Download Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string formattedMonth = new DateTime(selectedYear, selectedMonth, 1).ToString("MMMM");
                SaveAttendanceHistoryToCsv(_id, csvData.ToString(), formattedMonth, selectedYear);
            }
        }

        private void SaveAttendanceHistoryToCsv(string employeeId, string csvContent, string month, int year)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = $"AttendanceHistory_{employeeId}_{month}_{year}.csv"; // Include month and year in the filename
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, csvContent);
                    MessageBox.Show("Attendance history downloaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ComputeAttendancePercentageForMonth(string id, int selectedMonth, int selectedYear)
        {
            double attendancePercentage = 0.0;

            try
            {
                DateTime currentDate = DateTime.Now;

                // Step 1: Get the employee's start date
                string employeeSql = $"SELECT start_date FROM tbl_employee WHERE emp_id = '{id}'";
                DataTable employeeDt = DB_OperationHelperClass.QueryData(employeeSql);

                if (employeeDt.Rows.Count == 0)
                {
                    MessageBox.Show($"No employee found with ID: '{id}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime startDate = Convert.ToDateTime(employeeDt.Rows[0]["start_date"]);

                // Ensure startDate is not in the future
                if (startDate > currentDate)
                {
                    MessageBox.Show($"Employee start date is in the future: '{startDate:yyyy-MM-dd}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblEmployeeAttPerfPercemtage.Text = "0.00%";
                    return;
                }

                // Calculate the first and last day of the selected month
                DateTime firstDayOfMonth = new DateTime(selectedYear, selectedMonth, 1);
                DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                // Step 2: Get the employee's working days
                string workDaysSql = $"SELECT DISTINCT work_days FROM tbl_schedule WHERE emp_id = '{id}'";
                DataTable workDaysDt = DB_OperationHelperClass.QueryData(workDaysSql);

                if (workDaysDt.Rows.Count == 0)
                {
                    MessageBox.Show($"No work schedule found for employee ID: '{id}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblEmployeeAttPerfPercemtage.Text = "0.00%";
                    return;
                }

                List<DayOfWeek> workingDays = new List<DayOfWeek>();

                foreach (DataRow row in workDaysDt.Rows)
                {
                    string daysString = row["work_days"].ToString().Trim();
                    string[] daysArray = daysString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string day in daysArray)
                    {
                        if (Enum.TryParse(day.Trim(), true, out DayOfWeek dayOfWeek))
                        {
                            workingDays.Add(dayOfWeek);
                        }
                        else
                        {
                            MessageBox.Show($"Invalid working day found: '{day}'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                // Step 3: Calculate total working days in the selected month
                int totalWorkingDays = CountWorkingDays(startDate, lastDayOfMonth, workingDays);

                // Step 4: Get the count of attended days for the month
                string attendanceSql = $@"SELECT COUNT(*) FROM tbl_attendance
                                  WHERE emp_id = '{id}' 
                                  AND (time_in_status = 'On Time' OR time_in_status = 'Late')
                                  AND DATE(time_in) BETWEEN '{firstDayOfMonth:yyyy-MM-dd}' AND '{lastDayOfMonth:yyyy-MM-dd}'";
                DataTable attendanceDt = DB_OperationHelperClass.QueryData(attendanceSql);

                int attendedDays = attendanceDt.Rows.Count > 0 ? Convert.ToInt32(attendanceDt.Rows[0][0]) : 0;

                // Step 5: Calculate attendance percentage
                if (totalWorkingDays > 0)
                {
                    attendancePercentage = (attendedDays / (double)totalWorkingDays) * 100;
                }

                lblEmployeeAttPerfPercemtage.Text = $"{attendancePercentage:F2}%";
            }
            catch (Exception ex)
            {
                string msg = $"Error occurred while computing attendance percentage for employee ID: '{id}': {ex.Message}";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComputeAverageTimeOutForMonth(string id, int selectedMonth, int selectedYear)
        {
            string averageTimeOut = string.Empty;
            string averageTimeOutQuery = $@"SELECT SEC_TO_TIME(AVG(TIME_TO_SEC(TIME(time_out)))) AS AverageTime
                                            FROM tbl_attendance
                                            WHERE emp_id = {id}
                                            AND MONTH(time_out) = {selectedMonth} 
                                            AND YEAR(time_out) = {selectedYear}";

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
                string msg = $"Error occurred while computing average time-out for employee with ID: '{id}': {ex.Message}";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblEmployeeAveTimeOut.Text = averageTimeOut;
        }

        private void ComputeAverageTimeInForMonth(string id, int selectedMonth, int selectedYear)
        {
            string averageTimeIn = string.Empty;
            string averageTimeInQuery = $@"SELECT SEC_TO_TIME(AVG(TIME_TO_SEC(TIME(time_in)))) AS AverageTime
                                           FROM tbl_attendance
                                           WHERE emp_id = {id}
                                           AND MONTH(time_in) = {selectedMonth} 
                                           AND YEAR(time_in) = {selectedYear}";

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
                string msg = $"Error occurred while computing average time-in for employee with ID: '{id}': {ex.Message}";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblEmployeeAveTimeIn.Text = averageTimeIn;
        }

        private void CountTotalAttendanceForMonth(string id, int selectedMonth, int selectedYear)
        {
            int count = 0;
            string sqlCountTotalAttendance = $@"SELECT COUNT(*) FROM tbl_attendance
                                                WHERE (time_in_status = 'On Time' OR time_in_status = 'Late')
                                                AND emp_id = {id}
                                                AND MONTH(time_in) = {selectedMonth} 
                                                AND YEAR(time_in) = {selectedYear}";

            try
            {
                DataTable dt = DB_OperationHelperClass.QueryData(sqlCountTotalAttendance);

                count = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;

                lblEmployeeTotalAttendance.Text = count.ToString();
            }
            catch (Exception ex)
            {
                string msg = $"Error occurred while counting total attendance for employee with ID: '{id}': {ex.Message}";
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboFilterMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string month = cboFilterMonth.SelectedItem.ToString();
            int selectedMonth = DateTime.ParseExact(month, "MMMM", CultureInfo.InvariantCulture).Month;

            if (cboFilterYear.SelectedItem == null)
            {
                MessageBox.Show("Please select a year.", "Year Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedYear = (int)cboFilterYear.SelectedItem;

            ComputeAttendancePercentageForMonth(_id, selectedMonth, selectedYear);
            ComputeAverageTimeOutForMonth(_id, selectedMonth, selectedYear);
            ComputeAverageTimeInForMonth(_id, selectedMonth, selectedYear);
            CountTotalAttendanceForMonth(_id, selectedMonth, selectedYear);
            FilterAndDisplayEmployeeAttendanceHistory(_id, selectedMonth, selectedYear);
        }

        private void FilterAndDisplayEmployeeAttendanceHistory(string id, int selectedMonth, int selectedYear)
        {
            flowLayoutPanel1.Controls.Clear();

            string employeeSql = $"SELECT start_date FROM tbl_employee WHERE emp_id = '{id}'";
            DateTime startDate;

            try
            {
                DataTable employeeDt = DB_OperationHelperClass.QueryData(employeeSql);
                if (employeeDt.Rows.Count > 0)
                {
                    startDate = Convert.ToDateTime(employeeDt.Rows[0]["start_date"]);
                }
                else
                {
                    MessageBox.Show($"No employee found with ID: {id}", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving employee data.", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string scheduledSql = $"SELECT work_days FROM tbl_schedule WHERE emp_id = '{id}'";
            DataTable scheduledDt = DB_OperationHelperClass.QueryData(scheduledSql);

            if (scheduledDt.Rows.Count == 0)
            {
                MessageBox.Show("No scheduled work days found for this employee.", "No Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            HashSet<string> workDaysSet = new HashSet<string>(scheduledDt.Rows[0]["work_days"].ToString().Split(','));

            DateTime date = new DateTime(selectedYear, selectedMonth, 1);
            DateTime endDate = date.AddMonths(1).AddDays(-1);
            DateTime currentDate = DateTime.Now.Date;

            string leaveSql = $"SELECT start_date, end_date FROM tbl_leave WHERE emp_id = '{id}' AND (leave_status = 'Active' OR leave_status = 'Completed')";
            DataTable leaveDt = DB_OperationHelperClass.QueryData(leaveSql);

            List<(DateTime start, DateTime end)> leavePeriods = new List<(DateTime, DateTime)>();

            foreach (DataRow row in leaveDt.Rows)
            {
                DateTime leaveStart = Convert.ToDateTime(row["start_date"]);
                DateTime leaveEnd = Convert.ToDateTime(row["end_date"]);
                leavePeriods.Add((leaveStart, leaveEnd));
            }

            bool hasAttendanceRecords = false;

            while (date <= endDate)
            {
                // Skip if the date is in the future
                if (date > currentDate)
                {
                    break;
                }

                // Skip the current date
                if (date == currentDate)
                {
                    date = date.AddDays(1);
                    continue;
                }

                // Skip if the date is before the employee's start date
                if (date < startDate)
                {
                    date = date.AddDays(1);
                    continue;
                }

                // Skip weekends (Saturday and Sunday)
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    date = date.AddDays(1);
                    continue;
                }

                // Check if the employee is on leave for the current date
                bool isOnLeave = leavePeriods.Any(leave => date >= leave.start && date <= leave.end);

                string attendanceSql = $@"SELECT time_in, DATE_FORMAT(time_in, '%h:%i %p') as time_in_formatted, 
                                          time_out, DATE_FORMAT(time_out, '%h:%i %p') as time_out_formatted, 
                                          time_in_status 
                                          FROM tbl_attendance 
                                          WHERE emp_id = '{id}' AND DATE(time_in) = DATE('{date:yyyy-MM-dd}')";

                DataTable attendanceDt = DB_OperationHelperClass.QueryData(attendanceSql);

                EmployeePastAttendanceHistoryCard employeePastAttendanceHistoryCard = new EmployeePastAttendanceHistoryCard(_employeeAttendance)
                {
                    AttendanceDate = date.ToString("ddd. MMM. dd, yyyy"),
                    ID = id,
                    ClockInTime = "--",
                    ClockOutTime = "--",
                    Status = "--",
                };

                if (attendanceDt.Rows.Count > 0)
                {
                    hasAttendanceRecords = true;
                    employeePastAttendanceHistoryCard.ClockInTime = attendanceDt.Rows[0]["time_in_formatted"].ToString();
                    employeePastAttendanceHistoryCard.ClockOutTime = attendanceDt.Rows[0]["time_out_formatted"].ToString();
                    employeePastAttendanceHistoryCard.Status = attendanceDt.Rows[0]["time_in_status"].ToString();

                    if (attendanceDt.Rows[0]["time_in_status"].ToString() == "On Time" || attendanceDt.Rows[0]["time_in_status"].ToString() == "Late")
                    {
                        employeePastAttendanceHistoryCard.btnPresentMark.Visible = true;
                    }
                }
                else if (isOnLeave)
                {
                    employeePastAttendanceHistoryCard.btnLeaveMark.Visible = true;
                    employeePastAttendanceHistoryCard.EmployeeListCardEmployeeDetailsCard.FillColor = Color.FromArgb(240, 248, 255);
                    employeePastAttendanceHistoryCard.lblClockIn.Location = new Point(12, 10);
                    employeePastAttendanceHistoryCard.lblClockOut.Location = new Point(119, 10);
                    employeePastAttendanceHistoryCard.lblClockIn.Text = "Start Date";
                    employeePastAttendanceHistoryCard.lblClockOut.Text = "End Date";

                    var leavePeriod = leavePeriods.FirstOrDefault(leave => date >= leave.start && date <= leave.end);

                    employeePastAttendanceHistoryCard.lblTimeIn.Text = leavePeriod.start.ToString("M/dd/yyyy");
                    employeePastAttendanceHistoryCard.lblTimeOut.Text = leavePeriod.end.ToString("M/dd/yyyy");
                    hasAttendanceRecords = true;
                }
                else if (workDaysSet.Contains(date.DayOfWeek.ToString()))
                {
                    employeePastAttendanceHistoryCard.btnAbsentMark.Visible = true;
                    employeePastAttendanceHistoryCard.EmployeeListCardEmployeeDetailsCard.FillColor = Color.FromArgb(255, 240, 240);
                    employeePastAttendanceHistoryCard.lblTimeIn.TextAlign = ContentAlignment.MiddleCenter;
                    hasAttendanceRecords = true;
                }

                flowLayoutPanel1.Controls.Add(employeePastAttendanceHistoryCard);
                date = date.AddDays(1);
            }

            if (!hasAttendanceRecords)
            {
                flowLayoutPanel1.Controls.Clear();
                MessageBox.Show($"No Attendance History for the selected month and year for employee with ID: {id}", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblEmployeeTotalAttendance.Text = "No Data";
                lblEmployeeAveTimeIn.Text = "No Data";
                lblEmployeeAveTimeOut.Text = "No Data";
                lblEmployeeAttPerfPercemtage.Text = "No Data";
                lblStartDate.Text = "N/A";

                btnDownloadAttendanceHistoryRecords.Enabled = false;
            }
            else
            {
                btnDownloadAttendanceHistoryRecords.Enabled = true;
            }
        }

        private void btnBackToAttendanceForm_Click(object sender, EventArgs e)
        {
            if (monthChangeTimer != null)
            {
                monthChangeTimer.Stop();
                monthChangeTimer.Dispose();
                monthChangeTimer = null;
            }

            _employeeAttendance.flowLayoutPanel2.Visible = false;
            _employeeAttendance.flowLayoutPanel2.Dock = DockStyle.Right;
            _employeeAttendance.panelAttendanceDetails.Visible = true;
            _employeeAttendance.flowLayoutPanel1.Visible = true;
            _employeeAttendance.flowLayoutPanel1.Dock = DockStyle.Fill;

            _employeeAttendance?.ViewEmployeeList(); // access the exposed btnViewEmployeeList_Click event from the EmployeeAttendance Form
        }
    }
}
