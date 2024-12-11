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
        private string _status;
        private string _currentDate;
        private EmployeeAttendance _employeeAttendance;

        public EmployeePastAttendanceHistoryCard(EmployeeAttendance employeeAttendance)
        {
            InitializeComponent();
            _employeeAttendance = employeeAttendance;
        }

        [Category("Custom Control")]
        public string AttendanceDate
        {
            get => _currentDate;
            set
            {
                _currentDate = value;
                lblPastAttendanceDate.Text = value;
            }
        }

        [Category("Custom Control")]
        public string ClockInTime
        {
            get => _clockInTime;
            set
            {
                _clockInTime = value;
                btnClockIn.Text = value;
            }
        }

        [Category("Custom Control")]
        public string ClockOutTime
        {
            get => _clockOutTime;
            set
            {
                _clockOutTime = value;
                btnClockOut.Text = value;
            }
        }

        [Category("Custom Control")]
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                btnStatus.Text = _status;
            }
        }
    }
}
