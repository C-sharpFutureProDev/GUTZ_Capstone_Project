using OfficeOpenXml.Drawing.Style.Effect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;

namespace GUTZ_Capstone_Project
{
    public partial class FormGenerateReports : Form
    {
        private HashSet<int> previouslySelectedEmployees = new HashSet<int>();

        public FormGenerateReports()
        {
            InitializeComponent();
            chkSelectAllEmployee.CheckedChanged += chkSelectAllEmployee_CheckedChanged;
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

        private async Task LoadAllAvailablePastPayrollPeriod()
        {
            try
            {
                string sql = @"SELECT pay_start_date, pay_end_date FROM tbl_payroll WHERE payroll_status = 'Completed'";
                DataTable dt = await Task.Run(() => DB_OperationHelperClass.QueryData(sql));

                flowLayoutPanelPayrollPeriods.Controls.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    DateTime payStartDate = Convert.ToDateTime(row["pay_start_date"]);
                    DateTime payEndDate = Convert.ToDateTime(row["pay_end_date"]);
                    string formattedPayrollPeriod = $"{payStartDate:MMM. d, yyyy} - {payEndDate:MMM. d, yyyy}";

                    // Create a new radio button for each payroll period
                    RadioButton rdbPayrollPeriod = new RadioButton
                    {
                        Text = formattedPayrollPeriod,
                        AutoSize = true,
                        Font = new System.Drawing.Font("Arial", 9),
                        Tag = new { StartDate = payStartDate, EndDate = payEndDate }, // Store dates in the Tag property
                        AutoCheck = false // Disable automatic checking
                    };

                    // Add event handler for checking this radio button
                    rdbPayrollPeriod.Click += RdbPayrollPeriod_Click;

                    flowLayoutPanelPayrollPeriods.Controls.Add(rdbPayrollPeriod);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("An error occurred while loading payroll periods: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void RdbPayrollPeriod_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is RadioButton radioButton)
                {
                    // Uncheck all other radio buttons
                    foreach (Control control in flowLayoutPanelPayrollPeriods.Controls)
                    {
                        if (control is RadioButton rb && rb != radioButton)
                        {
                            rb.Checked = false;
                        }
                    }

                    // Check the clicked radio button
                    radioButton.Checked = true;

                    // Retrieve the dates from the Tag property
                    var dates = (dynamic)radioButton.Tag;
                    DateTime payStartDate = dates.StartDate;
                    DateTime payEndDate = dates.EndDate;

                    // Load employees for the selected payroll period
                    await LoadEmployeesForPayrollPeriod(payStartDate, payEndDate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while selecting a payroll period: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadEmployeesForPayrollPeriod(DateTime payStartDate, DateTime payEndDate)
        {
            try
            {
                string sql = @"SELECT DISTINCT e.emp_id, e.f_name, e.m_name, e.l_name, e.emp_ProfilePic
                               FROM tbl_employee e
                               INNER JOIN tbl_wage w ON e.emp_id = w.emp_id
                               INNER JOIN tbl_payroll p ON w.payroll_id = p.payroll_id
                               WHERE p.pay_start_date = @PayStartDate AND p.pay_end_date = @PayEndDate AND is_deleted = 0
                               ORDER BY e.f_name";

                var parameters = new Dictionary<string, object>
                {
                    { "@PayStartDate", payStartDate },
                    { "@PayEndDate", payEndDate }
                };

                DataTable dt = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(sql, parameters));

                // Clear the existing controls
                flowLayoutPanelEmployeeListForReports.Controls.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    string firstName = row["f_name"].ToString();
                    string lastName = row["l_name"].ToString();
                    string middleName = row["m_name"].ToString();
                    string fullName = string.IsNullOrEmpty(middleName) || middleName.Equals("N/A", StringComparison.OrdinalIgnoreCase)
                        ? $"{firstName} {lastName}"
                        : $"{firstName} {middleName} {lastName}";

                    string imagePath = row["emp_ProfilePic"].ToString();
                    int empID = Convert.ToInt32(row["emp_id"]);

                    SampleEmployeeListCardForReport sampleEmployeeListCardForReport = new SampleEmployeeListCardForReport()
                    {
                        EmployeeName = fullName,
                        EmployeeProfilePic = await LoadImageAsync(imagePath),
                        EmployeeID = empID,
                        IsChecked = previouslySelectedEmployees.Contains(empID) // Set IsChecked based on previously selected employees
                    };

                    // Add an event handler for the checkbox
                    sampleEmployeeListCardForReport.CheckboxChanged += SampleEmployeeListCardForReport_CheckboxChanged;

                    flowLayoutPanelEmployeeListForReports.Controls.Add(sampleEmployeeListCardForReport);
                }

                UpdateSelectedEmployeeCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading employees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<System.Drawing.Image> LoadImageAsync(string imagePath)
        {
            return await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
                {
                    MessageBox.Show("No profile picture found.");
                    return null;
                }

                try
                {
                    using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        return System.Drawing.Image.FromStream(stream);
                    }
                }
                catch
                {
                    MessageBox.Show("No profile picture found.");
                    return null;
                }
            });
        }

        private void SampleEmployeeListCardForReport_CheckboxChanged(object sender, EventArgs e)
        {
            if (sender is SampleEmployeeListCardForReport card)
            {
                if (card.IsChecked)
                {
                    previouslySelectedEmployees.Add(card.EmployeeID);
                }
                else
                {
                    previouslySelectedEmployees.Remove(card.EmployeeID);
                    flowLayoutPanelReportDetails.Controls.Clear();
                }
            }
            UpdateSelectedEmployeeCount();
        }

        private async void FormGenerateReports_Load(object sender, EventArgs e)
        {
            cboReportType.SelectedIndex = 0;
            await LoadAllAvailablePastPayrollPeriod();
        }

        private async Task LoadAttendanceReport(DateTime payStartDate, DateTime payEndDate, int empID)
        {
            // Get total working days
            int totalWorkingDays = GetTotalWorkingDays(empID, payStartDate, payEndDate);

            // Get total leave days
            int totalLeaveDays = GetTotalLeaveDays(empID, payStartDate, payEndDate);

            string sql = @"SELECT 
                                tbl_employee.emp_id, 
                                f_name, 
                                m_name, 
                                l_name, 
                                tbl_schedule.schedule_id,
                                start_time, 
                                end_time, 
                                pay_start_date, 
                                pay_end_date, 
                                payroll_status, 
                                work_days, 
                                emp_total_attendance,
                                SUM(CASE WHEN tbl_attendance.time_in_status = 'On Time' THEN 1 ELSE 0 END) AS TotalOnTime,
                                SUM(CASE WHEN tbl_attendance.time_in_status = 'Late' THEN 1 ELSE 0 END) AS TotalLate
                            FROM 
                                tbl_employee
                            INNER JOIN 
                                tbl_schedule ON tbl_employee.emp_id = tbl_schedule.emp_id
                            INNER JOIN 
                                tbl_wage ON tbl_employee.emp_id = tbl_wage.emp_id
                            INNER JOIN 
                                tbl_payroll ON tbl_wage.payroll_id = tbl_payroll.payroll_id
                            LEFT JOIN 
                                tbl_attendance ON tbl_employee.emp_id = tbl_attendance.emp_id 
                                AND DATE(tbl_attendance.time_in) BETWEEN tbl_payroll.pay_start_date AND tbl_payroll.pay_end_date
                            WHERE 
                                tbl_payroll.pay_start_date >= @payStartDate 
                                AND tbl_payroll.pay_end_date <= @payEndDate
                                AND tbl_employee.emp_id = @empID
                            GROUP BY 
                                tbl_employee.emp_id, 
                                f_name, 
                                m_name, 
                                l_name, 
                                tbl_schedule.schedule_id, 
                                start_time, 
                                end_time, 
                                pay_start_date, 
                                pay_end_date, 
                                payroll_status, 
                                work_days, 
                                emp_total_attendance";

            // Prepare the parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@payStartDate", payStartDate },
                { "@payEndDate", payEndDate },
                { "@empID", empID }
            };

            // Execute the query and get the results
            DataTable result = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(sql, parameters));

            // Process the result
            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];

                // Format work_days to display first letter of each day
                string[] days = row["work_days"].ToString().Split(',');
                string formattedWorkDays = string.Join(",", days.Select(day => day.Trim()[0]));

                // Format start_time and end_time to 12-hour format
                DateTime startTime = DateTime.Parse(row["start_time"].ToString());
                DateTime endTime = DateTime.Parse(row["end_time"].ToString());
                string formattedStartTime = startTime.ToString("hh:mm tt");
                string formattedEndTime = endTime.ToString("hh:mm tt");

                // Calculate total absent days
                int totalPresentDays = Convert.ToInt32(row["emp_total_attendance"]);
                int totalAbsentDays = totalWorkingDays - totalPresentDays;

                // Calculate Required Tutoring Hours
                TimeSpan tutoringDuration = endTime - startTime;
                string requiredTutoringHours;

                if (tutoringDuration.TotalMinutes > 0)
                {
                    requiredTutoringHours = $"{(int)tutoringDuration.TotalHours} hour{(tutoringDuration.TotalHours == 1 ? "" : "s")}";

                    if (tutoringDuration.Minutes > 0)
                    {
                        requiredTutoringHours += $" {tutoringDuration.Minutes} minute{(tutoringDuration.Minutes == 1 ? "" : "s")}";
                    }
                }
                else
                {
                    requiredTutoringHours = "0 hours"; // In case of zero duration
                }

                // Create the attendance report card
                SampleAttendanceReportsDetailsCard card = new SampleAttendanceReportsDetailsCard()
                {
                    EmployeeName = $"Name: {row["f_name"]} {(row["m_name"].ToString() == "N/A" ? "" : row["m_name"] + " ")}{row["l_name"]}",
                    ID = $"Emp. ID: {row["emp_id"]}",
                    AttendancePeriod = $"Date Range: {payStartDate.ToShortDateString()} - {payEndDate.ToShortDateString()}",
                    RequiredTutoringHours = $"Required Tutoring Hours/Day: {requiredTutoringHours}",
                    ScheduleID = $"Schedule ID: {row["schedule_id"]}",
                    WorkDays = $"Work Days: {formattedWorkDays}",
                    StartTime = $"Start Time: {formattedStartTime}",
                    EndTime = $"End Time: {formattedEndTime}",
                    AttendancePeriodStatus = $"Status: {row["payroll_status"]}",
                    TotalWorkingDays = $"{totalWorkingDays}", // Display the total working days
                    TotalPresentDays = $"{totalPresentDays}",
                    TotalDaysOnLeave = $"{totalLeaveDays}",
                    TotalDaysLate = $"{row["TotalLate"]}", // New property for total late days
                    TotalDaysAbsent = $"{totalAbsentDays}", // Add the total absent days
                    TotalDaysOnTime = $"{row["TotalOnTime"]}", // New property for total on-time days
                };

                // Add the card to the report details panel
                flowLayoutPanelReportDetails.Controls.Add(card);
            }
            else
            {
                // Handle the case where no records were found
                MessageBox.Show($"No attendance data found for employee ID {empID} in the specified period.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private int GetTotalWorkingDays(int empID, DateTime payStartDate, DateTime payEndDate)
        {
            string sql = @"SELECT COUNT(*) AS TotalWorkingDays
                            FROM (
                                SELECT DATE_ADD(@payStartDate, INTERVAL t1.n + t2.n * 10 + t3.n * 100 DAY) AS working_date
                                FROM (SELECT 0 n UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9) t1,
                                     (SELECT 0 n UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9) t2,
                                     (SELECT 0 n UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9) t3
                            ) AS date_range
                            JOIN tbl_schedule s ON FIND_IN_SET(DAYNAME(date_range.working_date), s.work_days) > 0
                            WHERE s.emp_id = @empID
                              AND date_range.working_date BETWEEN @payStartDate AND @payEndDate";

            // Prepare the parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@empID", empID },
                { "@payStartDate", payStartDate },
                { "@payEndDate", payEndDate }
            };

            // Execute the query and get the result
            DataTable result = DB_OperationHelperClass.ParameterizedQueryData(sql, parameters);

            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["TotalWorkingDays"]);
            }

            return 0; // Return 0 if no records found
        }

        private int GetTotalLeaveDays(int empID, DateTime payStartDate, DateTime payEndDate)
        {
            string sql = @"SELECT SUM(CASE 
                                         WHEN leave_status = 'Completed' THEN DATEDIFF(end_date, start_date) + 1
                                         WHEN leave_status = 'Active' AND start_date <= @payEndDate THEN 
                                             CASE 
                                                 WHEN end_date <= @payEndDate THEN DATEDIFF(end_date, start_date) + 1
                                                 ELSE DATEDIFF(@payEndDate, start_date) + 1
                                             END
                                         ELSE 0 
                                       END) AS TotalLeaveDays
                            FROM tbl_leave
                            WHERE emp_id = @empID
                              AND (
                                (leave_status = 'Completed' AND end_date >= @payStartDate AND end_date <= @payEndDate)
                                OR 
                                (leave_status = 'Active' AND start_date <= @payEndDate AND end_date >= @payStartDate)
                              )";

            // Prepare the parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@empID", empID },
                { "@payStartDate", payStartDate },
                { "@payEndDate", payEndDate }
            };

            // Execute the query and get the result
            DataTable result = DB_OperationHelperClass.ParameterizedQueryData(sql, parameters);

            if (result.Rows.Count > 0 && result.Rows[0]["TotalLeaveDays"] != DBNull.Value)
            {
                return Convert.ToInt32(result.Rows[0]["TotalLeaveDays"]);
            }

            return 0; // Return 0 if no records found or if TotalLeaveDays is null
        }

        private async Task LoadPayrollReport(DateTime payStartDate, DateTime payEndDate, int empID)
        {
            // Prepare the SQL query
            string sql = @"SELECT 
                                tbl_employee.emp_id, 
                                f_name, 
                                COALESCE(m_name, 'N/A') AS m_name, 
                                l_name, 
                                tbl_payroll.payroll_id, 
                                tbl_payroll.payroll_status,
                                wage_id, 
                                account_name, 
                                employment_type, 
                                tenured_rate, 
                                non_tenured_rate,
                                tbl_payroll.cut_date,
                                tbl_wage.custom_cut_date,
                                tbl_wage.emp_total_attendance,
                                tbl_wage.tutoring_hours,
                                tbl_wage.late_time,
                                tbl_wage.gross_pay,
                                tbl_wage.deduction,
                                tbl_wage.net_pay
                            FROM 
                                tbl_employee
                            INNER JOIN 
                                tbl_account ON tbl_employee.account_id = tbl_account.account_id
                            INNER JOIN 
                                tbl_wage ON tbl_employee.emp_id = tbl_wage.emp_id
                            INNER JOIN 
                                tbl_payroll ON tbl_wage.payroll_id = tbl_payroll.payroll_id
                            INNER JOIN 
                                tbl_rates ON tbl_rates.account_id = tbl_account.account_id
                            WHERE 
                                tbl_employee.emp_id = @empID
                                AND tbl_payroll.pay_start_date >= @payStartDate
                                AND tbl_payroll.pay_end_date <= @payEndDate";

            // Prepare the parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@empID", empID },
                { "@payStartDate", payStartDate },
                { "@payEndDate", payEndDate }
            };

            // Execute the query
            DataTable result = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(sql, parameters));

            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];

                // Calculate the rate per hour based on employment type
                decimal ratePerHour = row["employment_type"].ToString() == "Tenured"
                    ? Convert.ToDecimal(row["tenured_rate"])
                    : Convert.ToDecimal(row["non_tenured_rate"]);

                // Determine the cut date
                DateTime cutDate = row["custom_cut_date"] != DBNull.Value && !string.IsNullOrEmpty(row["custom_cut_date"].ToString())
                    ? Convert.ToDateTime(row["custom_cut_date"])
                    : Convert.ToDateTime(row["cut_date"]);

                // Convert late_time to TimeSpan and then to decimal (total hours)
                TimeSpan lateTimeSpan = TimeSpan.Parse(row["late_time"].ToString());
                decimal lateTime = (decimal)lateTimeSpan.TotalHours; // Convert to hours

                // Create a new SamplePayrollReportsDetailsCard
                SamplePayrollReportsDetailsCard card = new SamplePayrollReportsDetailsCard
                {
                    EmployeeName = $"Name: {row["f_name"]} {(row["m_name"].ToString() == "N/A" ? "" : row["m_name"] + " ")}{row["l_name"]}",
                    ID = $"Emp. ID: {row["emp_id"]}",
                    PayrollID = $"Payroll ID: {row["payroll_id"]}",
                    WageID = $"Wage ID: {row["wage_id"]}",
                    AccountName = $"Rate: {row["account_name"]}",
                    RatePerHour = $"Rate/Hour: {row["employment_type"]}, {ratePerHour:C}",
                    PayrollPeriod = $"Payroll Period: {payStartDate.ToShortDateString()} - {payEndDate.ToShortDateString()}",
                    PayrollCutDate = $"Cut Date: {cutDate.ToShortDateString()}",
                    PayrollStatus = $"Status: {row["payroll_status"]}",
                    TotalAttendance = row["emp_total_attendance"].ToString(),
                    TotalTutoringHours = row["tutoring_hours"].ToString() + "hrs.",
                    TotalLateTime = lateTime.ToString("0.00") + "hrs.", // Format to 2 decimal places
                    TotalGrossPay = Convert.ToDecimal(row["gross_pay"]).ToString("C"),
                    TotalDeductions = Convert.ToDecimal(row["deduction"]).ToString("C"),
                    TotalNetPay = Convert.ToDecimal(row["net_pay"]).ToString("C")
                };

                // Add the card to the report details panel
                flowLayoutPanelReportDetails.Controls.Add(card);
            }
            else
            {
                MessageBox.Show($"No payroll data found for employee ID {empID} in the specified period.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateSelectedEmployeeCount()
        {
            int selectedCount = previouslySelectedEmployees.Count;
            if (lblSelectedEmployeeCount.InvokeRequired)
            {
                lblSelectedEmployeeCount.Invoke(new MethodInvoker(() => lblSelectedEmployeeCount.Text = $"Selected Employees: {selectedCount}"));
            }
            else
            {
                lblSelectedEmployeeCount.Text = $"Selected Employees: {selectedCount}";
            }
        }

        private async void btnGenerateReports_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateSelectedEmployeeCount();

                string selectedReportType = cboReportType.SelectedItem?.ToString() ?? string.Empty;

                if (string.IsNullOrEmpty(selectedReportType))
                {
                    MessageBox.Show("Please select a report type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var selectedRadioButton = flowLayoutPanelPayrollPeriods.Controls
                    .OfType<RadioButton>()
                    .FirstOrDefault(rb => rb.Checked);

                if (selectedRadioButton == null)
                {
                    MessageBox.Show("Please select a payroll period.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var dates = (dynamic)selectedRadioButton.Tag;
                DateTime payStartDate = dates.StartDate;
                DateTime payEndDate = dates.EndDate;

                List<int> selectedEmployeeIDs = new List<int>();
                foreach (SampleEmployeeListCardForReport card in flowLayoutPanelEmployeeListForReports.Controls)
                {
                    if (card.IsChecked)
                    {
                        selectedEmployeeIDs.Add(card.EmployeeID);
                    }
                }

                if (selectedEmployeeIDs.Count == 0)
                {
                    MessageBox.Show("Please select at least one employee.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Clear existing controls in the report details panel
                flowLayoutPanelReportDetails.Controls.Clear();

                switch (selectedReportType)
                {
                    case "Attendance":
                        foreach (int empID in selectedEmployeeIDs)
                        {
                            await LoadAttendanceReport(payStartDate, payEndDate, empID);
                        }
                        break;
                    case "Payroll":
                        foreach (int empID in selectedEmployeeIDs)
                        {
                            await LoadPayrollReport(payStartDate, payEndDate, empID);
                        }
                        break;
                    default:
                        MessageBox.Show("Invalid report type selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                if (flowLayoutPanelReportDetails.Controls.Count > 0)
                {
                    MessageBox.Show("Reports generated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No reports were generated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while generating the report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkSelectAllEmployee_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = chkSelectAllEmployee.Checked;

            previouslySelectedEmployees.Clear();
            flowLayoutPanelReportDetails.Controls.Clear();

            foreach (SampleEmployeeListCardForReport card in flowLayoutPanelEmployeeListForReports.Controls.OfType<SampleEmployeeListCardForReport>())
            {
                card.IsChecked = isChecked;
                if (isChecked)
                {
                    previouslySelectedEmployees.Add(card.EmployeeID);
                }
            }

            UpdateSelectedEmployeeCount();
        }

        private void btnDownloadGeneratedReports_Click(object sender, EventArgs e)
        {
            try
            {
                if (flowLayoutPanelReportDetails.Controls.Count == 0)
                {
                    MessageBox.Show("No reports to download. Please generate reports first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    Title = "Save Generated Reports",
                    FileName = $"Generated_Reports_{DateTime.Now:yyyy-MM-dd_HHmmss}.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    int reportCount = 0;
                    var reportTypes = new List<string>();

                    using (var fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                    {
                        var document = new Document(PageSize.A4, 50, 50, 70, 50);
                        var writer = PdfWriter.GetInstance(document, fileStream);

                        document.Open();

                        AddHeader(document);
                        AddTitle(document, "Generated Reports");

                        foreach (Control control in flowLayoutPanelReportDetails.Controls)
                        {
                            reportCount++;
                            PdfPTable reportTable = null;

                            if (control is SampleAttendanceReportsDetailsCard attendanceCard)
                            {
                                reportTable = CreateAttendanceReportTable(attendanceCard);
                                reportTypes.Add("Attendance Report");
                            }
                            else if (control is SamplePayrollReportsDetailsCard payrollCard)
                            {
                                reportTable = CreatePayrollReportTable(payrollCard);
                                reportTypes.Add("Payroll Report");
                            }

                            if (reportTable != null)
                            {
                                document.Add(reportTable);
                                document.Add(new Paragraph(" ")); // Add some space after each report
                            }

                            if (reportCount < flowLayoutPanelReportDetails.Controls.Count)
                            {
                                document.NewPage();
                            }
                        }

                        document.Close();
                        writer.Close();
                    }

                    // Customize the success message based on report types
                    string successMessage = reportTypes.Contains("Attendance Report") && reportTypes.Contains("Payroll Report")
                        ? "Generated Attendance and Payroll reports downloaded successfully!"
                        : reportTypes.Contains("Attendance Report")
                            ? "Generated Attendance reports downloaded successfully!"
                            : reportTypes.Contains("Payroll Report")
                                ? "Generated Payroll reports downloaded successfully!"
                                : "No specific report types found.";

                    MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while downloading the generated reports: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private PdfPTable CreateAttendanceReportTable(SampleAttendanceReportsDetailsCard card)
        {
            var table = new PdfPTable(2) { WidthPercentage = 100, SpacingBefore = 10 };

            // Title Row
            table.AddCell(CreateCell("Attendance Details", GetTitleFont(), 2, Element.ALIGN_CENTER, true));

            // Employee Information Section
            table.AddCell(CreateCell("Employee Information", GetBoldFont(), 2, Element.ALIGN_LEFT, false));
            AddDetailRow(table, "Employee Name", card.EmployeeName);
            AddDetailRow(table, "ID", card.ID);

            // Attendance Records Section
            table.AddCell(CreateCell("Attendance Records", GetBoldFont(), 2, Element.ALIGN_LEFT, false));
            AddDetailRow(table, "Attendance Period", card.AttendancePeriod);
            AddDetailRow(table, "Schedule ID", card.ScheduleID);
            AddDetailRow(table, "Work Days", card.WorkDays);
            AddDetailRow(table, "Start Time", card.StartTime);
            AddDetailRow(table, "End Time", card.EndTime);

            // Summary Section
            table.AddCell(CreateCell("Attendance Summary", GetBoldFont(), 2, Element.ALIGN_LEFT, false));
            AddDetailRow(table, "Attendance Period Status", card.AttendancePeriodStatus);
            AddDetailRow(table, "Total Working Days", card.TotalWorkingDays);
            AddDetailRow(table, "Total Present Days", card.TotalPresentDays);
            AddDetailRow(table, "Total Days on Leave", card.TotalDaysOnLeave);
            AddDetailRow(table, "Total Days Late", card.TotalDaysLate);
            AddDetailRow(table, "Total Days Absent", card.TotalDaysAbsent);
            AddDetailRow(table, "Total Days On Time", card.TotalDaysOnTime);

            return table;
        }

        private PdfPTable CreatePayrollReportTable(SamplePayrollReportsDetailsCard card)
        {
            var table = new PdfPTable(2) { WidthPercentage = 100, SpacingBefore = 10 };

            // Title Row
            table.AddCell(CreateCell("Payroll Details", GetTitleFont(), 2, Element.ALIGN_CENTER, true));

            // Employee Information Section
            table.AddCell(CreateCell("Employee Information", GetBoldFont(), 2, Element.ALIGN_LEFT, false));
            AddDetailRow(table, "Employee Name", card.EmployeeName);
            AddDetailRow(table, "ID", card.ID);

            // Payroll Information Section
            table.AddCell(CreateCell("Payroll Information", GetBoldFont(), 2, Element.ALIGN_LEFT, false));
            AddDetailRow(table, "Payroll ID", card.PayrollID);
            AddDetailRow(table, "Wage ID", card.WageID);
            AddDetailRow(table, "Account Name", card.AccountName);
            AddDetailRow(table, "Rate/Hour", card.RatePerHour.ToString()); // Format as currency
            AddDetailRow(table, "Payroll Period", card.PayrollPeriod);
            AddDetailRow(table, "Cut Date", card.PayrollCutDate);
            AddDetailRow(table, "Payroll Status", card.PayrollStatus);

            // Attendance Summary Section
            table.AddCell(CreateCell("Attendance Summary", GetBoldFont(), 2, Element.ALIGN_LEFT, false));
            AddDetailRow(table, "Total Attendance", card.TotalAttendance.ToString());
            AddDetailRow(table, "Total Tutoring Hours", card.TotalTutoringHours.ToString());
            AddDetailRow(table, "Total Late Time", card.TotalLateTime.ToString());

            // Payment Details Section
            table.AddCell(CreateCell("Payment Details", GetBoldFont(), 2, Element.ALIGN_LEFT, false));
            AddDetailRow(table, "Total Gross Pay", card.TotalGrossPay.ToString()); // Format as currency
            AddDetailRow(table, "Total Deductions", card.TotalDeductions.ToString()); // Format as currency
            AddDetailRow(table, "Total Net Pay", card.TotalNetPay.ToString()); // Format as currency

            return table;
        }

        private void AddDetailRow(PdfPTable table, string label, string value)
        {
            table.AddCell(CreateCell(label + ":", GetBoldFont(), 1, Element.ALIGN_LEFT, false));
            table.AddCell(CreateCell(value, GetRegularFont(), 1, Element.ALIGN_LEFT, false));
        }

        private PdfPCell CreateCell(string text, iTextSharp.text.Font font, int colspan, int alignment, bool isHeader)
        {
            var cell = new PdfPCell(new Phrase(text, font))
            {
                Colspan = colspan,
                HorizontalAlignment = alignment,
                Padding = 5,
                Border = iTextSharp.text.Rectangle.BOX // Solid borders for all cells
            };
            if (isHeader)
            {
                cell.BackgroundColor = new BaseColor(230, 230, 230); // Light gray background for headers
            }
            return cell;
        }

        private void AddHeader(Document document)
        {
            var headerTable = new PdfPTable(1)
            {
                TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin,
                LockedWidth = true
            };

            var companyNameCell = new PdfPCell(new Phrase("GUTZ Online Communication Services", GetLargerHeaderFont()))
            {
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 10
            };
            headerTable.AddCell(companyNameCell);
            document.Add(headerTable);
        }

        private void AddTitle(Document document, string title)
        {
            document.Add(new Paragraph(title, GetTitleFont()));
            document.Add(new Paragraph(" ", GetRegularFont()));
        }

        private iTextSharp.text.Font GetLargerHeaderFont() => new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 24, iTextSharp.text.Font.BOLD);
        private iTextSharp.text.Font GetTitleFont() => new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD);
        private iTextSharp.text.Font GetBoldFont() => new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD);
        private iTextSharp.text.Font GetRegularFont() => new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
    }
}
