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
        string retrieveAttendanceQuery = @"SELECT attendance_id, emp_profilePic, position_id, CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS FullName, 
                                                     work_shift, 
                                                     DATE_FORMAT(time_in, '%h:%i %p') AS time_in_formatted,
                                                     DATE_FORMAT(time_out, '%h:%i %p') AS time_out_formatted
                                                     FROM tbl_employee
                                                     INNER JOIN tbl_attendance
                                                     ON tbl_employee.emp_id = tbl_attendance.emp_id";

        private const int BPO_REQUIRED_WORKING_HOURS = 8;
        public FormAttendanceMonitoring()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            this.DGVAttendance.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            DGVAttendance.Rows.Clear(); // Clear existing rows before loading new data
            DGVAttendance.AutoGenerateColumns = false;
            try
            {
                DataTable dt = DB_OperationHelperClass.QueryData(retrieveAttendanceQuery);
                foreach (DataRow row in dt.Rows)
                {
                    byte[] employee_profile_pic = (byte[])row["emp_profilePic"];
                    Image img;

                    using (MemoryStream ms = new MemoryStream(employee_profile_pic))
                    {
                        img = Image.FromStream(ms);
                    }

                    string f_name = row["FullName"].ToString();
                    string working_shift = row["work_shift"].ToString();
                    DateTime time_in = DateTime.Parse(row["time_in_formatted"].ToString());

                    DateTime time_out;
                    string time_out_formatted = row["time_out_formatted"].ToString();
                    bool hasTimeOut = DateTime.TryParse(time_out_formatted, out time_out);

                    string working_hours = (working_shift == "MORNING") ? "6AM - 2PM" : "2PM - 10PM";

                    string time_in_status;
                    TimeSpan lateTime = TimeSpan.Zero;
                    int currentYear = DateTime.Now.Year;
                    DateTime morningShiftStart = new DateTime(currentYear, 8, 16, 6, 0, 0);
                    DateTime nightShiftStart = new DateTime(currentYear, 8, 16, 14, 0, 0);

                    if (DateTime.Today.Month > 8)
                    {
                        morningShiftStart = new DateTime(currentYear, 9, 16, 6, 0, 0);
                        nightShiftStart = new DateTime(currentYear, 9, 16, 14, 0, 0);
                    }
                    else if (DateTime.Today.Month > 8 && DateTime.Today.Year > currentYear)
                    {
                        morningShiftStart = new DateTime(currentYear + 1, 9, 16, 6, 0, 0);
                        nightShiftStart = new DateTime(currentYear + 1, 9, 16, 14, 0, 0);
                    }

                    time_in_status = (time_in >= morningShiftStart && time_in < morningShiftStart.AddSeconds(1)) ? "On Time" :
                                     (time_in > morningShiftStart && working_shift == "MORNING") ? "Late" :
                                     (time_in >= nightShiftStart && time_in < nightShiftStart.AddSeconds(1)) ? "On Time" :
                                     (time_in > nightShiftStart && working_shift == "NIGHT") ? "Late" : "Unknown";

                    // Calculate the Late Time
                    if (time_in_status == "Late" && working_shift == "MORNING")
                        lateTime = time_in - morningShiftStart;
                    else if (time_in_status == "Late" && working_shift == "NIGHT")
                        lateTime = time_in - nightShiftStart;
                    else
                        lateTime = TimeSpan.Zero;

                    DGVAttendance.Rows.Add(img, f_name, working_shift, working_hours, time_in_status, time_in.ToString("hh:mm:ss tt").ToUpper(), "", BPO_REQUIRED_WORKING_HOURS.ToString() + " Hours");

                    if (!hasTimeOut)
                    {
                        DGVAttendance.Rows[DGVAttendance.Rows.Count - 1].Cells[6].Value = "Pending";
                        DGVAttendance.Rows[DGVAttendance.Rows.Count - 1].Cells[8].Value = "Pending";
                    }
                    else
                    {
                        DGVAttendance.Rows[DGVAttendance.Rows.Count - 1].Cells[6].Value = time_out.ToString("hh:mm:ss tt").ToUpper();
                        TimeSpan totalWorkingHours = time_out - time_in;
                        DGVAttendance.Rows[DGVAttendance.Rows.Count - 1].Cells[8].Value = totalWorkingHours.ToString(@"hh\:mm\:ss");
                    }
                }// end foreach
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving employee attendance records: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (DGVAttendance.Rows.Count == 0)
                    MessageBox.Show("No records found.", "No Records",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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