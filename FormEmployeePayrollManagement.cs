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
using System.Windows.Forms;

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

        private async Task<Image> LoadImageAsync(string imagePath)
        {
            SampleEmployeePayrollCard sampleEmployeePayrollCard = new SampleEmployeePayrollCard();
            string defaultImagePath = "C:/GUTZ/Employee_Profil_Picture/GUTZ_Temporary_Profile.jpg";

            return await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
                {
                    MessageBox.Show("No profile picture found.");
                    return sampleEmployeePayrollCard.employeeProfilePicture.Image = Image.FromFile(defaultImagePath);
                }

                try
                {
                    using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        return Image.FromStream(stream);
                    }
                }
                catch (Exception ex)
                {
                    string message = "Error retrieving employee profile picture";
                    string caption = "Error";
                    MessageBox.Show(message + ex.Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return sampleEmployeePayrollCard.employeeProfilePicture.Image = Image.FromFile(defaultImagePath);
                }
            });
        }

        private void ComputeTotalTutoringHours()
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

                DataTable dtStartDate = DB_OperationHelperClass.ParameterizedQueryData(query, parameters);

                if (dtStartDate.Rows.Count > 0)
                {
                    startDate = dtStartDate.Rows[0]["pay_start_date"].ToString();
                    endDate = dtStartDate.Rows[0]["pay_end_date"].ToString();
                }

                // Check if start and end dates were retrieved
                if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                {
                    // Query to calculate total working time in seconds
                    string attendanceQuery = @"SELECT SUM(TIME_TO_SEC(TIMEDIFF(time_out, time_in))) AS TotalSeconds
                                               FROM tbl_attendance
                                               WHERE time_in >= @startDate AND time_out <= @endDate";

                    var attendanceParameters = new Dictionary<string, object>
                    {
                        { "@startDate", DateTime.Parse(startDate) },
                        { "@endDate", DateTime.Parse(endDate) }
                    };

                    DataTable dtAttendance = DB_OperationHelperClass.ParameterizedQueryData(attendanceQuery, attendanceParameters);

                    if (dtAttendance.Rows.Count > 0 && dtAttendance.Rows[0]["TotalSeconds"] != DBNull.Value)
                    {
                        // Get the total seconds
                        long totalSeconds = Convert.ToInt64(dtAttendance.Rows[0]["TotalSeconds"]);

                        // Convert seconds into hours, minutes, and seconds
                        long hours = totalSeconds / 3600; // Total hours
                        long minutes = (totalSeconds % 3600) / 60; // Remaining minutes
                        //long seconds = totalSeconds % 60; // Remaining seconds

                        // Format as HH:MM:SS
                        //string totalWorkingTime = $"{hours:D2}h : {minutes:D2}m : {seconds:D2}s"; // with seconds
                        string totalWorkingTime = $"{hours:D2}h : {minutes:D2}m";

                        lblTotalTutoringHours.Text = totalWorkingTime; // display result
                    }
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

        private void ComputeTotalDeductions()
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

                DataTable dtStartDate = DB_OperationHelperClass.ParameterizedQueryData(query, parameters);

                if (dtStartDate.Rows.Count > 0)
                {
                    startDate = dtStartDate.Rows[0]["pay_start_date"].ToString();
                    endDate = dtStartDate.Rows[0]["pay_end_date"].ToString();
                }

                // Check if start and end dates were retrieved
                if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                {
                    // Updated query to include late_time
                    string deductionQuery = @"SELECT 
                                                tbl_attendance.emp_id, 
                                                employment_type, 
                                                tbl_employee.account_id, 
                                                account_name, 
                                                tenured_rate, 
                                                non_tenured_rate, 
                                                SUM(TIME_TO_SEC(late_time)) / 60.0 AS TotalLateTime 
                                             FROM 
                                                tbl_attendance
                                             INNER JOIN 
                                                tbl_employee ON tbl_attendance.emp_id = tbl_employee.emp_id
                                             INNER JOIN 
                                                tbl_rates ON tbl_employee.account_id = tbl_rates.account_id
                                             INNER JOIN 
                                                tbl_account ON tbl_rates.account_id = tbl_account.account_id
                                             WHERE 
                                                time_in_status = 'Late' 
                                                AND time_in >= @startDate 
                                                AND time_out <= @endDate
                                             GROUP BY 
                                                tbl_attendance.emp_id, 
                                                employment_type, 
                                                tbl_employee.account_id, 
                                                account_name, 
                                                tenured_rate, 
                                                non_tenured_rate";

                    var deductionParameters = new Dictionary<string, object>
                    {
                        { "@startDate", DateTime.Parse(startDate) },
                        { "@endDate", DateTime.Parse(endDate) }
                    };

                    DataTable dtDeductions = DB_OperationHelperClass.ParameterizedQueryData(deductionQuery, deductionParameters);

                    decimal totalDeductions = 0;

                    // Calculate total deductions based on late_time and employee rate
                    foreach (DataRow row in dtDeductions.Rows)
                    {
                        if (row["TotalLateTime"] != DBNull.Value)
                        {
                            decimal lateTimeMinutes = Convert.ToDecimal(row["TotalLateTime"]); // late_time in minutes
                            decimal ratePerHour = row["employment_type"].ToString() == "Tenured"
                                ? Convert.ToDecimal(row["tenured_rate"])
                                : Convert.ToDecimal(row["non_tenured_rate"]); // Use the appropriate rate based on employment_type

                            // Convert late time to hours for calculation
                            decimal lateTimeHours = lateTimeMinutes / 60;

                            // Calculate the deduction for this employee
                            decimal deductionAmount = lateTimeHours * ratePerHour;

                            // Accumulate the total deductions
                            totalDeductions += deductionAmount;
                        }
                    }

                    // Display the total deductions
                    lblTotalDeductions.Text = $"₱{totalDeductions:n2}";
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

        private void ComputeTotalWages()
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

                DataTable dtStartDate = DB_OperationHelperClass.ParameterizedQueryData(query, parameters);

                if (dtStartDate.Rows.Count > 0)
                {
                    startDate = dtStartDate.Rows[0]["pay_start_date"].ToString();
                    endDate = dtStartDate.Rows[0]["pay_end_date"].ToString();
                }

                // Check if start and end dates were retrieved
                if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                {
                    // Query to retrieve attendance records and employee rates for the payroll period
                    string attendanceQuery = @"SELECT 
                                           a.emp_id, 
                                           a.time_in, 
                                           a.time_out, 
                                           e.employment_type, 
                                           r.tenured_rate, 
                                           r.non_tenured_rate 
                                       FROM 
                                           tbl_attendance a
                                       INNER JOIN 
                                           tbl_employee e ON a.emp_id = e.emp_id
                                       INNER JOIN 
                                           tbl_rates r ON e.account_id = r.account_id
                                       WHERE 
                                           a.time_in >= @startDate 
                                           AND a.time_out <= @endDate";

                    var attendanceParameters = new Dictionary<string, object>
                    {
                        { "@startDate", DateTime.Parse(startDate) },
                        { "@endDate", DateTime.Parse(endDate) }
                    };

                    DataTable dtAttendance = DB_OperationHelperClass.ParameterizedQueryData(attendanceQuery, attendanceParameters);

                    decimal totalWages = 0;

                    // Calculate total wages dynamically
                    foreach (DataRow row in dtAttendance.Rows)
                    {
                        DateTime? timeIn = row["time_in"] as DateTime?;
                        DateTime? timeOut = row["time_out"] as DateTime?;
                        if (timeIn.HasValue && timeOut.HasValue)
                        {
                            // Calculate working hours for this record
                            TimeSpan workingTime = timeOut.Value - timeIn.Value;
                            decimal workingHours = (decimal)workingTime.TotalHours;

                            // Determine the rate per hour based on employment type
                            decimal ratePerHour = row["employment_type"].ToString() == "Tenured"
                                ? Convert.ToDecimal(row["tenured_rate"])
                                : Convert.ToDecimal(row["non_tenured_rate"]);

                            // Calculate the wage for this record
                            decimal employeeWage = Math.Round(workingHours * ratePerHour, 2);

                            // Accumulate the total wages
                            totalWages += employeeWage;
                        }
                    }

                    // Display the total wages
                    lblTotalWages.Text = $"₱{totalWages:n2}";
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

        private async void PopulateActivePayrollList()
        {
            if (isUpdatingActivePayroll) return; // Prevent multiple updates at the same time
            isUpdatingActivePayroll = true;

            string sql = @"SELECT tbl_employee.emp_id, emp_profilePic, f_name, m_name, l_name, tbl_payroll.payroll_id, pay_start_date, pay_end_date, pay_date, payroll_status, wage_id
                           FROM tbl_employee 
                           INNER JOIN tbl_wage ON tbl_wage.emp_id = tbl_employee.emp_id
                           INNER JOIN tbl_payroll ON tbl_payroll.payroll_id = tbl_wage.payroll_id
                           WHERE is_deleted = 0 AND payroll_status = 'In-Progress'
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
                        existingCard.Status = payrollStatus;
                        existingCard.PayrollPeriod = payrollPeriod;
                        existingCard.EmployeeProfilePic = await LoadImageAsync(imagePath);
                    }
                    else
                    {
                        // Create a new card if it doesn't exist
                        var newCard = new SampleEmployeePayrollCard()
                        {
                            ID = id,
                            EmployeeProfilePic = await LoadImageAsync(imagePath),
                            EmployeeName = name,
                            Status = payrollStatus,
                            PayrollPeriod = payrollPeriod,
                        };

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

        private void ComputeIndividualPayroll(string employeeId)
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

                DataTable dtStartDate = DB_OperationHelperClass.ParameterizedQueryData(query, parameters);

                if (dtStartDate.Rows.Count > 0)
                {
                    startDate = dtStartDate.Rows[0]["pay_start_date"].ToString();
                    endDate = dtStartDate.Rows[0]["pay_end_date"].ToString();
                }

                if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                {
                    // SQL query to retrieve attendance records for the employee within the payroll period
                    string attendanceQuery = @"SELECT time_in, time_out, time_in_status 
                                               FROM tbl_attendance
                                               WHERE emp_id = @employeeId 
                                               AND time_in >= @startDate 
                                               AND time_out <= @endDate";

                    var attendanceParameters = new Dictionary<string, object>
                    {
                        { "@employeeId", employeeId },
                        { "@startDate", DateTime.Parse(startDate) },
                        { "@endDate", DateTime.Parse(endDate) }
                    };

                    DataTable dtAttendance = DB_OperationHelperClass.ParameterizedQueryData(attendanceQuery, attendanceParameters);

                    TimeSpan totalWorkingTime = TimeSpan.Zero;
                    TimeSpan totalLateTime = TimeSpan.Zero;

                    foreach (DataRow row in dtAttendance.Rows)
                    {
                        DateTime? timeIn = row["time_in"] as DateTime?;
                        DateTime? timeOut = row["time_out"] as DateTime?;
                        string timeInStatus = row["time_in_status"]?.ToString();

                        if (timeIn.HasValue && timeOut.HasValue)
                        {
                            // Calculate working time (time_out - time_in)
                            TimeSpan workingTime = timeOut.Value - timeIn.Value;
                            totalWorkingTime += workingTime;

                            // Calculate late time based on time_in_status
                            if (timeInStatus == "Late")
                            {
                                // Assuming "Late" means the employee was late for the entire duration of their shift.
                                // You can adjust this logic based on your requirements.
                                totalLateTime += workingTime;
                            }
                        }
                    }

                    // Format working hours and late time
                    decimal workingHoursDecimal = (decimal)totalWorkingTime.TotalHours;
                    string formattedLateTime = totalLateTime.TotalMinutes < 60
                        ? $"{totalLateTime.TotalMinutes:F0}m" // Display as minutes if less than 60
                        : $"{totalLateTime.TotalHours:F2}h"; // Display as hours otherwise

                    // Retrieve the employee's rate per hour
                    string rateQuery = @"SELECT employment_type, tenured_rate, non_tenured_rate, f_name, m_name, l_name
                                         FROM tbl_employee
                                         INNER JOIN tbl_rates ON tbl_employee.account_id = tbl_rates.account_id
                                         WHERE emp_id = @employeeId";

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
                        decimal lateTimeHours = (decimal)totalLateTime.TotalHours;
                        decimal totalDeductions = Math.Round(lateTimeHours * ratePerHour, 2); // Round to 2 decimal places

                        // Compute total wages
                        decimal totalWages = Math.Round(workingHoursDecimal * ratePerHour, 2); // Round to 2 decimal places

                        // Compute net wages after deductions
                        decimal netWages = Math.Round(totalWages - totalDeductions, 2); // Round to 2 decimal places

                        // Find the existing card for the employee
                        foreach (SampleEmployeePayrollCard card in flowLayoutPanel1.Controls)
                        {
                            if (card.ID == employeeId)
                            {
                                card.EmployeeName = name;
                                card.TutoringHours = $"{Math.Round(workingHoursDecimal, 2):F2}h"; // Working hours rounded to 2 decimal places
                                card.LateTime = formattedLateTime; // Late time with proper format (minutes or hours)
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
            // Start the timer when the form loads
            timer1.Interval = 5000; // Set the interval to 5 seconds (adjust as needed)
            timer1.Start();

            ComputeTotalTutoringHours();
            ComputeTotalDeductions();
            ComputeTotalWages();

            // Initial population of the active payroll list
            PopulateActivePayrollList();
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
            // Disable both buttons to prevent rapid clicking
            btnViewEmployeeList.Enabled = false;
            btnRefresh.Enabled = false;

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
            ComputeTotalTutoringHours();
            ComputeTotalDeductions();
            ComputeTotalWages();
            PopulateActivePayrollList();
        }

        private void FormEmployeePayrollManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }
    }
}