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
    public partial class SamplePastPayrollDetailsCard : UserControl
    {
        private string _id;
        private string _name;
        private int _totalAttendance;
        private string _totalTutoringHours;
        private decimal _totalGrossPay;
        private decimal _totalDeductions;
        private decimal _totalNetPay;

        public SamplePastPayrollDetailsCard()
        {
            InitializeComponent();
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
        public string EmployeeName
        {
            get => _name;
            set
            {
                _name = value;
                lblTutorsName.Text = value;
            }
        }

        [Category("Custom Control")]
        public int TotalAttendance
        {
            get => _totalAttendance;
            set
            {
                _totalAttendance = value;
                lblTotalAttendance.Text = value.ToString();
            }
        }

        [Category("Custom Control")]
        public string TotalTutoringHours
        {
            get => _totalTutoringHours;
            set
            {
                _totalTutoringHours = value;
                lblTotalTutoringHours.Text = value.ToString();
            }
        }

        [Category("Custom Control")]
        public decimal TotalGrossPay
        {
            get => _totalGrossPay;
            set
            {
                _totalGrossPay = value;
                lblTotalGrossPay.Text = value.ToString("C"); // Formats as currency
            }
        }

        [Category("Custom Control")]
        public decimal TotalDeductions
        {
            get => _totalDeductions;
            set
            {
                _totalDeductions = value;
                lblTotalDeductions.Text = value.ToString("C"); // Formats as currency
            }
        }

        [Category("Custom Control")]
        public decimal TotalNetPay
        {
            get => _totalNetPay;
            set
            {
                _totalNetPay = value;
                lblTotalNetPay.Text = value.ToString("C"); // Formats as currency
            }
        }
    }
}