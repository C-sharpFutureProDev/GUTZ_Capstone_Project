using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    public partial class SamplePayrollReportsDetailsCard : UserControl
    {
        private string _name;
        private string _id;
        private string _payrollID;
        private string _wageID;
        private string _accountName;
        private string _ratePerHour;
        private string _payrollPeriod;
        private string _payrollCutDate;
        private string _payrollStatus;
        private string _totalAttendance;
        private string _totalTutoringHours;
        private string _totalLateTime;
        private string _totalGrossPay;
        private string _totalDeductions;
        private string _totalNetPay;

        public SamplePayrollReportsDetailsCard()
        {
            InitializeComponent();
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
        public string AccountName
        {
            get => _accountName;
            set
            {
                _accountName = value;
                lblAccountName.Text = value;
            }
        }

        [Category("Custom Control")]
        public string PayrollID
        {
            get => _payrollID;
            set
            {
                _payrollID = value;
                lblPayrollID.Text = value;
            }
        }

        [Category("Custom Control")]
        public string WageID
        {
            get => _wageID;
            set
            {
                _wageID = value;
                lblWageID.Text = value;
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

        [Category("Custom Control")]
        public string PayrollPeriod
        {
            get => _payrollPeriod;
            set
            {
                _payrollPeriod = value;
                lblPayrollPeriod.Text = value;
            }
        }

        [Category("Custom Control")]
        public string PayrollCutDate
        {
            get => _payrollCutDate;
            set
            {
                _payrollCutDate = value;
                lblPayrollCutDate.Text = value;
            }
        }

        [Category("Custom Control")]
        public string PayrollStatus
        {
            get => _payrollStatus;
            set
            {
                _payrollStatus = value;
                lblPayrollStatus.Text = value;
            }
        }

        [Category("Custom Control")]
        public string TotalAttendance
        {
            get => _totalAttendance;
            set
            {
                _totalAttendance = value;
                lblTotalAttendance.Text = value;
            }
        }

        [Category("Custom Control")]
        public string TotalTutoringHours
        {
            get => _totalTutoringHours;
            set
            {
                _totalTutoringHours = value;
                lblTotalTutoringHours.Text = value;
            }
        }

        [Category("Custom Control")]
        public string TotalLateTime
        {
            get => _totalLateTime;
            set
            {
                _totalLateTime = value;
                lblTotalLateTime.Text = value;
            }
        }

        [Category("Custom Control")]
        public string TotalGrossPay
        {
            get => _totalGrossPay;
            set
            {
                _totalGrossPay = value;
                lblComputedGrossPay.Text = value;
            }
        }

        [Category("Custom Control")]
        public string TotalDeductions
        {
            get => _totalDeductions;
            set
            {
                _totalDeductions = value;
                lblComputedDeductions.Text = value;
            }
        }

        [Category("Custom Control")]
        public string TotalNetPay
        {
            get => _totalNetPay;
            set
            {
                _totalNetPay = value;
                lblComputedNetPay.Text = value;
            }
        }
    }
}


