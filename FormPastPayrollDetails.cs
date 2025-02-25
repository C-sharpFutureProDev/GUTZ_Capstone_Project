using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp;
using CsvHelper;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;

namespace GUTZ_Capstone_Project
{
    public partial class FormPastPayrollDetails : Form
    {
        public FormPastPayrollDetails()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnDownLoadSelectedPayrollPeriodReports, "Download Selected Payroll Period Report");
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

        private async void LoadEmployeePayrollDetails(int payrollId)
        {
            try
            {
                flowLayoutPanel2.Controls.Clear();

                string sql = @"SELECT w.emp_id, e.f_name, w.emp_total_attendance, w.gross_pay, w.tutoring_hours, w.deduction, w.net_pay
                               FROM tbl_wage w
                               INNER JOIN tbl_employee e ON w.emp_id = e.emp_id
                               WHERE w.payroll_id = @payrollId";

                var parameters = new Dictionary<string, object>
                {
                    { "@payrollId", payrollId }
                };

                DataTable dt = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(sql, parameters));

                foreach (DataRow row in dt.Rows)
                {
                    // Create a new instance of the SamplePastPayrollDetailsCard user control
                    SamplePastPayrollDetailsCard employeeCard = new SamplePastPayrollDetailsCard
                    {
                        ID = row["emp_id"].ToString(),
                        EmployeeName = row["f_name"].ToString(),
                        TotalAttendance = Convert.ToInt32(row["emp_total_attendance"]),
                        TotalTutoringHours = row["tutoring_hours"].ToString(),
                        TotalGrossPay = ParseDoubleToDecimal(row["gross_pay"].ToString()),
                        TotalDeductions = ParseDoubleToDecimal(row["deduction"].ToString()),
                        TotalNetPay = ParseDoubleToDecimal(row["net_pay"].ToString())
                    };

                    flowLayoutPanel2.Controls.Add(employeeCard);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("An error occurred while loading employee payroll details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper method to parse double values (as string) to decimal
        private decimal ParseDoubleToDecimal(string value)
        {
            if (double.TryParse(value, out double doubleValue))
            {
                return Convert.ToDecimal(doubleValue);
            }
            return 0m;
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
                    string formattedPayrollPeriod = $"{payStartDate:MMMM d, yyyy} - {payEndDate:MMMM d, yyyy}";

                    // Create a new radio button for each payroll period
                    RadioButton rdbPayrollPeriod = new RadioButton
                    {
                        Text = formattedPayrollPeriod,
                        AutoSize = true,
                        Font = new System.Drawing.Font("Arial", 10),
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

        private void RdbPayrollPeriod_Click(object sender, EventArgs e)
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

                    LoadSelectedPayrollPeriodDetails(payStartDate, payEndDate);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("An error occurred while selecting a payroll period: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadSelectedPayrollPeriodDetails(DateTime payStartDate, DateTime payEndDate)
        {
            try
            {
                string sql = @"SELECT payroll_id, total_attendance, gross_pay_total, deduction_total, net_pay_total, payroll_status, cut_date
                               FROM tbl_payroll
                               WHERE pay_start_date = @payStartDate AND pay_end_date = @payEndDate";

                var parameters = new Dictionary<string, object>
                {
                    { "@payStartDate", payStartDate },
                    { "@payEndDate", payEndDate }
                };

                DataTable dt = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(sql, parameters));

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    lblPayrollID.Text = "Payroll ID: " + row["payroll_id"].ToString();
                    lblPayrollCutDate.Text = "  Cut Date: " + Convert.ToDateTime(row["cut_date"]).ToString("MMMM d, yyyy");
                    lblTotalAttendance.Text = row["total_attendance"].ToString();
                    lblPastPayrollStatus.Text = "Payroll Status: " + row["payroll_status"].ToString();
                    lblTotalGrossPay.Text = Convert.ToDecimal(row["gross_pay_total"]).ToString("C");
                    lblTotalDeductions.Text = Convert.ToDecimal(row["deduction_total"]).ToString("C");
                    lblTotalNetPay.Text = Convert.ToDecimal(row["net_pay_total"]).ToString("C");

                    // Get the payroll_id
                    int payrollId = Convert.ToInt32(row["payroll_id"]);

                    // Count employees and sum tutoring hours for the selected payroll period
                    CountEmployeesAndTotalTutoringHours(payrollId);

                    // Load individual employee payroll details
                    LoadEmployeePayrollDetails(payrollId);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("An error occurred while loading payroll details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CountEmployeesAndTotalTutoringHours(int payrollId)
        {
            try
            {
                string sql = @"SELECT COUNT(*) AS total_employees, SUM(tutoring_hours) AS total_tutoring_hours 
                               FROM tbl_wage 
                               WHERE payroll_id = @payrollId";

                var parameters = new Dictionary<string, object>
                {
                    { "@payrollId", payrollId }
                };

                DataTable dt = await Task.Run(() => DB_OperationHelperClass.ParameterizedQueryData(sql, parameters));

                if (dt.Rows.Count > 0)
                {
                    // Get total employees
                    int totalEmployees = Convert.ToInt32(dt.Rows[0]["total_employees"]);
                    lblTotalEmployee.Text = totalEmployees.ToString();

                    // Get total tutoring hours
                    decimal totalTutoringHours = dt.Rows[0]["total_tutoring_hours"] != DBNull.Value
                        ? Convert.ToDecimal(dt.Rows[0]["total_tutoring_hours"])
                        : 0;
                    lblTotalTutoringHours.Text = totalTutoringHours.ToString() + " hrs.";
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("An error occurred while counting employees and summing up tutoring hours: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormPastPayrollDetails_Load(object sender, EventArgs e)
        {
            LoadAllAvailablePastPayrollPeriod();
        }

        private void btnDownLoadSelectedPayrollPeriodReports_Click(object sender, EventArgs e)
        {
            try
            {
                // Find the selected radio button in the flowLayoutPanelPayrollPeriods
                RadioButton selectedRadioButton = null;
                foreach (Control control in flowLayoutPanelPayrollPeriods.Controls)
                {
                    if (control is RadioButton rdb && rdb.Checked)
                    {
                        selectedRadioButton = rdb;
                        break;
                    }
                }

                if (selectedRadioButton == null)
                {
                    MessageBox.Show("Please select a payroll period first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Retrieve the dates from the selected radio button's Tag property
                var dates = (dynamic)selectedRadioButton.Tag;
                DateTime payStartDate = dates.StartDate;
                DateTime payEndDate = dates.EndDate;

                // Fetch the payroll details for the selected period
                DataTable payrollDetails = GetPayrollDetails(payStartDate, payEndDate);

                // Prompt the user to select a save location
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    Title = "Save Payroll Report",
                    FileName = $"Payroll_Report_{payStartDate:yyyy-MM-dd}_to_{payEndDate:yyyy-MM-dd}.pdf"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Generate the PDF and save it to the selected location
                    GeneratePayrollPdf(payrollDetails, saveFileDialog.FileName);

                    MessageBox.Show("Payroll report downloaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while downloading the payroll report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetPayrollDetails(DateTime payStartDate, DateTime payEndDate)
        {
            // Fetch payroll details from the database
            string sql = @"SELECT payroll_id, total_attendance, gross_pay_total, deduction_total, net_pay_total, payroll_status, cut_date
                           FROM tbl_payroll
                           WHERE pay_start_date = @payStartDate AND pay_end_date = @payEndDate";

            var parameters = new Dictionary<string, object>
            {
                { "@payStartDate", payStartDate },
                { "@payEndDate", payEndDate }
            };

            // Execute the query and return the result
            return DB_OperationHelperClass.ParameterizedQueryData(sql, parameters);
        }

        private void GeneratePayrollPdf(DataTable payrollDetails, string filePath)
        {
            try
            {
                // Create a new PDF document
                using (var document = new iTextSharp.text.Document(PageSize.A4, 50, 50, 70, 50))
                {
                    // Create a writer that writes the document to a file
                    using (var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create)))
                    {
                        // Open the document
                        document.Open();

                        // Add header
                        AddHeader(document, writer); // Pass the writer to AddHeader

                        // Add title
                        AddTitle(document, "Payroll Report");

                        // Add payroll summary details
                        if (payrollDetails.Rows.Count > 0)
                        {
                            AddSummaryDetails(document, payrollDetails.Rows[0]);

                            // Add employee details section
                            AddEmployeeDetailsSection(document, payrollDetails.Rows[0]);

                            // Add employee details table
                            AddEmployeeDetailsTable(document);
                        }
                        else
                        {
                            document.Add(new iTextSharp.text.Paragraph("No payroll details found for the selected period.", GetRegularFont()));
                        }

                        // Close the document
                        document.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating PDF: " + ex.Message, ex);
            }
        }

        private void AddHeader(iTextSharp.text.Document document, PdfWriter writer)
        {
            // Create a header table
            var headerTable = new iTextSharp.text.pdf.PdfPTable(1);
            headerTable.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            headerTable.LockedWidth = true;

            // Add company name with larger font
            var companyNameCell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("GUTZ Online Communication Services", GetLargerHeaderFont()));
            companyNameCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            companyNameCell.HorizontalAlignment = Element.ALIGN_LEFT;
            companyNameCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            companyNameCell.Padding = 10;
            headerTable.AddCell(companyNameCell);

            // Add header to document
            document.Add(headerTable);
        }

        private iTextSharp.text.Font GetLargerHeaderFont()
        {
            return new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 24, iTextSharp.text.Font.BOLD);
        }

        private void AddTitle(iTextSharp.text.Document document, string title)
        {
            document.Add(new iTextSharp.text.Paragraph(title, GetTitleFont()));
            document.Add(new iTextSharp.text.Paragraph(" ", GetRegularFont()));
        }

        private void AddSummaryDetails(iTextSharp.text.Document document, DataRow row)
        {
            var summaryTable = new iTextSharp.text.pdf.PdfPTable(2);
            summaryTable.WidthPercentage = 100;
            summaryTable.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            summaryTable.SpacingBefore = 10;

            string payrollPeriod = GetPayrollPeriod();

            AddSummaryRow(summaryTable, "Payroll ID", row["payroll_id"].ToString());
            AddSummaryRow(summaryTable, "Payroll Period", payrollPeriod);
            AddSummaryRow(summaryTable, "Total Attendance", row["total_attendance"].ToString());
            AddSummaryRow(summaryTable, "Payroll Status", row["payroll_status"].ToString());
            AddSummaryRow(summaryTable, "Total Gross Pay", FormatCurrency(Convert.ToDecimal(row["gross_pay_total"])));
            AddSummaryRow(summaryTable, "Total Deductions", FormatCurrency(Convert.ToDecimal(row["deduction_total"])));
            AddSummaryRow(summaryTable, "Total Net Pay", FormatCurrency(Convert.ToDecimal(row["net_pay_total"])));
            AddSummaryRow(summaryTable, "Total Employees", lblTotalEmployee.Text);
            AddSummaryRow(summaryTable, "Total Tutoring Hours", lblTotalTutoringHours.Text);

            document.Add(summaryTable);
            document.Add(new iTextSharp.text.Paragraph(" ", GetRegularFont()));
        }

        private void AddSummaryRow(iTextSharp.text.pdf.PdfPTable table, string label, string value)
        {
            table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(label + ":", GetBoldFont())) { Border = iTextSharp.text.Rectangle.NO_BORDER });
            table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(value, GetRegularFont())) { Border = iTextSharp.text.Rectangle.NO_BORDER });
        }

        // New method to get the payroll period
        private string GetPayrollPeriod()
        {
            // Find the selected radio button in the flowLayoutPanelPayrollPeriods
            RadioButton selectedRadioButton = null;
            foreach (Control control in flowLayoutPanelPayrollPeriods.Controls)
            {
                if (control is RadioButton rdb && rdb.Checked)
                {
                    selectedRadioButton = rdb;
                    break;
                }
            }

            if (selectedRadioButton != null)
            {
                var dates = (dynamic)selectedRadioButton.Tag;
                return $"{dates.StartDate:MMMM d, yyyy} to {dates.EndDate:MMMM d, yyyy}";
            }

            return string.Empty;
        }

        private void AddEmployeeDetailsSection(iTextSharp.text.Document document, DataRow row)
        {
            document.Add(new iTextSharp.text.Paragraph("Payroll Details", GetSectionHeaderFont()));
            document.Add(new iTextSharp.text.Paragraph(" ", GetRegularFont()));
        }

        private void AddEmployeeDetailsTable(iTextSharp.text.Document document)
        {
            var table = new iTextSharp.text.pdf.PdfPTable(7);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 1f, 2f, 1f, 1f, 1f, 1f, 1f });
            table.SpacingBefore = 10;

            // Add table headers (left-aligned as per new requirement)
            AddTableHeaderCell(table, "ID");
            AddTableHeaderCell(table, "Name");
            AddTableHeaderCell(table, "Attendance");
            AddTableHeaderCell(table, "Tutoring Hours");
            AddTableHeaderCell(table, "Gross Pay");
            AddTableHeaderCell(table, "Deductions");
            AddTableHeaderCell(table, "Net Pay");

            // Add employee details from the flowLayoutPanel2
            foreach (Control control in flowLayoutPanel2.Controls)
            {
                if (control is SamplePastPayrollDetailsCard card)
                {
                    table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(card.ID, GetRegularFont())) { HorizontalAlignment = Element.ALIGN_LEFT });
                    table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(card.EmployeeName, GetRegularFont())) { HorizontalAlignment = Element.ALIGN_LEFT });
                    table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(card.TotalAttendance.ToString(), GetRegularFont())) { HorizontalAlignment = Element.ALIGN_LEFT });
                    table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(card.TotalTutoringHours, GetRegularFont())) { HorizontalAlignment = Element.ALIGN_LEFT });
                    table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(FormatCurrency(card.TotalGrossPay), GetRegularFont())) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(FormatCurrency(card.TotalDeductions), GetRegularFont())) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(FormatCurrency(card.TotalNetPay), GetRegularFont())) { HorizontalAlignment = Element.ALIGN_RIGHT });
                }
            }

            // Add the table to the document
            document.Add(table);
        }

        // New method to format currency with Philippine peso symbol
        private string FormatCurrency(decimal amount)
        {
            return amount.ToString("C", new CultureInfo("tl-PH"));
        }

        private void AddTableHeaderCell(iTextSharp.text.pdf.PdfPTable table, string text)
        {
            var cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(text, GetTableHeaderFont()));
            cell.BackgroundColor = new iTextSharp.text.BaseColor(230, 230, 230);
            cell.HorizontalAlignment = Element.ALIGN_LEFT; // Changed to left align
            table.AddCell(cell);
        }

        private iTextSharp.text.Font GetTitleFont()
        {
            return new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD);
        }

        private iTextSharp.text.Font GetSectionHeaderFont()
        {
            return new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD);
        }

        private iTextSharp.text.Font GetBoldFont()
        {
            return new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD);
        }

        private iTextSharp.text.Font GetRegularFont()
        {
            return new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
        }

        private iTextSharp.text.Font GetTableHeaderFont()
        {
            return new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD);
        }
    }
}