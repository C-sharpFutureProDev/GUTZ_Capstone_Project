using GUTZ_Capstone_Project.Forms;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GUTZ_Capstone_Project
{
    public partial class EmployeeProfile : UserControl
    {
        private EmployeeList _employeeList;
        string _id = "";

        public EmployeeProfile(string _empID, EmployeeList employeeList)
        {
            InitializeComponent();
            if (_empID != null)
            {
                this._id = _empID;
                _employeeList = employeeList;
            }

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnMaximize, "Maximize View");
            toolTip.SetToolTip(btnMinimize, "Minimize View");
            btnMaximize.Click += btnMaximize_Click;
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

        private void EmployeeProfileCard_Load(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void LoadProfile()
        {
            string sqlRetrieveEmployeeProfile = @"SELECT emp_id, f_name, m_name, l_name, emp_ProfilePic, position_desc, phone, email, account_name
                                                         FROM tbl_employee
                                                         INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                                         INNER JOIN tbl_account ON tbl_employee.account_id = tbl_account.account_id
                                                         WHERE emp_id = @empId";

            var empId = new Dictionary<string, object>
            {
                { "@empId", _id }
            };

            try
            {
                DataTable profile = DB_OperationHelperClass.ParameterizedQueryData(sqlRetrieveEmployeeProfile, empId);
                if (profile.Rows.Count > 0)
                {
                    string firstName = profile.Rows[0]["f_name"].ToString();
                    string middleName = profile.Rows[0]["m_name"].ToString();
                    string lastName = profile.Rows[0]["l_name"].ToString();

                    string fullName = string.IsNullOrEmpty(middleName) || middleName.Equals("N/A", StringComparison.OrdinalIgnoreCase)
                        ? $"{firstName} {lastName}"
                        : $"{firstName} {middleName[0]}. {lastName}";

                    string imagePath = profile.Rows[0]["emp_ProfilePic"].ToString();
                    string jobRole = profile.Rows[0]["position_desc"].ToString();
                    string phoneNo = profile.Rows[0]["phone"].ToString();
                    string email = profile.Rows[0]["email"].ToString();
                    string accountName = profile.Rows[0]["account_name"].ToString();

                    lblEmployeeFullName.Text = fullName;
                    LoadImage(employeeProfilePicture, imagePath);
                    lblJobRole.Text = jobRole;
                    lblID.Text = _id;
                    lblEmpPhoneNo.Text = phoneNo;
                    lblEmployeeEmail.Text = email;
                    btnEmployeeAccountRate.Text = accountName;

                    if (jobRole == "Administrator")
                    {
                        string reportToImage = "C:/GUTZ/Employee_Profil_Picture/COO.jpg";
                        lblEmployeeReportingTo.Text = "Katherine J. Agripa";
                        LoadImage(reportToProfilePic, reportToImage);
                    }
                    else if (jobRole == "ESL Tutor")
                    {
                        string adminRole = "Administrator";

                        string _sql = @"SELECT f_name, m_name, l_name, emp_ProfilePic FROM tbl_employee 
                                        INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id 
                                        WHERE position_desc = @adminRole";

                        var adminParam = new Dictionary<string, object>
                        {
                            { "@adminRole", adminRole }
                        };

                        DataTable dt = DB_OperationHelperClass.ParameterizedQueryData(_sql, adminParam);

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                string adminProfilePic = row["emp_ProfilePic"].ToString();
                                LoadImage(reportToProfilePic, adminProfilePic);

                                string _firstName = row["f_name"].ToString();
                                string _middleName = row["m_name"].ToString();
                                string _lastName = row["l_name"].ToString();

                                string _fullName = string.IsNullOrEmpty(_middleName) || _middleName.Equals("N/A", StringComparison.OrdinalIgnoreCase)
                                    ? $"{_firstName} {_lastName}"
                                    : $"{_firstName} {_middleName[0]}. {_lastName}";

                                lblEmployeeReportingTo.Text = _fullName;

                                break;
                            }
                        }
                        else
                        {
                            reportToProfilePic.Image = null;
                            MessageBox.Show("No image found for the Administrator.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No records found", "No Records");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading employee profile: {ex.Message}");
            }
        }

        private void LoadImage(PictureBox pictureBox, string imagePath)
        {
            if (File.Exists(imagePath))
            {
                pictureBox.Image = Image.FromFile(imagePath);
            }
            else
            {
                pictureBox.Image = null;
                MessageBox.Show("Image not found: " + imagePath);
            }
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (_employeeList != null)
            {
                // Disable auto-scrolling
                _employeeList.flowLayoutPanel2.AutoScroll = false;

                // Hide the flow layout panel and the main panel
                _employeeList.flowLayoutPanel1.Visible = false;
                _employeeList.panelEmployeeListFeatures.Visible = false;

                // Make the minimize button visible and bring it to the front
                btnMinimize.Visible = true;
                btnMinimize.BringToFront();

                _employeeList.flowLayoutPanel1.PerformLayout();
                _employeeList.panelEmployeeListFeatures.PerformLayout();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            if (_employeeList != null)
            {
                // Enabled auto-scrolling
                _employeeList.flowLayoutPanel2.AutoScroll = true;

                btnMinimize.Visible = false;
                //_employeeList.txtSearch.Clear();
                _employeeList.flowLayoutPanel1.Visible = true;
                _employeeList.panelEmployeeListFeatures.Visible = true;
            }
        }
    }
}
