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
    public partial class EmployeeEducation : Form
    {
        string _id_ = "";
        public EmployeeEducation(string id_)
        {
            InitializeComponent();
            if (id_ != null)
            {
                this._id_ = id_;
            }
        }

        private void EmployeeEducation_Load(object sender, EventArgs e)
        {
            cboHighestEducAttObt.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;

            string sql = @"SELECT deg_obtained, field_of_study, major, institution, location, status, from_date, to_date, lic_cert 
                           FROM tbl_profile
                           INNER JOIN tbl_employee ON tbl_employee.emp_id = tbl_profile.emp_id
                           WHERE tbl_profile.emp_id = '" + _id_ + "' AND is_deleted = 0";

            DataTable dt = DB_OperationHelperClass.QueryData(sql);
            if (dt.Rows.Count > 0)
            {
                string degObtained = dt.Rows[0]["deg_obtained"].ToString();
                string fieldOfStudy = dt.Rows[0]["field_of_study"].ToString();
                string major = dt.Rows[0]["major"].ToString();
                string institution = dt.Rows[0]["institution"].ToString();
                string location = dt.Rows[0]["location"].ToString();
                string status = dt.Rows[0]["status"].ToString();
                string fromDate = dt.Rows[0]["from_date"].ToString();
                string toDate = dt.Rows[0]["to_date"].ToString();
                string licCert = dt.Rows[0]["lic_cert"].ToString();

                if (string.IsNullOrWhiteSpace(degObtained) && string.IsNullOrWhiteSpace(fieldOfStudy) &&
                    string.IsNullOrWhiteSpace(major) && string.IsNullOrWhiteSpace(institution) &&
                    string.IsNullOrWhiteSpace(location) && string.IsNullOrWhiteSpace(status) &&
                    string.IsNullOrWhiteSpace(fromDate) && string.IsNullOrWhiteSpace(toDate) &&
                    string.IsNullOrWhiteSpace(licCert))
                {
                    MessageBox.Show("Please add employee Educational Background Details.", "No Details Yet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                cboHighestEducAttObt.SelectedItem = degObtained;
                txtFieldOfStudy.Text = fieldOfStudy;
                txtMajor.Text = major;
                txtInstitutionName.Text = institution;
                txtLocation.Text = location;
                cboStatus.SelectedItem = status;
                txtYearStarted.Text = fromDate;
                txtYearFinished.Text = toDate;
                txtLicensesAndCertifications.Text = licCert;
            }
            else
            {
                MessageBox.Show("No records found to update.", "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation 
            var validationChecks = new List<Func<bool>>
            {
                 () => User_InputsValidatorHelperClass.ValidateGunaComboBoxSelection(cboHighestEducAttObt, "Highest Degree Obtained"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtFieldOfStudy, "Field of Study"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtMajor, "Major Subject"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtInstitutionName, "InstitutionName Name"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtLocation, "Location"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtInstitutionName, "InstitutionName Name"),
                 () => User_InputsValidatorHelperClass.ValidateGunaComboBoxSelection(cboStatus, "Status"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtYearStarted, "Year Started"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxAsYear(txtYearStarted, "Year Started"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtYearFinished, "Year Finished"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxAsYear(txtYearFinished, "Year Finished"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtLicensesAndCertifications, "Licenses and Certifications"),
            };

            // Iterate through the validation checks and return if any fail
            foreach (var check in validationChecks)
            {
                if (!check())
                    return;
            }

            string sql = @"
            UPDATE tbl_profile
            SET 
                deg_obtained = @deg_obtained,
                field_of_study = @field_of_study,
                major = @major,
                institution = @institution,
                location = @location,
                status = @status,
                from_date = @from_date,
                to_date = @to_date,
                lic_cert = @lic_cert
            WHERE emp_id = @id";

            // Create a dictionary to hold the parameters
            var parameters = new Dictionary<string, object>
            {
                { "@deg_obtained", cboHighestEducAttObt.SelectedItem.ToString() },
                { "@field_of_study", txtFieldOfStudy.Text },
                { "@major", txtMajor.Text },
                { "@institution", txtInstitutionName.Text },
                { "@location", txtLocation.Text },
                { "@status", cboStatus.SelectedItem.ToString() },
                { "@from_date", txtYearStarted.Text },
                { "@to_date", txtYearFinished.Text },
                { "@lic_cert", txtLicensesAndCertifications.Text },
                { "@id", _id_ }
            };

            // Check if the update was successful
            if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(sql, parameters))
            {
                MessageBox.Show("Record updated successfully!", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("No record was updated. Please check your input.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
