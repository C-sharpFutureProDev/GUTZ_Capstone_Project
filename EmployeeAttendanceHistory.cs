using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    public partial class EmployeeAttendanceHistory : UserControl
    {
        private string _id = "";
        private EmployeeAttendance _employeeAttendance;

        public EmployeeAttendanceHistory(string empID, EmployeeAttendance employeeAttendance)
        {
            InitializeComponent();
            if (empID != null)
            {
                _id = empID;
            }

            _employeeAttendance = employeeAttendance;
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

        private void ComputeAttendancePercentage(string empId)
        {
            double attendancePercentage = 0.0;

            try
            {
                // Get the current date
                DateTime currentDate = DateTime.Now;

                // Step 1: Get the employee's start date
                string employeeSql = $"SELECT start_date FROM tbl_employee WHERE emp_id = '{empId}'";
                DataTable employeeDt = DB_OperationHelperClass.QueryData(employeeSql);

                if (employeeDt.Rows.Count == 0)
                {
                    MessageBox.Show($"No employee found with ID: '{empId}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                // Step 2: Get the employee's working days (e.g., Monday, Tuesday)
                string workDaysSql = $"SELECT DISTINCT work_days FROM tbl_schedule WHERE emp_id = '{empId}'";
                DataTable workDaysDt = DB_OperationHelperClass.QueryData(workDaysSql);

                if (workDaysDt.Rows.Count == 0)
                {
                    MessageBox.Show($"No work schedule found for employee ID: '{empId}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblEmployeeAttPerfPercemtage.Text = "0.00%";
                    return;
                }

                // Extract working days into a list
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

                // Step 3: Calculate total working days between startDate and currentDate
                int totalWorkingDays = CountWorkingDays(startDate, currentDate, workingDays);

                // Step 4: Get the count of attended days
                string attendanceSql = $@"SELECT COUNT(*) FROM tbl_attendance
                                   WHERE emp_id = '{empId}' 
                                   AND (time_in_status = 'On Time' OR time_in_status = 'Late')";
                DataTable attendanceDt = DB_OperationHelperClass.QueryData(attendanceSql);

                int attendedDays = attendanceDt.Rows.Count > 0 ? Convert.ToInt32(attendanceDt.Rows[0][0]) : 0;

                // Step 5: Calculate attendance percentage
                if (totalWorkingDays > 0)
                {
                    attendancePercentage = (attendedDays / (double)totalWorkingDays) * 100;
                }

                // Display the result in the label
                lblEmployeeAttPerfPercemtage.Text = $"{attendancePercentage:F2}%";
            }
            catch (Exception ex)
            {
                string msg = $"Error occurred while computing attendance percentage for employee ID: '{empId}': {ex.Message}";
                string caption = "Error";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ComputeAverageTimeOut(string id)
        {
            string averageTimeOut = string.Empty;
            string averageTimeInQuery = $@"SELECT SEC_TO_TIME(AVG(TIME_TO_SEC(TIME(time_out)))) AS AverageTime
                                           FROM tbl_attendance
                                           WHERE emp_id = {id}";

            try
            {
                DataTable dt = DB_OperationHelperClass.QueryData(averageTimeInQuery);

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
                string msg = $"Error occurred while computing average time-in for employee with ID: '{id}': {ex.Message}";
                string caption = "Error";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblEmployeeAveTimeOut.Text = averageTimeOut;
        }

        private void ComputeAverageTimeIn(string id)
        {
            string averageTimeIn = string.Empty;
            string averageTimeInQuery = $@"SELECT SEC_TO_TIME(AVG(TIME_TO_SEC(TIME(time_in)))) AS AverageTime
                                           FROM tbl_attendance
                                           WHERE emp_id = {id}";

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
                string caption = "Error";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lblEmployeeAveTimeIn.Text = averageTimeIn;
        }

        private void CountTotalAttendance(string id)
        {
            int count = 0;
            string sqlCountTotalAttendance = $@"SELECT COUNT(*) FROM tbl_attendance
                                                WHERE (time_in_status = 'On Time' OR time_in_status = 'Late')
                                                AND emp_id = {id}";

            try
            {
                DataTable dt = DB_OperationHelperClass.QueryData(sqlCountTotalAttendance);

                count = dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0][0]) : 0;

                lblEmployeeTotalAttendance.Text = count.ToString();
            }
            catch (Exception ex)
            {
                string msg = $"Error occurred while counting total attendance for employee with ID: '{id}': {ex.Message}";
                string caption = "Error";
                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RetrieveAndDisplayEmployeeAttendanceHistory(string id)
        {
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

            // Create a set of workdays for quick lookup
            HashSet<string> workDaysSet = new HashSet<string>(scheduledDt.Rows[0]["work_days"].ToString().Split(','));

            DateTime currentDate = DateTime.Now;
            DateTime date = startDate;

            string leaveSql = $"SELECT start_date, end_date FROM tbl_leave WHERE emp_id = '{id}' AND (leave_status = 'Active' OR leave_status = 'Completed')";
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
                    employeePastAttendanceHistoryCard.EmployeeListCardEmployeeDetailsCard.FillColor = Color.FromArgb(74, 144, 226);
                    employeePastAttendanceHistoryCard.lblClockIn.Location = new Point(12, 10);
                    employeePastAttendanceHistoryCard.lblClockOut.Location = new Point(119, 10);
                    employeePastAttendanceHistoryCard.lblClockIn.Text = "Start Date";
                    employeePastAttendanceHistoryCard.lblClockOut.Text = "End Date";

                    var leavePeriod = leavePeriods.FirstOrDefault(leave => date >= leave.start && date <= leave.end);

                    employeePastAttendanceHistoryCard.lblTimeIn.Text = leavePeriod.start.ToString("M/dd/yyyy");
                    employeePastAttendanceHistoryCard.lblTimeOut.Text = leavePeriod.end.ToString("M/dd/yyyy");
                }
                else if (workDaysSet.Contains(date.DayOfWeek.ToString()))
                {
                    employeePastAttendanceHistoryCard.btnAbsentMark.Visible = true;
                    employeePastAttendanceHistoryCard.lblTimeIn.TextAlign = ContentAlignment.MiddleCenter;
                }

                flowLayoutPanel1.Controls.Add(employeePastAttendanceHistoryCard);
                date = date.AddDays(1);
            }
        }

        private void EmployeeAttendanceHistory_Load(object sender, EventArgs e)
        {
            CountTotalAttendance(_id);
            ComputeAverageTimeIn(_id);
            ComputeAverageTimeOut(_id);
            RetrieveAndDisplayEmployeeAttendanceHistory(_id);
            ComputeAttendancePercentage(_id);

            cboFilterYear.SelectedIndex = 0;
            cboFilterMonth.SelectedIndex = 0;

            try
            {
                string employeeSql = @"SELECT emp_ProfilePic, CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS FullName, phone, email, position_desc
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
            csvData.AppendLine("Date,Clock In,Clock Out,Status"); // CSV Header

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
                SaveAttendanceHistoryToCsv(_id, csvData.ToString());
            }
        }

        private void SaveAttendanceHistoryToCsv(string employeeId, string csvContent)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = $"AttendanceHistory_{employeeId}.csv";
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, csvContent);
                    MessageBox.Show("Attendance history downloaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}