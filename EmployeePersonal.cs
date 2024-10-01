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
    public partial class EmployeePersonal : Form
    {
        string _id_ = "";
        public EmployeePersonal(string id_)
        {
            InitializeComponent();
            if (id_ != null)
            {
                this._id_ = id_;
            }

            this.MaximizeBox = false;
            this.MinimizeBox = false;
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

        private void EmployeePersonal_Load(object sender, EventArgs e)
        {
            cboRelationship.SelectedIndex = 0;

            if (_id_ != null)
            {
                string sql = @"SELECT f_name, m_name, l_name, b_day, age, gender, civil_status, address, email, phone, emerg_contact, contact_person, 
                                      relationship
                              FROM tbl_employee
                              INNER JOIN tbl_profile ON tbl_employee.emp_id = tbl_profile.emp_id
                              WHERE tbl_employee.emp_id = '" + _id_ + "' AND is_deleted = 0";

                DataTable dt = DB_OperationHelperClass.QueryData(sql);
                if (dt.Rows.Count > 0)
                {
                    txtFirstName.Text = dt.Rows[0]["f_name"].ToString();
                    string middleName = dt.Rows[0]["m_name"].ToString();
                    txtMiddleName.Text = middleName == "N/A" ? "N/A" : middleName;
                    txtLastName.Text = dt.Rows[0]["l_name"].ToString();
                    string savedGender = dt.Rows[0]["gender"].ToString();
                    switch (savedGender)
                    {
                        case "Male":
                            cboGender.SelectedIndex = 0;
                            break;
                        case "Female":
                            cboGender.SelectedIndex = 1;
                            break;
                    }

                    cboCivilStatus.SelectedItem = dt.Rows[0]["civil_status"].ToString();
                    txtAge.Text = dt.Rows[0]["age"].ToString();
                    dtpDateOfBirth.Value = Convert.ToDateTime(dt.Rows[0]["b_day"]);
                    txtContactNumber.Text = dt.Rows[0]["phone"].ToString();
                    txtEmail.Text = dt.Rows[0]["email"].ToString();
                    txtEmergencyContact.Text = dt.Rows[0]["emerg_contact"].ToString();
                    string[] addressParts = dt.Rows[0]["address"].ToString().Split(',');
                    cboCityMunicipality.SelectedItem = (addressParts.Length == 2) ? addressParts[1].Trim() : null;
                    txtBrgyAddress.Text = (addressParts.Length == 2) ? addressParts[0].Trim() : string.Empty;

                    txtEmergencyContactPerson.Text = dt.Rows[0]["contact_person"].ToString();
                    cboRelationship.SelectedItem = dt.Rows[0]["relationship"].ToString();
                }
                else
                {
                    MessageBox.Show("No records found to update.", "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Validation 
            var validationChecks = new List<Func<bool>>
            {
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtFirstName, "First Name"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtLastName, "First Name"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtLastName, "First Name"),
                () => User_InputsValidatorHelperClass.ValidateGunaComboBoxSelection(cboGender, "Gender"),
                () => User_InputsValidatorHelperClass.ValidateGunaComboBoxSelection(cboCivilStatus, "Civil Status"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtAge, "Age"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtContactNumber, "Contact Number"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmail, "Email Address"),
                () => User_InputsValidatorHelperClass.ValidateEmailFormat(txtEmail),
                () => User_InputsValidatorHelperClass.ValidateGunaComboBoxSelection(cboCityMunicipality, "City/Municipality"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtBrgyAddress, "Barangay Address"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmergencyContact, "Emergency Contact Number"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmergencyContactPerson, "Emergency Contact Person"),
                () => User_InputsValidatorHelperClass.ValidateGunaComboBoxSelection(cboRelationship, "Relationship"),
            };

            // Iterate through the validation checks and return if any fail
            foreach (var check in validationChecks)
            {
                if (!check())
                    return;
            }

            // Construct the SQL update query for tbl_employee
            string sqlEmployee = @"UPDATE tbl_employee
                                    SET
                                        f_name = @fName,
                                        m_name = @mName,
                                        l_name = @lName,
                                        b_day = @bDay,
                                        age = @age,
                                        gender = @gender,
                                        civil_status = @civilStatus,
                                        address = @address,
                                        email = @email,
                                        phone = @phone,
                                        emerg_contact = @emergencyContact
                                    WHERE emp_id = @empId";

            // Construct the SQL update query for tbl_profile
            string sqlProfile = @"UPDATE tbl_profile
                                    SET
                                        contact_person = @contactPerson,
                                        relationship = @relationship
                                    WHERE emp_id = @empId";

            // Prepare the parameters for tbl_employee
            var parameterUpdateEmployee = new Dictionary<string, object>
            {
                { "@fName", txtFirstName.Text },
                { "@mName", txtMiddleName.Text },
                { "@lName", txtLastName.Text },
                { "@bDay", dtpDateOfBirth.Value },
                { "@age", txtAge.Text },
                { "@gender", cboGender.SelectedItem.ToString() },
                { "@civilStatus", cboCivilStatus.SelectedItem.ToString() },
                { "@address", $"{txtBrgyAddress.Text}, {cboCityMunicipality.SelectedItem}" },
                { "@email", txtEmail.Text },
                { "@phone", txtContactNumber.Text },
                { "@emergencyContact", txtEmergencyContact.Text },
                { "@empId", _id_ }
            };

            // Prepare the parameters for tbl_profile
            var parameterUpdateProfile = new Dictionary<string, object>
            {
                { "@contactPerson", txtEmergencyContactPerson.Text },
                { "@relationship", cboRelationship.SelectedItem.ToString() },
                { "@empId", _id_ }
            };

            // Execute the update queries
            bool employeeUpdateSuccess = DB_OperationHelperClass.ExecuteCRUDSQLQuery(sqlEmployee, parameterUpdateEmployee);
            bool profileUpdateSuccess = DB_OperationHelperClass.ExecuteCRUDSQLQuery(sqlProfile, parameterUpdateProfile);

            // Check if both updates were successful
            if (employeeUpdateSuccess && profileUpdateSuccess)
            {
                MessageBox.Show("Employee details updated successfully.", "Update Successful", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update employee details.", "Update Failed", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
