﻿using Guna.UI2.WinForms;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project.Forms
{
    public partial class FormEmployeeProfiling : Form
    {
        string retrieveEmployeeDetails = @"SELECT emp_profilePic, tbl_employee.emp_id, 
                                   CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS Fullname, 
                                   agent_code, department_name, 
                                   position_type, DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                                   FROM tbl_employee
                                   INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                                   INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                   WHERE is_deleted = 0";

        private string id;
        public FormEmployeeProfiling()
        {
            InitializeComponent();
            DGVEmployee.AutoGenerateColumns = false;
            LoadData();

            // Customize header and  button cell 
            this.DGVEmployee.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            Column8.CellTemplate.Style.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
            Column9.CellTemplate.Style.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
        }

        // Method:: Display retrieve employee data to the data grid view
        private void LoadData()
        {
            // Retrieve employee data and display to the DataGridView
            try
            {
                DataTable dt = DB_OperationHelperClass.QueryData(retrieveEmployeeDetails);
                if (dt.Rows.Count > 0)
                    DGVEmployee.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving employee data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (DGVEmployee.Rows.Count == 0)
                    MessageBox.Show("No records found.", "No Records",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormEmployeeProfiling_Load(object sender, EventArgs e)
        {
           
        }

        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            using (FormEmployeeEnrollment formEmployeeEnrollment = new FormEmployeeEnrollment(""))
            {
                formEmployeeEnrollment.FormClosed += (s, args) => LoadData();
                formEmployeeEnrollment.ShowDialog(this);
            }
        }

        private void DGVEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the selected row from the DataGridView
            int selectedRowIndex = e.RowIndex;

            // Get the employee ID from the selected row
             id = DGVEmployee.Rows[selectedRowIndex].Cells[2].Value.ToString();

            // Get the selected column index
            int selectedColumnIndex = e.ColumnIndex;

            // Get the column name of the selected column
            string selectedColumnName = DGVEmployee.Columns[selectedColumnIndex].Name;

            switch (selectedColumnName) {
                case "Column8":
                    {
                        // instance of the frmUpdate form, passing the employee ID as a parameter
                        FormEmployeeEnrollment enrollmentForm = new FormEmployeeEnrollment(id);
                        enrollmentForm.ShowDialog(this);
                        break;
                    } //end case Column8
                   
                case "Column9":
                    {
                        // Display a confirmation message
                        DialogResult result = MessageBox.Show("Are you sure you want to delete the record for employee with ID: '" + id + "'?",
                                                              "Confirm Deletion",
                                                              MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // SQL command for soft delete with parameterized query
                            string softDeleteRecord = "UPDATE tbl_employee SET is_deleted = 1, deleted_at = CURRENT_TIMESTAMP WHERE emp_id = @id";
                            var parameters = new Dictionary<string, object>
                            {
                                 { "@id", id }
                            };

                            // Execute SQL Delete Command
                            if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(softDeleteRecord, parameters))
                            {
                                MessageBox.Show("Selected record deleted Successfully.",
                                                "Record Deletion Successful",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);

                                // Remove the row from the DataGridView
                                DGVEmployee.Rows.RemoveAt(selectedRowIndex);
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete selected record.",
                                                "Record Deletion Unsuccessful",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Exclamation);
                            }
                        }
                        break;
                    }// end case Column9
            }
        }
    }
}
