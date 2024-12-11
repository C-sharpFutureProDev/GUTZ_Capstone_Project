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

        private void EmployeeAttendanceHistory_Load(object sender, EventArgs e)
        {
            try
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
                    string image_path = employeeDt.Rows[0]["emp_ProfilePic"].ToString();
                    employeeProfilePicture.Image = System.Drawing.Image.FromFile(image_path);
                    lblEmployeeName.Text = employeeDt.Rows[0]["FullName"].ToString();
                    lblEmployeeJobRole.Text = employeeDt.Rows[0]["position_desc"].ToString();
                    lblEmployeePhoneNumber.Text = employeeDt.Rows[0]["phone"].ToString();
                    lblEmployeeEmail.Text = employeeDt.Rows[0]["email"].ToString();
                }
                else
                {
                    MessageBox.Show("No attendance records found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}