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
    public partial class SampleEmployeePayrollHistoryDetailsCard : UserControl
    {
        private string _payrollId;
        private string _payrollPeriod;
        private string _wageId;
        private string _cutDate;
        private string _payrollStatus;
        private string _name;
        private string _id;
        private string _account;
        private string _hoursWorked;
        private string _grossPay;
        private string _deductions;
        private string _netPay;

        public SampleEmployeePayrollHistoryDetailsCard()
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
        public string Account
        {
            get => _account;
            set
            {
                _account = value;
                lblRateAndType.Text = value;
            }
        }

        [Category("Custom Control")]
        public string PayrollId
        {
            get => _payrollId;
            set
            {
                _payrollId = value;
                lblPayrollID.Text = value;
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
        public string WageId
        {
            get => _wageId;
            set
            {
                _wageId = value;
                lblWageID.Text = value;
            }
        }

        [Category("Custom Control")]
        public string CutDate
        {
            get => _cutDate;
            set
            {
                _cutDate = value;
                lblCutDate.Text = value;
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
        public string HoursWorked
        {
            get => _hoursWorked;
            set
            {
                _hoursWorked = value;
                lblTotalHoursWorked.Text = value;
            }
        }

        [Category("Custom Control")]
        public string GrossPay
        {
            get => _grossPay;
            set
            {
                _grossPay = value;
                lblTotalGrossPay.Text = value;
            }
        }

        [Category("Custom Control")]
        public string Deductions
        {
            get => _deductions;
            set
            {
                _deductions = value;
                lblTotalDeductions.Text = value;
            }
        }

        [Category("Custom Control")]
        public string NetPay
        {
            get => _netPay;
            set
            {
                _netPay = value;
                lblTotalNetpay.Text = value;
            }
        }
    }
}