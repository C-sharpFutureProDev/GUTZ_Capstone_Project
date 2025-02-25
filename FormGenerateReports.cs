using OfficeOpenXml.Drawing.Style.Effect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private async void LoadAllAvailablePastPayrollPeriod()
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
                        EmployeeProfilePic = Image.FromFile(imagePath),
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

        private void FormGenerateReports_Load(object sender, EventArgs e)
        {
            cboReportType.SelectedIndex = 0;
            LoadAllAvailablePastPayrollPeriod();
        }

        private void LoadAttendanceReport(DateTime payStartDate, DateTime payEndDate, int empID)
        {
            //MessageBox.Show($"Generating Attendance Report for Employee ID {empID}");
            //MessageBox.Show($"Payroll Period: {payStartDate.ToString("yyyy-MM-dd")} to {payEndDate.ToString("yyyy-MM-dd")}");
            // TODO: Implement actual attendance report generation logic here
        }

        private void LoadPayrollReport(DateTime payStartDate, DateTime payEndDate, int empID)
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
            DataTable result = DB_OperationHelperClass.ParameterizedQueryData(sql, parameters);

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

        private void btnGenerateReports_Click(object sender, EventArgs e)
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
                            LoadAttendanceReport(payStartDate, payEndDate, empID);
                        }
                        break;
                    case "Payroll":
                        foreach (int empID in selectedEmployeeIDs)
                        {
                            LoadPayrollReport(payStartDate, payEndDate, empID);
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
    }
}
