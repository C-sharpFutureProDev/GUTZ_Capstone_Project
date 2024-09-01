using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project.Forms
{
    public partial class FormAttendanceManagement : Form
    {
        private const int BPO_REQUIRED_WORKING_HOURS = 8;
        public FormAttendanceManagement()
        {
            InitializeComponent();
            CountAttendance();
            // Initialize the timer
            timer1.Interval = 10;
            timer1.Tick += timer1_Tick;
            timer1.Start();
            DGVAttendance.Columns["Column2"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            DGVAttendance.Columns["Column3"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            DGVAttendance.Columns["Column9"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            DGVAttendance.Columns["Column4"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            DGVAttendance.Columns["Column5"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            DGVAttendance.Columns["Column6"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            DGVAttendance.Columns["Column7"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            DGVAttendance.Columns["Column8"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
        }

        // Fixed flicker issue on controls rendering
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void LoadData()
        {
            this.DGVAttendance.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            DGVAttendance.Rows.Clear(); // Clear existing rows before loading new data
            DGVAttendance.AutoGenerateColumns = false;

            // Get the current date and time
            DateTime currentDate = DateTime.Today;
            DateTime currentTime = DateTime.Now;

            // Define the time ranges for the morning and evening shifts
            DateTime morningShiftStart = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 6, 0, 0); // 6:00 AM
            DateTime morningShiftEnd = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 14, 0, 0); // 2:00 PM
            DateTime eveningShiftStart = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 18, 0, 0); // 6:00 PM
            DateTime eveningShiftEnd = currentDate.Date.AddDays(1).AddHours(6); // 6:00 AM (next day)

            string shiftCondition = "";

            if (currentTime >= morningShiftStart && currentTime <= morningShiftEnd)
                shiftCondition = "work_shift = 'MORNING'";
            else if (currentTime >= eveningShiftStart || currentTime <= eveningShiftEnd)
                shiftCondition = "work_shift = 'NIGHT'";

            string retrieveAttendanceQuery = $@"SELECT attendance_id, emp_profilePic, position_id, CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS FullName, 
                                                   work_shift, working_hours, time_in_status, DATE_FORMAT(time_in, '%h:%i %p') AS time_in_formatted,
                                                   DATE_FORMAT(time_out, '%h:%i %p') AS time_out_formatted
                                                FROM tbl_employee
                                                INNER JOIN tbl_attendance ON tbl_employee.emp_id = tbl_attendance.emp_id
                                                WHERE is_deleted = 0 AND DATE(time_in) = '{currentDate:yyyy-MM-dd}' AND {shiftCondition}";
            // ORDER BY kung sino ang pinaka-unang nag time in

            try
            {
                DataTable dt = DB_OperationHelperClass.QueryData(retrieveAttendanceQuery);
                foreach (DataRow row in dt.Rows)
                {
                    string image_path = row["emp_profilePic"].ToString();
                    string fullName = row["FullName"].ToString();
                    string working_shift = row["work_shift"].ToString();
                    string shift_duration = working_shift == "MORNING" ? "6AM - 2PM" : working_shift == "NIGHT" ? "6PM - 6AM" : "Unknown";
                    string time_in_status = row["time_in_status"].ToString();
                    string time_in_formatted = row["time_in_formatted"].ToString();
                    string time_out_formatted = row["time_out_formatted"].ToString();
                    string working_hours_str = row["working_hours"].ToString();

                    DateTime time_in = DateTime.ParseExact(time_in_formatted, "hh:mm tt", null);
                    DateTime? time_out = string.IsNullOrEmpty(time_out_formatted) ? (DateTime?)null : DateTime.ParseExact(time_out_formatted, "hh:mm tt", null);
                    string working_hours_display = "Pending";

                    if (!string.IsNullOrEmpty(working_hours_str))
                    {
                        TimeSpan working_hours = TimeSpan.Parse(working_hours_str);
                        working_hours_display = $"{(int)working_hours.TotalHours} Hrs, " +
                                                $"{working_hours.Minutes} mins, " +
                                                $"{working_hours.Seconds} secs";
                    }

                    DGVAttendance.Rows.Add(
                        System.Drawing.Image.FromFile(image_path),
                        fullName,
                        working_shift,
                        shift_duration,
                        time_in_status,
                        time_in.ToString("hh:mm:ss tt").ToUpper(),
                        time_out?.ToString("hh:mm:ss tt").ToUpper() ?? "Pending",
                        BPO_REQUIRED_WORKING_HOURS.ToString() + " Hours",
                        working_hours_display
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving employee attendance records: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (DGVAttendance.Rows.Count == 0)
                    MessageBox.Show("No records found for the current shift.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormAttendanceMonitoring_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        /*private void CountAttendance()
        {
            // Get the current date
            DateTime currentDate = DateTime.Today;

            // Define the time ranges for the morning and evening shifts
            DateTime morningShiftStart = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 6, 0, 0); // 6:00 AM
            DateTime morningShiftEnd = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 14, 0, 0); // 2:00 PM
            DateTime eveningShiftStart = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 18, 0, 0); // 6:00 PM
            DateTime eveningShiftEnd = currentDate.Date.AddDays(1).AddHours(6); // 6:00 AM (next day)

            // Add grace period of 15 minutes
            DateTime morningGracePeriodEnd = morningShiftStart.AddMinutes(15);
            DateTime eveningGracePeriodEnd = eveningShiftStart.AddMinutes(15);

            int countMorningPresent = 0;
            int countMorningOnTime = 0;
            int countMorningLate = 0;

            int countEveningPresent = 0;
            int countEveningOnTime = 0;
            int countEveningLate = 0;

            // Retrieve all records for the current day
            string sqlCountAttendance = $"SELECT * FROM tbl_attendance WHERE DATE(time_in) = '{currentDate.Date.ToString("yyyy-MM-dd")}'";
            DataTable dtAttendance = DB_OperationHelperClass.QueryData(sqlCountAttendance);

            foreach (DataRow row in dtAttendance.Rows)
            {
                DateTime timeIn = (DateTime)row["time_in"];

                // Check if the time-in is within the morning shift range
                if (timeIn >= morningShiftStart && timeIn <= morningShiftEnd)
                {
                    countMorningPresent++;
                    shiftLabelStatus.Text = "Today, Morning Shift";

                    if (timeIn <= morningGracePeriodEnd)
                    {
                        countMorningOnTime++;
                    }
                    else
                    {
                        countMorningLate++;
                    }
                    // Update the button texts for morning shift count
                    btnPresent.Text = countMorningPresent.ToString();
                    btnOnTime.Text = countMorningOnTime.ToString();
                    btnLate.Text = countMorningLate.ToString();
                }
                // Check if the time-in is within the evening shift range
                else if (timeIn >= eveningShiftStart || timeIn <= eveningShiftEnd)
                {
                    countEveningPresent++;
                    shiftLabelStatus.Text = "Today, Evening Shift";

                    if (timeIn <= eveningGracePeriodEnd)
                    {
                        countEveningOnTime++;
                    }
                    else
                    {
                        countEveningLate++;
                    }

                    // Update the button texts for evening shift count
                    btnPresent.Text = countEveningPresent.ToString();
                    btnOnTime.Text = countEveningOnTime.ToString();
                    btnLate.Text = countEveningLate.ToString();
                }
            }
        }*/

        private void CountAttendance()
        {
            // Get the current date and time
            DateTime currentDate = DateTime.Today;
            DateTime currentTime = DateTime.Now;

            // Define the time ranges for the morning and evening shifts
            DateTime morningShiftStart = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 6, 0, 0); // 6:00 AM
            DateTime morningShiftEnd = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 14, 0, 0); // 2:00 PM
            DateTime eveningShiftStart = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 18, 0, 0); // 6:00 PM
            DateTime eveningShiftEnd = currentDate.Date.AddDays(1).AddHours(6); // 6:00 AM (next day)

            // Add grace period of 15 minutes
            DateTime morningGracePeriodEnd = morningShiftStart.AddMinutes(15);
            DateTime eveningGracePeriodEnd = eveningShiftStart.AddMinutes(15);

            // Initialize counts
            int countMorningPresent = 0;
            int countMorningOnTime = 0;
            int countMorningLate = 0;

            int countEveningPresent = 0;
            int countEveningOnTime = 0;
            int countEveningLate = 0;

            // Retrieve all records for the current day
            string sqlCountAttendance = $"SELECT * FROM tbl_attendance WHERE DATE(time_in) = '{currentDate.Date.ToString("yyyy-MM-dd")}'";
            DataTable dtAttendance = DB_OperationHelperClass.QueryData(sqlCountAttendance);

            // Reset counts if shifts have ended
            if (currentTime > morningShiftEnd && currentTime < eveningShiftStart)
            {
                countMorningPresent = 0;
                countMorningOnTime = 0;
                countMorningLate = 0;
                btnPresent.Text = "0";
                btnOnTime.Text = "0";
                btnLate.Text = "0";
            }
            else if (currentTime > eveningShiftEnd)
            {
                countEveningPresent = 0;
                countEveningOnTime = 0;
                countEveningLate = 0;
                btnPresent.Text = "0";
                btnOnTime.Text = "0";
                btnLate.Text = "0";
            }

            foreach (DataRow row in dtAttendance.Rows)
            {
                DateTime timeIn = (DateTime)row["time_in"];

                // Check if the time-in is within the morning shift range
                if (timeIn >= morningShiftStart && timeIn <= morningShiftEnd)
                {
                    countMorningPresent++;
                    shiftLabelStatus.Text = "Today, Morning Shift";

                    if (timeIn <= morningGracePeriodEnd)
                    {
                        countMorningOnTime++;
                    }
                    else
                    {
                        countMorningLate++;
                    }
                }
                // Check if the time-in is within the evening shift range
                else if (timeIn >= eveningShiftStart && timeIn <= eveningShiftEnd)
                {
                    countEveningPresent++;
                    shiftLabelStatus.Text = "Today, Evening Shift";

                    if (timeIn <= eveningGracePeriodEnd)
                    {
                        countEveningOnTime++;
                    }
                    else
                    {
                        countEveningLate++;
                    }
                }
            }

            // Update the button texts for the current shift
            btnPresent.Text = (countMorningPresent + countEveningPresent).ToString();
            btnOnTime.Text = (countMorningOnTime + countEveningOnTime).ToString();
            btnLate.Text = (countMorningLate + countEveningLate).ToString();
        }

        private void btnAddTimeInTimeOut_Click(object sender, EventArgs e)
        {
            using (FormTimeInTimeOut formTimeInTimeOut = new FormTimeInTimeOut())
            {
                formTimeInTimeOut.FormClosed += (s, args) => LoadData();
                formTimeInTimeOut.ShowDialog(this);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CountAttendance();
        }
    }
}