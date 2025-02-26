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
    public partial class EmployeeListCardForPayrollHistory : UserControl
    {
        private string _name;
        private string _id;
        private Image _image;
        private string _account;
        private string _employmentType;
        private string _ratePerHour;
        private FormEmployeePayrollManagement _employeePayrollManagement;

        public EmployeeListCardForPayrollHistory(FormEmployeePayrollManagement employeePayrollManagement)
        {
            InitializeComponent();
            if (employeePayrollManagement != null)
            {
                _employeePayrollManagement = employeePayrollManagement;
            }
        }

        [Category("Custom Control")]
        public string EmploymentType
        {
            get => _employmentType;
            set
            {
                _employmentType = value;
                btnEmploymentType.Text = value;
            }
        }

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
        public string Account
        {
            get => _account;
            set
            {
                _account = value;
                lblRateAccount.Text = value;
            }
        }

        [Category("Custom Control")]
        public string RatePerHour
        {
            get => _ratePerHour;
            set
            {
                _ratePerHour = value;
                lblRatePerHour.Text = value;
            }
        }

        private void btnViewPayrollHistory_Click(object sender, EventArgs e)
        {
            if (_employeePayrollManagement != null)
            {
                EmployeePayrollHistory employeePayrollHistory = new EmployeePayrollHistory(_id, _employeePayrollManagement);
                _employeePayrollManagement.panelPayrollDetails.Visible = false;
                _employeePayrollManagement.flowLayoutPanel3.Visible = true;
                _employeePayrollManagement.flowLayoutPanel3.Controls.Clear();
                _employeePayrollManagement.flowLayoutPanel3.Dock = DockStyle.Fill;
                _employeePayrollManagement.flowLayoutPanel3.Controls.Add(employeePayrollHistory);
            }
        }
    }
}