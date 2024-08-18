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
                    string image_path = row["emp_profilePic"].ToString();
                    string f_name = row["FullName"].ToString();
                    string working_shift = row["work_shift"].ToString();
                    DateTime time_in = DateTime.Parse(row["time_in_formatted"].ToString());

                    DateTime time_out;
                    string time_out_formatted = row["time_out_formatted"].ToString();
                    bool hasTimeOut = DateTime.TryParse(time_out_formatted, out time_out);

                    string working_hours = (working_shift == "MORNING") ? "6AM - 2PM" : "6PM - 6AM";

                    DateTime morningShiftStart = new DateTime(time_in.Year, time_in.Month, time_in.Day, 6, 0, 0); // 6:00 AM
                    DateTime morningShiftEnd = new DateTime(time_in.Year, time_in.Month, time_in.Day, 14, 0, 0); // 2:00 PM
                    DateTime eveningShiftStart = new DateTime(time_in.Year, time_in.Month, time_in.Day, 18, 0, 0); // 6:00 PM
                    DateTime eveningShiftEnd = new DateTime(time_in.Year, time_in.Month, time_in.Day + 1, 6, 0, 0); // 6:00 AM (next day)

                    // Add a 15-minute grace period
                    TimeSpan gracePeriod = TimeSpan.FromMinutes(15);

                    string time_in_status;
                    TimeSpan lateTime = TimeSpan.Zero;

                    // Determine time_in_status and calculate lateTime
                    if (working_shift == "MORNING")
                    {
                        if (time_in <= morningShiftStart.Add(gracePeriod))
                            time_in_status = "On Time";
                        else
                        {
                            time_in_status = "Late";
                            lateTime = time_in - morningShiftStart;
                        }
                    }
                    else if (working_shift == "NIGHT")
                    {
                        if (time_in <= eveningShiftStart.Add(gracePeriod))
                            time_in_status = "On Time";
                        else
                        {
                            time_in_status = "Late";
                            lateTime = time_in - eveningShiftStart;
                        }
                    }
                    else
                    {
                        time_in_status = "Unknown";
                        lateTime = TimeSpan.Zero;
                    }

                    DGVAttendance.Rows.Add(System.Drawing.Image.FromFile(image_path), f_name, working_shift, working_hours, time_in_status, time_in.ToString("hh:mm:ss tt").ToUpper(), "", BPO_REQUIRED_WORKING_HOURS.ToString() + " Hours");

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