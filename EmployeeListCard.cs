using GUTZ_Capstone_Project.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
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
        private string _joinDate;
        private string _rate;
        public event EventHandler EmployeeDeleted;
        public event EventHandler EmployeeDeactivated;
        private EmployeeList _employeeList;
        private static EmployeeListCard _activeCard = null;

        public EmployeeListCard(EmployeeList employeeList)
        {
            InitializeComponent();
            if (employeeList != null)
            {
                _employeeList = employeeList;
            }

            btnViewProfile.Click += btnViewProfile_Click;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnDeactivateEmployee, "Deactivate");
            toolTip.SetToolTip(btnEdit, "Update Profile");
            toolTip.SetToolTip(btnActivate, "Reactivate");
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
            get => _joinDate;
            set
            {
                _joinDate = value;
                lblJoinedDate.Text = value;
            }
        }

        [Category("Custom Control")]
        public string Rate
        {
            get => _rate;
            set
            {
                _rate = value;
                lblEmpRate.Text = value;
            }
        }

        private void ActivateCard()
        {
            btnViewProfile.FillColor = Color.Green;
            btnViewProfile.ForeColor = Color.White;
            btnViewProfile.Enabled = false;
        }

        private void DeactivateCard()
        {
            btnViewProfile.FillColor = Color.FromArgb(12, 90, 37); // Reset to default color
            btnViewProfile.Enabled = true;
        }

        private void btnViewProfile_Click(object sender, EventArgs e)
        {
            if (_activeCard != null && _activeCard != this)
            {
                // Reset the previous active card
                _activeCard.DeactivateCard();
            }

            // Set the current card as active
            _activeCard = this;
            ActivateCard();

            if (_employeeList != null)
            {
                foreach (var card in _employeeList.flowLayoutPanel1.Controls.OfType<EmployeeListCard>())
                {
                    // Update location for each card's panelEmployeeList
                    card.panelEmployeeList.Location = new Point(7, 25);
                }

                _employeeList.flowLayoutPanel1.BackColor = Color.Gray; // Change background color
                _employeeList.flowLayoutPanel1.Dock = DockStyle.Left; // Change docking style
                _employeeList.flowLayoutPanel1.Size = new Size(424, 1000); // Set size if needed

                // Show flowLayoutPanel2
                _employeeList.flowLayoutPanel2.Visible = true;
                _employeeList.flowLayoutPanel2.Dock = DockStyle.Fill;

                // Clear existing controls in flowLayoutPanel2
                _employeeList.flowLayoutPanel2.Controls.Clear();

                // Create and add the EmployeeProfileCard
                EmployeeProfile employeeProfileCard = new EmployeeProfile(_id, _employeeList);
                _employeeList.flowLayoutPanel2.Controls.Add(employeeProfileCard);

                // Refresh layout
                _employeeList.flowLayoutPanel1.Refresh();
                _employeeList.PerformLayout();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Open FormAddNewEmployee for editing with the employee ID
            using (FormAddNewEmployee formEditEmployee = new FormAddNewEmployee(_id, _employeeList))
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
                string deactivate = "UPDATE tbl_employee SET is_deleted = 1, deleted_at = CURRENT_TIMESTAMP WHERE emp_id = @id";
                var parameters = new Dictionary<string, object>
                { { "@id", _id }  };

                // Execute SQL soft delete
                if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(deactivate, parameters))
                {
                    MessageBox.Show("Selected employee deactivated successfully.",
                            "Deactivation Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    // Invoke the EmployeeDeleted event
                    EmployeeDeleted?.Invoke(this, EventArgs.Empty);
                    EmployeeDeactivated?.Invoke(this, EventArgs.Empty);
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

        private void btnActivate_Click(object sender, EventArgs e)
        {
            // Display a confirmation message
            DialogResult result = MessageBox.Show("Are you sure you want to activate employee with ID: '" + _id + "'?",
                                           "Confirm Deactivation",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // SQL query for update with parameterized query
                string reactivate = "UPDATE tbl_employee SET is_deleted = 0, deleted_at = NULL WHERE emp_id = @id";
                var parameters = new Dictionary<string, object>
                { { "@id", _id } };

                // Execute SQL update
                if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(reactivate, parameters))
                {
                    MessageBox.Show("Selected employee reactivated successfully.",
                            "Deactivation Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    // Invoke the EmployeeDeleted event
                    EmployeeDeleted?.Invoke(this, EventArgs.Empty);
                    EmployeeDeactivated?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Failed to reactivate selected record.",
                                    "Record Deletion Unsuccessful",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
