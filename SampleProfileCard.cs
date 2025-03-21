﻿using GUTZ_Capstone_Project.Forms;
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
    public partial class SampleProfileCard : UserControl
    {
        private string _name;
        private string _id;
        private Image _image;
        private string _role;
        private string _account;
        private string _joinDate;
        private EmployeeList _employeeList;
        private static SampleProfileCard _activeCard = null;

        public SampleProfileCard(EmployeeList employeeList)
        {
            InitializeComponent();
            if (employeeList != null)
            {
                _employeeList = employeeList;
            }

            btnViewEmployeeDetails.Click += btnViewEmployeeDetails_Click;
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnActiveOrInactiveStatus, "Active");
            toolTip.SetToolTip(btnDeactivateEmployee, "Deactivate");
            toolTip.SetToolTip(btnEdit, "Update Profile");
            toolTip.SetToolTip(btnReactivateEmployee, "Reactivate");
            toolTip.SetToolTip(btnViewEmployeeDetails, "View Profile Details");
            toolTip.UseAnimation = false;
            toolTip.UseFading = false;
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
        public string Account
        {
            get => _account;
            set
            {
                _account = value;
                lblEmpRate.Text = value;
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Open FormAddNewEmployee for edit/update
            using (FormAddNewEmployee formEditEmployee = new FormAddNewEmployee(_id, _employeeList))
            {
                formEditEmployee.FormClosed += (s, args) => _employeeList.PopulateItems();
                formEditEmployee.FormClosed += (s, args) => _employeeList.CountActiveAndInactive();
                formEditEmployee.FormClosed += (s, args) => _employeeList.CountEmployeeListDetails();

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
                // SQL query for deactivation with parameterized query
                string deactivate = "UPDATE tbl_employee SET is_deleted = 1, deleted_at = CURRENT_TIMESTAMP WHERE emp_id = @id";
                var parameters = new Dictionary<string, object>
                { { "@id", _id }  };

                // Execute deactivation query
                if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(deactivate, parameters))
                {
                    // Display success deactivation message
                    MessageBox.Show("Selected employee deactivated successfully.",
                            "Deactivation Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    _employeeList.RefreshUI();
                    _employeeList.PopulateItems();
                    _employeeList.CountActiveAndInactive();
                    _employeeList.CountEmployeeListDetails();
                }
                else
                {
                    // Display failed deactivation message
                    MessageBox.Show("Failed to delete selected record.",
                                    "Record Deletion Unsuccessful",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            // Display a confirmation message for reactivation
            DialogResult result = MessageBox.Show("Are you sure you want to activate employee with ID: '" + _id + "'?",
                                           "Confirm Deactivation",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // SQL query for reactivation with parameterized query
                string reactivate = "UPDATE tbl_employee SET is_deleted = 0, deleted_at = NULL WHERE emp_id = @id";
                var parameters = new Dictionary<string, object>
                { { "@id", _id } };

                // Execute reactivation query
                if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(reactivate, parameters))
                {
                    // Display success reactivation message
                    MessageBox.Show("Selected employee reactivated successfully.",
                            "Deactivation Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    _employeeList.RefreshUI();
                    _employeeList.PopulateItems();
                    _employeeList.CountActiveAndInactive();
                    _employeeList.CountEmployeeListDetails();
                }
                else
                {
                    // Display failed reactivation message
                    MessageBox.Show("Failed to reactivate selected record.",
                                    "Record Deletion Unsuccessful",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
            }
        }

        private void ActivateCard()
        {
            btnViewEmployeeDetails.FillColor = Color.DarkCyan;
            btnViewEmployeeDetails.ForeColor = Color.White;
            btnViewEmployeeDetails.Enabled = false;
        }

        private void DeactivateCard()
        {
            btnViewEmployeeDetails.FillColor = Color.FromArgb(0, 121, 107); // Reset to default color
            btnViewEmployeeDetails.Enabled = true;
        }

        private void btnViewEmployeeDetails_Click(object sender, EventArgs e)
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
                foreach (var card in _employeeList.flowLayoutPanel1.Controls.OfType<SampleProfileCard>())
                {
                    // Update location for each card's
                    card.panelEmployeeListCard.Location = new Point(12, 20);
                }

                _employeeList.flowLayoutPanel1.Dock = DockStyle.Left; // Change docking style

                if (_employeeList.IsSearching == true)
                    _employeeList.flowLayoutPanel1.Size = new Size(376, 0);
                else
                    _employeeList.flowLayoutPanel1.Size = new Size(410, 0); // Set size if needed

                // Show flowLayoutPanel2
                _employeeList.flowLayoutPanel2.Visible = true;
                _employeeList.flowLayoutPanel2.Dock = DockStyle.Fill;

                // Clear existing controls in flowLayoutPanel2
                _employeeList.flowLayoutPanel2.Controls.Clear();

                // Query to check if the employee is an admin
                string query = @"SELECT tbl_employee.position_id, position_type 
                                        FROM tbl_employee 
                                 INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id 
                                 WHERE emp_id = '" + _id + "'";

                DataTable result = DB_OperationHelperClass.QueryData(query);

                /*if (result != null && result.Rows.Count > 0) // admin 
                {
                    DataRow row = result.Rows[0];
                    int positionId = Convert.ToInt32(row["position_id"]);
                    string positionType = row["position_type"].ToString();

                    if (positionId == 1101 && positionType == "Administrator")
                    {
                        // Display SampleAdminProfile for admin
                        SampleAdminProfile sampleAdminProfile = new SampleAdminProfile();
                        _employeeList.flowLayoutPanel2.Controls.Add(sampleAdminProfile);
                    }
                    else
                    {
                        // Display SampleEmployeeDetailsCard for regular employee
                        SampleEmployeeDetailsCard sampleEmployeeDetailsCard = new SampleEmployeeDetailsCard(_id, _employeeList);
                        _employeeList.flowLayoutPanel2.Controls.Add(sampleEmployeeDetailsCard);
                    }
                }*/

                if (result != null && result.Rows.Count > 0)
                {
                    DataRow row = result.Rows[0];
                    int positionId = Convert.ToInt32(row["position_id"]);
                    string positionType = row["position_type"].ToString();

                    // Display profile details card based on specified condition
                    var cardToAdd = (positionId == 1101 && positionType == "Administrator")
                        ? (Control)new SampleAdminProfile() // admin
                        : new SampleEmployeeDetailsCard(_id, _employeeList); // employee

                    _employeeList.flowLayoutPanel2.Controls.Add(cardToAdd);
                }

                // Refresh layout
                _employeeList.flowLayoutPanel1.Refresh();
                _employeeList.PerformLayout();
            }
        }
    }
}

