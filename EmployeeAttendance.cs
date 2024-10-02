using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    public partial class EmployeeAttendance : Form
    {
        public int id;
        private bool noRecordsShown = false;
        private const string sql = @"SELECT attendance_id, tbl_employee.emp_id, emp_profilePic, tbl_employee.f_name, 
                                           tbl_employee.m_name, tbl_employee.l_name, 
                                           CONCAT(tbl_employee.f_name, ' ', LEFT(tbl_employee.m_name, 1), '. ', tbl_employee.l_name) AS FullName, 
                                           working_hours, time_in_status, DATE_FORMAT(time_in, '%h:%i %p') AS time_in_formatted,
                                           DATE_FORMAT(time_out, '%h:%i %p') AS time_out_formatted, time_in, time_out
                                           FROM tbl_employee
                                           INNER JOIN tbl_attendance ON tbl_employee.emp_id = tbl_attendance.emp_id
                                           WHERE is_deleted = 0 AND DATE(time_in) = CURDATE()";

        public EmployeeAttendance()
        {
            InitializeComponent();
            timer1.Interval = 1000; // 1 second
            timer1.Tick += timer1_Tick; // Subscribe to the Tick event
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

        private async void LoadAndRetrieveEmployeeAttendanceData()
        {
            // Run the data retrieval in a background thread
            try
            {
                DataTable dt = await Task.Run(() => DB_OperationHelperClass.QueryData(sql));

                flowLayoutPanel1.Controls.Clear(); // Clear previous items

                if (dt.Rows.Count == 0)
                {
                    if (!noRecordsShown) // Check if the message has already been shown
                    {
                        MessageBox.Show("No records found for the current working schedule.", "No Records",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        noRecordsShown = true; // Set flag to true
                    }
                    return; // Exit if no records found
                }
                else
                {
                    noRecordsShown = false; // Reset the flag if records are found
                }

                foreach (DataRow row in dt.Rows)
                {
                    // Retrieve employee ID and full name
                    int id = int.Parse(row["emp_id"].ToString());
                    string firstName = row["f_name"].ToString();
                    string middleName = row["m_name"].ToString();
                    string lastName = row["l_name"].ToString();
                    string name;

                    // Construct the full name
                    if (string.IsNullOrEmpty(middleName) || middleName == "N/A")
                    {
                        name = $"{firstName} {lastName}"; // No middle name
                    }
                    else
                    {
                        name = $"{firstName} {middleName[0]}. {lastName}"; // With middle initial
                    }

                    // Directly load the employee profile picture
                    string imagePath = row["emp_profilePic"].ToString();

                    // Retrieve and format time in and time out
                    string timeInFormatted = row["time_in_formatted"].ToString();
                    string timeInStatus = row["time_in_status"].ToString();
                    string timeOutFormatted = row["time_out_formatted"] != DBNull.Value ? row["time_out_formatted"].ToString() : "Pending";

                    // Create the attendance card
                    EmployeeAttendanceCard employeeAttendanceCard = new EmployeeAttendanceCard()
                    {
                        _id = id.ToString(),
                        CurrentDate = DateTime.Now.ToString("dddd, MMM. dd, yyyy"), // Consider changing to attendance date if needed
                        EmployeeProfilePic = Image.FromFile(imagePath), // Directly loading the image
                        EmployeeName = name,
                        ClockInTime = timeInFormatted,
                        Status = timeInStatus,
                        ClockOutTime = timeOutFormatted,
                    };

                    flowLayoutPanel1.Controls.Add(employeeAttendanceCard);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving employee attendance records: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EmployeeAttendance_Load(object sender, EventArgs e)
        {
            LoadAndRetrieveEmployeeAttendanceData();
            timer1.Start(); // Start the timer
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadAndRetrieveEmployeeAttendanceData();
        }

        private void EmployeeAttendance_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
        }
    }
}