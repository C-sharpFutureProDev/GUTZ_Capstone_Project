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
        string sql = @"SELECT emp_profilePic, tbl_employee.emp_id, gender, email, phone, start_date, position_desc,
               f_name, m_name, l_name, tbl_employee.department_id, account_name, department_name, 
               DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate, is_deleted
               FROM tbl_employee
               INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
               INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
               INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
               WHERE is_deleted = 0
               ORDER BY emp_id ASC";

        public EmployeeList()
        {
            InitializeComponent();
            PopulateItems();
            txtSearch.TextChanged += txtSearch_TextChanged;
            cboFilter.SelectedIndexChanged += cboFilter_SelectedIndexChanged;
            cboSort.SelectedIndexChanged += cboSort_SelectedIndexChanged;
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
            //boSearch.SelectedIndex = 0; // Set to the first item
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "";

                switch (cboFilter.SelectedIndex)
                {
                    case 0: // Active
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted,
                             CONCAT(f_name, ' ', 
                             CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                             l_name) AS FullName, tbl_employee.department_id, position_desc, account_name,
                             DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                             FROM tbl_employee
                             INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                             INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                             INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
                             WHERE is_deleted = 0";
                        break;

                    case 1: // Inactive
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted,
                             CONCAT(f_name, ' ', 
                             CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                             l_name) AS FullName, tbl_employee.department_id, position_desc, account_name,
                             DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                             FROM tbl_employee
                             INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                             INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                             INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
                             WHERE is_deleted = 1";
                        break;

                    case 2: // Male
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted,
                             CONCAT(f_name, ' ', 
                             CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                             l_name) AS FullName, tbl_employee.department_id, position_desc, account_name,
                             DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                             FROM tbl_employee
                             INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                             INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                             INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
                             WHERE is_deleted = 0 AND gender = 'Male'";
                        break;

                    case 3: // Female
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted,
                             CONCAT(f_name, ' ', 
                             CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                             l_name) AS FullName, tbl_employee.department_id, position_desc, account_name,
                             DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                             FROM tbl_employee
                             INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                             INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                             INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
                             WHERE is_deleted = 0 AND gender = 'Female'";
                        break;

                    case 4: // Full Time
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted,
                             CONCAT(f_name, ' ', 
                             CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                             l_name) AS FullName, tbl_employee.department_id, position_desc, account_name,
                             DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                             FROM tbl_employee
                             INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                             INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                             INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
                             WHERE is_deleted = 0 AND work_arrangement = 'Full-Time'";
                        break;

                    case 5: // Part Time
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted,
                             CONCAT(f_name, ' ', 
                             CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                             l_name) AS FullName, tbl_employee.department_id, position_desc, account_name,
                             DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                             FROM tbl_employee
                             INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                             INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                             INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
                             WHERE is_deleted = 0 AND work_arrangement = 'Part-Time'";
                        break;

                    default:
                        MessageBox.Show("Please select a valid filter criterion.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

                // Execute the query
                DataTable dt = DB_OperationHelperClass.QueryData(query);

                flowLayoutPanel1.Controls.Clear();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int id = int.Parse(row["emp_id"].ToString());
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

                        if(isDeleted == 1)
                        {
                            employeeControl.panelEmployeeList.FillColor = Color.LightGray;
                            employeeControl.btnActiveInactive.BorderColor = Color.FromArgb(176, 176, 176);
                            employeeControl.employeeProfilePicture.BackColor = Color.LightGray;
                            employeeControl.btnActiveInactive.ShadowDecoration.Color = Color.FromArgb(176, 176, 176);
                            employeeControl.btnActiveInactive.FillColor = Color.White;
                            employeeControl.btnActiveInactive.ForeColor = Color.Black;
                            employeeControl.btnActiveInactive.HoverState.FillColor = Color.White;
                            employeeControl.btnActiveInactive.HoverState.BorderColor = Color.FromArgb(176, 176, 176);
                            employeeControl.btnActiveInactive.HoverState.ForeColor = Color.Black;
                            employeeControl.btnActivate.Visible = true;
                        }

                        // Set the button text based on the is_deleted status
                        employeeControl.btnActiveInactive.Text = isDeleted == 0 ? "Active" : "Inactive";

                        employeeControl.EmployeeDeleted += (s, args) => PopulateItems();
                        employeeControl.EmployeeDeactivated += (s, args) => CountActiveAndInactive();

                        flowLayoutPanel1.Controls.Add(employeeControl);
                    }
                }
                else
                {
                    MessageBox.Show("No employees found based on the selected filter.", "Search Result",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while filtering employees: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboSort_DropDown(object sender, EventArgs e)
        {
            // Populate items
            PopulateItems();

            // Check if "SEARCH BY" exists before removing
            if (cboSort.Items.Contains("SORT BY"))
            {
                cboSort.Items.Remove("SORT BY");
            }

            // Set to the first item
            //cboSort.SelectedIndex = 0; // Set to the first item
        }


        private void cboFilter_DropDown(object sender, EventArgs e)
        {
            // Populate items
            PopulateItems();

            // Check if "SEARCH BY" exists before removing
            if (cboFilter.Items.Contains("FILTER BY"))
            {
                cboFilter.Items.Remove("FILTER BY");
            }

            // Set to the first item
            //cboFilter.SelectedIndex = 0; // Set to the first item
        }

        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isRefreshing) return;
            try
            {
                string query = "";

                switch (cboSort.SelectedIndex)
                {
                    case 0: // Non-Tenured
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted,
                             CONCAT(f_name, ' ', 
                             CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                             l_name) AS FullName, tbl_employee.department_id, position_desc, tbl_account.account_name,
                             DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                             FROM tbl_employee
                             INNER JOIN tbl_account ON tbl_employee.account_id = tbl_account.account_id
                             INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                             WHERE is_deleted = 0 AND employment_type = 'Non-Tenured'
                             ORDER BY FullName";
                        break;

                    case 1: // Tenured
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted,
                             CONCAT(f_name, ' ', 
                             CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                             l_name) AS FullName, tbl_employee.department_id, position_desc, tbl_account.account_name,
                             DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                             FROM tbl_employee
                             INNER JOIN tbl_account ON tbl_employee.account_id = tbl_account.account_id
                             INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                             WHERE is_deleted = 0 AND employment_type = 'Tenured'
                             ORDER BY FullName";
                        break;

                    case 2: // ESO
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted,
                             CONCAT(f_name, ' ', 
                             CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                             l_name) AS FullName, tbl_employee.department_id, position_desc, tbl_account.account_name,
                             DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                             FROM tbl_employee
                             INNER JOIN tbl_account ON tbl_employee.account_id = tbl_account.account_id
                             INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                             WHERE is_deleted = 0 AND tbl_account.account_name LIKE '%ESO%'
                             ORDER BY FullName";
                        break;

                    case 3: // RKESI
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted,
                             CONCAT(f_name, ' ', 
                             CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                             l_name) AS FullName, tbl_employee.department_id, position_desc, tbl_account.account_name,
                             DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                             FROM tbl_employee
                             INNER JOIN tbl_account ON tbl_employee.account_id = tbl_account.account_id
                             INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                             WHERE is_deleted = 0 AND tbl_account.account_name LIKE '%RKESI%'
                             ORDER BY FullName";
                        break;

                    case 4: // VUIHOC
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted,
                             CONCAT(f_name, ' ', 
                             CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                             l_name) AS FullName, tbl_employee.department_id, position_desc, tbl_account.account_name,
                             DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                             FROM tbl_employee
                             INNER JOIN tbl_account ON tbl_employee.account_id = tbl_account.account_id
                             INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                             WHERE is_deleted = 0 AND tbl_account.account_name LIKE '%VUIHOC%'
                             ORDER BY FullName";
                        break;

                    default:
                        MessageBox.Show("Please select a valid sort criterion.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

                // Execute the query
                DataTable dt = DB_OperationHelperClass.QueryData(query);

                flowLayoutPanel1.Controls.Clear();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        int id = int.Parse(row["emp_id"].ToString());
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
                }
                else
                {
                    MessageBox.Show("No employees found based on the selected sort criteria.", "Search Result",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while sorting employees: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isRefreshing = false;
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            isRefreshing = true; // Set the flag to indicate refresh operation
            flowLayoutPanel1.Controls.Clear();
            cboSearch.SelectedIndex = 0;
            txtSearch.Clear();
            flowLayoutPanel2.Visible = false;
            flowLayoutPanel1.Dock = DockStyle.Fill;

            PopulateItems();

            if (!cboSearch.Items.Contains("SEARCH BY"))
            {
                cboSearch.Items.Insert(0, "SEARCH BY");
            }
            cboSearch.SelectedIndex = 0;

            if (!cboSort.Items.Contains("SORT BY"))
            {
                cboSort.Items.Insert(0, "SORT BY");
            }
            cboSort.SelectedIndex = 0;

            if (!cboFilter.Items.Contains("FILTER BY"))
            {
                cboFilter.Items.Insert(0, "FILTER BY");
            }
            cboFilter.SelectedIndex = 0;

            isRefreshing = false; // Reset the flag after the refresh
        }
    }
}