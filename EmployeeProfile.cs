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
            string sqlRetrieveEmployeeProfile = @"SELECT emp_id, f_name, m_name, l_name, b_day, age, gender, civil_status, emp_ProfilePic, position_desc, phone, email, 
                                                         address, emerg_contact, account_name
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
                    string gender = profile.Rows[0]["gender"].ToString();
                    string dateOfBirth = profile.Rows[0]["b_day"].ToString();
                    string age = profile.Rows[0]["age"].ToString();
                    string civilStatus = profile.Rows[0]["civil_status"].ToString();
                    string emailAddress = profile.Rows[0]["email"].ToString();
                    string emergencyContactNo = profile.Rows[0]["emerg_contact"].ToString();
                    string address = profile.Rows[0]["address"].ToString();

                    // Split the address into barangay and city or municipality
                    string[] addressParts = address.Split(',');

                    lblEmployeeFullName.Text = fullName;
                    LoadImage(employeeProfilePicture, imagePath);
                    lblJobRole.Text = jobRole;
                    lblID.Text = _id;
                    lblEmpPhoneNo.Text = phoneNo;
                    lblEmployeeEmail.Text = email;
                    btnEmployeeAccountRate.Text = accountName;
                    txtFirstName.Text = firstName;
                    txtLastName.Text = lastName;
                    txtMiddleName.Text = middleName;
                    txtGender.Text = gender;
                    txtAge.Text = age;
                    txtCivilStatus.Text = civilStatus;
                    txtContactNo.Text = phoneNo;
                    txtEmailAddress.Text = emailAddress;
                    txtEmergContactNo.Text = emergencyContactNo;

                    DateTime parsedDateOfBirth;
                    // Parse retrieve date of birth and display to a desired format
                    if (DateTime.TryParse(dateOfBirth, out parsedDateOfBirth))
                    {
                        // Format the date as Month-Day Number-Year
                        txtBirthday.Text = parsedDateOfBirth.ToString("MMMM dd, yyyy");
                    }

                    // Check if the split was successful and assign value to text boxes
                    if (addressParts.Length == 2)
                    {
                        txtBrgyAddress.Text = addressParts[0].Trim(); // Get barangay name
                        txtCityMunicipality.Text = addressParts[1].Trim();     // Get city name
                    }

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

        private void ResetPanelLocation()
        {
            // Reset all panel locations and hide them
            panelPersonalDetails.Location = new Point(74, 297);
            panelEmploymentDetails.Location = new Point(74, 885);
            panelScheduleDetails.Location = new Point(74, 1472);
            panelSalaryDetails.Location = new Point(75, 2059);

            // Hide all panels initially
            panelPersonalDetails.Visible = false;
            panelEmploymentDetails.Visible = false;
            panelScheduleDetails.Visible = false;
            panelSalaryDetails.Visible = false;
        }

        private void ResetButton()
        {
            // Reset button colors to default
            btnPersonalDetails.FillColor = Color.FromArgb(164, 195, 178);
            btnPersonalDetails.ForeColor = Color.FromArgb(61, 61, 61);

            btnEmploymentDetails.FillColor = Color.FromArgb(164, 195, 178);
            btnEmploymentDetails.ForeColor = Color.FromArgb(61, 61, 61);

            btnClassSchedules.FillColor = Color.FromArgb(164, 195, 178);
            btnClassSchedules.ForeColor = Color.FromArgb(61, 61, 61);

            btnSalaryDetails.FillColor = Color.FromArgb(164, 195, 178);
            btnSalaryDetails.ForeColor = Color.FromArgb(61, 61, 61);
        }


        private void btnPersonalDetails_Click(object sender, EventArgs e)
        {
            // Reset everything first
            ResetButton();
            ResetPanelLocation();

            // Set the clicked button to selected state
            btnPersonalDetails.FillColor = Color.FromArgb(107, 144, 128);
            btnPersonalDetails.ForeColor = Color.White;

            // Show the relevant panel
            panelPersonalDetails.Visible = true;
            panelPersonalDetails.Location = new Point(74, 297);
        }

        private void btnEmploymentDetails_Click(object sender, EventArgs e)
        {
            // Reset everything first
            ResetButton();
            ResetPanelLocation();

            // Set the clicked button to selected state
            btnEmploymentDetails.FillColor = Color.FromArgb(107, 144, 128);
            btnEmploymentDetails.ForeColor = Color.White;

            // Show the relevant panel
            panelEmploymentDetails.Visible = true;
            panelEmploymentDetails.Location = new Point(74, 297);
        }

        private void btnClassSchedules_Click(object sender, EventArgs e)
        {
            // Reset everything first
            ResetButton();
            ResetPanelLocation();

            // Set the clicked button to selected state
            btnClassSchedules.FillColor = Color.FromArgb(107, 144, 128);
            btnClassSchedules.ForeColor = Color.White;

            // Show the relevant panel
            panelScheduleDetails.Visible = true;
            panelScheduleDetails.Location = new Point(74, 297);
        }

        private void btnSalaryDetails_Click(object sender, EventArgs e)
        {
            // Reset everything first
            ResetButton();
            ResetPanelLocation();

            // Set the clicked button to selected state
            btnSalaryDetails.FillColor = Color.FromArgb(107, 144, 128);
            btnSalaryDetails.ForeColor = Color.White;

            // Show the relevant panel
            panelSalaryDetails.Visible = true;
            panelSalaryDetails.Location = new Point(74, 297);
        }
    }
}
