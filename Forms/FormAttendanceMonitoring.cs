using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private const int ESL_REQUIRED_WORKING_HOURS = 4;

        public FormAttendanceMonitoring()
        {
            InitializeComponent();
            // Customize header and  button cell 
            this.DGVAttendance.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            LoadData();
        }

        private void LoadData()
        {
            DGVAttendance.AutoGenerateColumns = false;
            // Retrieve employee data and display to the DataGridView
            try
            {
                DataTable dt = DB_OperationHelperClass.QueryData(retrieveAttendanceQuery);
                if (dt.Rows.Count > 0)
                    DGVAttendance.DataSource = dt;
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
            
        }

        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            using (FormTimeInTimeOut formTimeInTimeOut = new FormTimeInTimeOut())
            {
                formTimeInTimeOut.FormClosed += (s, args) => LoadData();
                formTimeInTimeOut.ShowDialog(this);
            }
        }
    }
}
