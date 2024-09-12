using GUTZ_Capstone_Project.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    public partial class EmployeeList : Form
    {
        int id;

        public EmployeeList()
        {
            InitializeComponent();
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set default selected index for ComboBoxes
            cboSearch.SelectedIndex = 0;
            cboSort.SelectedIndex = 0;
            cboFilter.SelectedIndex = 0;
            PopulateItems();
        }

        private void PopulateItems()
        {
            string sql = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, position_type, hired_date,
                                   CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS FullName, 
                                   agent_code, tbl_employee.department_id, department_name, 
                                   position_type, DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                                   FROM tbl_employee
                                   INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                                   INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                   WHERE is_deleted = 0
                                   ORDER BY emp_id ASC";

            try
            {
                DataTable dt = DB_OperationHelperClass.QueryData(sql);
                flowLayoutPanel1.Controls.Clear(); // Clear previous items

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No employee records found.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (DataRow row in dt.Rows)
                {
                    id = int.Parse(row["emp_id"].ToString());
                    string name = row["FullName"].ToString();
                    string imagePath = row["emp_ProfilePic"].ToString();
                    string jobRole = row["position_type"].ToString();
                    string email = row["email"].ToString();
                    string contactNo = row["phone"].ToString();
                    string hired_date = row["hired_date"].ToString();
                    string agentCode = row["agent_code"].ToString();

                    EmployeeListCard employeeControl = new EmployeeListCard
                    {
                        EmployeeName = name,
                        ID = id.ToString(),
                        EmployeeProfilePic = Image.FromFile(imagePath),
                        JobRole = jobRole,
                        Email = email,
                        Contact = contactNo,
                        JoinDate = DateTime.TryParse(hired_date, out DateTime date) ? date.ToString("dd MMM, yyyy") : string.Empty,
                        AgentCode = agentCode
                    };

                    employeeControl.EmployeeDeleted += (s, args) => PopulateItems();

                    flowLayoutPanel1.Controls.Add(employeeControl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving employee data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            using (FormAddNewEmployee formAddNewEmployee = new FormAddNewEmployee(""))
            {
                formAddNewEmployee.FormClosed += (s, args) => PopulateItems();
                formAddNewEmployee.ShowDialog(this);
            }
        }

        private void cboSearch_DropDown(object sender, EventArgs e)
        {
            // Check if "SEARCH BY" exists before removing
            txtSearch.Clear();
            PopulateItems();
            if (cboSearch.Items.Contains("SEARCH BY"))
            {
                cboSearch.Items.Remove("SEARCH BY");
                cboSearch.SelectedIndex = 0; // Set to the first item
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchText = txtSearch.Text.Trim();

                // Validate search input
                if (string.IsNullOrEmpty(searchText))
                {
                    MessageBox.Show("Please enter a valid search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    string query = "";

                    switch (cboSearch.SelectedIndex)
                    {
                        case 0: // Employee ID
                            query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, position_type, hired_date,
                               CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS FullName, 
                               agent_code, tbl_employee.department_id, department_name, 
                               position_type, DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                               FROM tbl_employee
                               INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                               INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                               WHERE is_deleted = 0 AND emp_id = @empId";
                            break;

                        case 1: // Employee Name
                            query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, position_type, hired_date,
                               CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS FullName, 
                               agent_code, tbl_employee.department_id, department_name, 
                               position_type, DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                               FROM tbl_employee
                               INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                               INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                               WHERE is_deleted = 0 AND CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) LIKE @empName";
                            break;

                        case 2: // Employee Agent Code
                            query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, position_type, hired_date,
                               CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS FullName, 
                               agent_code, tbl_employee.department_id, department_name, 
                               position_type, DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                               FROM tbl_employee
                               INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                               INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                               WHERE is_deleted = 0 AND agent_code = @agentCode";
                            break;

                        default:
                            MessageBox.Show("Please select a valid search criterion.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                    }

                    // Create a parameter dictionary based on the selected search criteria
                    var parameters = new Dictionary<string, object>();

                    switch (cboSearch.SelectedIndex)
                    {
                        case 0: // Employee ID
                            parameters.Add("@empId", searchText);
                            break;
                        case 1: // Employee Name
                            parameters.Add("@empName", "%" + searchText + "%");
                            break;
                        case 2: // Employee Agent Code
                            parameters.Add("@agentCode", searchText);
                            break;
                    }

                    // Execute the query
                    DataTable dt = DB_OperationHelperClass.ParameterizedQueryData(query, parameters);

                    flowLayoutPanel1.Controls.Clear();

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        id = int.Parse(row["emp_id"].ToString());
                        string name = row["FullName"].ToString();
                        string imagePath = row["emp_ProfilePic"].ToString();
                        string jobRole = row["position_type"].ToString();
                        string email = row["email"].ToString();
                        string contactNo = row["phone"].ToString();
                        string hiredDate = row["hired_date"].ToString();
                        string agentCode = row["agent_code"].ToString();

                        EmployeeListCard employeeControl = new EmployeeListCard
                        {
                            EmployeeName = name,
                            ID = id.ToString(),
                            EmployeeProfilePic = Image.FromFile(imagePath),
                            JobRole = jobRole,
                            Email = email,
                            Contact = contactNo,
                            JoinDate = DateTime.TryParse(hiredDate, out DateTime date) ? date.ToString("dd MMM, yyyy") : string.Empty,
                            AgentCode = agentCode
                        };

                        flowLayoutPanel1.Controls.Add(employeeControl);
                    }
                    else
                    {
                        switch (cboSearch.SelectedIndex)
                        {
                            case 0:
                                MessageBox.Show("No employee found with the provided ID.", "Search Result",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case 1:
                                MessageBox.Show("No employee found with the provided name.", "Search Result",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case 2:
                                MessageBox.Show("No employee found with the provided agent code.", "Search Result",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while searching for the employee: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                PopulateItems();
            }
        }
    }
}