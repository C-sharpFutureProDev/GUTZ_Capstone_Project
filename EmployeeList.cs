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
using ZstdSharp.Unsafe;
using Mysqlx.Crud;
using System.Windows.Documents;

namespace GUTZ_Capstone_Project
{
    public partial class EmployeeList : Form
    {
        public int id;
        private readonly string[] defaultSearchItems = { "Search By", "ID Number", "Name", "Email Address" };
        private readonly string[] defaultSortItems = { "Sort By", "Non-Tenured", "Tenured", "ESO", "RKESI", "VUIHOC" };
        private readonly string[] defaultFilterItems = { "Filter By", "Active", "Inactive", "Male", "Female", "Full Time", "Part Time" };
        private bool isUserInteraction = false;
        bool isRefreshing = false;

        private string sql = @"SELECT emp_profilePic, tbl_employee.emp_id, gender, email, phone, start_date, position_desc, f_name, m_name, l_name, 
                                      tbl_employee.department_id, account_name, department_name, work_arrangement,
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
            isUserInteraction = false;

            PopulateItems();
            CountActiveAndInactive();
            CountEmployeeListDetails();
        }

        public void CountActiveAndInactive()
        {
            string countActive = "SELECT COUNT(*) FROM tbl_employee WHERE is_deleted = 0";
            string countInactive = "SELECT COUNT(*) FROM tbl_employee WHERE is_deleted = 1";

            DataTable activeEmployee = DB_OperationHelperClass.QueryData(countActive);
            DataTable inactiveEmployee = DB_OperationHelperClass.QueryData(countInactive);

            if (activeEmployee.Rows.Count > 0)
            {
                int activeCount = Convert.ToInt32(activeEmployee.Rows[0][0]);
                lblActiveEmployee.Text = activeCount.ToString();
            }

            if (inactiveEmployee.Rows.Count > 0)
            {
                int inactiveCount = Convert.ToInt32(inactiveEmployee.Rows[0][0]);
                lblInactiveEmployee.Text = inactiveCount.ToString();
            }
        }

        public void CountEmployeeListDetails()
        {
            string countMale = "SELECT COUNT(*) FROM tbl_employee WHERE gender = '" + "Male" + "' AND is_deleted = 0";
            string countFemale = "SELECT COUNT(*) FROM tbl_employee WHERE gender = '" + "Female" + "' AND is_deleted = 0";
            string countFullTine = "SELECT COUNT(*) FROM tbl_employee WHERE work_arrangement = '" + "Full-Time" + "' AND is_deleted = 0";
            string countPartTime = "SELECT COUNT(*) FROM tbl_employee WHERE work_arrangement = '" + "Part-Time" + "' AND is_deleted = 0";
            string countESO = "SELECT COUNT(*) FROM tbl_employee WHERE account_id = 1 AND is_deleted = 0";
            string countRKESI = "SELECT COUNT(*) FROM tbl_employee WHERE account_id = 2 AND is_deleted = 0";
            string countVUIHOC = "SELECT COUNT(*) FROM tbl_employee WHERE account_id = 3 AND is_deleted = 0";

            DataTable maleEmployee = DB_OperationHelperClass.QueryData(countMale);
            DataTable femaleEmployee = DB_OperationHelperClass.QueryData(countFemale);
            DataTable fullTimeEmployee = DB_OperationHelperClass.QueryData(countFullTine);
            DataTable partTimeEmployee = DB_OperationHelperClass.QueryData(countPartTime);
            DataTable ESO = DB_OperationHelperClass.QueryData(countESO);
            DataTable RKESI = DB_OperationHelperClass.QueryData(countRKESI);
            DataTable VUIHOC = DB_OperationHelperClass.QueryData(countVUIHOC);

            if (maleEmployee.Rows.Count > 0)
            {
                int count = Convert.ToInt32(maleEmployee.Rows[0][0]);
                lblMaleEmployee.Text = count.ToString();
            }
            if (femaleEmployee.Rows.Count > 0)
            {
                int count = Convert.ToInt32(femaleEmployee.Rows[0][0]);
                lblFemaleEmployee.Text = count.ToString();
            }
            if (fullTimeEmployee.Rows.Count > 0)
            {
                int count = Convert.ToInt32(fullTimeEmployee.Rows[0][0]);
                lblFullTime.Text = count.ToString();
            }
            if (partTimeEmployee.Rows.Count > 0)
            {
                int count = Convert.ToInt32(partTimeEmployee.Rows[0][0]);
                lblPartTime.Text = count.ToString();
            }
            if (ESO.Rows.Count > 0)
            {
                int count = Convert.ToInt32(ESO.Rows[0][0]);
                lblESO.Text = count.ToString();
            }
            if (RKESI.Rows.Count > 0)
            {
                int count = Convert.ToInt32(RKESI.Rows[0][0]);
                lblRKESI.Text = count.ToString();
            }
            if (VUIHOC.Rows.Count > 0)
            {
                int count = Convert.ToInt32(VUIHOC.Rows[0][0]);
                lblVUIHOC.Text = count.ToString();
            }
        }

        public async void PopulateItems()
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
                    string joinedDate = row["start_date"].ToString();
                    string accountName = row["account_name"].ToString();
                    string workingArrangement = row["work_arrangement"].ToString();

                    SampleProfileCard sampleProfileCard = new SampleProfileCard(this)
                    {
                        EmployeeProfilePic = await LoadImageAsync(imagePath),
                        ID = id.ToString(),
                        EmployeeName = name,
                        JobRole = jobRole,
                        Account = accountName,
                        JoinDate = DateTime.TryParse(joinedDate, out DateTime date) ? date.ToString("dd MMM, yyyy") : string.Empty,
                    };

                    if (workingArrangement == "Full-Time")
                        sampleProfileCard.btnWorkingArrangement.Text = workingArrangement;
                    else if (workingArrangement == "Part-Time")
                        sampleProfileCard.btnWorkingArrangement.Text = workingArrangement;

                    if(jobRole == "Administrator")
                    {
                        sampleProfileCard.lblEmpRate.Text = "";
                    }

                    flowLayoutPanel1.Controls.Add(sampleProfileCard);
                }

                /*for (int i = 1; i <= 100; i++) // Test Purposes
                {
                    SampleProfileCard sampleProfileCard = new SampleProfileCard(this);
                    flowLayoutPanel1.Controls.Add(sampleProfileCard);
                }*/
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
                    MessageBox.Show("No profile picture found.");
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
                    MessageBox.Show("No profile picture found.");
                    return null;
                }
            });
        }

        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            using (FormAddNewEmployee formAddNewEmployee = new FormAddNewEmployee("", this))
            {
                formAddNewEmployee.FormClosed += (s, args) =>
                {
                    // Check if the operation was successful
                    if (formAddNewEmployee.IsSuccessful)
                    {
                        PopulateItems();
                        CountActiveAndInactive();
                        CountEmployeeListDetails();
                    }
                };

                formAddNewEmployee.ShowDialog();
            }
        }

        private async void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isUserInteraction)
            {
                MessageBox.Show("Please choose any of available search criteria");
                txtSearch.Clear();
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                string searchText = txtSearch.Text.Trim();

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
                        case 0: // ID
                            query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted, work_arrangement,
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

                        case 1: // Name
                            query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted, work_arrangement,
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
                                      l_name) LIKE @empName
                                      ORDER BY emp_id ASC";
                            break;

                        case 2: // Email
                            query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted, work_arrangement,
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
                        case 0:
                            parameters.Add("@empId", searchText);
                            break;
                        case 1:
                            parameters.Add("@empName", "%" + searchText + "%");
                            break;
                        case 2:
                            parameters.Add("@empEmail", searchText);
                            break;
                    }

                    DataTable dt = DB_OperationHelperClass.ParameterizedQueryData(query, parameters);

                    flowLayoutPanel1.Controls.Clear();

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            string imagePath = row["emp_profilePic"].ToString();
                            id = int.Parse(row["emp_id"].ToString());
                            string name = row["FullName"].ToString();
                            string jobRole = row["position_desc"].ToString();
                            string accountName = row["account_name"].ToString();
                            string joinedDate = row["start_date"].ToString();
                            string workingArrangement = row["work_arrangement"].ToString();

                            SampleProfileCard sampleProfileCard = new SampleProfileCard(this)
                            {
                                EmployeeProfilePic = await LoadImageAsync(imagePath),
                                ID = id.ToString(),
                                EmployeeName = name,
                                JobRole = jobRole,
                                Account = accountName,
                                JoinDate = DateTime.TryParse(joinedDate, out DateTime date) ? date.ToString("dd MMM, yyyy") : string.Empty,
                            };

                            if (workingArrangement == "Full-Time")
                                sampleProfileCard.btnWorkingArrangement.Text = workingArrangement;
                            else if (workingArrangement == "Part-Time")
                                sampleProfileCard.btnWorkingArrangement.Text = workingArrangement;

                            flowLayoutPanel1.Controls.Add(sampleProfileCard);
                        }
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
            if (!isRefreshing)
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                {
                    PopulateItems();
                }
            }
        }

        private async void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isUserInteraction)
                return;

            try
            {
                string query = "";

                switch (cboSort.SelectedIndex)
                {
                    case 0:
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted, work_arrangement,
                                  CONCAT(f_name, ' ', 
                                  CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                                  l_name) AS FullName, tbl_employee.department_id, position_desc, tbl_account.account_name,
                                  DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                                  FROM tbl_employee
                                  INNER JOIN tbl_account ON tbl_employee.account_id = tbl_account.account_id
                                  INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                  WHERE is_deleted = 0 AND employment_type = 'Non-Tenured'
                                  ORDER BY emp_id ASC";
                        break;

                    case 1:
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted, work_arrangement,
                                  CONCAT(f_name, ' ', 
                                  CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                                  l_name) AS FullName, tbl_employee.department_id, position_desc, tbl_account.account_name,
                                  DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                                  FROM tbl_employee
                                  INNER JOIN tbl_account ON tbl_employee.account_id = tbl_account.account_id
                                  INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                  WHERE is_deleted = 0 AND employment_type = 'Tenured'
                                  ORDER BY emp_id ASC";
                        break;

                    case 2:
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted, work_arrangement,
                                  CONCAT(f_name, ' ', 
                                  CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                                  l_name) AS FullName, tbl_employee.department_id, position_desc, tbl_account.account_name,
                                  DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                                  FROM tbl_employee
                                  INNER JOIN tbl_account ON tbl_employee.account_id = tbl_account.account_id
                                  INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                  WHERE is_deleted = 0 AND tbl_account.account_name LIKE '%ESO%'
                                  ORDER BY emp_id ASC";
                        break;

                    case 3:
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted, work_arrangement,
                                  CONCAT(f_name, ' ', 
                                  CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                                  l_name) AS FullName, tbl_employee.department_id, position_desc, tbl_account.account_name,
                                  DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                                  FROM tbl_employee
                                  INNER JOIN tbl_account ON tbl_employee.account_id = tbl_account.account_id
                                  INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                  WHERE is_deleted = 0 AND tbl_account.account_name LIKE '%RKESI%'
                                  ORDER BY emp_id ASC";
                        break;

                    case 4:
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted, work_arrangement,
                                  CONCAT(f_name, ' ', 
                                  CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                                  l_name) AS FullName, tbl_employee.department_id, position_desc, tbl_account.account_name,
                                  DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                                  FROM tbl_employee
                                  INNER JOIN tbl_account ON tbl_employee.account_id = tbl_account.account_id
                                  INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                  WHERE is_deleted = 0 AND tbl_account.account_name LIKE '%VUIHOC%'
                                  ORDER BY emp_id ASC";
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
                        string imagePath = row["emp_profilePic"].ToString();
                        id = int.Parse(row["emp_id"].ToString());
                        string name = row["FullName"].ToString();
                        string jobRole = row["position_desc"].ToString();
                        string accountName = row["account_name"].ToString();
                        string joinedDate = row["start_date"].ToString();
                        string workingArrangement = row["work_arrangement"].ToString();

                        SampleProfileCard sampleProfileCard = new SampleProfileCard(this)
                        {
                            EmployeeProfilePic = await LoadImageAsync(imagePath),
                            ID = id.ToString(),
                            EmployeeName = name,
                            JobRole = jobRole,
                            Account = accountName,
                            JoinDate = DateTime.TryParse(joinedDate, out DateTime date) ? date.ToString("dd MMM, yyyy") : string.Empty,
                        };

                        if (workingArrangement == "Full-Time")
                            sampleProfileCard.btnWorkingArrangement.Text = workingArrangement;
                        else if (workingArrangement == "Part-Time")
                            sampleProfileCard.btnWorkingArrangement.Text = workingArrangement;

                        flowLayoutPanel1.Controls.Add(sampleProfileCard);
                    }
                }
                else
                {
                    MessageBox.Show("No employees found based on the selected sort criteria.", "Result",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while sorting employees: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isUserInteraction)
                return;

            try
            {
                string query = "";

                switch (cboFilter.SelectedIndex)
                {
                    case 0:
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted, work_arrangement,
                                  CONCAT(f_name, ' ', 
                                  CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                                  l_name) AS FullName, tbl_employee.department_id, position_desc, account_name,
                                  DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                                  FROM tbl_employee
                                  INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                                  INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                  INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
                                  WHERE is_deleted = 0
                                  ORDER BY emp_id ASC";
                        break;

                    case 1:
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted, work_arrangement,
                                  CONCAT(f_name, ' ', 
                                  CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                                  l_name) AS FullName, tbl_employee.department_id, position_desc, account_name,
                                  DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                                  FROM tbl_employee
                                  INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                                  INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                  INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
                                  WHERE is_deleted = 1
                                  ORDER BY emp_id ASC";
                        break;

                    case 2:
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted, work_arrangement,
                                  CONCAT(f_name, ' ', 
                                  CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                                  l_name) AS FullName, tbl_employee.department_id, position_desc, account_name,
                                  DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                                  FROM tbl_employee
                                  INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                                  INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                  INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
                                  WHERE is_deleted = 0 AND gender = 'Male'
                                  ORDER BY emp_id ASC";
                        break;

                    case 3:
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted, work_arrangement,
                                  CONCAT(f_name, ' ', 
                                  CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                                  l_name) AS FullName, tbl_employee.department_id, position_desc, account_name,
                                  DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                                  FROM tbl_employee
                                  INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                                  INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                  INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
                                  WHERE is_deleted = 0 AND gender = 'Female'
                                  ORDER BY emp_id ASC";
                        break;

                    case 4:
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted, work_arrangement,
                                  CONCAT(f_name, ' ', 
                                  CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                                  l_name) AS FullName, tbl_employee.department_id, position_desc, account_name,
                                  DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                                  FROM tbl_employee
                                  INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                                  INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                  INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
                                  WHERE is_deleted = 0 AND work_arrangement = 'Full-Time'
                                  ORDER BY emp_id ASC";
                        break;

                    case 5:
                        query = @"SELECT emp_profilePic, tbl_employee.emp_id, email, phone, start_date, is_deleted, work_arrangement,
                                  CONCAT(f_name, ' ', 
                                  CASE WHEN m_name IS NULL OR m_name = 'N/A' THEN '' ELSE CONCAT(LEFT(m_name, 1), '. ') END, 
                                  l_name) AS FullName, tbl_employee.department_id, position_desc, account_name,
                                  DATE_FORMAT(hired_date, '%M %d, %Y') AS HiredDate
                                  FROM tbl_employee
                                  INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                                  INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                  INNER JOIN tbl_account ON tbl_account.account_id = tbl_employee.account_id
                                  WHERE is_deleted = 0 AND work_arrangement = 'Part-Time'
                                  ORDER BY emp_id ASC";
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
                        string imagePath = row["emp_profilePic"].ToString();
                        id = int.Parse(row["emp_id"].ToString());
                        string name = row["FullName"].ToString();
                        string jobRole = row["position_desc"].ToString();
                        string accountName = row["account_name"].ToString();
                        string joinedDate = row["start_date"].ToString();
                        int isDeleted = int.Parse(row["is_deleted"].ToString());
                        string workingArrangement = row["work_arrangement"].ToString();

                        SampleProfileCard sampleProfileCard = new SampleProfileCard(this)
                        {
                            EmployeeProfilePic = await LoadImageAsync(imagePath),
                            ID = id.ToString(),
                            EmployeeName = name,
                            JobRole = jobRole,
                            Account = accountName,
                            JoinDate = DateTime.TryParse(joinedDate, out DateTime date) ? date.ToString("dd MMM, yyyy") : string.Empty,
                        };

                        if (isDeleted == 1)
                        {
                            sampleProfileCard.btnActiveOrInactiveStatus.Visible = false;
                            sampleProfileCard.btnWorkingArrangement.Enabled = false;
                            sampleProfileCard.btnActiveOrInactiveStatus.ShadowDecoration.Enabled = false;
                            sampleProfileCard.btnEdit.Enabled = false;
                            sampleProfileCard.btnDeactivateEmployee.Visible = false;
                            sampleProfileCard.btnReactivateEmployee.Visible = true;
                            sampleProfileCard.btnViewEmployeeDetails.Enabled = false;
                            sampleProfileCard.lblID.ForeColor = Color.LightGray;
                        }

                        if (workingArrangement == "Full-Time")
                            sampleProfileCard.btnWorkingArrangement.Text = workingArrangement;
                        else if (workingArrangement == "Part-Time")
                            sampleProfileCard.btnWorkingArrangement.Text = workingArrangement;

                        flowLayoutPanel1.Controls.Add(sampleProfileCard);
                    }
                }
                else
                {
                    MessageBox.Show("No employees found based on the selected filter.", "Result",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while filtering employees: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshUI()
        {
            isRefreshing = true;
            isUserInteraction = false;

            cboSearch.Items.Clear();
            cboSearch.Items.AddRange(defaultSearchItems);
            cboSearch.SelectedIndex = 0;

            cboSort.Items.Clear();
            cboSort.Items.AddRange(defaultSortItems);
            cboSort.SelectedIndex = 0;

            cboFilter.Items.Clear();
            cboFilter.Items.AddRange(defaultFilterItems);
            cboFilter.SelectedIndex = 0;

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.BackColor = Color.Gray;
            txtSearch.Clear();
            flowLayoutPanel2.Visible = false;
            flowLayoutPanel1.Dock = DockStyle.Fill;

            isRefreshing = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshUI();
            PopulateItems();
        }

        private void ExportEmployeesToCsv()
        {
            string sql = @"SELECT account_name, f_name, m_name, l_name, email, phone, is_deleted, start_date, end_date
                           FROM tbl_employee
                           INNER JOIN tbl_account
                           ON tbl_employee.account_id = tbl_account.account_id";

            DataTable dt = DB_OperationHelperClass.QueryData(sql);

            if (dt.Rows.Count > 0)
            {
                ExportToCsv(dt);
            }
            else
            {
                MessageBox.Show("No employee records to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExportToCsv(DataTable dataTable)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                saveFileDialog.Title = "Save Employee List as CSV";
                saveFileDialog.FileName = "GUTZ_employee_list.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder csvContent = new StringBuilder();

                        csvContent.AppendLine("ACCOUNT,TUTOR'S NAME,NAME,EMAIL,Phone Number,Status,Start Date,End Date");

                        foreach (DataRow row in dataTable.Rows)
                        {
                            string account = row["account_name"]?.ToString() ?? "N/A";
                            string tutorName = row["f_name"]?.ToString() ?? "N/A";
                            string middleInitial = !string.IsNullOrWhiteSpace(row["m_name"].ToString()) ? $"{row["m_name"].ToString()[0]}." : "N/A";
                            string fullName = $"{tutorName} {middleInitial} {row["l_name"]?.ToString() ?? "N/A"}".Trim();
                            string email = row["email"]?.ToString() ?? "N/A";
                            string phone = row["phone"]?.ToString() ?? "N/A";
                            string status = (Convert.ToInt32(row["is_deleted"]) == 0) ? "Active" : "Inactive";

                            string startDate = row["start_date"]?.ToString();
                            string formattedStartDate = DateTime.TryParse(startDate, out DateTime start) ? start.ToString("MM/dd/yyyy") : "N/A";

                            string endDate = row["end_date"]?.ToString();
                            string formattedEndDate = DateTime.TryParse(endDate, out DateTime end) ? end.ToString("MM/dd/yyyy") : "N/A";

                            csvContent.AppendLine($"\"{account}\",\"{tutorName}\",\"{fullName}\",\"{email}\",\"'{phone}\",\"{status}\",\"{formattedStartDate}\",\"{formattedEndDate}\"");
                        }

                        File.WriteAllText(saveFileDialog.FileName, csvContent.ToString());
                        MessageBox.Show("Export successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while exporting the data to CSV: {ex.Message}", "Error",
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
            isUserInteraction = true;
            ComboBox comboBox = sender as ComboBox;

            // Check if comboBox is not null and has a selected item
            if (comboBox != null)
            {
                // Ensure there's a selected item before accessing it
                if (comboBox.SelectedItem != null && comboBox.SelectedItem.ToString() == "Search By")
                {
                    comboBox.Items.RemoveAt(0);
                    comboBox.SelectedIndex = -1; // Reset the selection
                }
            }
        }

        private void cboSort_Click(object sender, EventArgs e)
        {
            isUserInteraction = true;
            ComboBox comboBox = sender as ComboBox;

            // Check if comboBox is not null
            if (comboBox != null)
            {
                // Ensure there's a selected item before accessing it
                if (comboBox.SelectedItem != null && comboBox.SelectedItem.ToString() == "Sort By")
                {
                    // Remove the first item if it exists
                    if (comboBox.Items.Count > 0)
                    {
                        comboBox.Items.RemoveAt(0);
                    }
                    comboBox.SelectedIndex = -1; // Reset the selection
                }
            }
        }

        private void cboFilter_Click(object sender, EventArgs e)
        {
            isUserInteraction = true;
            ComboBox comboBox = sender as ComboBox;

            // Check if comboBox is not null
            if (comboBox != null)
            {
                // Ensure there's a selected item before accessing it
                if (comboBox.SelectedItem != null && comboBox.SelectedItem.ToString() == "Filter By")
                {
                    // Remove the first item if it exists
                    if (comboBox.Items.Count > 0)
                    {
                        comboBox.Items.RemoveAt(0);
                    }
                    comboBox.SelectedIndex = -1; // Reset the selection
                }
            }
        }
    }
}
