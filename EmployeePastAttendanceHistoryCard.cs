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
    public partial class EmployeePastAttendanceHistoryCard : UserControl
    {
        public string _id;
        private string _clockInTime;
        private string _clockOutTime;
        private string _attendanceDate;
        private string _status;
        private EmployeeAttendance _employeeAttendance;

        public EmployeePastAttendanceHistoryCard(EmployeeAttendance employeeAttendance)
        {
            InitializeComponent();
            _employeeAttendance = employeeAttendance;
        }

        [Category("Custom Control")]
        public string AttendanceDate
        {
            get => _attendanceDate;
            set
            {
                _attendanceDate = value;
                lblPastAttendanceDate.Text = value;
            }
        }

        [Category("Custom Control")]
        public string ID
        {
            get => _id;
            set
            {
                _id = value;
            }
        }

        [Category("Custom Control")]
        public string ClockInTime
        {
            get => _clockInTime;
            set
            {
                _clockInTime = value;
                lblTimeIn.Text = value;
            }
        }

        [Category("Custom Control")]
        public string ClockOutTime
        {
            get => _clockOutTime;
            set
            {
                _clockOutTime = value;
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
            }
        }
    }
}
