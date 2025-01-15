using GUTZ_Capstone_Project.Forms;
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
    public partial class EmployeeListCardForAttendanceHistory : UserControl
    {
        private string _name;
        private string _id;
        private Image _image;
        private string _role;
        private string[] _workDays;
        private string _scheduleWorkingHours;
        private EmployeeAttendance _employeeAttendance;

        public EmployeeListCardForAttendanceHistory(EmployeeAttendance employeeAttendance)
        {
            InitializeComponent();
            if (employeeAttendance != null)
            {
                _employeeAttendance = employeeAttendance;
            }

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnAddEmployeeLeaveSchedule, "Set Leave Schedule");
            toolTip.SetToolTip(btnUpdateSchedule, "Update Schedule");
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
        public string JobRole
        {
            get => _role;
            set
            {
                _role = value;
                lblJobRole.Text = value;
            }
        }

        [Category("Custom Control")]
        public string[] WorkDays
        {
            get => _workDays;
            set
            {
                _workDays = value;
                lblWorkingDays.Text = string.Join(", ", value.Select(day => day.Substring(0, 1).ToUpper()));
            }
        }

        [Category("Custom Control")]
        public string ScheduleWorkingHours
        {
            get => _scheduleWorkingHours;
            set
            {
                _scheduleWorkingHours = value;
                lblScheduleWorkingHours.Text = value;
            }
        }

        private void btnViewEmployeeAttendanceHistory_Click(object sender, EventArgs e)
        {
            if (_employeeAttendance != null)
            {
                EmployeeAttendanceHistory employeeAttendanceHistory = new EmployeeAttendanceHistory(_id, _employeeAttendance);
                _employeeAttendance.flowLayoutPanel2.Controls.Clear();
                _employeeAttendance.panelAttendanceDetails.Visible = false;
                _employeeAttendance.flowLayoutPanel2.Visible = true;
                _employeeAttendance.flowLayoutPanel2.Dock = DockStyle.Fill;
                _employeeAttendance.flowLayoutPanel2.Visible = true;
                _employeeAttendance.flowLayoutPanel2.Controls.Add(employeeAttendanceHistory);
            }
        }

        private void btnAddEmployeeLeaveSchedule_Click(object sender, EventArgs e)
        {
            if (_employeeAttendance != null)
            {
                EmployeeLeave employeeLeave = new EmployeeLeave(_id, _employeeAttendance);
                employeeLeave.ShowDialog();
            }
        }

        private void btnUpdateSchedule_Click(object sender, EventArgs e)
        {
            if (_employeeAttendance != null)
            {
                // Create an instance of EmployeeSchedule and pass the employee ID
                EmployeeSchedule employeeSchedule = new EmployeeSchedule(_id);

                // Show the dialog and check the result
                if (employeeSchedule.ShowDialog() == DialogResult.OK)
                {
                    // Retrieve the selected days and times from the employeeSchedule form
                    string[] selectedDays = employeeSchedule.SelectedDays;
                    TimeSpan startTime = employeeSchedule.StartTime;
                    TimeSpan endTime = employeeSchedule.EndTime;

                    // Update the schedule in the database
                    UpdateScheduleInDatabase(_id, selectedDays, startTime, endTime);

                    // Refresh the attendance list after updating the schedule
                    _employeeAttendance.ViewEmployeeList();
                }
            }
        }

        // Method to update the schedule in the database
        private void UpdateScheduleInDatabase(string empId, string[] selectedDays, TimeSpan startTime, TimeSpan endTime)
        {
            string workDays = string.Join(",", selectedDays);

            string updateScheduleSql = @"UPDATE tbl_schedule SET work_days = @WorkDays, start_time = @StartTime, end_time = @EndTime 
                                 WHERE emp_id = @EmpId";

            var scheduleParams = new Dictionary<string, object>
            {
                { "@EmpId", empId },
                { "@WorkDays", workDays },
                { "@StartTime", startTime.ToString(@"hh\:mm") },
                { "@EndTime", endTime.ToString(@"hh\:mm") }
            };

            if (!DB_OperationHelperClass.ExecuteCRUDSQLQuery(updateScheduleSql, scheduleParams))
            {
                MessageBox.Show("Failed to update schedule data.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
