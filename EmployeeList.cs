using GUTZ_Capstone_Project.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Web.UI.WebControls.WebParts;

namespace GUTZ_Capstone_Project
{
    public partial class EmployeeList : Form
    {
        public int id;
        private readonly string[] defaultSearchItems = { "Search By", "ID Number", "Name", "Email Address" };
        private readonly string[] defaultSortItems = { "Sort By", "Non-Tenured", "Tenured", "ESO", "RKESI", "VUIHOC" };
        private readonly string[] defaultFilterItems = { "Filter By", "Active", "Inactive", "Male", "Female", "Full Time", "Part Time" };
        private string sql = @"SELECT emp_profilePic, tbl_employee.emp_id, gender, email, phone, start_date, position_desc,
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
        }

        private void EmployeeList_Load(object sender, EventArgs e)
        {
            cboSearch.SelectedIndex = 0;
            cboSort.SelectedIndex = 0;
            cboFilter.SelectedIndex = 0;

            flowLayoutPanel1.SuspendLayout();
            PopulateItems();
            flowLayoutPanel1.ResumeLayout();
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
                lblActiveEmployee.Text = "0";
            }

            if (inactiveEmployee.Rows.Count > 0)
            {
                int inactiveCount = Convert.ToInt32(inactiveEmployee.Rows[0][0]);
                lblInactiveEmployee.Text = inactiveCount.ToString();
            }
            else
            {
                lblInactiveEmployee.Text = "0";
            }
        }

        private async void PopulateItems()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();

                DataTable dt = await Task.Run(() => DB_OperationHelperClass.QueryData(sql));

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No employee records found.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                flowLayoutPanel1.SuspendLayout();

                foreach (DataRow row in dt.Rows)
                {
                    int id = int.Parse(row["emp_id"].ToString());
                    string firstName = row["f_name"].ToString();
                    string middleName = row["m_name"].ToString();
                    string lastName = row["l_name"].ToString();
                    string name = string.IsNullOrEmpty(middleName) || middleName == "N/A"
                        ? $"{firstName} {lastName}"
                        : $"{firstName} {middleName[0]}. {lastName}";

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
                        EmployeeProfilePic = await LoadImageAsync(imagePath),
                        JobRole = jobRole,
                        Email = email,
                        Contact = contactNo,
                        JoinDate = DateTime.TryParse(joinedDate, out DateTime date) ? date.ToString("dd MMM, yyyy") : string.Empty,
                        Rate = accountName,
                    };

                    employeeControl.btnActiveInactive.Text = isDeleted == 0 ? "Active" : "Inactive";
                    employeeControl.EmployeeDeleted += (s, args) => PopulateItems();
                    employeeControl.EmployeeDeactivated += (s, args) => CountActiveAndInactive();

                    flowLayoutPanel1.Controls.Add(employeeControl);
                }

                flowLayoutPanel1.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving employee data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<Image> LoadImageAsync(string imagePath)
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
                        return Image.FromStream(stream);
                    }
                }
                catch
                {
                    return null;
                }
            });
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
                                    WHERE is_deleted = 0 AND email = @empEmail";
                            break;

                        default:
                            MessageBox.Show("Please select a valid search criterion.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                    }

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
                            parameters.Add("@empEmail", searchText); // Remove wildcards for exact match
                            break;
                    }

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

        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
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

                        if (isDeleted == 1)
                        {
                            employeeControl.panelEmployeeList.FillColor = Color.Gainsboro;
                            employeeControl.EmployeeListCardEmployeeDetailsCard.FillColor = Color.Gainsboro;
                            employeeControl.btnViewProfile.Enabled = false;
                            employeeControl.btnEdit.Enabled = false;
                            employeeControl.btnActiveInactive.BorderColor = Color.FromArgb(176, 176, 176);
                            employeeControl.employeeProfilePicture.BackColor = Color.Gainsboro;
                            employeeControl.btnActiveInactive.ShadowDecoration.Color = Color.FromArgb(176, 176, 176);
                            employeeControl.btnActiveInactive.FillColor = Color.White;
                            employeeControl.btnActiveInactive.ForeColor = Color.Black;
                            employeeControl.btnActiveInactive.HoverState.FillColor = Color.White;
                            employeeControl.btnActiveInactive.HoverState.BorderColor = Color.FromArgb(176, 176, 176);
                            employeeControl.btnActiveInactive.HoverState.ForeColor = Color.Black;
                            employeeControl.btnActivate.Visible = true;
                        }

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cboSearch.Items.Clear();
            cboSearch.Items.AddRange(defaultSearchItems);
            cboSearch.SelectedIndex = 0;

            cboSort.Items.Clear();
            cboSort.Items.AddRange(defaultSortItems);
            cboSort.SelectedIndex = 0;

            cboFilter.Items.Clear();
            cboFilter.Items.AddRange(defaultFilterItems);
            cboFilter.SelectedIndex = 0;

            flowLayoutPanel1.SuspendLayout();

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.BackColor = Color.Gray;
            txtSearch.Clear();
            flowLayoutPanel2.Visible = false;
            flowLayoutPanel1.Dock = DockStyle.Fill;

            PopulateItems();

            flowLayoutPanel1.ResumeLayout();
        }

        private void ExportEmployeesToCsv()
        {
            string sql = @"SELECT 
                            account_name, 
                            f_name, 
                            m_name, 
                            l_name, 
                            email, 
                            phone, 
                            is_deleted,
                            start_date, 
                            end_date
                            FROM tbl_employee
                            INNER JOIN tbl_account ON tbl_employee.account_id = tbl_account.account_id";

            DataTable employeeData = DB_OperationHelperClass.QueryData(sql);

            if (employeeData.Rows.Count > 0)
            {
                ExportToCsv(employeeData);
            }
            else
            {
                MessageBox.Show("No employee records to export.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExportToCsv(DataTable dataTable)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                saveFileDialog.Title = "Save Employee List as CSV";
                saveFileDialog.FileName = "employee_list.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder csvContent = new StringBuilder();

                        csvContent.AppendLine("ACCOUNT,TUTOR'S NAME, NAME, EMAIL, Phone Number, Status, Start Date, End Date");

                        foreach (DataRow row in dataTable.Rows)
                        {
                            string account = row["account_name"].ToString() ?? "N/A";
                            string tutorName = row["f_name"].ToString() ?? "N/A";
                            string middleInitial = !string.IsNullOrWhiteSpace(row["m_name"].ToString()) ? $"{row["m_name"].ToString()[0]}." : "N/A";
                            string fullName = $"{tutorName} {middleInitial} {row["l_name"]?.ToString() ?? "N/A"}".Trim();
                            string email = row["email"].ToString() ?? "N/A";
                            string phone = row["phone"].ToString() ?? "N/A";
                            string status = (Convert.ToInt32(row["is_deleted"]) == 0) ? "Active" : "Inactive";

                            string startDate = row["start_date"].ToString();
                            string formattedStartDate = DateTime.TryParse(startDate, out DateTime start) ? start.ToString("MM/dd/yyyy") : "N/A";

                            string endDate = row["end_date"].ToString();
                            string formattedEndDate = DateTime.TryParse(endDate, out DateTime end) ? end.ToString("MM/dd/yyyy") : "N/A";

                            csvContent.AppendLine($"{account},{tutorName},{fullName},{email},{phone},{status},{formattedStartDate},{formattedEndDate}");
                        }

                        File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());
                        MessageBox.Show("Export successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("An error occurred while exporting the data to CSV. Please try again.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportEmployeesToCsv();
        }

        private void cboSearch_Click(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            if (comboBox.SelectedIndex == 0)
            {
                comboBox.Items.RemoveAt(0);
                comboBox.SelectedIndex = -1;
            }
        }

        private void cboSort_Click(object sender, EventArgs e)
        {

            ComboBox comboBox = sender as ComboBox;

            if (comboBox.SelectedItem.ToString() == "Sort By")
            {
                comboBox.Items.RemoveAt(0);
                comboBox.SelectedIndex = -1;
            }
        }

        private void cboFilter_Click(object sender, EventArgs e)
        {

            ComboBox comboBox = sender as ComboBox;

            if (comboBox.SelectedItem.ToString() == "Filter By")
            {
                comboBox.Items.RemoveAt(0);
                comboBox.SelectedIndex = -1;
            }
        }
    }
}