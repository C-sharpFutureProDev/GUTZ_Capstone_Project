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
    public partial class SampleAttendanceReportsDetailsCard : UserControl
    {
        private string _name;
        private string _id;
        private string _scheduleID;
        private string _workDays;
        private string _startTime;
        private string _endTime;
        private string _attendancePeriod;
        private string _requiredTutoringHours;
        private string _attendancePeriodStatus;
        private string _totalWorkingDays;
        private string _totalPresentDays;
        private string _totalDaysAbsent;
        private string _totalDaysOnLeave;
        private string _totalDaysLate;
        private string _totalDaysOnTime;

        public SampleAttendanceReportsDetailsCard()
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
        public string ScheduleID
        {
            get => _scheduleID;
            set
            {
                _scheduleID = value;
               lblScheduleID.Text = value;
            }
        }

        [Category("Custom Control")]
        public string WorkDays
        {
            get => _workDays;
            set
            {
                _workDays = value;
                lblWorkingDays.Text = value;
            }
        }

        [Category("Custom Control")]
        public string StartTime
        {
            get => _startTime;
            set
            {
                _startTime = value;
                lblStartTime.Text = value;
            }
        }

        [Category("Custom Control")]
        public string EndTime
        {
            get => _endTime;
            set
            {
                _endTime = value;
                lblEndTime.Text = value;
            }
        }

        [Category("Custom Control")]
        public string AttendancePeriod
        {
            get => _attendancePeriod;
            set
            {
                _attendancePeriod = value;
                lblDateRange.Text = value;
            }
        }

        [Category("Custom Control")]
        public string RequiredTutoringHours
        {
            get => _requiredTutoringHours;
            set
            {
                _requiredTutoringHours = value;
                lblRequiredTutoringHoursPerDay.Text = value;
            }
        }

        [Category("Custom Control")]
        public string AttendancePeriodStatus
        {
            get => _attendancePeriodStatus;
            set
            {
                _attendancePeriodStatus = value;
                lblAttendancePeriodStatus.Text = value;
            }
        }

        [Category("Custom Control")]
        public string TotalWorkingDays
        {
            get => _totalWorkingDays;
            set
            {
                _totalWorkingDays = value;
                lblTotalWorkingDays.Text = value;
            }
        }

        [Category("Custom Control")]
        public string TotalPresentDays
        {
            get => _totalPresentDays;
            set
            {
                _totalPresentDays = value;
                lblTotalDaysPresent.Text = value;
            }
        }

        [Category("Custom Control")]
        public string TotalDaysAbsent
        {
            get => _totalDaysAbsent;
            set
            {
                _totalDaysAbsent = value;
                lblTotalDaysAbsent.Text = value;
            }
        }

        [Category("Custom Control")]
        public string TotalDaysOnLeave
        {
            get => _totalDaysOnLeave;
            set
            {
                _totalDaysOnLeave = value;
                lblTotalLeaveDays.Text = value;
            }
        }

        [Category("Custom Control")]
        public string TotalDaysLate
        {
            get => _totalDaysLate;
            set
            {
                _totalDaysLate = value;
                lblTotalDaysLate.Text = value;
            }
        }

        [Category("Custom Control")]
        public string TotalDaysOnTime
        {
            get => _totalDaysOnTime;
            set
            {
                _totalDaysOnTime = value;
                lblTotalDaysOnTime.Text = value;
            }
        }

    }
}


