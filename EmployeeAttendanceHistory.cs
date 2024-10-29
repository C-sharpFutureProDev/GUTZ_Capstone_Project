using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    public partial class EmployeeAttendanceHistory : UserControl
    {
        private string _id = "";
        private EmployeeAttendance _employeeAttendance;

        public EmployeeAttendanceHistory(string empID, EmployeeAttendance employeeAttendance)
        {
            InitializeComponent();
            if (empID != null)
            {
                _id = empID;
            }

            _employeeAttendance = employeeAttendance;
        }

        // Fixed flicker user interface rendering
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void RetrieveEmployeeAttendanceHistory(string empID)
        {
            var employeeInfo = GetEmployeeInfo(empID);

            if (employeeInfo.StartDate == DateTime.MinValue)
            {
                MessageBox.Show("Start date not found for this employee.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var attendanceRecords = GetAttendanceRecords(empID, employeeInfo.StartDate);

            DisplayAttendanceRecords(attendanceRecords, employeeInfo);
            DisplayAttendanceStatistics(attendanceRecords, employeeInfo.StartDate);
        }

        private (DateTime StartDate, string ProfilePicPath, string FirstName, string MiddleName, string LastName) GetEmployeeInfo(string empID)
        {
            string sqlEmployeeInfo = @"SELECT start_date, emp_profilePic, f_name, m_name, l_name 
                                       FROM tbl_employee 
                                       WHERE emp_id = @empId AND is_deleted = 0";

            var parameters = new Dictionary<string, object> { { "@empId", empID } };
            DataTable dtEmployeeInfo = DB_OperationHelperClass.ParameterizedQueryData(sqlEmployeeInfo, parameters);

            DateTime startDate = dtEmployeeInfo.Rows.Count > 0 && dtEmployeeInfo.Rows[0]["start_date"] != DBNull.Value
                ? (DateTime)dtEmployeeInfo.Rows[0]["start_date"]
                : DateTime.MinValue;

            string profilePicPath = dtEmployeeInfo.Rows.Count > 0 && dtEmployeeInfo.Rows[0]["emp_profilePic"] != DBNull.Value
                ? dtEmployeeInfo.Rows[0]["emp_profilePic"].ToString()
                : null;

            string firstName = dtEmployeeInfo.Rows.Count > 0 ? dtEmployeeInfo.Rows[0]["f_name"].ToString() : "N/A";
            string middleName = dtEmployeeInfo.Rows.Count > 0 ? dtEmployeeInfo.Rows[0]["m_name"].ToString() : "N/A";
            string lastName = dtEmployeeInfo.Rows.Count > 0 ? dtEmployeeInfo.Rows[0]["l_name"].ToString() : "N/A";

            return (startDate, profilePicPath, firstName, middleName, lastName);
        }

        private DataTable GetAttendanceRecords(string empID, DateTime startDate)
        {
            string sqlAttendance = @"SELECT attendance_id, tbl_attendance.emp_id, emp_profilePic, time_in_status, 
                                     DATE_FORMAT(time_in, '%h:%i %p') AS time_in_formatted,
                                     DATE_FORMAT(time_out, '%h:%i %p') AS time_out_formatted, 
                                     time_in, time_out
                                     FROM tbl_attendance
                                     INNER JOIN tbl_employee ON tbl_attendance.emp_id = tbl_employee.emp_id
                                     WHERE tbl_employee.is_deleted = 0 
                                     AND tbl_employee.emp_id = @empId 
                                     AND DATE(tbl_attendance.time_in) >= @startDate";

            var parameters = new Dictionary<string, object>
            {
                { "@empId", empID },
                { "@startDate", startDate }
            };

            return DB_OperationHelperClass.ParameterizedQueryData(sqlAttendance, parameters);
        }

        private (TimeSpan StartTime, TimeSpan EndTime) GetScheduledTimesForEmployee(string empID)
        {
            // Query to retrieve start and end times from the schedule table
            string sqlSchedule = @"SELECT start_time, end_time 
                           FROM tbl_schedule 
                           WHERE emp_id = @empId";

            var parameters = new Dictionary<string, object> { { "@empId", empID } };
            DataTable dtSchedule = DB_OperationHelperClass.ParameterizedQueryData(sqlSchedule, parameters);

            if (dtSchedule.Rows.Count > 0)
            {
                string startTimeString = dtSchedule.Rows[0]["start_time"].ToString();
                string endTimeString = dtSchedule.Rows[0]["end_time"].ToString();

                TimeSpan startTime = TimeSpan.Parse(startTimeString);
                TimeSpan endTime = TimeSpan.Parse(endTimeString);

                return (startTime, endTime);
            }

            throw new InvalidOperationException("Schedule not found for the specified employee.");
        }

        // Usage in DisplayAttendanceRecords
        private void DisplayAttendanceRecords(DataTable dtAttendance, (DateTime StartDate, string ProfilePicPath, string FirstName, string MiddleName, string LastName) employeeInfo)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.SuspendLayout();

            HashSet<DateTime> attendanceDates = new HashSet<DateTime>();

            foreach (DataRow row in dtAttendance.Rows)
            {
                DateTime attendanceDate = DateTime.Parse(row["time_in"].ToString()).Date;
                attendanceDates.Add(attendanceDate);
            }

            for (DateTime date = employeeInfo.StartDate; date <= DateTime.Now; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }

                if (date == DateTime.Today)
                {
                    var scheduledTimes = GetScheduledTimesForEmployee(_id);

                    if (DateTime.Now.TimeOfDay < scheduledTimes.EndTime)
                    {
                        continue;
                    }
                }

                if (attendanceDates.Contains(date))
                {
                    DataRow row = dtAttendance.AsEnumerable().FirstOrDefault(r => DateTime.Parse(r["time_in"].ToString()).Date == date);
                    if (row != null)
                    {
                        EmployeeAttendanceCard employeeAttendanceCard = CreateAttendanceCard(row, date, employeeInfo, true);
                        flowLayoutPanel1.Controls.Add(employeeAttendanceCard);
                    }
                }
                else
                {
                    EmployeeAttendanceCard absentCard = CreateAttendanceCard(null, date, employeeInfo, false);
                    flowLayoutPanel1.Controls.Add(absentCard);
                }
            }

            flowLayoutPanel1.ResumeLayout();
        }


        private EmployeeAttendanceCard CreateAttendanceCard(DataRow row, DateTime date, (DateTime StartDate, string ProfilePicPath, string FirstName, string MiddleName, string LastName) employeeInfo, bool isPresent)
        {
            EmployeeAttendanceCard card = new EmployeeAttendanceCard(_employeeAttendance)
            {
                _id = employeeInfo.FirstName,
                CurrentDate = date.ToString("dddd, MMM. dd, yyyy"),
                EmployeeProfilePic = File.Exists(employeeInfo.ProfilePicPath) ? Image.FromFile(employeeInfo.ProfilePicPath) : null,
                EmployeeName = FormatEmployeeName(employeeInfo.FirstName, employeeInfo.MiddleName, employeeInfo.LastName),
                ClockInTime = isPresent ? row["time_in_formatted"].ToString() : "--",
                ClockOutTime = isPresent ? (row["time_out_formatted"] != DBNull.Value ? row["time_out_formatted"].ToString() : "Pending") : "--",
                Status = isPresent ? row["time_in_status"].ToString() : "--"
            };

            if (isPresent && row["time_in_status"].ToString() == "Late")
                card.btnStatus.Text = "LATE";

            card.btnAttendanceStatus.Visible = true;
            card.btnAttendanceStatus.Text = isPresent ? "Present" : "Absent";
            card.btnAttendanceStatus.FillColor = isPresent ? Color.ForestGreen : Color.FromArgb(255, 107, 107);
            card.Size = new Size(480, 259);
            card.panelEmployeeAttendanceDetails.Location = new Point(22, 24);
            card.btnAttendanceStatus.Location = new Point(320, 10);
            card.panelEmployeeAttendanceDetails.Size = new Size(445, 233);
            card.EmployeeListCardEmployeeDetailsCard.Size = new Size(300, 105);
            card.lblClockIn.Location = new Point(5, 19);
            card.lblClockInStatus.Location = new Point(95, 19);
            card.lblClockOut.Location = new Point(195, 19);
            card.btnClockIn.Location = new Point(1, 55);
            card.btnStatus.Location = new Point(94, 55);
            card.btnClockOut.Location = new Point(195, 55);

            return card;
        }

        private void DisplayAttendanceStatistics(DataTable dtAttendance, DateTime startDate)
        {
            int totalWorkingDays = 0;
            int totalPresentDays = 0;
            TimeSpan totalCheckInTime = TimeSpan.Zero;
            TimeSpan totalCheckOutTime = TimeSpan.Zero;

            for (DateTime date = startDate; date <= DateTime.Now; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }

                totalWorkingDays++;

                DataRow row = dtAttendance.AsEnumerable().FirstOrDefault(r => DateTime.Parse(r["time_in"].ToString()).Date == date);
                if (row != null)
                {
                    totalPresentDays++;
                    if (row["time_in"] != DBNull.Value)
                        totalCheckInTime += DateTime.Parse(row["time_in"].ToString()).TimeOfDay;
                    if (row["time_out"] != DBNull.Value)
                        totalCheckOutTime += DateTime.Parse(row["time_out"].ToString()).TimeOfDay;
                }
            }

            lblEmployeeTotalAttendance.Text = totalPresentDays.ToString();

            if (totalPresentDays > 0)
            {
                lblEmployeeAveTimeIn.Text = new TimeSpan(totalCheckInTime.Ticks / totalPresentDays).ToString(@"hh\:mm");
                lblEmployeeAveTimeOut.Text = new TimeSpan(totalCheckOutTime.Ticks / totalPresentDays).ToString(@"hh\:mm");
            }
            else
            {
                lblEmployeeAveTimeIn.Text = "--";
                lblEmployeeAveTimeOut.Text = "--";
            }

            double attendancePercentage = totalWorkingDays > 0 ? (totalPresentDays / (double)totalWorkingDays) * 100 : 0;
            lblEmployeeAttPerfPercemtage.Text = attendancePercentage.ToString("F2") + "%";
        }

        private string FormatEmployeeName(string firstName, string middleName, string lastName)
        {
            return middleName != "N/A" ? $"{firstName} {middleName[0]}. {lastName}" : $"{firstName} {lastName}";
        }

        private void EmployeeAttendanceHistory_Load(object sender, EventArgs e)
        {
            string employeeSql = @"SELECT emp_ProfilePic, CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS FullName, phone, email, position_desc
                                          FROM tbl_employee
                                          INNER JOIN tbl_position ON tbl_employee.position_id = tbl_position.position_id
                                          WHERE emp_id = @empId";

            var paramID = new Dictionary<string, object>
            {{ "@empId", _id }};

            DataTable employeeDt = DB_OperationHelperClass.ParameterizedQueryData(employeeSql, paramID);
            if (employeeDt.Rows.Count > 0)
            {
                string image_path = employeeDt.Rows[0]["emp_profilePic"].ToString();
                employeeProfilePicture.Image = System.Drawing.Image.FromFile(image_path);
                lblEmployeeName.Text = employeeDt.Rows[0]["FullName"].ToString();
                lblEmployeeJobRole.Text = employeeDt.Rows[0]["position_desc"].ToString();
                lblEmployeePhoneNumber.Text = employeeDt.Rows[0]["phone"].ToString();
                lblEmployeeEmail.Text = employeeDt.Rows[0]["email"].ToString();
            }

            RetrieveEmployeeAttendanceHistory(_id);
        }
    }
}