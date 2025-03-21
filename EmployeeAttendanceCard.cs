﻿using System;
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
    public partial class EmployeeAttendanceCard : UserControl
    {
        public string _id;
        private Image _image;
        private string _name;
        private string _clockInTime;
        private string _clockOutTime;
        private string _status;
        private string _currentDate;
        private string _workedHours;
        private EmployeeAttendance _employeeAttendance;

        public EmployeeAttendanceCard(EmployeeAttendance employeeAttendance)
        {
            InitializeComponent();
            _employeeAttendance = employeeAttendance;
        }

        [Category("Custom Control")]
        public string CurrentDate
        {
            get => _currentDate;
            set
            {
                _currentDate = value;
                lblCurrentDate.Text = value;
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

        [Category("Custom Control")]
        public string WorkedHours
        {
            get => _workedHours;
            set
            {
                _workedHours = value;
                btnHoursWorked.Text = _workedHours;
            }
        }

    }
}
