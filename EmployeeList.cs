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
        public int id;

        public EmployeeList()
        {
            InitializeComponent();
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        // Fixed flicker user interface rendering
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void EmployeeList_Load(object sender, EventArgs e)
        {
            // Set default selected index for ComboBoxes
            cboSearch.SelectedIndex = 0;
            cboSort.SelectedIndex = 0;
            cboFilter.SelectedIndex = 0;
            PopulateItems();
            CountActiveAndInactive();
        }

        private void CountActiveAndInactive()
        {
            string sqlActive = "SELECT COUNT(*) FROM tbl_employee WHERE is_deleted = 0";
            string sqlInactive = "SELECT COUNT(*) FROM tbl_employee WHERE is_deleted = 1";

            DataTable activeEmployee = DB_OperationHelperClass.QueryData(sqlActive);
            DataTable inactiveEmployee = DB_OperationHelperClass.QueryData(sqlInactive);

            if (activeEmployee.Rows.Count > 0)
            {
                int activeCount = Convert.ToInt32(activeEmployee.Rows[0][0]);
                lblActiveEmployee.Text = activeCount.ToString();
            }
            else
            {
                lblActiveEmployee.Text = "0"; // No active employees found
            }

            if (inactiveEmployee.Rows.Count > 0)
            {
                int inactiveCount = Convert.ToInt32(inactiveEmployee.Rows[0][0]);
                lblInactiveEmployee.Text = inactiveCount.ToString();
            }
            else
            {
                lblInactiveEmployee.Text = "0"; // No inactive employees found
            }
        }

        private void PopulateItems()
        {
            string sql = @"SELECT emp_profilePic, tbl_employee.emp_id, gender, email, phone, start_date, position_desc,
               f_name, m_name, l_name, tbl_employee.department_id, account_name, department_name, 
               DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate, is_deleted
               FROM tbl_employee
               INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
               INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
               INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
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
                    string firstName = row["f_name"].ToString();
                    string middleName = row["m_name"].ToString();
                    string lastName = row["l_name"].ToString();
                    string name;

                    // Check for middle name and construct the full name accordingly
                    if (string.IsNullOrEmpty(middleName) || middleName == "N/A")
                    {
                        name = $"{firstName} {lastName}"; // No middle name
                    }
                    else
                    {
                        name = $"{firstName} {middleName[0]}. {lastName}"; // With middle initial
                    }

                    string imagePath = row["emp_ProfilePic"].ToString();
                    string jobRole = row["position_desc"].ToString();
                    string email = row["email"].ToString();
                    string contactNo = row["phone"].ToString();
                    string joinedDate = row["start_date"].ToString();
                    string gender = row["gender"].ToString();
                    string accountName = row["account_name"].ToString();
                    int isDeleted = int.Parse(row["is_deleted"].ToString());

                    EmployeeListCard employeeControl = new EmployeeListCard(this)
                    {
                        EmployeeName = name,
                        ID = id.ToString(),
                        EmployeeProfilePic = Image.FromFile(imagePath),
                        JobRole = jobRole,
                        Email = email,
                        Contact = contactNo,
                        JoinDate = DateTime.TryParse(joinedDate, out DateTime date) ? date.ToString("dd MMM, yyyy") : string.Empty,
                        Rate = accountName,
                    };

                    // Set the button text based on the is_deleted status
                    employeeControl.btnActiveInactive.Text = isDeleted == 0 ? "Active" : "Inactive";

                    employeeControl.EmployeeDeleted += (s, args) => PopulateItems();
                    employeeControl.EmployeeDeactivated += (s, args) => CountActiveAndInactive();

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
                            query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted,
                      CONCAT(f_name, ' ', 
                      CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                      l_name) AS FullName, tbl_employee.department_id, position_desc, account_name,
                      DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                      FROM tbl_employee
                      INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                      INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                      INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
                      WHERE is_deleted = 0 AND emp_id = @empId";
                            break;

                        case 1: // Employee Name
                            query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted,
                      CONCAT(f_name, ' ', 
                      CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                      l_name) AS FullName, tbl_employee.department_id, position_desc, account_name,
                      DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                      FROM tbl_employee
                      INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                      INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                      INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
                      WHERE is_deleted = 0 AND CONCAT(f_name, ' ', 
                      CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                      l_name) LIKE @empName";
                            break;

                        case 2: // Employee Email
                            query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted,
                      CONCAT(f_name, ' ', 
                      CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                      l_name) AS FullName, tbl_employee.department_id, position_desc, account_name,
                      DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                      FROM tbl_employee
                      INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                      INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                      INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
                      WHERE is_deleted = 0 AND email LIKE @empEmail";
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
                        case 2: // Employee Email
                            parameters.Add("@empEmail", "%" + searchText + "%");
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
                        string imagePath = row["emp_profilePic"].ToString();
                        string jobRole = row["position_desc"].ToString();
                        string email = row["email"].ToString();
                        string contactNo = row["phone"].ToString();
                        string joinedDate = row["start_date"].ToString();
                        string accountName = row["account_name"].ToString();
                        int isDeleted = int.Parse(row["is_deleted"].ToString());

                        EmployeeListCard employeeControl = new EmployeeListCard(this)
                        {
                            EmployeeName = name,
                            ID = id.ToString(),
                            EmployeeProfilePic = Image.FromFile(imagePath),
                            JobRole = jobRole,
                            Email = email,
                            Contact = contactNo,
                            JoinDate = DateTime.TryParse(joinedDate, out DateTime date) ? date.ToString("dd MMM, yyyy") : string.Empty,
                            Rate = accountName,
                        };

                        // Set the button text based on the is_deleted status
                        employeeControl.btnActiveInactive.Text = isDeleted == 0 ? "Active" : "Inactive";

                        employeeControl.EmployeeDeleted += (s, args) => PopulateItems();
                        employeeControl.EmployeeDeactivated += (s, args) => CountActiveAndInactive();

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
                                MessageBox.Show("No employee found with the provided email.", "Search Result",
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

        private void cboSearch_DropDown(object sender, EventArgs e)
        {
            // Clear the search text
            txtSearch.Clear();

            // Populate items
            PopulateItems();

            // Check if "SEARCH BY" exists before removing
            if (cboSearch.Items.Contains("SEARCH BY"))
            {
                cboSearch.Items.Remove("SEARCH BY");
            }

            // Set to the first item
            cboSearch.SelectedIndex = 0; // Set to the first item
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            cboSearch.SelectedIndex = 0;
            txtSearch.Clear();
            flowLayoutPanel2.Visible = false;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            PopulateItems();

            // Check if "SEARCH BY" exists, if not, add it
            if (!cboSearch.Items.Contains("SEARCH BY"))
            {
                cboSearch.Items.Insert(0, "SEARCH BY"); // Add "SEARCH BY" at the top
            }

            // Reset selected index to the first item
            cboSearch.SelectedIndex = 0;
        }
    }
}