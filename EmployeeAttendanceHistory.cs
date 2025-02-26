using DPFP;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        private List<EmployeePastAttendanceHistoryCard> _attendanceHistoryCards = new List<EmployeePastAttendanceHistoryCard>();

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

        private async void EmployeeAttendanceHistory_Load(object sender, EventArgs e)
        {
            // Unsubscribe from events to prevent them from firing during initialization
            cboSortAttendanceHistory.SelectedIndexChanged -= cboSortAttendanceHistory_SelectedIndexChanged;

            // Populate the year ComboBox (last 6 years including the current year)
            cboFilterYear.Items.Clear();
            int currentYear = DateTime.Now.Year;
            for (int year = currentYear; year >= currentYear - 6; year--)
            {
                cboFilterYear.Items.Add(year);
            }
            cboFilterYear.SelectedItem = currentYear;

            // Populate the month ComboBox to show all months by name
            UpdateComboBoxToCurrentMonth();

            // Set default sort option
            cboSortAttendanceHistory.SelectedIndex = 0;

            // Initialize and start the timer for refreshing data
            monthChangeTimer = new Timer
            {
                Interval = 3600000 // 1 hour
            };
            monthChangeTimer.Tick += MonthChangeTimer_Tick;
            monthChangeTimer.Start();

            // Load employee data asynchronously
            await LoadEmployeeDataAsync();

            // Compute attendance metrics
            ComputeTotalAttendanceMetrics(_id);

            // Display the initial attendance history (current month and year)
            await FilterAndDisplayEmployeeAttendanceHistory(_id, DateTime.Now.Month, currentYear);

            // Re-subscribe to the event after initialization
            cboSortAttendanceHistory.SelectedIndexChanged += cboSortAttendanceHistory_SelectedIndexChanged;
        }

        private async Task LoadEmployeeDataAsync()
        {
            try
            {
                string employeeSql = @"SELECT emp_ProfilePic, CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS FullName, work_days, start_time, end_time, position_desc, start_date
                                       FROM tbl_employee
                                       INNER JOIN tbl_schedule ON tbl_employee.emp_id = tbl_schedule.emp_id
                                       INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                       WHERE tbl_employee.emp_id = @empId";

                var paramID = new Dictionary<string, object> { { "@empId", _id } };

                DataTable employeeDt = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(employeeSql, paramID));

                if (employeeDt.Rows.Count > 0)
                {
                    string image_path = employeeDt.Rows[0]["emp_ProfilePic"].ToString();
                    employeeProfilePicture.Image = await LoadImageAsync(image_path);
                    lblEmployeeName.Text = employeeDt.Rows[0]["FullName"].ToString();
                    lblEmployeeJobRole.Text = employeeDt.Rows[0]["position_desc"].ToString();

                    // Format work_days
                    string workDays = employeeDt.Rows[0]["work_days"].ToString();
                    string[] daysArray = workDays.Split(',');
                    string formattedDays = string.Join(",", daysArray.Select(day => day.Trim().Substring(0, 1).ToUpper()));
                    lblEmployeeWorkDays.Text = formattedDays;

                    // Format start_time and end_time in 12-hour format
                    DateTime startTime = DateTime.Parse(employeeDt.Rows[0]["start_time"].ToString());
                    DateTime endTime = DateTime.Parse(employeeDt.Rows[0]["end_time"].ToString());
                    lblStartTimeAndEndTime.Text = $"{startTime:hh:mm tt} - {endTime:hh:mm tt}";

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

        private void btnDownloadAttendanceHistoryRecords_Click(object sender, EventArgs e)
        {
            // Retrieve selected month and year from the combo boxes
            if (cboFilterMonth.SelectedItem == null || cboFilterYear.SelectedItem == null)
            {
                MessageBox.Show("Please select both month and year.", "Selection Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string month = cboFilterMonth.SelectedItem.ToString();
            int selectedMonth = DateTime.ParseExact(month, "MMMM", CultureInfo.InvariantCulture).Month;
            int selectedYear = (int)cboFilterYear.SelectedItem;

            int totalAttendance = 0;
            int totalLate = 0;
            int totalAbsent = 0;

            // Retrieve work days set for this employee
            string scheduledSql = $"SELECT work_days FROM tbl_schedule WHERE emp_id = '{_id}'";
            DataTable scheduledDt = DB_OperationHelperClass.QueryData(scheduledSql);
            HashSet<string> workDaysSet = new HashSet<string>(scheduledDt.Rows[0]["work_days"].ToString().Split(','));

            // Set the first day of the selected month and the last day of the month
            DateTime firstDate = new DateTime(selectedYear, selectedMonth, 1);
            DateTime lastDate = firstDate.AddMonths(1).AddDays(-1); // Last day of the selected month

            // Prepare to create Excel data
            DataTable attendanceDataTable = new DataTable();
            attendanceDataTable.Columns.Add("Date");
            attendanceDataTable.Columns.Add("Clock In");
            attendanceDataTable.Columns.Add("Clock Out");
            attendanceDataTable.Columns.Add("Status");

            // Loop through the selected month to count attendance and absences
            for (DateTime date = firstDate; date <= lastDate; date = date.AddDays(1))
            {
                // Only consider past dates
                if (date.Date >= DateTime.Today)
                {
                    continue; // Skip future dates
                }

                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue; // Skip weekends
                }

                // Check if the employee was scheduled to work on this day
                bool isScheduled = workDaysSet.Contains(date.DayOfWeek.ToString());

                // Attendance data retrieval for that date
                string sql = $@"SELECT
                                     time_in,
                                     DATE_FORMAT(time_in, '%h:%i %p') AS time_in_formatted,
                                     time_out,
                                     DATE_FORMAT(time_out, '%h:%i %p') AS time_out_formatted,
                                     time_in_status
                                 FROM
                                     tbl_attendance
                                 WHERE
                                     emp_id = '{_id}' AND 
                                     DATE(time_in) = DATE('{date:yyyy-MM-dd}')";

                DataTable attendanceDt = DB_OperationHelperClass.QueryData(sql);

                string clockIn = "--";
                string clockOut = "--";
                string status = "--";

                if (attendanceDt.Rows.Count > 0)
                {
                    // Employee clocked in
                    clockIn = attendanceDt.Rows[0]["time_in_formatted"].ToString();
                    clockOut = attendanceDt.Rows[0]["time_out_formatted"].ToString();
                    status = attendanceDt.Rows[0]["time_in_status"].ToString();
                    totalAttendance++;

                    if (status == "Late") totalLate++;
                }
                else if (isScheduled)
                {
                    // If scheduled but no clock-in record, count as absent
                    status = "Absent";
                    totalAbsent++;
                }

                // Add attendance record to the DataTable
                attendanceDataTable.Rows.Add($"{date:yyyy-MM-dd}", clockIn, clockOut, status);
            }

            DialogResult result = MessageBox.Show($"Do you want to download the attendance history for employee with ID: {_id} for {month} {selectedYear}?", "Download Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ExportAttendanceHistoryToExcel(attendanceDataTable, selectedMonth, selectedYear, totalAttendance, totalLate, totalAbsent);
            }
        }

        private void ExportAttendanceHistoryToExcel(DataTable attendanceDataTable, int month, int year, int totalAttendance, int totalLate, int totalAbsent)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Save Attendance History as Excel File";
                saveFileDialog.FileName = $"AttendanceHistory_{_id}_{new DateTime(year, month, 1):MMMM}_{year}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                        using (ExcelPackage package = new ExcelPackage())
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Attendance History");

                            // Add primary header
                            worksheet.Cells["A1:D1"].Merge = true;
                            worksheet.Cells["A1"].Value = "Attendance History";
                            worksheet.Cells["A1"].Style.Font.Bold = true;
                            worksheet.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            worksheet.Cells["A1"].Style.Font.Size = 16; // Adjusted font size
                            worksheet.Cells["A1"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.None; // No background color
                            worksheet.Cells["A1"].Style.Font.Color.SetColor(System.Drawing.Color.Black); // Black text color

                            // Define headers
                            worksheet.Cells[2, 1].Value = "Date";
                            worksheet.Cells[2, 2].Value = "Clock In";
                            worksheet.Cells[2, 3].Value = "Clock Out";
                            worksheet.Cells[2, 4].Value = "Status";

                            // Customize header row with blue background and white text
                            worksheet.Cells["A2:D2"].Style.Font.Bold = true; // Make header bold
                            worksheet.Cells["A2:D2"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid; // Solid fill
                            worksheet.Cells["A2:D2"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(0, 123, 255)); // Blue background color
                            worksheet.Cells["A2:D2"].Style.Font.Color.SetColor(System.Drawing.Color.White); // Set font color to white
                            worksheet.Cells["A2:D2"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left; // Left align

                            // Populate data with alternating row colors
                            for (int i = 0; i < attendanceDataTable.Rows.Count; i++)
                            {
                                DataRow row = attendanceDataTable.Rows[i];
                                worksheet.Cells[i + 3, 1].Value = row["Date"];
                                worksheet.Cells[i + 3, 2].Value = row["Clock In"];
                                worksheet.Cells[i + 3, 3].Value = row["Clock Out"];
                                worksheet.Cells[i + 3, 4].Value = row["Status"];

                                // Set alternating row colors for better readability
                                if (i % 2 == 0)
                                {
                                    worksheet.Cells[i + 3, 1, i + 3, 4].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                    worksheet.Cells[i + 3, 1, i + 3, 4].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(248, 249, 250)); // Light gray
                                }
                            }

                            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns(); // Auto-fit columns

                            FileInfo fi = new FileInfo(saveFileDialog.FileName);
                            package.SaveAs(fi);
                        }

                        MessageBox.Show("Attendance history downloaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while exporting the data to Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private async void cboFilterMonth_SelectedIndexChanged(object sender, EventArgs e)
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
            await FilterAndDisplayEmployeeAttendanceHistory(_id, selectedMonth, selectedYear);
        }

        private async Task FilterAndDisplayEmployeeAttendanceHistory(string id, int selectedMonth, int selectedYear)
        {
            flowLayoutPanel1.Controls.Clear();

            string employeeSql = $"SELECT start_date FROM tbl_employee WHERE emp_id = '{id}'";
            DateTime startDate;

            try
            {
                DataTable employeeDt = await Task.Run(() => DB_OperationHelperClass.QueryData(employeeSql));

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
            DataTable scheduledDt = await Task.Run(() => DB_OperationHelperClass.QueryData(scheduledSql));

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
            DataTable leaveDt = await Task.Run(() => DB_OperationHelperClass.QueryData(leaveSql));

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

                // Check if the employee is on leave for the current date
                bool isOnLeave = leavePeriods.Any(leave => date >= leave.start && date <= leave.end);

                // Initialize the card once
                EmployeePastAttendanceHistoryCard employeePastAttendanceHistoryCard = new EmployeePastAttendanceHistoryCard(_employeeAttendance)
                {
                    AttendanceDate = date.ToString("ddd. MMM. dd, yyyy"),
                    ID = id,
                    ClockInTime = "--",
                    ClockOutTime = "--",
                    Status = "--",
                };

                // If the employee is on leave, display the leave card regardless of scheduled work days
                if (isOnLeave)
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
                // If the day is a scheduled work day, check for attendance
                else if (workDaysSet.Contains(date.DayOfWeek.ToString()))
                {
                    string attendanceSql = $@"SELECT time_in, DATE_FORMAT(time_in, '%h:%i %p') as time_in_formatted, 
                                              time_out, DATE_FORMAT(time_out, '%h:%i %p') as time_out_formatted, 
                                              time_in_status 
                                              FROM tbl_attendance 
                                              WHERE emp_id = '{id}' AND DATE(time_in) = DATE('{date:yyyy-MM-dd}')";

                    DataTable attendanceDt = DB_OperationHelperClass.QueryData(attendanceSql);

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
                    else
                    {
                        employeePastAttendanceHistoryCard.btnAbsentMark.Visible = true;
                        employeePastAttendanceHistoryCard.EmployeeListCardEmployeeDetailsCard.FillColor = Color.FromArgb(255, 240, 240);
                        employeePastAttendanceHistoryCard.lblTimeIn.TextAlign = ContentAlignment.MiddleCenter;
                        hasAttendanceRecords = true;
                    }
                }
                else
                {
                    // Skip non-scheduled work days
                    date = date.AddDays(1);
                    continue;
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

                btnDownloadAttendanceHistoryRecords.Enabled = false;
            }
            else
            {
                btnDownloadAttendanceHistoryRecords.Enabled = true;
            }
        }

        private async void cboSortAttendanceHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected year and month from the filter ComboBoxes
            int selectedYear = Convert.ToInt32(cboFilterYear.SelectedItem);
            int selectedMonth = cboFilterMonth.SelectedIndex + 1; // Assuming 0-based index for months (Jan = 0, Feb = 1, etc.)

            // Validation
            if (selectedYear < 1900 || selectedYear > DateTime.Now.Year)
            {
                MessageBox.Show("Please select a valid year.", "Invalid Year", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedMonth < 1 || selectedMonth > 12)
            {
                MessageBox.Show("Please select a valid month (1-12).", "Invalid Month", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Clear the FlowLayoutPanel before loading new records
                flowLayoutPanel1.Controls.Clear();

                // Define the query string based on the selected sort option
                string query = "";

                switch (cboSortAttendanceHistory.SelectedIndex)
                {
                    case 0: // ALL (Display all records regardless of status)
                        await FilterAndDisplayEmployeeAttendanceHistory(_id, selectedMonth, selectedYear);
                        return; // Exit after displaying all records

                    case 1: // On Time
                        query = $@"SELECT ta.emp_id, ta.time_in, ta.time_out, ta.time_in_status, 
                                    DATE_FORMAT(ta.time_in, '%Y-%m-%d') AS attendance_date
                             FROM tbl_attendance ta
                             WHERE ta.time_in_status = 'On Time' AND emp_id = '{_id}'
                                   AND YEAR(ta.time_in) = {selectedYear}
                                   AND MONTH(ta.time_in) = {selectedMonth}
                             ORDER BY ta.time_in ASC";
                        break;

                    case 2: // Late
                        query = $@"SELECT ta.emp_id, ta.time_in, ta.time_out, ta.time_in_status, 
                                    DATE_FORMAT(ta.time_in, '%Y-%m-%d') AS attendance_date
                             FROM tbl_attendance ta
                             WHERE ta.time_in_status = 'Late' AND emp_id = '{_id}'
                                   AND YEAR(ta.time_in) = {selectedYear}
                                   AND MONTH(ta.time_in) = {selectedMonth}
                             ORDER BY ta.time_in ASC";
                        break;

                    case 3: // Absent
                            // Call a method to handle displaying absent records specifically
                        await DisplayAbsentRecords(_id, selectedMonth, selectedYear);
                        return; // Exit after displaying absent records

                    case 4: // On Leave
                        await DisplayOnLeaveRecords(_id, selectedMonth, selectedYear);
                        return; // Exit after displaying leave records

                    default:
                        MessageBox.Show("Please select a valid sorting criterion.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

                // Execute the query to retrieve data (only for cases 1 and 2)
                if (cboSortAttendanceHistory.SelectedIndex != 0 && cboSortAttendanceHistory.SelectedIndex != 3 && cboSortAttendanceHistory.SelectedIndex != 4) // Skip query execution for "ALL", "Absent", and "On Leave"
                {
                    DataTable dt = await Task.Run(() => DB_OperationHelperClass.QueryData(query));

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            // Create an attendance card for each row in the result
                            EmployeePastAttendanceHistoryCard employeePastAttendanceHistoryCard = new EmployeePastAttendanceHistoryCard(_employeeAttendance)
                            {
                                AttendanceDate = Convert.ToDateTime(row["attendance_date"]).ToString("ddd. MMM. dd, yyyy"),
                                ID = row["emp_id"].ToString(),
                                ClockInTime = row["time_in"] != DBNull.Value
                                    ? Convert.ToDateTime(row["time_in"]).ToString("hh:mm tt")
                                    : "--",
                                ClockOutTime = row["time_out"] != DBNull.Value
                                    ? Convert.ToDateTime(row["time_out"]).ToString("hh:mm tt")
                                    : "--",
                                Status = row["time_in_status"].ToString()
                            };

                            // Adjust visibility of Present/Late button based on status
                            employeePastAttendanceHistoryCard.btnPresentMark.Visible = employeePastAttendanceHistoryCard.Status == "On Time" || employeePastAttendanceHistoryCard.Status == "Late";

                            // Add the card to the FlowLayoutPanel
                            flowLayoutPanel1.Controls.Add(employeePastAttendanceHistoryCard);
                        }
                    }
                    else
                    {
                        // No records found
                        MessageBox.Show($"No attendance records found for {selectedMonth}/{selectedYear} based on the selected sorting criterion.",
                            "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving attendance history: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DisplayAbsentRecords(string id, int selectedMonth, int selectedYear)
        {
            flowLayoutPanel1.Controls.Clear();

            // Get the employee's start date
            DateTime startDate;
            string employeeSql = $"SELECT start_date FROM tbl_employee WHERE emp_id = '{id}'";

            try
            {
                DataTable employeeDt = await Task.Run(() => DB_OperationHelperClass.QueryData(employeeSql));

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
                MessageBox.Show("An error occurred while retrieving employee data: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the employee's scheduled workdays
            string scheduledSql = $"SELECT work_days FROM tbl_schedule WHERE emp_id = '{id}'";
            DataTable scheduledDt;

            try
            {
                scheduledDt = await Task.Run(() => DB_OperationHelperClass.QueryData(scheduledSql));

                if (scheduledDt.Rows.Count == 0)
                {
                    MessageBox.Show("No scheduled workdays found for this employee.", "No Record",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving scheduled workdays: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Parse scheduled workdays into a HashSet
            HashSet<DayOfWeek> workDaysSet = new HashSet<DayOfWeek>(
                scheduledDt.Rows[0]["work_days"].ToString()
                .Split(',')
                .Select(day => (DayOfWeek)Enum.Parse(typeof(DayOfWeek), day, true))
            );

            // Iterate through the selected month
            DateTime date = new DateTime(selectedYear, selectedMonth, 1);
            DateTime endDate = date.AddMonths(1).AddDays(-1);
            DateTime currentDate = DateTime.Now.Date;

            while (date <= endDate)
            {
                // Skip dates that are in the future or before the employee start date
                if (date > currentDate || date < startDate)
                {
                    date = date.AddDays(1);
                    continue;
                }

                // Check if the current date is a scheduled workday
                if (!workDaysSet.Contains(date.DayOfWeek))
                {
                    date = date.AddDays(1);
                    continue;
                }

                // Check if attendance exists for the current date
                string attendanceSql = $@"SELECT time_in, time_out, time_in_status 
                                          FROM tbl_attendance 
                                          WHERE emp_id = '{id}' AND DATE(time_in) = '{date:yyyy-MM-dd}'";

                DataTable attendanceDt = await Task.Run(() => DB_OperationHelperClass.QueryData(attendanceSql));

                // If attendance exists, skip creating an "Absent" card
                if (attendanceDt.Rows.Count > 0)
                {
                    date = date.AddDays(1);
                    continue;
                }

                // Only create an "Absent" card when no attendance record exists for the date
                EmployeePastAttendanceHistoryCard employeePastAttendanceHistoryCard = new EmployeePastAttendanceHistoryCard(_employeeAttendance)
                {
                    AttendanceDate = date.ToString("ddd. MMM. dd, yyyy"),
                    ID = id,
                    ClockInTime = "     --",
                    ClockOutTime = "    --",
                    Status = "Absent",
                    btnAbsentMark = { Visible = true },
                    EmployeeListCardEmployeeDetailsCard = { FillColor = Color.FromArgb(255, 240, 240) }
                };

                // Add the card to the FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(employeePastAttendanceHistoryCard);

                // Move to the next day
                date = date.AddDays(1);
            }
        }

        private async Task DisplayOnLeaveRecords(string id, int selectedMonth, int selectedYear)
        {
            flowLayoutPanel1.Controls.Clear();

            // Query to retrieve leave records for the selected month and year
            string leaveSql = $@"SELECT start_date, end_date 
                         FROM tbl_leave 
                         WHERE emp_id = '{id}' 
                               AND (leave_status = 'Active' OR leave_status = 'Completed')
                               AND ((YEAR(start_date) = {selectedYear} AND MONTH(start_date) = {selectedMonth})
                                    OR (YEAR(end_date) = {selectedYear} AND MONTH(end_date) = {selectedMonth}))";

            try
            {
                DataTable leaveDt = await Task.Run(() => DB_OperationHelperClass.QueryData(leaveSql));

                if (leaveDt.Rows.Count > 0)
                {
                    foreach (DataRow row in leaveDt.Rows)
                    {
                        DateTime leaveStart = Convert.ToDateTime(row["start_date"]);
                        DateTime leaveEnd = Convert.ToDateTime(row["end_date"]);

                        // Iterate through each day in the leave period
                        for (DateTime date = leaveStart; date <= leaveEnd; date = date.AddDays(1))
                        {
                            // Only display leave records for the selected month and year
                            if (date.Year == selectedYear && date.Month == selectedMonth)
                            {
                                EmployeePastAttendanceHistoryCard employeePastAttendanceHistoryCard = new EmployeePastAttendanceHistoryCard(_employeeAttendance)
                                {
                                    AttendanceDate = date.ToString("ddd. MMM. dd, yyyy"),
                                    ID = id,
                                    ClockInTime = "--",
                                    ClockOutTime = "--",
                                    Status = "On Leave",
                                    btnLeaveMark = { Visible = true },
                                    EmployeeListCardEmployeeDetailsCard = { FillColor = Color.FromArgb(240, 248, 255) }
                                };

                                // Add the card to the FlowLayoutPanel
                                flowLayoutPanel1.Controls.Add(employeePastAttendanceHistoryCard);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"No leave records found for {selectedMonth}/{selectedYear}.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving leave records: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            _employeeAttendance.isReturningFromHistory = true;
            _employeeAttendance.txtSearch.Clear();
            _employeeAttendance?.ViewEmployeeList(); // access the exposed btnViewEmployeeList_Click event from the EmployeeAttendance Form
        }
    }
}

