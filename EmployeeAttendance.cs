using System;
using System.Data;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    public partial class EmployeeAttendance : Form
    {
        public int id;
        private const string sql = @"SELECT attendance_id, tbl_employee.emp_id, emp_profilePic, tbl_employee.f_name, 
                                            tbl_employee.m_name, tbl_employee.l_name, 
                                            CONCAT(tbl_employee.f_name, ' ', LEFT(tbl_employee.m_name, 1), '. ', tbl_employee.l_name) AS FullName, 
                                            working_hours, time_in_status, DATE_FORMAT(time_in, '%h:%i %p') AS time_in_formatted,
                                            DATE_FORMAT(time_out, '%h:%i %p') AS time_out_formatted, time_in, time_out
                                            FROM tbl_employee
                                            INNER JOIN tbl_attendance ON tbl_employee.emp_id = tbl_attendance.emp_id
                                            WHERE is_deleted = 0 AND DATE(time_in) = CURDATE()
                                            ORDER BY time_in ASC";

        public EmployeeAttendance()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
        }

        private async void LoadAndRetrieveEmployeeAttendanceData()
        {
            try
            {
                DataTable dt = await Task.Run(() => DB_OperationHelperClass.QueryData(sql));

                flowLayoutPanel1.Controls.Clear();

                flowLayoutPanel1.SuspendLayout();

                foreach (DataRow row in dt.Rows)
                {
                    int id = int.Parse(row["emp_id"].ToString());
                    string firstName = row["f_name"].ToString();
                    string middleName = row["m_name"].ToString();
                    string lastName = row["l_name"].ToString();
                    string name = string.IsNullOrEmpty(middleName) || middleName == "N/A"
                                  ? $"{firstName} {lastName}"
                                  : $"{firstName} {middleName[0]}. {lastName}";

                    string imagePath = row["emp_profilePic"].ToString();
                    string timeInFormatted = row["time_in_formatted"].ToString();
                    string timeInStatus = row["time_in_status"].ToString();
                    string timeOutFormatted = row["time_out_formatted"] != DBNull.Value ? row["time_out_formatted"].ToString() : "Pending";

                    EmployeeAttendanceCard employeeAttendanceCard = new EmployeeAttendanceCard(this)
                    {
                        _id = id.ToString(),
                        CurrentDate = DateTime.Now.ToString("dddd, MMM. dd, yyyy"),
                        EmployeeProfilePic = Image.FromFile(imagePath),
                        EmployeeName = name,
                        ClockInTime = timeInFormatted,
                        Status = timeInStatus,
                        ClockOutTime = timeOutFormatted,
                    };

                    if (timeInStatus == "Late")
                    {
                        employeeAttendanceCard.btnStatus.ForeColor = Color.Red;
                        employeeAttendanceCard.btnStatus.Text = "LATE";
                        employeeAttendanceCard.btnStatus.HoverState.ForeColor = Color.Red;
                        employeeAttendanceCard.btnStatus.HoverState.BorderColor = Color.Red;
                    }
                    else
                    {
                        employeeAttendanceCard.btnStatus.ForeColor = Color.Green;
                        employeeAttendanceCard.btnStatus.Text = "ON TIME";
                        employeeAttendanceCard.btnStatus.HoverState.ForeColor = Color.Green;
                        employeeAttendanceCard.btnStatus.HoverState.BorderColor = Color.Green;
                    }

                    flowLayoutPanel1.Controls.Add(employeeAttendanceCard);
                }
                flowLayoutPanel1.ResumeLayout();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving employee attendance records: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CountAttendance()
        {
            DateTime currentDate = DateTime.Today;

            int countWorkingPresent = 0;
            int countWorkingOnTime = 0;
            int countWorkingLate = 0;

            string sqlCountAttendance = $"SELECT a.*, s.start_time, s.work_days FROM tbl_attendance a " +
                                         "INNER JOIN tbl_schedule s ON a.emp_id = s.emp_id " +
                                         $"WHERE DATE(a.time_in) = '{currentDate:yyyy-MM-dd}'";

            DataTable dtAttendance = DB_OperationHelperClass.QueryData(sqlCountAttendance);

            foreach (DataRow row in dtAttendance.Rows)
            {
                DateTime timeIn = (DateTime)row["time_in"];
                TimeSpan startTime = TimeSpan.Parse(row["start_time"].ToString());
                string workDays = row["work_days"].ToString();
                string currentDay = currentDate.DayOfWeek.ToString();

                // Check if today is a work day for the employee
                if (workDays.Contains(currentDay))
                {
                    countWorkingPresent++;

                    // Define working shift times for the employee
                    DateTime workingShiftStart = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, startTime.Hours, startTime.Minutes, 0);
                    DateTime gracePeriodEnd = workingShiftStart.AddMinutes(15);
                    DateTime workingShiftEnd = workingShiftStart.AddHours(8); // Assuming 8-hour shifts

                    if (timeIn <= gracePeriodEnd)
                    {
                        countWorkingOnTime++;
                    }
                    else if (timeIn > gracePeriodEnd && timeIn <= workingShiftEnd)
                    {
                        countWorkingLate++;
                    }
                }
            }

            dateOfCurrentAttendanceRecord.Text = currentDate.ToString("dddd, MMM. dd, yyyy");
            btnPresent.Text = countWorkingPresent.ToString();
            btnOnTime.Text = countWorkingOnTime.ToString();
            btnLate.Text = countWorkingLate.ToString();
        }

        private void EmployeeAttendance_Load(object sender, EventArgs e)
        {
            LoadAndRetrieveEmployeeAttendanceData();
            CountAttendance();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!dtpEmpSelectDate.Visible)
            {
                LoadAndRetrieveEmployeeAttendanceData();
                CountAttendance();
            }
        }

        private void EmployeeAttendance_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }

        private void btnViewPastAttendanceRecord_Click(object sender, EventArgs e)
        {
            dtpEmpSelectDate.Visible = true;
        }

        private async void dtpEmpSelectDate_ValueChanged(object sender, EventArgs e)
        {
            await LoadAttendanceDataForSelectedDate();
            CountAttendanceForSelectedDate();
        }

        private async Task LoadAttendanceDataForSelectedDate()
        {
            DateTime selectedDate = dtpEmpSelectDate.Value;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");
            string displayDate = selectedDate.ToString("dddd, MMM. dd, yyyy");

            string sql = $@"SELECT 
                            attendance_id, 
                            tbl_employee.emp_id, 
                            emp_profilePic, 
                            tbl_employee.f_name, 
                            tbl_employee.m_name, 
                            tbl_employee.l_name, 
                            CONCAT(tbl_employee.f_name, ' ', LEFT(tbl_employee.m_name, 1), '. ', tbl_employee.l_name) AS FullName, 
                            working_hours, 
                            time_in_status, 
                            DATE_FORMAT(time_in, '%h:%i %p') AS time_in_formatted,
                            DATE_FORMAT(time_out, '%h:%i %p') AS time_out_formatted, 
                            time_in, 
                            time_out
                            FROM 
                            tbl_employee
                            INNER JOIN 
                            tbl_attendance ON tbl_employee.emp_id = tbl_attendance.emp_id
                            WHERE 
                            is_deleted = 0 
                            AND DATE(time_in) = '{formattedDate}'";

            try
            {
                DataTable dt = await Task.Run(() => DB_OperationHelperClass.QueryData(sql));
                dateOfCurrentAttendanceRecord.Text = displayDate;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show(this, "No attendance records found for the selected date.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flowLayoutPanel1.Controls.Clear();
                    return;
                }

                flowLayoutPanel1.Controls.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    int id = int.Parse(row["emp_id"].ToString());
                    string firstName = row["f_name"].ToString();
                    string middleName = row["m_name"].ToString();
                    string lastName = row["l_name"].ToString();
                    string name = string.IsNullOrEmpty(middleName) || middleName == "N/A"
                                  ? $"{firstName} {lastName}"
                                  : $"{firstName} {middleName[0]}. {lastName}";

                    string imagePath = row["emp_profilePic"].ToString();
                    string timeInFormatted = row["time_in_formatted"].ToString();
                    string timeInStatus = row["time_in_status"].ToString();
                    string timeOutFormatted = row["time_out_formatted"] != DBNull.Value ? row["time_out_formatted"].ToString() : "Pending";

                    EmployeeAttendanceCard employeeAttendanceCard = new EmployeeAttendanceCard(this)
                    {
                        CurrentDate = displayDate,
                        _id = id.ToString(),
                        EmployeeProfilePic = Image.FromFile(imagePath),
                        EmployeeName = name,
                        ClockInTime = timeInFormatted,
                        Status = timeInStatus,
                        ClockOutTime = timeOutFormatted,
                    };

                    if (timeInStatus == "Late")
                    {
                        employeeAttendanceCard.btnStatus.ForeColor = Color.Red;
                        employeeAttendanceCard.btnStatus.Text = "LATE";
                        employeeAttendanceCard.btnStatus.HoverState.ForeColor = Color.Red;
                        employeeAttendanceCard.btnStatus.HoverState.BorderColor = Color.Red;
                    }
                    else
                    {
                        employeeAttendanceCard.btnStatus.ForeColor = Color.Green;
                        employeeAttendanceCard.btnStatus.Text = "ON TIME";
                        employeeAttendanceCard.btnStatus.HoverState.ForeColor = Color.Green;
                        employeeAttendanceCard.btnStatus.HoverState.BorderColor = Color.Green;
                    }

                    flowLayoutPanel1.Controls.Add(employeeAttendanceCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving employee attendance records: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CountAttendanceForSelectedDate()
        {
            DateTime selectedDate = dtpEmpSelectDate.Value;

            int countPresent = 0;
            int countOnTime = 0;
            int countLate = 0;

            string sqlCountAttendance = $"SELECT a.emp_id, a.time_in, s.start_time, s.work_days " +
                                         "FROM tbl_attendance a " +
                                         "INNER JOIN tbl_schedule s ON a.emp_id = s.emp_id " +
                                         $"WHERE DATE(a.time_in) = '{selectedDate:yyyy-MM-dd}'";

            DataTable dtAttendance = DB_OperationHelperClass.QueryData(sqlCountAttendance);

            foreach (DataRow row in dtAttendance.Rows)
            {
                string empId = row["emp_id"].ToString();
                DateTime timeIn = (DateTime)row["time_in"];
                TimeSpan startTime = TimeSpan.Parse(row["start_time"].ToString());
                string workDays = row["work_days"].ToString();
                string currentDay = selectedDate.DayOfWeek.ToString();

                // Check if today is a work day for the employee
                if (workDays.Contains(currentDay))
                {
                    countPresent++;

                    // Define working shift times for the employee
                    DateTime workingShiftStart = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, startTime.Hours, startTime.Minutes, 0);
                    DateTime gracePeriodEnd = workingShiftStart.AddMinutes(15);
                    DateTime workingShiftEnd = workingShiftStart.AddHours(8); // Assuming 8-hour shifts

                    if (timeIn <= gracePeriodEnd)
                    {
                        countOnTime++;
                    }
                    else if (timeIn > gracePeriodEnd && timeIn <= workingShiftEnd)
                    {
                        countLate++;

                        // Update the existing card color for late employees
                        foreach (EmployeeAttendanceCard card in flowLayoutPanel1.Controls)
                        {
                            if (card._id == empId)
                            {
                                card.btnStatus.BorderColor = Color.Red;
                                card.btnStatus.ForeColor = Color.Red;
                                card.btnStatus.HoverState.ForeColor = Color.Red;
                            }
                        }
                    }
                }
            }

            btnPresent.Text = countPresent.ToString();
            btnOnTime.Text = countOnTime.ToString();
            btnLate.Text = countLate.ToString();
        }
    }
}
