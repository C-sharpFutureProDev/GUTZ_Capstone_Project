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
    public partial class SampleEmployeePayrollCard : UserControl
    {

        public string _id;
        private Image _image;
        private string _name;
        private string _tutoringHours;
        private string _lateTime;
        private string _deductions;
        private string _wage;
        private string _status;
        private string _payrollPeriod;

        public SampleEmployeePayrollCard()
        {
            InitializeComponent();
        }

        [Category("Custom Control")]
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                btnActivePayrollStatus.Text = value;
            }
        }

        [Category("Custom Control")]
        public string PayrollPeriod
        {
            get => _payrollPeriod;
            set
            {
                _payrollPeriod = value;
                btnPayrollPeriod.Text = value;
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
        public string TutoringHours
        {
            get => _tutoringHours;
            set
            {
                _tutoringHours = value;
                lblComputedTutoringHours.Text = value;
            }
        }

        [Category("Custom Control")]
        public string LateTime
        {
            get => _lateTime;
            set
            {
                _lateTime = value;
                lblComputedLateTime.Text = value;
            }
        }

        [Category("Custom Control")]
        public string Deductions
        {
            get => _deductions;
            set
            {
                _deductions = value;
                lblComputedDeductions.Text = value;
            }
        }

        [Category("Custom Control")]
        public string Wage
        {
            get => _wage;
            set
            {
                _wage = value;
                lblComputedWage.Text = value;
            }
        }

        private void btnViewEmployeeDetails_Click(object sender, EventArgs e)
        {

        }

        private void btnCutPayroll_Click(object sender, EventArgs e)
        {

        }
    }
}
