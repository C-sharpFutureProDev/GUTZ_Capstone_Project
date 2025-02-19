using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;

namespace GUTZ_Capstone_Project
{
    public partial class FormEmployeePayrollManagement : Form
    {
        string id;
        private bool isUpdatingActivePayroll = false; // To prevent overlapping updates

        public FormEmployeePayrollManagement()
        {
            InitializeComponent();
        }

        private async void PopulateEmployeeList()
        {
            string sql = @"SELECT emp_id, position_desc, emp_profilePic, work_arrangement, f_name, m_name, l_name, account_name, tenured_rate, non_tenured_rate, employment_type
                           FROM tbl_employee
                           INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                           INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
                           INNER JOIN tbl_rates ON tbl_rates.account_id = tbl_account.account_id
                           WHERE is_deleted = 0
                           ORDER BY emp_id ASC";

            DataTable dt = await Task.Run(() => DB_OperationHelperClass.QueryData(sql));

            try
            {
                flowLayoutPanel2.Controls.Clear();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No employee records found.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        id = row["emp_id"].ToString();
                        string firstName = row["f_name"].ToString();
                        string middleName = row["m_name"].ToString();
                        string lastName = row["l_name"].ToString();
                        string name = string.IsNullOrEmpty(middleName) || middleName == "N/A"
                            ? $"{firstName} {lastName}"
                            : $"{firstName} {middleName[0]}. {lastName}";

                        string imagePath = row["emp_ProfilePic"].ToString();
                        string accountName = row["account_name"].ToString();
                        string employmentType = row["employment_type"].ToString();
                        string jobRole = row["position_desc"].ToString();
                        string ratePerHour = string.Empty;

                        if (employmentType == "Tenured")
                            ratePerHour = row["tenured_rate"].ToString();
                        else if (employmentType == "Non-Tenured")
                            ratePerHour = row["non_tenured_rate"].ToString();

                        EmployeeListCardForPayrollHistory employeeListCardForPayrollHistory = new EmployeeListCardForPayrollHistory()
                        {
                            ID = id,
                            EmployeeProfilePic = await LoadImageAsync(imagePath),
                            EmployeeName = name,
                            Account = accountName,
                            EmploymentType = employmentType,
                            RatePerHour = "₱" + ratePerHour + " / Hour",
                        };

                        if (jobRole == "Administrator")
                        {
                            employeeListCardForPayrollHistory.Hide();
                        }

                        flowLayoutPanel2.Controls.Add(employeeListCardForPayrollHistory);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "Error retrieving employee list: ";
                string caption = "Error";
                MessageBox.Show(message + ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<System.Drawing.Image> LoadImageAsync(string imagePath)
        {
            SampleEmployeePayrollCard sampleEmployeePayrollCard = new SampleEmployeePayrollCard();
            string defaultImagePath = "C:/GUTZ/Employee_Profil_Picture/GUTZ_Temporary_Profile.jpg";

            return await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
                {
                    MessageBox.Show("No profile picture found.");
                    return sampleEmployeePayrollCard.employeeProfilePicture.Image = System.Drawing.Image.FromFile(defaultImagePath);
                }

                try
                {
                    using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        return System.Drawing.Image.FromStream(stream);
                    }
                }
                catch (Exception ex)
                {
                    string message = "Error retrieving employee profile picture";
                    string caption = "Error";
                    MessageBox.Show(message + ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return sampleEmployeePayrollCard.employeeProfilePicture.Image = System.Drawing.Image.FromFile(defaultImagePath);
                }
            });
        }

        private async void ComputeTotalTutoringHours()
        {
            try
            {
                string startDate = string.Empty;
                string endDate = string.Empty;

                // Retrieve the payroll start and end dates
                string query = "SELECT pay_start_date, pay_end_date FROM tbl_payroll WHERE payroll_status = @status";
                var parameters = new Dictionary<string, object>
                {
                    { "@status", "In-Progress" }
                };

                DataTable dtStartDate = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(query, parameters));

                if (dtStartDate.Rows.Count > 0)
                {
                    startDate = dtStartDate.Rows[0]["pay_start_date"].ToString();
                    endDate = dtStartDate.Rows[0]["pay_end_date"].ToString();
                }

                // Check if start and end dates were retrieved
                if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                {
                    DateTime payrollStartDate = DateTime.Parse(startDate);
                    DateTime payrollEndDate = DateTime.Parse(endDate);

                    long totalSeconds = 0; // Total working time in seconds

                    // Retrieve all employees
                    string employeeQuery = "SELECT emp_id FROM tbl_employee";
                    DataTable dtEmployees = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(employeeQuery, new Dictionary<string, object>()));

                    // Loop through each employee
                    foreach (DataRow employeeRow in dtEmployees.Rows)
                    {
                        string employeeId = employeeRow["emp_id"].ToString();

                        // Retrieve the employee's schedule
                        string scheduleQuery = "SELECT start_time, end_time, work_days FROM tbl_schedule WHERE emp_id = @empId";
                        var scheduleParameters = new Dictionary<string, object>
                        {
                            { "@empId", employeeId }
                        };

                        DataTable dtSchedule = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(scheduleQuery, scheduleParameters));

                        if (dtSchedule.Rows.Count > 0)
                        {
                            DataRow scheduleRow = dtSchedule.Rows[0];
                            TimeSpan scheduledStartTime = TimeSpan.Parse(scheduleRow["start_time"].ToString());
                            TimeSpan scheduledEndTime = TimeSpan.Parse(scheduleRow["end_time"].ToString());
                            string workDays = scheduleRow["work_days"].ToString();

                            // Loop through each date in the payroll period
                            for (DateTime date = payrollStartDate; date <= payrollEndDate; date = date.AddDays(1))
                            {
                                // Check if the current date is a working day for the employee
                                string currentDay = date.DayOfWeek.ToString();
                                if (workDays.Contains(currentDay))
                                {
                                    // Retrieve attendance records for the current date
                                    string attendanceQuery = @"SELECT time_in, time_out, time_in_status 
                                                               FROM tbl_attendance
                                                               INNER JOIN tbl_employee ON tbl_attendance.emp_id = tbl_employee.emp_id
                                                               WHERE tbl_attendance.emp_id = @employeeId 
                                                               AND CAST(time_in AS DATE) = @date
                                                               AND is_deleted = 0";

                                    var attendanceParameters = new Dictionary<string, object>
                                    {
                                        { "@employeeId", employeeId },
                                        { "@date", date.ToString("yyyy-MM-dd") }
                                    };

                                    DataTable dtAttendance = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(attendanceQuery, attendanceParameters));

                                    if (dtAttendance.Rows.Count > 0)
                                    {
                                        DataRow attendanceRow = dtAttendance.Rows[0];
                                        DateTime? timeIn = attendanceRow["time_in"] as DateTime?;
                                        DateTime? timeOut = attendanceRow["time_out"] as DateTime?;
                                        string timeInStatus = attendanceRow["time_in_status"].ToString();

                                        if (timeIn.HasValue && timeOut.HasValue)
                                        {
                                            // Define scheduled start and end times for the day
                                            DateTime scheduledStartDateTime = date.Add(scheduledStartTime);
                                            DateTime scheduledEndDateTime = date.Add(scheduledEndTime);

                                            TimeSpan workingHours;

                                            if (timeInStatus == "On Time")
                                            {
                                                // If on time, compute working hours from scheduled start to scheduled end
                                                workingHours = scheduledEndDateTime - scheduledStartDateTime;
                                            }
                                            else
                                            {
                                                // If late, compute working hours from actual time_in to actual time_out
                                                DateTime effectiveTimeOut = timeOut.Value > scheduledEndDateTime
                                                    ? scheduledEndDateTime // Cap time_out to scheduled end time
                                                    : timeOut.Value; // Use actual time_out if within schedule

                                                // Ensure time_in is not before scheduled start time
                                                DateTime effectiveTimeIn = timeIn.Value < scheduledStartDateTime
                                                    ? scheduledStartDateTime // Cap time_in to scheduled start time
                                                    : timeIn.Value; // Use actual time_in if after scheduled start time

                                                workingHours = effectiveTimeOut - effectiveTimeIn;
                                            }

                                            // Ensure working hours are not negative
                                            if (workingHours.TotalSeconds < 0)
                                            {
                                                workingHours = TimeSpan.Zero;
                                            }

                                            // Accumulate total working hours in seconds
                                            long workingSeconds = (long)workingHours.TotalSeconds;
                                            totalSeconds += workingSeconds;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Convert total seconds to hours and minutes
                    int totalHours = (int)(totalSeconds / 3600); // Total hours
                    int totalMinutes = (int)((totalSeconds % 3600) / 60); // Remaining minutes

                    // Convert total seconds to decimal hours
                    long roundedTotalSeconds = (long)Math.Round((double)totalSeconds); // Round total seconds to the nearest whole number
                    decimal totalDecimalHours = Math.Round((decimal)roundedTotalSeconds / 3600, 2); // Convert to decimal hours and round to 2 decimal places

                    // Format the result
                    string totalWorkingTime = $"{totalDecimalHours} Hrs."; // Display as decimal hours

                    // Display the result
                    lblTotalTutoringHours.Text = totalWorkingTime;
                }
                else
                {
                    string message = "No payroll dates found.";
                    string caption = "Payroll Dates Missing";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                string message = $"An error occurred: {ex.Message}";
                string caption = "Error";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ComputeTotalDeductions()
        {
            try
            {
                string startDate = string.Empty;
                string endDate = string.Empty;

                // Retrieve the payroll start and end dates
                string query = "SELECT pay_start_date, pay_end_date FROM tbl_payroll WHERE payroll_status = @status";
                var parameters = new Dictionary<string, object>
                {
                    { "@status", "In-Progress" }
                };

                DataTable dtStartDate = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(query, parameters));

                if (dtStartDate.Rows.Count > 0)
                {
                    startDate = dtStartDate.Rows[0]["pay_start_date"].ToString();
                    endDate = dtStartDate.Rows[0]["pay_end_date"].ToString();
                }

                // Check if start and end dates were retrieved
                if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                {
                    DateTime payrollStartDate = DateTime.Parse(startDate);
                    DateTime payrollEndDate = DateTime.Parse(endDate);

                    // Retrieve all employee IDs
                    string getEmployeeIdsQuery = "SELECT emp_id FROM tbl_employee WHERE is_deleted = 0";
                    DataTable dtEmployeeIds = await Task.Run(() => DB_OperationHelperClass.QueryData(getEmployeeIdsQuery));

                    decimal totalDeductions = 0;

                    // Calculate deductions for each employee
                    foreach (DataRow row in dtEmployeeIds.Rows)
                    {
                        string employeeId = row["emp_id"].ToString();
                        TimeSpan totalLateTime = TimeSpan.Zero;

                        // Loop through each date in the payroll period
                        for (DateTime date = payrollStartDate; date <= payrollEndDate; date = date.AddDays(1))
                        {
                            // Retrieve the employee's schedule for the current date
                            string getScheduleQuery = "SELECT start_time, work_days FROM tbl_schedule WHERE emp_id = @empId";
                            var getScheduleParams = new Dictionary<string, object> { { "@empId", employeeId } };
                            DataTable scheduleTable = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(getScheduleQuery, getScheduleParams));

                            if (scheduleTable.Rows.Count > 0)
                            {
                                DataRow scheduleRow = scheduleTable.Rows[0];
                                string workDays = scheduleRow["work_days"].ToString();
                                TimeSpan scheduledStartTime = TimeSpan.Parse(scheduleRow["start_time"].ToString());

                                // Check if the current date is a working day for the employee
                                string currentDay = date.DayOfWeek.ToString();
                                if (workDays.Contains(currentDay))
                                {
                                    // Retrieve attendance records for the current date
                                    string attendanceQuery = @"SELECT time_in, time_in_status 
                                                               FROM tbl_attendance
                                                               WHERE emp_id = @employeeId 
                                                               AND CAST(time_in AS DATE) = @date";
                                    var attendanceParameters = new Dictionary<string, object>
                                    {
                                        { "@employeeId", employeeId },
                                        { "@date", date.ToString("yyyy-MM-dd") }
                                    };

                                    DataTable dtAttendance = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(attendanceQuery, attendanceParameters));

                                    if (dtAttendance.Rows.Count > 0)
                                    {
                                        DataRow attendanceRow = dtAttendance.Rows[0];
                                        DateTime? timeIn = attendanceRow["time_in"] as DateTime?;
                                        string timeInStatus = attendanceRow["time_in_status"].ToString();

                                        if (timeIn.HasValue && timeInStatus == "Late")
                                        {
                                            // Calculate late time
                                            TimeSpan lateTime = timeIn.Value.TimeOfDay - scheduledStartTime;
                                            totalLateTime += lateTime;
                                        }
                                    }
                                }
                            }
                        }

                        // Retrieve the employee's rate per hour
                        string rateQuery = @"SELECT employment_type, tenured_rate, non_tenured_rate
                                             FROM tbl_employee
                                             INNER JOIN tbl_rates ON tbl_employee.account_id = tbl_rates.account_id
                                             WHERE emp_id = @employeeId
                                             AND is_deleted = 0";

                        var rateParameters = new Dictionary<string, object>
                        {
                            { "@employeeId", employeeId }
                        };

                        DataTable dtRate = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(rateQuery, rateParameters));

                        if (dtRate.Rows.Count > 0)
                        {
                            DataRow rateRow = dtRate.Rows[0];
                            decimal ratePerHour = rateRow["employment_type"].ToString() == "Tenured"
                                ? Convert.ToDecimal(rateRow["tenured_rate"])
                                : Convert.ToDecimal(rateRow["non_tenured_rate"]);

                            // Compute deductions for this employee
                            decimal lateTimeHours = Math.Round((decimal)totalLateTime.TotalHours, 2);
                            decimal employeeDeductions = Math.Round(lateTimeHours * ratePerHour, 2);

                            // Accumulate the total deductions
                            totalDeductions += employeeDeductions;
                        }
                    }

                    // Display the total deductions
                    lblTotalDeductions.Text = $"₱{totalDeductions:n2}";
                }
                else
                {
                    MessageBox.Show("No payroll dates found.", "Payroll Dates Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ComputeTotalWages()
        {
            try
            {
                string startDate = string.Empty;
                string endDate = string.Empty;

                // Retrieve the payroll start and end dates
                string query = "SELECT pay_start_date, pay_end_date FROM tbl_payroll WHERE payroll_status = @status";
                var parameters = new Dictionary<string, object>
                {
                    { "@status", "In-Progress" }
                };

                DataTable dtStartDate = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(query, parameters));

                if (dtStartDate.Rows.Count > 0)
                {
                    startDate = dtStartDate.Rows[0]["pay_start_date"].ToString();
                    endDate = dtStartDate.Rows[0]["pay_end_date"].ToString();
                }

                // Check if start and end dates were retrieved
                if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                {
                    DateTime payrollStartDate = DateTime.Parse(startDate);
                    DateTime payrollEndDate = DateTime.Parse(endDate);

                    // Retrieve all employee IDs
                    string getEmployeeIdsQuery = "SELECT emp_id FROM tbl_employee WHERE is_deleted = 0";
                    DataTable dtEmployeeIds = await Task.Run(() => DB_OperationHelperClass.QueryData(getEmployeeIdsQuery));

                    decimal totalWages = 0;

                    // Calculate wages for each employee
                    foreach (DataRow row in dtEmployeeIds.Rows)
                    {
                        string employeeId = row["emp_id"].ToString();
                        decimal totalWorkingHours = 0;

                        // Loop through each date in the payroll period
                        for (DateTime date = payrollStartDate; date <= payrollEndDate; date = date.AddDays(1))
                        {
                            // Retrieve the employee's schedule for the current date
                            string getScheduleQuery = "SELECT start_time, end_time, work_days FROM tbl_schedule WHERE emp_id = @empId";
                            var getScheduleParams = new Dictionary<string, object> { { "@empId", employeeId } };
                            DataTable scheduleTable = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(getScheduleQuery, getScheduleParams));

                            if (scheduleTable.Rows.Count > 0)
                            {
                                DataRow scheduleRow = scheduleTable.Rows[0];
                                string workDays = scheduleRow["work_days"].ToString();
                                TimeSpan scheduledStartTime = TimeSpan.Parse(scheduleRow["start_time"].ToString());
                                TimeSpan scheduledEndTime = TimeSpan.Parse(scheduleRow["end_time"].ToString());

                                // Check if the current date is a working day for the employee
                                string currentDay = date.DayOfWeek.ToString();
                                if (workDays.Contains(currentDay))
                                {
                                    // Retrieve attendance records for the current date
                                    string attendanceQuery = @"SELECT time_in, time_out 
                                                      FROM tbl_attendance
                                                      WHERE emp_id = @employeeId 
                                                      AND CAST(time_in AS DATE) = @date";
                                    var attendanceParameters = new Dictionary<string, object>
                                    {
                                        { "@employeeId", employeeId },
                                        { "@date", date.ToString("yyyy-MM-dd") }
                                    };

                                    DataTable dtAttendance = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(attendanceQuery, attendanceParameters));

                                    if (dtAttendance.Rows.Count > 0)
                                    {
                                        DataRow attendanceRow = dtAttendance.Rows[0];
                                        DateTime? timeIn = attendanceRow["time_in"] as DateTime?;
                                        DateTime? timeOut = attendanceRow["time_out"] as DateTime?;

                                        if (timeIn.HasValue && timeOut.HasValue)
                                        {
                                            // Handle early time-out
                                            DateTime effectiveEndTime = timeOut.Value.TimeOfDay < scheduledEndTime
                                                ? date.Add(timeOut.Value.TimeOfDay) // Early time-out
                                                : date.Add(scheduledEndTime); // Scheduled end time

                                            // Handle late arrival
                                            DateTime effectiveStartTime = timeIn.Value.TimeOfDay < scheduledStartTime
                                                ? date.Add(scheduledStartTime) // Start at scheduled time if early
                                                : date.Add(timeIn.Value.TimeOfDay); // Use actual time-in if late

                                            // Calculate working hours for this record
                                            TimeSpan workingTime = effectiveEndTime - effectiveStartTime;

                                            // Ensure working hours are not negative
                                            if (workingTime.TotalHours < 0)
                                            {
                                                workingTime = TimeSpan.Zero;
                                            }

                                            decimal workingHours = Math.Round((decimal)workingTime.TotalHours, 2);

                                            // Accumulate total working hours
                                            totalWorkingHours += workingHours;
                                        }
                                    }
                                }
                            }
                        }

                        // Retrieve the employee's rate per hour
                        string rateQuery = @"SELECT employment_type, tenured_rate, non_tenured_rate
                                             FROM tbl_employee
                                             INNER JOIN tbl_rates ON tbl_employee.account_id = tbl_rates.account_id
                                             WHERE emp_id = @employeeId
                                             AND is_deleted = 0";

                        var rateParameters = new Dictionary<string, object>
                        {
                            { "@employeeId", employeeId }
                        };

                        DataTable dtRate = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(rateQuery, rateParameters));

                        if (dtRate.Rows.Count > 0)
                        {
                            DataRow rateRow = dtRate.Rows[0];
                            decimal ratePerHour = rateRow["employment_type"].ToString() == "Tenured"
                                ? Convert.ToDecimal(rateRow["tenured_rate"])
                                : Convert.ToDecimal(rateRow["non_tenured_rate"]);

                            // Compute wages for this employee
                            decimal employeeWages = Math.Round(totalWorkingHours * ratePerHour, 2);

                            // Accumulate the total wages
                            totalWages += employeeWages;
                        }
                    }

                    // Display the total wages
                    lblTotalWages.Text = $"₱{totalWages:n2}";
                }
                else
                {
                    MessageBox.Show("No payroll dates found.", "Payroll Dates Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void PopulateActivePayrollList()
        {
            if (isUpdatingActivePayroll) return; // Prevent multiple updates at the same time
            isUpdatingActivePayroll = true;

            // Modify the SQL query to include both "In-Progress" and "Completed" statuses
            string sql = @"SELECT tbl_employee.emp_id, emp_profilePic, f_name, m_name, l_name, tbl_payroll.payroll_id, pay_start_date, pay_end_date, pay_date, tbl_wage.status AS wage_status
                           FROM tbl_employee 
                           INNER JOIN tbl_wage ON tbl_wage.emp_id = tbl_employee.emp_id
                           INNER JOIN tbl_payroll ON tbl_payroll.payroll_id = tbl_wage.payroll_id
                           WHERE is_deleted = 0 AND tbl_payroll.payroll_status = 'In-Progress'
                           ORDER BY emp_id ASC";

            DataTable dt = await Task.Run(() => DB_OperationHelperClass.QueryData(sql));

            try
            {
                if (dt.Rows.Count == 0)
                {
                    lblCurrentPayrollStatus.Text = "Status - No Active Payroll";
                    lblActivePayrollStatus.Text = "Status - No Active Payroll";
                    lblActivePayrollDate.Text = "No Active Payroll Period";
                    lblPayDate.Text = "No Active Pay Date";

                    flowLayoutPanel1.Controls.Clear(); // Clear any existing payroll cards
                    return;
                }

                // Keep track of existing employee IDs to remove obsolete cards later
                var existingEmployeeIds = new HashSet<string>();

                // Loop through the data and either update existing cards or add new ones
                foreach (DataRow row in dt.Rows)
                {
                    string id = row["emp_id"].ToString();
                    string firstName = row["f_name"].ToString();
                    string middleName = row["m_name"].ToString();
                    string lastName = row["l_name"].ToString();
                    string name = string.IsNullOrEmpty(middleName) || middleName == "N/A"
                        ? $"{firstName} {lastName}"
                        : $"{firstName} {middleName[0]}. {lastName}";

                    string imagePath = row["emp_ProfilePic"].ToString();
                    string wageStatus = row["wage_status"].ToString(); // Use the wage status instead of payroll status
                    DateTime startDate = DateTime.Parse(row["pay_start_date"].ToString());
                    DateTime endDate = DateTime.Parse(row["pay_end_date"].ToString());
                    DateTime payDate = DateTime.Parse(row["pay_date"].ToString());

                    string payrollPeriod = $"Period: {startDate:MMM. dd, yyyy} - {endDate:MMM. dd, yyyy}";
                    string paymentDate = $"Pay Date: {payDate:MMM. dd, yyyy}";

                    lblCurrentPayrollStatus.Text = "Status - Active";
                    lblActivePayrollStatus.Text = "Status - Active";
                    lblActivePayrollDate.Text = payrollPeriod;
                    lblPayDate.Text = paymentDate;

                    // Add the employee ID to the set of existing IDs
                    existingEmployeeIds.Add(id);

                    // Check if a card for this employee already exists
                    var existingCard = flowLayoutPanel1.Controls
                        .OfType<SampleEmployeePayrollCard>()
                        .FirstOrDefault(c => c.ID == id);

                    if (existingCard != null)
                    {
                        // Update the existing card's data
                        existingCard.EmployeeName = name;
                        existingCard.Status = wageStatus; // Use the wage status
                        existingCard.PayrollPeriod = payrollPeriod;
                        existingCard.EmployeeProfilePic = await LoadImageAsync(imagePath);

                        // Reset the card to active state if the wage status is not "Completed"
                        if (wageStatus != "Completed")
                        {
                            existingCard.lblTextPendingPayrollSummary.ForeColor = Color.FromArgb(245, 124, 0);
                            existingCard.lblTextPendingPayrollSummary.Text = "Pending Payroll Summary";
                            existingCard.lblTutoringHours.Text = "Tutoring Hours (Cumulative):";
                            existingCard.lblLateTime.Text = "Late Time (Cumulative):";
                            existingCard.lblDeductions.Text = "Deductions (Cumulative):";
                            existingCard.lblNetWage.Text = "Net Wage (Cumulative):";
                            existingCard.btnCutCurrentPayroll.Visible = true;
                            existingCard.btnViewProcessedPayrollDetails.Visible = false;
                        }
                    }
                    else
                    {
                        // Create a new card if it doesn't exist
                        var newCard = new SampleEmployeePayrollCard()
                        {
                            ID = id,
                            EmployeeProfilePic = await LoadImageAsync(imagePath),
                            EmployeeName = name,
                            Status = wageStatus, // Use the wage status
                            PayrollPeriod = payrollPeriod,
                        };

                        if (wageStatus == "Completed")
                        {
                            newCard.lblTextPendingPayrollSummary.ForeColor = Color.ForestGreen;
                            newCard.lblTextPendingPayrollSummary.Text = "Completed Payroll Summary";
                            newCard.lblTutoringHours.Text = "Tutoring Hours (Total):";
                            newCard.lblLateTime.Text = "Late Time (Total):";
                            newCard.lblDeductions.Text = "Deductions (Total):";
                            newCard.lblNetWage.Text = "Net Wage (Total):";
                            newCard.btnCutCurrentPayroll.Visible = false;
                            newCard.btnViewProcessedPayrollDetails.Visible = true;
                        }

                        flowLayoutPanel1.Controls.Add(newCard);
                    }

                    // Compute and display the individual payroll for this employee
                    ComputeIndividualPayroll(id);
                }

                // Remove obsolete cards
                foreach (SampleEmployeePayrollCard card in flowLayoutPanel1.Controls.OfType<SampleEmployeePayrollCard>().ToList())
                {
                    if (!existingEmployeeIds.Contains(card.ID))
                    {
                        flowLayoutPanel1.Controls.Remove(card);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "Error retrieving employee data: ";
                string caption = "Error";
                MessageBox.Show(message + ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isUpdatingActivePayroll = false;
            }
        }

        private async void ComputeIndividualPayroll(string employeeId)
        {
            try
            {
                // Retrieve the payroll start and end dates
                string startDate = string.Empty;
                string endDate = string.Empty;

                string query = "SELECT pay_start_date, pay_end_date FROM tbl_payroll WHERE payroll_status = @status";
                var parameters = new Dictionary<string, object>
                {
                    { "@status", "In-Progress" }
                };

                DataTable dtStartDate = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(query, parameters));

                if (dtStartDate.Rows.Count > 0)
                {
                    startDate = dtStartDate.Rows[0]["pay_start_date"].ToString();
                    endDate = dtStartDate.Rows[0]["pay_end_date"].ToString();
                }

                if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                {
                    DateTime payrollStartDate = DateTime.Parse(startDate);
                    DateTime payrollEndDate = DateTime.Parse(endDate);

                    decimal totalWorkingHours = 0; // Total working hours in decimal format
                    TimeSpan totalLateTime = TimeSpan.Zero;

                    // Loop through each date in the payroll period
                    for (DateTime date = payrollStartDate; date <= payrollEndDate; date = date.AddDays(1))
                    {
                        // Retrieve the employee's schedule for the current date
                        string getScheduleQuery = "SELECT start_time, end_time, work_days FROM tbl_schedule WHERE emp_id = @empId";
                        var getScheduleParams = new Dictionary<string, object> { { "@empId", employeeId } };
                        DataTable scheduleTable = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(getScheduleQuery, getScheduleParams));

                        if (scheduleTable.Rows.Count > 0)
                        {
                            DataRow scheduleRow = scheduleTable.Rows[0];
                            string workDays = scheduleRow["work_days"].ToString();
                            TimeSpan scheduledStartTime = TimeSpan.Parse(scheduleRow["start_time"].ToString());
                            TimeSpan scheduledEndTime = TimeSpan.Parse(scheduleRow["end_time"].ToString());

                            // Check if the current date is a working day for the employee
                            string currentDay = date.DayOfWeek.ToString();
                            if (workDays.Contains(currentDay))
                            {
                                // Retrieve attendance records for the current date
                                string attendanceQuery = @"SELECT time_in, time_out, time_in_status 
                                                           FROM tbl_attendance
                                                           INNER JOIN tbl_employee ON tbl_attendance.emp_id = tbl_employee.emp_id
                                                           WHERE tbl_attendance.emp_id = @employeeId 
                                                           AND CAST(time_in AS DATE) = @date
                                                           AND is_deleted = 0";
                                var attendanceParameters = new Dictionary<string, object>
                                {
                                    { "@employeeId", employeeId },
                                    { "@date", date.ToString("yyyy-MM-dd") }
                                };

                                DataTable dtAttendance = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(attendanceQuery, attendanceParameters));

                                if (dtAttendance.Rows.Count > 0)
                                {
                                    DataRow attendanceRow = dtAttendance.Rows[0];
                                    DateTime? timeIn = attendanceRow["time_in"] as DateTime?;
                                    DateTime? timeOut = attendanceRow["time_out"] as DateTime?;
                                    string timeInStatus = attendanceRow["time_in_status"].ToString();

                                    if (timeIn.HasValue && timeOut.HasValue)
                                    {
                                        // Handle early clock-in and clock-out before scheduled start time
                                        if (timeIn.Value.TimeOfDay < scheduledStartTime && timeOut.Value.TimeOfDay < scheduledStartTime)
                                        {
                                            // If the employee clocks in and out before the scheduled start time, set working hours to zero
                                            totalWorkingHours += 0;
                                        }
                                        else
                                        {
                                            // Handle early time-out
                                            DateTime effectiveEndTime = timeOut.Value.TimeOfDay < scheduledEndTime
                                                ? date.Add(timeOut.Value.TimeOfDay) // Early time-out
                                                : date.Add(scheduledEndTime); // Scheduled end time

                                            // Handle late arrival
                                            DateTime effectiveStartTime = timeInStatus == "Late"
                                                ? date.Add(timeIn.Value.TimeOfDay) // Actual time-in
                                                : date.Add(scheduledStartTime); // Scheduled start time

                                            // Calculate working hours for this record
                                            TimeSpan workingTime = effectiveEndTime - effectiveStartTime;

                                            // Ensure working hours are not negative
                                            if (workingTime.TotalHours < 0)
                                            {
                                                workingTime = TimeSpan.Zero;
                                            }

                                            decimal workingHours = Math.Round((decimal)workingTime.TotalHours, 2); // Round to 2 decimal places

                                            // Accumulate total working hours
                                            totalWorkingHours += workingHours;

                                            // Calculate late time
                                            if (timeInStatus == "Late")
                                            {
                                                TimeSpan lateTime = timeIn.Value.TimeOfDay - scheduledStartTime;
                                                totalLateTime += lateTime;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Retrieve the employee's rate per hour
                    string rateQuery = @"SELECT employment_type, tenured_rate, non_tenured_rate, f_name, m_name, l_name
                                         FROM tbl_employee
                                         INNER JOIN tbl_rates ON tbl_employee.account_id = tbl_rates.account_id
                                         WHERE emp_id = @employeeId
                                         AND is_deleted = 0";

                    var rateParameters = new Dictionary<string, object>
                    {
                        { "@employeeId", employeeId }
                    };

                    DataTable dtRate = DB_OperationHelperClass.ParameterizedQueryData(rateQuery, rateParameters);

                    if (dtRate.Rows.Count > 0)
                    {
                        DataRow rateRow = dtRate.Rows[0];

                        string firstName = rateRow["f_name"].ToString();
                        string middleName = rateRow["m_name"].ToString();
                        string lastName = rateRow["l_name"].ToString();
                        string name = string.IsNullOrEmpty(middleName) || middleName == "N/A"
                            ? $"{firstName} {lastName}"
                            : $"{firstName} {middleName[0]}. {lastName}";

                        decimal ratePerHour = rateRow["employment_type"].ToString() == "Tenured"
                            ? Convert.ToDecimal(rateRow["tenured_rate"])
                            : Convert.ToDecimal(rateRow["non_tenured_rate"]);

                        // Compute deductions
                        decimal lateTimeHours = Math.Round((decimal)totalLateTime.TotalHours, 2); // Round to 2 decimal places
                        decimal totalDeductions = Math.Round(lateTimeHours * ratePerHour, 2); // Round to 2 decimal places

                        // Compute total wages
                        decimal totalWages = Math.Round(totalWorkingHours * ratePerHour, 2); // Round to 2 decimal places

                        // Compute net wages after deductions
                        decimal netWages = Math.Round(totalWages - totalDeductions, 2); // Round to 2 decimal places

                        // Find the existing card for the employee
                        foreach (SampleEmployeePayrollCard card in flowLayoutPanel1.Controls)
                        {
                            if (card.ID == employeeId)
                            {
                                card.EmployeeName = name;
                                card.TutoringHours = $"{totalWorkingHours:F2} hours"; // Working hours in decimal format
                                card.LateTime = $"{totalLateTime.TotalMinutes:F0}m"; // Late time in minutes
                                card.Deductions = $"₱{totalDeductions:n2}"; // Total deductions rounded
                                card.Wage = $"₱{netWages:n2}"; // Net wages after deductions rounded
                                break;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No payroll dates found.", "Payroll Dates Missing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                string message = $"An error occurred: {ex.Message}";
                string caption = "Error";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormEmployeePayrollManagement_Load(object sender, EventArgs e)
        {
            cboSearchEmployeeForActivePayroll.SelectedIndex = 0;
            // Start the timer when the form loads
            timer1.Interval = 5000; // Set the interval to 5 seconds (adjust as needed)
            timer1.Start();

            // Initial population of the active payroll list
            PopulateActivePayrollList();

            ComputeTotalTutoringHours();
            ComputeTotalDeductions();
            ComputeTotalWages();
        }

        private void btnViewEmployeeList_Click(object sender, EventArgs e)
        {
            // Disable both buttons to prevent rapid clicking
            btnViewEmployeeList.Enabled = false;
            btnRefresh.Enabled = false;

            try
            {
                flowLayoutPanel1.Visible = false;
                flowLayoutPanel2.Visible = true;
                flowLayoutPanel2.Dock = DockStyle.Fill;

                PopulateEmployeeList();
            }
            finally
            {
                // Re-enable buttons after operation completes
                btnViewEmployeeList.Enabled = true;
                btnRefresh.Enabled = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            timer1.Start();
            // Disable both buttons to prevent rapid clicking
            btnViewEmployeeList.Enabled = false;
            btnRefresh.Enabled = false;
            flowLayoutPanel1.Controls.Clear();

            try
            {
                flowLayoutPanel2.Visible = false;
                flowLayoutPanel1.Visible = true;
                flowLayoutPanel1.Dock = DockStyle.Fill;
                flowLayoutPanel1.Controls.Clear();

                PopulateActivePayrollList();
            }
            finally
            {
                // Re-enable buttons after operation completes
                btnViewEmployeeList.Enabled = true;
                btnRefresh.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Update the active payroll list on each timer tick
            PopulateActivePayrollList();
            ComputeTotalTutoringHours();
            ComputeTotalDeductions();
            ComputeTotalWages();
        }

        private void FormEmployeePayrollManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }

        private async void btnCutPayroll_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the current payroll details
                string query = "SELECT * FROM tbl_payroll WHERE payroll_status = 'In-Progress'";
                DataTable dtPayroll = await Task.Run(() => DB_OperationHelperClass.QueryData(query));

                if (dtPayroll.Rows.Count == 0)
                {
                    MessageBox.Show("No active payroll found to cut.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DataRow currentPayroll = dtPayroll.Rows[0];

                DateTime payStartDate = DateTime.Parse(currentPayroll["pay_start_date"].ToString());
                DateTime payEndDate = DateTime.Parse(currentPayroll["pay_end_date"].ToString());
                int payrollId = int.Parse(currentPayroll["payroll_id"].ToString());

                // Check if the end date has passed
                if (DateTime.Now < payEndDate)
                {
                    MessageBox.Show("The payroll period has not ended yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Retrieve all employee IDs for the current payroll
                string getEmployeeIdsQuery = "SELECT emp_id FROM tbl_employee WHERE is_deleted = 0";
                DataTable dtEmployeeIds = await Task.Run(() => DB_OperationHelperClass.QueryData(getEmployeeIdsQuery));

                decimal grossPayTotal = 0;
                decimal deductionTotal = 0;
                decimal netPayTotal = 0;
                int totalAttendance = 0;

                // Calculate individual payroll for each employee
                foreach (DataRow row in dtEmployeeIds.Rows)
                {
                    string empId = row["emp_id"].ToString();

                    // Query to retrieve the total attendance for the employee within the payroll period
                    string getAttendanceQuery = @"SELECT COUNT(*) AS EmployeeTotalAttendance
                                                  FROM tbl_attendance
                                                  WHERE emp_id = @empId
                                                  AND CAST(time_in AS DATE) >= @startDate
                                                  AND CAST(time_in AS DATE) <= @endDate";

                    var attendanceParameters = new Dictionary<string, object>
                    {
                        { "@empId", empId },
                        { "@startDate", payStartDate.ToString("yyyy-MM-dd") },
                        { "@endDate", payEndDate.ToString("yyyy-MM-dd") }
                    };

                    DataTable dtAttendance = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(getAttendanceQuery, attendanceParameters));

                    int empTotalAttendance = 0;
                    if (dtAttendance.Rows.Count > 0)
                    {
                        empTotalAttendance = Convert.ToInt32(dtAttendance.Rows[0]["EmployeeTotalAttendance"]);
                    }

                    // Call ComputeIndividualPayroll to calculate the employee's payroll details
                    ComputeIndividualPayroll(empId);

                    // Retrieve the individual payroll details from the UI
                    foreach (SampleEmployeePayrollCard card in flowLayoutPanel1.Controls)
                    {
                        if (card.ID == empId)
                        {
                            // Parse tutoring hours from the card (format: "XX.XX hours")
                            decimal tutoringHours = decimal.Parse(card.TutoringHours.Replace(" hours", ""));

                            // Parse late time from the card (format: "XXm")
                            decimal lateTimeMinutes = decimal.Parse(card.LateTime.Replace("m", ""));
                            TimeSpan lateTime = TimeSpan.FromMinutes((double)lateTimeMinutes);
                            string lateTimeFormatted = lateTime.ToString(@"hh\:mm\:ss");

                            // Parse deductions and net pay from the card
                            decimal deduction = decimal.Parse(card.Deductions.Replace("₱", "").Replace(",", ""));
                            decimal netPay = decimal.Parse(card.Wage.Replace("₱", "").Replace(",", ""));

                            // Compute gross pay as net pay plus deduction
                            decimal grossPay = netPay + deduction;

                            // Accumulate totals for the payroll
                            grossPayTotal += grossPay; // Total gross pay
                            deductionTotal += deduction; // Total deductions
                            netPayTotal += netPay; // Total net pay
                            totalAttendance += empTotalAttendance; // Use actual attendance count

                            // Check if the employee's payroll has already been cut individually
                            string getCustomCutDateQuery = @"SELECT custom_cut_date FROM tbl_wage
                                                             WHERE payroll_id = @payrollId AND emp_id = @empId";
                            var customCutDateParameters = new Dictionary<string, object>
                            {
                                { "@payrollId", payrollId },
                                { "@empId", empId }
                            };

                            DataTable dtCustomCutDate = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(getCustomCutDateQuery, customCutDateParameters));
                            string customCutDate = dtCustomCutDate.Rows.Count > 0 ? dtCustomCutDate.Rows[0]["custom_cut_date"].ToString() : null;

                            // Format customCutDate to include only the date part (yyyy-MM-dd)
                            string formattedCustomCutDate = null;
                            if (!string.IsNullOrEmpty(customCutDate))
                            {
                                DateTime parsedDate;
                                if (DateTime.TryParse(customCutDate, out parsedDate))
                                {
                                    formattedCustomCutDate = parsedDate.ToString("yyyy-MM-dd");
                                }
                            }

                            // Update existing employee payroll details in tbl_wage
                            string updateWageQuery = @"UPDATE tbl_wage
                                                       SET emp_total_attendance = @totalAttendance,
                                                           gross_pay = @grossPay,
                                                           tutoring_hours = @tutoringHours,
                                                           late_time = @lateTime,
                                                           deduction = @deduction,
                                                           net_pay = @netPay,
                                                           custom_cut_date = @customCutDate, -- Retain existing custom_cut_date if already set
                                                           status = 'Completed'
                                                       WHERE payroll_id = @payrollId
                                                         AND emp_id = @empId";

                            var wageParameters = new Dictionary<string, object>
                            {
                                { "@totalAttendance", empTotalAttendance },
                                { "@grossPay", grossPay },
                                { "@tutoringHours", tutoringHours },
                                { "@lateTime", lateTimeFormatted },
                                { "@deduction", deduction },
                                { "@netPay", netPay },
                                { "@customCutDate", string.IsNullOrEmpty(formattedCustomCutDate) ? (object)DBNull.Value : formattedCustomCutDate }, // Corrected line
                                { "@payrollId", payrollId },
                                { "@empId", empId }
                            };

                            await Task.Run(() => DB_OperationHelperClass.ExecuteCRUDSQLQuery(updateWageQuery, wageParameters));
                            break;
                        }
                    }
                }

                // Update the payroll summary, mark it as completed, and set the cut date
                string updatePayrollQuery = @"UPDATE tbl_payroll
                                              SET total_attendance = @totalAttendance,
                                                  gross_pay_total = @grossPayTotal,
                                                  deduction_total = @deductionTotal,
                                                  net_pay_total = @netPayTotal,
                                                  payroll_status = 'Completed',
                                                  cut_date = @cutDate
                                              WHERE payroll_id = @payrollId";

                var payrollParameters = new Dictionary<string, object>
                {
                    { "@totalAttendance", totalAttendance },
                    { "@grossPayTotal", grossPayTotal },
                    { "@deductionTotal", deductionTotal },
                    { "@netPayTotal", netPayTotal },
                    { "@cutDate", DateTime.Now.ToString("yyyy-MM-dd") }, // Current date in the required format
                    { "@payrollId", payrollId }
                };

                await Task.Run(() => DB_OperationHelperClass.ExecuteCRUDSQLQuery(updatePayrollQuery, payrollParameters));

                // Create a new payroll for the next period
                DateTime newPayStartDate = payEndDate.AddDays(1);
                DateTime newPayEndDate = newPayStartDate.AddMonths(1).AddDays(-1);
                DateTime newPayDate = newPayEndDate.AddDays(1);

                string insertNewPayrollQuery = @"INSERT INTO tbl_payroll (pay_start_date, pay_end_date, pay_date, payroll_status, cut_date)
                                                 VALUES (@payStartDate, @payEndDate, @payDate, 'In-Progress', NULL)";

                var newPayrollParameters = new Dictionary<string, object>
                {
                    { "@payStartDate", newPayStartDate.ToString("yyyy-MM-dd") },
                    { "@payEndDate", newPayEndDate.ToString("yyyy-MM-dd") },
                    { "@payDate", newPayDate.ToString("yyyy-MM-dd") }
                };

                // Execute the query to create a new payroll
                await Task.Run(() => DB_OperationHelperClass.ExecuteCRUDSQLQuery(insertNewPayrollQuery, newPayrollParameters));

                // Retrieve the new payroll ID
                string getNewPayrollIdQuery = "SELECT payroll_id FROM tbl_payroll WHERE payroll_status = 'In-Progress'";
                DataTable dtNewPayroll = await Task.Run(() => DB_OperationHelperClass.QueryData(getNewPayrollIdQuery));
                int newPayrollId = int.Parse(dtNewPayroll.Rows[0]["payroll_id"].ToString());

                // Retrieve all employees from the previous payroll and reinsert into tbl_wage for the new payroll
                string getPreviousEmployeesQuery = "SELECT emp_id FROM tbl_wage WHERE payroll_id = @payrollId";
                var previousEmployeesParameters = new Dictionary<string, object>
                {
                    { "@payrollId", payrollId }
                };

                DataTable dtPreviousEmployees = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(getPreviousEmployeesQuery, previousEmployeesParameters));

                foreach (DataRow row in dtPreviousEmployees.Rows)
                {
                    string empId = row["emp_id"].ToString();

                    string insertNewWageQuery = @"INSERT INTO tbl_wage (payroll_id, emp_id, status, is_paid, custom_cut_date)
                                  VALUES (@newPayrollId, @empId, 'In-Progress', NULL, NULL)"; // Set custom_cut_date to NULL for new payroll

                    var newWageParameters = new Dictionary<string, object>
                    {
                        { "@newPayrollId", newPayrollId },
                        { "@empId", empId }
                    };

                    await Task.Run(() => DB_OperationHelperClass.ExecuteCRUDSQLQuery(insertNewWageQuery, newWageParameters));
                }

                MessageBox.Show("Payroll has been successfully cut, employees have been carried over, and a new payroll period has been created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally refresh the UI to reflect the changes
                PopulateActivePayrollList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while cutting payroll: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void txtSearchForActivePayroll_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Enter key is pressed
            if (e.KeyCode == Keys.Enter)
            {
                string query = txtSearchForActivePayroll.Text.Trim();

                // Validate the search criteria
                if (string.IsNullOrEmpty(query))
                {
                    MessageBox.Show("Please enter a search criterion.", "Validation Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // End the method if no search criteria is provided
                }

                // Get the selected search criteria from the combo box
                string searchCriteria = cboSearchEmployeeForActivePayroll.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(searchCriteria))
                {
                    MessageBox.Show("Please select a search criteria.", "Validation Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // End the method if no search criteria is selected
                }

                string sql;
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                switch (searchCriteria)
                {
                    case "ID Number":
                        if (int.TryParse(query, out int empId))
                        {
                            // Prepare the SQL query for ID search
                            sql = @"SELECT tbl_employee.emp_id, emp_profilePic, f_name, m_name, l_name, tbl_payroll.payroll_id, pay_start_date, pay_end_date, pay_date, payroll_status, wage_id
                                    FROM tbl_employee 
                                    INNER JOIN tbl_wage ON tbl_wage.emp_id = tbl_employee.emp_id
                                    INNER JOIN tbl_payroll ON tbl_payroll.payroll_id = tbl_wage.payroll_id
                                    WHERE is_deleted = 0 AND payroll_status = 'In-Progress' AND tbl_employee.emp_id = @empId
                                    ORDER BY emp_id ASC";

                            parameters.Add("@empId", empId); // Use strict equality for employee ID
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid ID number.", "Validation Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // End the method if the query is not a valid ID number
                        }
                        break;

                    case "Employee Name":
                        // Prepare the SQL query for name search
                        sql = @"SELECT tbl_employee.emp_id, emp_profilePic, f_name, m_name, l_name, tbl_payroll.payroll_id, pay_start_date, pay_end_date, pay_date, payroll_status, wage_id
                                FROM tbl_employee 
                                INNER JOIN tbl_wage ON tbl_wage.emp_id = tbl_employee.emp_id
                                INNER JOIN tbl_payroll ON tbl_payroll.payroll_id = tbl_wage.payroll_id
                                WHERE is_deleted = 0 AND payroll_status = 'In-Progress' 
                                AND CONCAT(f_name, ' ', COALESCE(m_name, ''), ' ', l_name) LIKE @query
                                ORDER BY emp_id ASC";

                        parameters.Add("@query", "%" + query + "%"); // Use LIKE for searching names
                        break;

                    default:
                        MessageBox.Show("Invalid search criteria selected.", "Validation Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; // End the method if an invalid search criteria is selected
                }

                // Execute the query and get the data
                DataTable dt = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(sql, parameters));

                // Call the method to populate items based on the search results
                await PopulateActivePayrollList(dt);
            }
        }

        private async Task PopulateActivePayrollList(DataTable dt)
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No active payroll records found.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (DataRow row in dt.Rows)
                {
                    string id = row["emp_id"].ToString();
                    string firstName = row["f_name"].ToString();
                    string middleName = row["m_name"].ToString();
                    string lastName = row["l_name"].ToString();
                    string name = string.IsNullOrEmpty(middleName) || middleName == "N/A"
                        ? $"{firstName} {lastName}"
                        : $"{firstName} {middleName[0]}. {lastName}";

                    string imagePath = row["emp_ProfilePic"].ToString();
                    string payrollStatus = row["payroll_status"].ToString();
                    DateTime startDate = DateTime.Parse(row["pay_start_date"].ToString());
                    DateTime endDate = DateTime.Parse(row["pay_end_date"].ToString());
                    DateTime payDate = DateTime.Parse(row["pay_date"].ToString());

                    string payrollPeriod = $"Period: {startDate:MMM. dd, yyyy} - {endDate:MMM. dd, yyyy}";
                    string paymentDate = $"Pay Date: {payDate:MMM. dd, yyyy}";

                    lblCurrentPayrollStatus.Text = "Status - " + payrollStatus;
                    lblActivePayrollStatus.Text = "Status - " + payrollStatus;
                    lblActivePayrollDate.Text = payrollPeriod;
                    lblPayDate.Text = paymentDate;

                    // Create a new card for the employee
                    SampleEmployeePayrollCard sampleEmployeePayrollCard = new SampleEmployeePayrollCard()
                    {
                        ID = id,
                        EmployeeProfilePic = await LoadImageAsync(imagePath),
                        EmployeeName = name,
                        Status = payrollStatus,
                        PayrollPeriod = payrollPeriod,
                    };

                    flowLayoutPanel1.Controls.Add(sampleEmployeePayrollCard);

                    // Compute and display the individual payroll for this employee
                    ComputeIndividualPayroll(id);
                }
            }
            catch (Exception ex)
            {
                string message = "Error retrieving active payroll data: ";
                string caption = "Error";
                MessageBox.Show(message + ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchForActivePayroll_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            if (string.IsNullOrEmpty(txtSearchForActivePayroll.Text))
            {
                flowLayoutPanel1.Controls.Clear();
                timer1.Start();
                PopulateActivePayrollList();
            }
        }

        private void toggleSwitchViewRecentPayroll_CheckedChanged(object sender, EventArgs e)
        {
            if (toggleSwitchViewRecentPayroll.Checked)
            {
                FormPastPayrollDetails formPastPayrollDetails = new FormPastPayrollDetails();
                formPastPayrollDetails.FormClosed += (s, args) =>
                {
                    toggleSwitchViewRecentPayroll.Checked = false; // Turn off the toggle when the form is closed
                };
                formPastPayrollDetails.ShowDialog();
            }
        }

        private void btnViewProcessedPayrollDetails_Click(object sender, EventArgs e)
        {
           
        }

    }
}