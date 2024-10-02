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
    public partial class EmployeePreviousWorkingExperience : Form
    {
        string _id_ = "";

        public EmployeePreviousWorkingExperience(string id_)
        {
            InitializeComponent();
            if (id_ != null)
            {
                this._id_ = id_;
            }
        }

        private void EmployeePreviousWorkingExperience_Load(object sender, EventArgs e)
        {
            string sql = @"SELECT prev_comp_name, prev_job_title, prev_comp_location, tenure, prev_role, supv_mgr
                           FROM tbl_profile
                           INNER JOIN tbl_employee ON tbl_employee.emp_id = tbl_profile.emp_id
                           WHERE tbl_profile.emp_id = '" + _id_ + "' AND is_deleted = 0";

            DataTable dt = DB_OperationHelperClass.QueryData(sql);
            if (dt.Rows.Count > 0)
            {
                string prevCompName = dt.Rows[0]["prev_comp_name"].ToString();
                string prevJobTitle = dt.Rows[0]["prev_job_title"].ToString();
                string prevCompLocation = dt.Rows[0]["prev_comp_location"].ToString();
                string prevJobTenure = dt.Rows[0]["tenure"].ToString();
                string prevJobSupervisorOrManager = dt.Rows[0]["supv_mgr"].ToString();
                string prevJobRole = dt.Rows[0]["prev_role"].ToString();

                if (string.IsNullOrWhiteSpace(prevCompName) && string.IsNullOrWhiteSpace(prevJobTitle) &&
                    string.IsNullOrWhiteSpace(prevCompLocation) && string.IsNullOrWhiteSpace(prevJobTenure) &&
                    string.IsNullOrWhiteSpace(prevJobRole) && string.IsNullOrWhiteSpace(prevJobSupervisorOrManager))
                {
                    MessageBox.Show("Please add previous job details.", "No Details Yet", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                txtPrevCompanyName.Text = prevCompName;
                txtPrevJobTitle.Text = prevJobTitle;
                txtPrevJovLocation.Text = prevCompLocation;
                txtPrevJobTenure.Text = prevJobTenure;
                txtPrevJobSupvrMngr.Text = prevJobSupervisorOrManager;
                txtPrevJobRole.Text = prevJobRole;
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
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtPrevCompanyName, "Previous Company Name"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtPrevJobTitle, "Previous Job Title"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtPrevJovLocation, "Previous Company Location"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtPrevJobTenure, "Previous Job Tenure"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtPrevJobSupvrMngr, "Previous Job Supervisor or Manager"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtPrevJobRole, "Previous Job Role"),
            };

            // Iterate through the validation checks and return if any fail
            foreach (var check in validationChecks)
            {
                if (!check())
                    return;
            }

            string sql = @"UPDATE tbl_profile
                   SET prev_comp_name = @prevCompName,
                       prev_job_title = @prevJobTitle,
                       prev_comp_location = @prevCompLocation,
                       tenure = @tenure,
                       prev_role = @prevRole,
                       supv_mgr = @supvMgr
                   WHERE emp_id = @empId";

            // Create a dictionary for parameters
            var parameters = new Dictionary<string, object>
            {
                { "@prevCompName", txtPrevCompanyName.Text },
                { "@prevJobTitle", txtPrevJobTitle.Text },
                { "@prevCompLocation", txtPrevJovLocation.Text },
                { "@tenure", txtPrevJobTenure.Text },
                { "@prevRole", txtPrevJobRole.Text },
                { "@supvMgr", txtPrevJobSupvrMngr.Text },
                { "@empId", _id_ }
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
