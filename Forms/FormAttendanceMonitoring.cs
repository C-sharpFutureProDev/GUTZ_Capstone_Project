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
    public partial class FormAttendanceMonitoring : Form
    {
        private const int BPO_REQUIRED_WORKING_HOURS = 8;
        public FormAttendanceMonitoring()
        {
            InitializeComponent();
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
            string retrieveAttendanceQuery = @"SELECT attendance_id, emp_profilePic, position_id, CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS FullName, 
                                 work_shift, working_hours, time_in_status,
                                 DATE_FORMAT(time_in, '%h:%i %p') AS time_in_formatted,
                                 DATE_FORMAT(time_out, '%h:%i %p') AS time_out_formatted
                                 FROM tbl_employee
                                 INNER JOIN tbl_attendance
                                 ON tbl_employee.emp_id = tbl_attendance.emp_id
                                 WHERE is_deleted = 0";

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
                    MessageBox.Show("No records found.", "No Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormAttendanceMonitoring_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAddTimeInTimeOut_Click(object sender, EventArgs e)
        {
            using (FormTimeInTimeOut formTimeInTimeOut = new FormTimeInTimeOut())
            {
                formTimeInTimeOut.FormClosed += (s, args) => LoadData();
                formTimeInTimeOut.ShowDialog(this);
            }
        }
    }
}