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
    public partial class SampleEmployeeDetailsCard : UserControl
    {
        private EmployeeList _employeeList;
        string _id = "";

        public SampleEmployeeDetailsCard(string _empID, EmployeeList employeeList)
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
            toolTip.SetToolTip(btnDeactivateEmployee, "Deactivate Employee");
            toolTip.SetToolTip(btnDeleteProfile, "Delete Profile");
            btnMaximize.Click += btnMaximize_Click;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (_employeeList != null)
            {
                // Disable auto-scrolling
                //_employeeList.flowLayoutPanel2.AutoScroll = false;

                // Hide the flow layout panel and the main panel
                _employeeList.flowLayoutPanel1.Visible = false;
                _employeeList.panelEmployeeListFeatures.Visible = false;

                // Make the minimize button visible and bring it to the front
                btnMinimize.Visible = true;
                //btnMinimize.BringToFront();
                btnMaximize.Visible = false;

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

                //btnMinimize.Visible = false;
                btnMaximize.Visible = true;
                //_employeeList.txtSearch.Clear();
                _employeeList.flowLayoutPanel1.Visible = true;
                _employeeList.panelEmployeeListFeatures.Visible = true;
            }
        }
    }
}
