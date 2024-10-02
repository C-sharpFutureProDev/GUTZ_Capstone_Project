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

namespace GUTZ_Capstone_Project
{
    public partial class EmployeeProfileCard : UserControl
    {
        private EmployeeList _employeeList;
        string _id = "";

        public EmployeeProfileCard(string _empID, EmployeeList employeeList)
        {
            InitializeComponent();
            if (_empID != null)
            {
                this._id = _empID;
            }

            _employeeList = employeeList;
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

        private void LoadProfile()
        {
            if (_id != null)
            {
                string sql = @"SELECT emp_profilePic, tbl_account.account_id, account_name, fingerprint_data, f_name, m_name, l_name, b_day, age, gender, civil_status, address, email, phone, hired_date,
                                      CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS FullName, tbl_position.position_id, position_desc, employment_type, work_arrangement, department_name, position_type, 
                                      contact_person, emerg_contact, relationship, deg_obtained, field_of_study, major, institution, location, status, from_date, to_date, lic_cert, prev_comp_name, prev_job_title, 
                                      prev_comp_location, tenure, prev_role, supv_mgr
                               FROM tbl_employee
                               INNER JOIN tbl_fingerprint ON tbl_employee.emp_id = tbl_fingerprint.emp_id
                               INNER JOIN tbl_department ON tbl_employee.department_id = tbl_department.department_id
                               INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                               INNER JOIN tbl_account ON tbl_employee.account_id = tbl_account.account_id
                               INNER JOIN tbl_profile ON tbl_employee.emp_id = tbl_profile.emp_id
                               WHERE tbl_employee.emp_id = @empId AND is_deleted = 0";

                var paramID = new Dictionary<string, object>
                {
                    { "@empId", _id }
                };

                DataTable dt = DB_OperationHelperClass.ParameterizedQueryData(sql, paramID);
                if (dt.Rows.Count > 0)
                {
                    string image_path = dt.Rows[0]["emp_profilePic"].ToString();
                    employeeProfilePicture.Image = System.Drawing.Image.FromFile(image_path);
                    lblEmployeeFullName.Text = dt.Rows[0]["FullName"].ToString();
                    lblJobRole.Text = dt.Rows[0]["position_desc"].ToString();
                    lblID.Text = _id.ToString();
                    lblEmployeeEmail.Text = dt.Rows[0]["email"].ToString();
                    lblEmpPhoneNo.Text = dt.Rows[0]["phone"].ToString();
                    btnEmployeeAccountRate.Text = dt.Rows[0]["account_name"] + " RATE".ToString();

                    int posId = int.Parse(dt.Rows[0]["position_id"].ToString());

                    if (posId == 1101)
                    {
                        lblEmployeeReportingTo.Text = "Katherine J. Agripa / COO";
                        reportToProfilePic.Image = System.Drawing.Image.FromFile(@"C:\GUTZ\Employee_Profil_Picture\COO.jpg");

                    }
                    else if (posId == 2202)
                    {
                        lblEmployeeReportingTo.Text = "Lealyn Guarin / ESL Dept. Head";
                        reportToProfilePic.Image = System.Drawing.Image.FromFile(@"C:\GUTZ\Employee_Profil_Picture\IMG_20240918_160345_360-transformed.jpeg");
                    }

                    txtEmpFirstName.Text = dt.Rows[0]["f_name"].ToString();
                    txtEmpLastName.Text = dt.Rows[0]["l_name"].ToString();
                    string employmentType = dt.Rows[0]["employment_type"].ToString();

                    var employmentIndices = new Dictionary<string, int>
                    {
                        { "Tenured", 1 },
                        { "Non-Tenured", 0 }
                    };

                    if (employmentIndices.TryGetValue(employmentType, out var index))
                    {
                        cboEmploymentType.SelectedIndex = index;
                    }

                    txtEmpID.Text = _id.ToString();
                    deptJoinedDate.Value = Convert.ToDateTime(dt.Rows[0]["hired_date"]).AddDays(3);

                    cboEmployeeDept.SelectedItem = dt.Rows[0]["department_name"].ToString();
                    txtJobTitle.Text = dt.Rows[0]["position_desc"].ToString();

                    txtDesignation.Text = dt.Rows[0]["position_type"].ToString();
                    cboWorkArrangement.SelectedItem = dt.Rows[0]["work_arrangement"].ToString();
                    string posType = dt.Rows[0]["position_type"].ToString();

                    var roleDescriptions = new Dictionary<string, string>
                    {
                        { "Administrator", "Oversees the ESL program, manages curriculum development, supports staff training, and ensures the program meets educational standards and student needs." },
                        { "Tutor", "Creates and implements engaging lesson plans, assesses student progress, and fosters a supportive environment to enhance English language proficiency." }
                    };

                    if (roleDescriptions.TryGetValue(posType, out var description))
                    {
                        txtRoleAndResponsibilities.Text = description;
                    }

                    txtFirstName.Text = dt.Rows[0]["f_name"].ToString();
                    txtLastName.Text = dt.Rows[0]["l_name"].ToString();
                    txtMiddleName.Text = dt.Rows[0]["m_name"].ToString();
                    cboGender.SelectedItem = dt.Rows[0]["gender"].ToString();
                    cboCivilStatus.SelectedItem = dt.Rows[0]["civil_status"].ToString();
                    dtpDateOfBirth.Value = Convert.ToDateTime(dt.Rows[0]["b_day"]);
                    txtAge.Text = dt.Rows[0]["age"].ToString();
                    txtContactNumber.Text = dt.Rows[0]["phone"].ToString();
                    txtEmail.Text = dt.Rows[0]["email"].ToString();
                    string[] addressParts = dt.Rows[0]["address"].ToString().Split(',');
                    cboCityMunicipality.SelectedItem = (addressParts.Length == 2) ? addressParts[1].Trim() : null;
                    txtBrgyAddress.Text = (addressParts.Length == 2) ? addressParts[0].Trim() : string.Empty;
                    txtEmergencyContactPerson.Text = dt.Rows[0]["contact_person"].ToString();
                    cboRelationship.SelectedItem = dt.Rows[0]["relationship"].ToString();
                    txtEmergencyContactPersonPhoneNo.Text = dt.Rows[0]["emerg_contact"].ToString();
                    txtHighestDegreeObtained.Text = dt.Rows[0]["deg_obtained"].ToString();
                    txtFieldOfStudy.Text = dt.Rows[0]["field_of_study"].ToString();
                    txtMajor.Text = dt.Rows[0]["major"].ToString();
                    txtInstutionName.Text = dt.Rows[0]["institution"].ToString();
                    txtLocation.Text = dt.Rows[0]["location"].ToString();
                    cboStatus.SelectedItem = dt.Rows[0]["status"].ToString();
                    txtYearStarted.Text = dt.Rows[0]["from_date"].ToString();
                    txtYearFinished.Text = dt.Rows[0]["to_date"].ToString();
                    txtLicensesCertifications.Text = dt.Rows[0]["lic_cert"].ToString();
                    txtPrevCompName.Text = dt.Rows[0]["prev_comp_name"].ToString();
                    txtPrevJobTitle.Text = dt.Rows[0]["prev_job_title"].ToString();
                    txtPrevJobCompLoc.Text = dt.Rows[0]["prev_comp_location"].ToString();
                    txtPrevJobTenure.Text = dt.Rows[0]["tenure"].ToString();
                    txtPrevJobSupervisorOrManager.Text = dt.Rows[0]["supv_mgr"].ToString();
                    txtPrevJobRole.Text = dt.Rows[0]["prev_role"].ToString();

                    int accID = int.Parse(dt.Rows[0]["account_id"].ToString());

                    string[] accountRates = {
                        "Registered Account Rate : ESO",
                        "Registered Account Rate : RKESI",
                        "Registered Account Rate : VUIHOC"
                    };

                    if (accID >= 1 && accID <= 3)
                    {
                        lblAccountRate.Text = accountRates[accID - 1];
                    }

                    txtTeacherOrTutorName.Text = dt.Rows[0]["f_name"].ToString();

                    if (accID == 1) // ESO
                    {
                        cboModeOfPayment.SelectedIndex = 0;

                        // Retrieve ESO rates
                        string esoRateQuery = @"SELECT tenured_rate, non_tenured_rate, duration_id
                                                FROM tbl_rates
                                                WHERE rate_id IN (101, 102) AND account_id = @accountId";

                        var esoParameters = new Dictionary<string, object>
                        {
                            { "@accountId", accID }
                        };

                        DataTable esoRates = DB_OperationHelperClass.ParameterizedQueryData(esoRateQuery, esoParameters);

                        if (esoRates.Rows.Count > 0)
                        {
                            foreach (DataRow row in esoRates.Rows)
                            {
                                double tenuredRate = double.Parse(row["tenured_rate"].ToString());
                                double nonTenuredRate = double.Parse(row["non_tenured_rate"].ToString());
                                int durationId = Convert.ToInt32(row["duration_id"]);

                                // Determine which rate to display based on employment type
                                double rateToDisplay = (employmentType.Equals("Tenured", StringComparison.OrdinalIgnoreCase)) ? tenuredRate : nonTenuredRate;

                                // Display the rate based on duration_id
                                switch (durationId)
                                {
                                    case 1:
                                        txtRatePer60Mins.Text = rateToDisplay.ToString("F2");
                                        break;
                                    case 2:
                                        txtRatePer45Mins.Text = rateToDisplay.ToString("F2");
                                        break;
                                }
                            }
                        }
                        txtRatePer40Mins.Text = "NOT Applicable";
                        txtRatePer25Minutes.Text = "NOT Applicable";
                    }

                    if (accID == 2) // RKESI
                    {
                        cboModeOfPayment.SelectedIndex = 0;

                        // Retrieve RKESI rates
                        string rkesiRateQuery = @"SELECT tenured_rate, non_tenured_rate
                                                  FROM tbl_rates
                                                  WHERE rate_id = 103 AND account_id = @accountId";

                        var rkesiParameters = new Dictionary<string, object>
                        {
                            { "@accountId", accID }
                        };

                        DataTable rkesiRates = DB_OperationHelperClass.ParameterizedQueryData(rkesiRateQuery, rkesiParameters);

                        if (rkesiRates.Rows.Count > 0)
                        {
                            foreach (DataRow row in rkesiRates.Rows)
                            {
                                double tenuredRate = double.Parse(row["tenured_rate"].ToString());
                                double nonTenuredRate = double.Parse(row["non_tenured_rate"].ToString());

                                // Determine which rate to display based on employment type
                                double rateToDisplay = (employmentType.Equals("Tenured", StringComparison.OrdinalIgnoreCase)) ? tenuredRate : nonTenuredRate;

                                // Since RKESI has only one duration_id (3)
                                txtRatePer25Minutes.Text = rateToDisplay.ToString("F2");
                                txtRatePer60Mins.Text = "NOT Applicable";
                                txtRatePer45Mins.Text = "NOT Applicable";
                                txtRatePer40Mins.Text = "NOT Applicable";
                            }
                        }
                    }

                    if (accID == 3) // VUIHOC
                    {
                        cboModeOfPayment.SelectedIndex = 0;
                        string vuihocRate = @"SELECT employment_type, tenured_rate, non_tenured_rate, duration, duration_id, rate_id, tbl_account.account_id
                                              FROM tbl_employee
                                              INNER JOIN tbl_account ON tbl_employee.account_id = tbl_account.account_id
                                              INNER JOIN tbl_rates ON tbl_rates.account_id = tbl_account.account_id
                                              INNER JOIN tbl_duration ON tbl_duration.id = tbl_rates.duration_id
                                              WHERE emp_id = @empId AND employment_type = @employmentType";

                        var parameters = new Dictionary<string, object>
                        {
                            { "@empId", _id },
                            { "@employmentType", employmentType }
                        };

                        DataTable dataTable = DB_OperationHelperClass.ParameterizedQueryData(vuihocRate, parameters);

                        if (dataTable.Rows.Count > 0)
                        {
                            foreach (DataRow row in dataTable.Rows)
                            {
                                double tenuredRate = double.Parse(row["tenured_rate"].ToString());
                                double nonTenuredRate = double.Parse(row["non_tenured_rate"].ToString());
                                int durationId = Convert.ToInt32(row["duration_id"]);

                                // Determine which rate to display based on employment type
                                double rateToDisplay = (employmentType.Equals("Tenured", StringComparison.OrdinalIgnoreCase)) ? tenuredRate : nonTenuredRate;

                                // Display the rate based on duration_id
                                switch (durationId)
                                {
                                    case 4:
                                        txtRatePer60Mins.Text = rateToDisplay.ToString("F2");
                                        break;
                                    case 5:
                                        txtRatePer45Mins.Text = rateToDisplay.ToString("F2");
                                        break;
                                    case 6:
                                        txtRatePer40Mins.Text = rateToDisplay.ToString("F2");
                                        break;
                                    case 7:
                                        txtRatePer25Minutes.Text = rateToDisplay.ToString("F2");
                                        break;
                                }
                            }
                        }
                    }

                } // end if 
                else
                {
                    MessageBox.Show("No employee profile found.", "No Employee Profile Records Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void EmployeeProfileCard_Load(object sender, EventArgs e)
        {
            chkPenForExceedingQuotaLeave.Checked = true;
            chkPenForSuddenLeave.Checked = true;
            chkPenForDroppingTheClassMidway.Checked = true;
            chkDeductions.Checked = true;

            LoadProfile();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (_employeeList != null)
            {
                // Disable auto-scrolling
                _employeeList.flowLayoutPanel2.AutoScroll = false;

                // Hide the flow layout panel and the main panel
                _employeeList.flowLayoutPanel1.Visible = false;
                _employeeList.guna2Panel1.Visible = false;

                // Make the minimize button visible and bring it to the front
                btnMinimize.Visible = true;
                btnMinimize.BringToFront();

                _employeeList.flowLayoutPanel1.PerformLayout();
                _employeeList.guna2Panel1.PerformLayout();
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
                _employeeList.guna2Panel1.Visible = true;
            }
        }

        private void ResetButtons()
        {
            // Reset button colors and states
            btnOrganization.FillColor = Color.White;
            btnOrganization.ForeColor = Color.Green;
            btnPersonal.FillColor = Color.White;
            btnPersonal.ForeColor = Color.Green;
            btnSalary.FillColor = Color.White;
            btnSalary.ForeColor = Color.Green;
            btnEducation.FillColor = Color.White;
            btnEducation.ForeColor = Color.Green;
            btnExperience.FillColor = Color.White;
            btnExperience.ForeColor = Color.Green;
            btnPerformance.FillColor = Color.White;
            btnPerformance.ForeColor = Color.Green;

            // Hide all panels
            panelBasicDetails.Visible = false;
            panelPersonalDetails.Visible = false;
            panelSalaryDetails.Visible = false;
            panelEducationalBackground.Visible = false;
            panelPreWorkExperience.Visible = false;
            panelPerformance.Visible = false;
        }

        private void btnOrganization_Click(object sender, EventArgs e)
        {
            ResetButtons(); // Reset button states and hide panels

            // Show relevant panels and update button colors
            panelMainContainer.Visible = true;
            panelBasicDetails.Visible = true;

            btnOrganization.FillColor = Color.FromArgb(19, 92, 61);
            btnOrganization.ForeColor = Color.White;
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            ResetButtons(); // Reset button states and hide panels

            // Show relevant panels and update button colors
            panelMainContainer.Visible = true;
            panelPersonalDetails.Visible = true;
            panelPersonalDetails.Location = new Point(28, 30);

            btnPersonal.FillColor = Color.FromArgb(19, 92, 61);
            btnPersonal.ForeColor = Color.White;

        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            ResetButtons(); // Reset button states and hide panels

            // Show relevant panels and update button colors
            panelMainContainer.Visible = true;
            panelSalaryDetails.Visible = true;
            panelSalaryDetails.Location = new Point(28, 30);

            btnSalary.FillColor = Color.FromArgb(19, 92, 61);
            btnSalary.ForeColor = Color.White;
        }

        private void btnEducation_Click(object sender, EventArgs e)
        {
            ResetButtons(); // Reset button states and hide panels

            // Show relevant panels and update button colors
            panelMainContainer.Visible = true;
            panelEducationalBackground.Visible = true;
            panelEducationalBackground.Location = new Point(28, 30);

            btnEducation.FillColor = Color.FromArgb(19, 92, 61);
            btnEducation.ForeColor = Color.White;
        }

        private void btnExperience_Click(object sender, EventArgs e)
        {
            ResetButtons(); // Reset button states and hide panels

            // Show relevant panels and update button colors
            panelMainContainer.Visible = true;
            panelPreWorkExperience.Visible = true;
            panelPreWorkExperience.Location = new Point(28, 30);

            btnExperience.FillColor = Color.FromArgb(19, 92, 61);
            btnExperience.ForeColor = Color.White;
        }

        private void btnPerformance_Click(object sender, EventArgs e)
        {
            ResetButtons(); // Reset button states and hide panels

            panelMainContainer.Visible = true;
            panelPerformance.Visible = true;
            panelPerformance.Location = new Point(150, 30);

            btnPerformance.FillColor = Color.FromArgb(19, 92, 61);
            btnPerformance.ForeColor = Color.White;
        }

        private void btnEditPersonal_Click(object sender, EventArgs e)
        {
            using (EmployeePersonal employeePersonal = new EmployeePersonal(_id))
            {
                employeePersonal.FormClosed += (s, args) => LoadProfile();
                employeePersonal.ShowDialog(this);
            }
        }

        private void btnEditEducationalBackground_Click_1(object sender, EventArgs e)
        {
            using (EmployeeEducation employeeEducation = new EmployeeEducation(_id))
            {
                employeeEducation.FormClosed += (s, args) => LoadProfile();
                employeeEducation.ShowDialog(this);
            }
        }

        private void btnEditPrevWorkExp_Click(object sender, EventArgs e)
        {
            using (EmployeePreviousWorkingExperience employeePreviousWorkingExperience = new EmployeePreviousWorkingExperience(_id))
            {
                employeePreviousWorkingExperience.FormClosed += (s, args) => LoadProfile();
                employeePreviousWorkingExperience.ShowDialog(this);
            }
        }
    }
}
