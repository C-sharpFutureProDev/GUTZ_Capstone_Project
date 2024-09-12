using GUTZ_Capstone_Project.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    public partial class EmployeeListCard : UserControl
    {
        private string _name;
        private string _id;
        private Image _image;
        private string _role;
        private string _email;
        private string _contact;
        private string _hireDate;
        private string _agentCode;
        public event EventHandler EmployeeDeleted;

        public EmployeeListCard()
        {
            InitializeComponent();
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnDeactivateEmployee, "Deactivate");
            toolTip.SetToolTip(btnEdit, "Update Record");
            toolTip.UseAnimation = false;
            toolTip.UseFading = false;

        }

        [Category("Custom Control")]
        public string EmployeeName
        {
            get => _name;
            set
            {
                _name = value;
                lblName.Text = value;
            }
        }

        [Category("Custom Control")]
        public string ID
        {
            get => _id;
            set
            {
                _id = value;
                lblID.Text = value;
            }
        }

        [Category("Custom Control")]
        public Image EmployeeProfilePic
        {
            get => _image;
            set
            {
                _image = value;
                employeeProfilePicture.Image = value;
            }
        }

        [Category("Custom Control")]
        public string JobRole
        {
            get => _role;
            set
            {
                _role = value;
                lblJobRole.Text = value;
            }
        }

        [Category("Custom Control")]
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                lblEmail.Text = value;
            }
        }


        [Category("Custom Control")]
        public string Contact
        {
            get => _contact;
            set
            {
                _contact = value;
                lblContactNo.Text = value;
            }
        }

        [Category("Custom Control")]
        public string JoinDate
        {
            get => _hireDate;
            set
            {
                _hireDate = value;
                lblJoinedDate.Text = value;
            }
        }

        [Category("Custom Control")]
        public string AgentCode
        {
            get => _agentCode;
            set
            {
                _agentCode = value;
                lblAgentCode.Text = value;
            }
        }

        private void btnViewProfile_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Open FormAddNewEmployee for editing with the employee ID
            using (FormAddNewEmployee formEditEmployee = new FormAddNewEmployee(_id))
            {
                formEditEmployee.FormClosed += (s, args) =>
                {
                    // Refresh the employee list in the parent form if needed
                    EmployeeDeleted?.Invoke(this, EventArgs.Empty);
                };
                formEditEmployee.ShowDialog();
            }
        }

        private void btnDeactivateEmployee_Click(object sender, EventArgs e)
        {
            // Display a confirmation message
            DialogResult result = MessageBox.Show("Are you sure you want to deactivate employee with ID: '" + _id + "'?",
                                           "Confirm Deactivation",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // SQL command for soft delete with parameterized query
                string softDeleteRecord = "UPDATE tbl_employee SET is_deleted = 1, deleted_at = CURRENT_TIMESTAMP WHERE emp_id = @id";
                var parameters = new Dictionary<string, object>
                                { { "@id", _id }  };

                // Execute SQL Delete Command
                if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(softDeleteRecord, parameters))
                {
                    MessageBox.Show("Selected employee deactivated successfully.",
                            "Deactivation Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    // Invoke the EmployeeDeleted event
                    EmployeeDeleted?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Failed to delete selected record.",
                                    "Record Deletion Unsuccessful",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}