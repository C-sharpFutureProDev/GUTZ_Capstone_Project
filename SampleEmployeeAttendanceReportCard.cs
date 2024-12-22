using Org.BouncyCastle.Asn1.Cmp;
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
    public partial class SampleEmployeeAttendanceReportCard : UserControl
    {
        private string _id;
        private string _name;
        private string _timeIn;
        private string _timeOut;
        private string _status;
        private string _lateTime;
        private string _computedTutoringHours;

        public SampleEmployeeAttendanceReportCard()
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
                lblName.Text = value;
            }
        }

        [Category("Custom Control")]
        public string TimeIn
        {
            get => _timeIn;
            set
            {
                _timeIn = value;
                lblTimeIn.Text = value;
            }
        }

        [Category("Custom Control")]
        public string TimeOut
        {
            get => _timeOut;
            set
            {
                _timeOut = value;
                lblTimeOut.Text = value;
            }
        }

        [Category("Custom Control")]
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                lblAttendanceStatus.Text = value;
            }
        }

        [Category("Custom Control")]
        public string LateTime
        {
            get => _lateTime;
            set
            {
                _lateTime = value;
                lblLateTime.Text = value;
            }
        }

        [Category("Custom Control")]
        public string ComputedTutoringHours
        {
            get => _computedTutoringHours;
            set
            {
                _computedTutoringHours = value;
                lblComputedTutoringHours.Text = value;
            }
        }
    }
}
