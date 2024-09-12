using GUTZ_Capstone_Project.Forms;
using MySql.Data.MySqlClient;
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
    public partial class FormEmployee : Form
    {
        string retrieveEmployeeDetails = @"SELECT emp_profilePic, tbl_employee.emp_id, 
                                   CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS FullName, 
                                   agent_code, tbl_employee.department_id, department_name, 
                                   position_type, DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                                   FROM tbl_employee
                                   INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                                   INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                   WHERE is_deleted = 0
                                   ORDER BY emp_id ASC";

        string id = "";

        public FormEmployee()
        {
            InitializeComponent();
            this.DGVEmployee.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
            DGVEmployee.Paint += DGVEmployee_Paint;
            DGVEmployee.Columns["Column2"].DefaultCellStyle.Padding = new Padding(2, 0, 0, 0);
            DGVEmployee.Columns["Column3"].DefaultCellStyle.Padding = new Padding(1, 0, 0, 0);
            DGVEmployee.Columns["Column4"].DefaultCellStyle.Padding = new Padding(2, 0, 0, 0);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            cboSearch.SelectedIndex = 0;
            cboFilter.SelectedIndex = 0;
            cboSort.SelectedIndex = 0;
            LoadData();
        }

        private void LoadData()
        {
            DGVEmployee.AutoGenerateColumns = false;

            try
            {
                DataTable dt = DB_OperationHelperClass.QueryData(retrieveEmployeeDetails);
                if (dt.Rows.Count > 0)
                {
                    DGVEmployee.Rows.Clear(); // Clear any existing rows

                    foreach (DataRow row in dt.Rows)
                    {
                        string image_path = row["emp_profilePic"].ToString();
                        string full_name = row["FullName"].ToString();
                        int emp_id = int.Parse(row["emp_id"].ToString());
                        string agent_code = row["agent_code"].ToString();
                        string dept = row["department_name"].ToString();
                        string job_title = row["position_type"].ToString();
                        //DateTime hired_date = DateTime.Parse(row["HiredDate"].ToString());
                        DGVEmployee.Rows.Add(System.Drawing.Image.FromFile(image_path), full_name, emp_id, agent_code, dept, job_title, "Active"
                            /*hired_date.ToString("MMMM d, yyyy")*/);
                    }
                }
                else
                {
                    MessageBox.Show("No records found.", "No Records",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving employee data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGVEmployee_Paint(object sender, PaintEventArgs e)
        {
            // Define the border color and thickness
            Color borderColor = Color.FromArgb(204, 204, 204); // Change to your desired color
            int borderThickness = 1; // Change to your desired thickness

            // Draw the border
            e.Graphics.DrawRectangle(new Pen(borderColor, borderThickness),
                new Rectangle(0, 0, DGVEmployee.Width - borderThickness, DGVEmployee.Height - borderThickness));
        }

        private void btnAddNewEmployee_Click_1(object sender, EventArgs e)
        {
            FormAddNewEmployee formAddNewEmployee = new FormAddNewEmployee("");
            formAddNewEmployee.ShowDialog();
        }

        private void DGVEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the selected row from the DataGridView
            int selectedRowIndex = e.RowIndex;

            // Get the employee ID from the selected row
            id = DGVEmployee.Rows[selectedRowIndex].Cells[2].Value.ToString();

            panelEmployeeProfile.Visible = true;
        }
    }
}
