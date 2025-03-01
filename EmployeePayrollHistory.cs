using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    public partial class EmployeePayrollHistory : UserControl
    {
        string _id_ = string.Empty;
        private FormEmployeePayrollManagement _employeePayrollManagement;

        public EmployeePayrollHistory(string id_, FormEmployeePayrollManagement employeePayrollManagement)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(id_))
            {
                _id_ = id_;
            }

            _employeePayrollManagement = employeePayrollManagement;
        }

        private async void EmployeePayrollHistory_Load(object sender, EventArgs e)
        {
            await LoadEmployeeDataAsync();
            await LoadEmployeePastPayrollHistoryDetailsAsync();
        }

        private async Task LoadEmployeeDataAsync()
        {
            try
            {
                string employeeSql = @"SELECT 
                                            emp_ProfilePic, 
                                            CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS FullName, 
                                            work_days, 
                                            start_time, 
                                            end_time, 
                                            position_desc, 
                                            start_date, 
                                            tbl_account.account_name, 
                                            employment_type, 
                                            tenured_rate, 
                                            non_tenured_rate
                                        FROM 
                                            tbl_employee
                                        INNER JOIN 
                                            tbl_account ON tbl_employee.account_id = tbl_account.account_id
                                        INNER JOIN 
                                            tbl_rates ON tbl_rates.account_id = tbl_account.account_id
                                        INNER JOIN 
                                            tbl_schedule ON tbl_employee.emp_id = tbl_schedule.emp_id
                                        INNER JOIN 
                                            tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                        WHERE 
                                            tbl_employee.emp_id = @empId";

                var paramID = new Dictionary<string, object> { { "@empId", _id_ } };

                DataTable employeeDt = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(employeeSql, paramID));

                if (employeeDt.Rows.Count > 0)
                {
                    // Load employee profile picture and basic information
                    string image_path = employeeDt.Rows[0]["emp_ProfilePic"].ToString();
                    employeeProfilePicture.Image = await LoadImageAsync(image_path);
                    lblEmployeeName.Text = employeeDt.Rows[0]["FullName"].ToString();
                    lblEmployeeJobRole.Text = employeeDt.Rows[0]["position_desc"].ToString();

                    // Get account name and format work days
                    string accountName = employeeDt.Rows[0]["account_name"].ToString();
                    lblRateName.Text = accountName;

                    string workDays = employeeDt.Rows[0]["work_days"]?.ToString() ?? "N/A";
                    var workDaysArray = workDays.Split(',').Select(day => day.Trim().Substring(0, 1).ToUpper());
                    string formattedWorkDays = string.Join(", ", workDaysArray);

                    // Format start_time and end_time to 12-hour format
                    DateTime startTime = DateTime.Parse(employeeDt.Rows[0]["start_time"].ToString());
                    DateTime endTime = DateTime.Parse(employeeDt.Rows[0]["end_time"].ToString());

                    string formattedStartTime = startTime.ToString("hh:mm tt");
                    string formattedEndTime = endTime.ToString("hh:mm tt");

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

                    lblRequiredTutoringHours.Text = requiredTutoringHours;

                    // Calculate the rate per hour based on employment type
                    decimal ratePerHour = employeeDt.Rows[0]["employment_type"].ToString() == "Tenured"
                        ? Convert.ToDecimal(employeeDt.Rows[0]["tenured_rate"])
                        : Convert.ToDecimal(employeeDt.Rows[0]["non_tenured_rate"]);

                    lblRatePerHour.Text = ratePerHour.ToString("C");

                    // Query for payroll data
                    string payrollSql = @"SELECT SUM(w.gross_pay) AS total_gross_pay,
                                                 SUM(w.deduction) AS total_deductions,
                                                 SUM(w.net_pay) AS total_net_pay,
                                                 SUM(w.tutoring_hours) AS total_tutoring_hours,
                                                 COUNT(DISTINCT CONCAT(p.pay_start_date, '-', p.pay_end_date)) AS total_completed_payroll_periods
                                                 FROM tbl_payroll p
                                                 INNER JOIN tbl_wage w ON p.payroll_id = w.payroll_id
                                                 WHERE w.emp_id = @empId 
                                                 AND p.payroll_status = 'Completed'
                                                 AND p.pay_start_date IS NOT NULL
                                                 AND p.pay_end_date IS NOT NULL";

                    var payrollParams = new Dictionary<string, object> { { "@empId", _id_ } };

                    DataTable payrollDt = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(payrollSql, payrollParams));

                    if (payrollDt.Rows.Count > 0)
                    {
                        lblTotalGrossPay.Text = "₱" + decimal.Parse(payrollDt.Rows[0]["total_gross_pay"].ToString()).ToString("N2");
                        lblTotalDeductions.Text = "₱" + decimal.Parse(payrollDt.Rows[0]["total_deductions"].ToString()).ToString("N2");
                        lblTotalNetpay.Text = "₱" + decimal.Parse(payrollDt.Rows[0]["total_net_pay"].ToString()).ToString("N2");
                        lblTotalTutoringHours.Text = payrollDt.Rows[0]["total_tutoring_hours"].ToString() + "hrs";
                        lblTotalPayrollPeriod.Text = payrollDt.Rows[0]["total_completed_payroll_periods"].ToString();
                    }
                    else
                    {
                        // Handle case where no payroll records are found
                        lblTotalGrossPay.Text = "₱0.00";
                        lblTotalDeductions.Text = "₱0.00";
                        lblTotalNetpay.Text = "₱0.00";
                        lblTotalTutoringHours.Text = "0";
                        lblTotalPayrollPeriod.Text = "0";
                    }
                }
                else
                {
                    MessageBox.Show("No employee records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading employee payroll data.: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadEmployeePastPayrollHistoryDetailsAsync()
        {
            try
            {
                string sql = @"SELECT 
                                    tbl_employee.emp_id, 
                                    f_name, 
                                    m_name, 
                                    l_name, 
                                    tbl_payroll.payroll_id, 
                                    wage_id, 
                                    pay_start_date, 
                                    pay_end_date, 
                                    custom_cut_date, 
                                    cut_date, 
                                    account_name, 
                                    employment_type, 
                                    tutoring_hours, 
                                    gross_pay, 
                                    deduction, 
                                    net_pay,
                                    tbl_payroll.payroll_status
                                FROM 
                                    tbl_employee
                                INNER JOIN 
                                    tbl_account ON tbl_employee.account_id = tbl_account.account_id
                                INNER JOIN 
                                    tbl_wage ON tbl_employee.emp_id = tbl_wage.emp_id
                                INNER JOIN 
                                    tbl_payroll ON tbl_wage.payroll_id = tbl_payroll.payroll_id
                                WHERE 
                                    tbl_employee.emp_id = @empId 
                                    AND tbl_payroll.payroll_status = 'Completed';";

                var paramID = new Dictionary<string, object> { { "@empId", _id_ } };

                DataTable dt = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(sql, paramID));

                flowLayoutPanel1.Controls.Clear();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        // Format employee name
                        string firstName = row["f_name"].ToString();
                        string middleName = row["m_name"].ToString();
                        string lastName = row["l_name"].ToString();

                        string formattedName = middleName != "N/A" && !string.IsNullOrEmpty(middleName)
                            ? $"{firstName} {middleName[0]}. {lastName}"
                            : $"{firstName} {lastName}";

                        // Format dates
                        string payStartDate = Convert.ToDateTime(row["pay_start_date"]).ToShortDateString();
                        string payEndDate = Convert.ToDateTime(row["pay_end_date"]).ToShortDateString();
                        string cutDate = Convert.ToDateTime(row["cut_date"]).ToShortDateString();

                        // Handle Hours Worked using ternary operator
                        string hoursWorked = Convert.ToDecimal(row["tutoring_hours"]) == 0.00m
                            ? "0h"
                            : $"{row["tutoring_hours"]}hrs";

                        // Create payroll history card
                        SampleEmployeePayrollHistoryDetailsCard sampleEmployeePayrollHistoryDetailsCard = new SampleEmployeePayrollHistoryDetailsCard
                        {
                            EmployeeName = $"Name: {formattedName}",
                            ID = $"Emp. ID: {row["emp_id"]}",
                            Account = $"Rate: {row["account_name"]} - {row["employment_type"]}",
                            PayrollId = $"Payroll ID: {row["payroll_id"]}",
                            PayrollPeriod = $"Period: {payStartDate} - {payEndDate}",
                            WageId = $"Wage ID: {row["wage_id"]}",
                            CutDate = $"Cut Date: {cutDate}",
                            PayrollStatus = $"Status: {row["payroll_status"]}",
                            HoursWorked = $"{hoursWorked}",
                            GrossPay = string.Format("₱{0:N2}", Convert.ToDecimal(row["gross_pay"])),
                            Deductions = string.Format("₱{0:N2}", Convert.ToDecimal(row["deduction"])),
                            NetPay = string.Format("₱{0:N2}", Convert.ToDecimal(row["net_pay"]))
                        };

                        // Add the card to the container
                        flowLayoutPanel1.Controls.Add(sampleEmployeePayrollHistoryDetailsCard);
                    }
                }
                else
                {
                    MessageBox.Show($"No payroll history found for employee with ID: {_id_}.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading employee past payroll history details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<System.Drawing.Image> LoadImageAsync(string imagePath)
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
                        return System.Drawing.Image.FromStream(stream);
                    }
                }
                catch
                {
                    return null;
                }
            });
        }

        private async void btnDownloadPayrollHistoryRecords_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"SELECT 
                                    tbl_employee.emp_id, 
                                    f_name, 
                                    m_name, 
                                    l_name, 
                                    tbl_payroll.payroll_id, 
                                    wage_id, 
                                    pay_start_date, 
                                    pay_end_date, 
                                    custom_cut_date, 
                                    cut_date, 
                                    account_name, 
                                    employment_type, 
                                    tutoring_hours, 
                                    gross_pay, 
                                    deduction, 
                                    net_pay,
                                    tbl_payroll.payroll_status
                                FROM 
                                    tbl_employee
                                INNER JOIN 
                                    tbl_account ON tbl_employee.account_id = tbl_account.account_id
                                INNER JOIN 
                                    tbl_wage ON tbl_employee.emp_id = tbl_wage.emp_id
                                INNER JOIN 
                                    tbl_payroll ON tbl_wage.payroll_id = tbl_payroll.payroll_id
                                WHERE 
                                    tbl_employee.emp_id = @empId 
                                    AND tbl_payroll.payroll_status = 'Completed';";

                var paramID = new Dictionary<string, object> { { "@empId", _id_ } };

                DataTable dt = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(sql, paramID));

                if (dt.Rows.Count > 0)
                {
                    // Show Save File Dialog
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                        saveFileDialog.Title = "Save Payroll History PDF";

                        // Default file name based on emp_id
                        string defaultFileName = $"Payroll_History_{_id_}.pdf";
                        saveFileDialog.FileName = defaultFileName;

                        // Show the dialog and check if the user clicked OK
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string directoryPath = Path.GetDirectoryName(saveFileDialog.FileName); // Get the directory for saving

                            foreach (DataRow row in dt.Rows)
                            {
                                // Create a unique file name for each PDF based on payroll_id
                                string payrollId = row["payroll_id"].ToString();
                                string filePath = Path.Combine(directoryPath, $"Payroll_History_{_id_}_{payrollId}.pdf");

                                // Create a PDF for each payroll history record
                                CreatePayrollHistoryPdf(row, filePath);
                            }

                            MessageBox.Show($"Payroll history for employee with ID: {_id_}, downloaded successfully", "Success", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"No payroll history found for employee with ID: {_id_}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while downloading payroll history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreatePayrollHistoryPdf(DataRow row, string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (var document = new Document(PageSize.A4, 50, 50, 50, 50))
            using (var writer = PdfWriter.GetInstance(document, fs))
            {
                document.Open();

                AddHeader(document);  // Add header and title only once per report

                // Create the table and add it to the document
                var table = CreatePayrollHistoryTable(row);
                document.Add(table);

                document.Close();
            }
        }

        private PdfPTable CreatePayrollHistoryTable(DataRow row)
        {
            var table = new PdfPTable(2) { WidthPercentage = 100, SpacingBefore = 10, DefaultCell = { Border = PdfPCell.BOX } };
            table.SetWidths(new float[] { 1f, 2f }); // Adjust the column widths

            // Employee Information Section
            table.AddCell(CreateCell("Employee Information", GetBoldFont(), 2, Element.ALIGN_LEFT, false));
            table.AddCell(CreateCell("Employee ID:", GetBoldFont(), 1, Element.ALIGN_LEFT, false));
            table.AddCell(CreateCell(row["emp_id"].ToString(), GetRegularFont(), 1, Element.ALIGN_LEFT, false));
            table.AddCell(CreateCell("Name:", GetBoldFont(), 1, Element.ALIGN_LEFT, false));
            table.AddCell(CreateCell(FormatEmployeeName(row), GetRegularFont(), 1, Element.ALIGN_LEFT, false));

            // Payroll Details Section
            table.AddCell(CreateCell("Payroll Details", GetBoldFont(), 2, Element.ALIGN_LEFT, false));
            AddPayrollDetailRow(table, "Payroll ID:", row["payroll_id"].ToString());
            AddPayrollDetailRow(table, "Wage ID:", row["wage_id"].ToString());

            // Format dates to show only the date without time
            string payStartDate = Convert.ToDateTime(row["pay_start_date"]).ToShortDateString();
            string payEndDate = Convert.ToDateTime(row["pay_end_date"]).ToShortDateString();
            AddPayrollDetailRow(table, "Pay Period:", $"{payStartDate} - {payEndDate}");

            AddPayrollDetailRow(table, "Cut Date:", Convert.ToDateTime(row["cut_date"]).ToShortDateString());

            // Account and Employment Information
            table.AddCell(CreateCell("Rate and Employment", GetBoldFont(), 2, Element.ALIGN_LEFT, false));
            AddPayrollDetailRow(table, "Rate:", row["account_name"].ToString());
            AddPayrollDetailRow(table, "Employment Type:", row["employment_type"].ToString());

            // Work and Pay Information
            table.AddCell(CreateCell("Work and Pay Information", GetBoldFont(), 2, Element.ALIGN_LEFT, false));
            AddPayrollDetailRow(table, "Hours Worked:", FormatHoursWorked(row));
            AddPayrollDetailRow(table, "Gross Pay:", $"₱{Convert.ToDecimal(row["gross_pay"]):N2}");
            AddPayrollDetailRow(table, "Deductions:", $"₱{Convert.ToDecimal(row["deduction"]):N2}");
            AddPayrollDetailRow(table, "Net Pay:", $"₱{Convert.ToDecimal(row["net_pay"]):N2}");

            // Payroll Status
            table.AddCell(CreateCell("Payroll Status", GetBoldFont(), 2, Element.ALIGN_LEFT, false));
            AddPayrollDetailRow(table, "Status:", row["payroll_status"].ToString());

            return table;
        }

        private void AddPayrollDetailRow(PdfPTable table, string label, string value)
        {
            table.AddCell(CreateCell(label, GetBoldFont(), 1, Element.ALIGN_LEFT, false));
            table.AddCell(CreateCell(value, GetRegularFont(), 1, Element.ALIGN_LEFT, false));
        }

        private void AddHeader(Document document)
        {
            var headerTable = new PdfPTable(1) { WidthPercentage = 100 };
            headerTable.AddCell(CreateCell("Payroll History Report", GetHeaderFont(), 1, Element.ALIGN_CENTER, false));
            document.Add(headerTable);
        }

        private void AddTitle(Document document, string title)
        {
            var titleParagraph = new Paragraph(title, GetTitleFont()) { Alignment = Element.ALIGN_CENTER, SpacingAfter = 20 };
            document.Add(titleParagraph);
        }

        private PdfPCell CreateCell(string text, iTextSharp.text.Font font, int colspan, int alignment, bool isGray)
        {
            var cell = new PdfPCell(new Phrase(text, font))
            {
                Colspan = colspan,
                HorizontalAlignment = alignment,
                Border = PdfPCell.BOX, // Set border for Excel-like appearance
                Padding = 5
            };

            if (isGray)
            {
                cell.BackgroundColor = new BaseColor(240, 240, 240);
            }

            return cell;
        }

        private iTextSharp.text.Font GetHeaderFont()
        {
            return FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14f, BaseColor.DARK_GRAY);
        }

        private iTextSharp.text.Font GetTitleFont()
        {
            return FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12f, BaseColor.BLACK);
        }

        private iTextSharp.text.Font GetBoldFont()
        {
            return FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10f, BaseColor.BLACK);
        }

        private iTextSharp.text.Font GetRegularFont()
        {
            return FontFactory.GetFont(FontFactory.HELVETICA, 10f, BaseColor.BLACK);
        }

        private string FormatEmployeeName(DataRow row)
        {
            string firstName = row["f_name"].ToString();
            string middleName = row["m_name"].ToString();
            string lastName = row["l_name"].ToString();

            return middleName != "N/A" && !string.IsNullOrEmpty(middleName)
                ? $"{firstName} {middleName[0]}. {lastName}"
                : $"{firstName} {lastName}";
        }

        private string FormatHoursWorked(DataRow row)
        {
            decimal hours = Convert.ToDecimal(row["tutoring_hours"]);
            return hours == 0 ? "0h" : $"{hours}hrs";
        }

        private void btnBackToPayrollForm_Click(object sender, EventArgs e)
        {
            if (_employeePayrollManagement != null)
            {
                // Hide the current user control
                this.Visible = false;
                _employeePayrollManagement.flowLayoutPanel3.Visible = false;
                _employeePayrollManagement.flowLayoutPanel1.Visible = false;
                _employeePayrollManagement.panelPayrollDetails.Visible = true;
                _employeePayrollManagement.flowLayoutPanel2.Visible = true;
                _employeePayrollManagement.flowLayoutPanel2.Dock = DockStyle.Fill;

                // Simulate the button click on the main form
                _employeePayrollManagement.SimulateViewEmployeeListClick();
            }
        }
    }
}

