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
    public partial class EmployeeLeave : Form
    {
        string _id = "";
        EmployeeAttendance _attendance;

        public EmployeeLeave(string id, EmployeeAttendance employeeAttendance)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(id))
            {
                _id = id;
                _attendance = employeeAttendance;
            }

            this.MaximizeBox = false;
            this.MinimizeBox = false;
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

        private void EmployeeLeave_Load(object sender, EventArgs e)
        {
            cboLeaveType.SelectedIndex = 0;

            // Get employee details and profile picture
            LoadEmployeeProfile();

            // Check for active leave
            CheckActiveLeave();
        }

        private void LoadEmployeeProfile()
        {
            string sql = "SELECT emp_id, emp_profilePic, f_name, m_name, l_name FROM tbl_employee WHERE emp_id = @empId";
            var parameterGetEmployeeProfilePicture = new Dictionary<string, object>
            {{ "@empId", _id }};

            DataTable dt = DB_OperationHelperClass.ParameterizedQueryData(sql, parameterGetEmployeeProfilePicture);
            if (dt.Rows.Count > 0)
            {
                string firstName = dt.Rows[0]["f_name"].ToString();
                string middleName = dt.Rows[0]["m_name"].ToString();
                string lastName = dt.Rows[0]["l_name"].ToString();
                string name = string.IsNullOrEmpty(middleName) || middleName == "N/A"
                    ? $"{firstName} {lastName}"
                    : $"{firstName} {middleName[0]}. {lastName}";

                string empID = dt.Rows[0]["emp_id"].ToString();
                string imagePath = dt.Rows[0]["emp_profilePic"].ToString();

                employeeProfilePicture.Image = Image.FromFile(imagePath);
                lblEmployeeFullName.Text = "Name: " + name;
                lblID.Text = "ID: " + empID;
            }
        }

        private void CheckActiveLeave()
        {
            groupBox1.Text = "Active Leave Details";

            string sql = @"SELECT leave_type, start_date, end_date, date_requested, date_approved 
                           FROM tbl_leave 
                           WHERE emp_id = @empId AND end_date >= @today";
            var parameterCheckActiveLeave = new Dictionary<string, object>
            {
                { "@empId", _id },
                { "@today", DateTime.Now.Date }
            };

            DataTable dt = DB_OperationHelperClass.ParameterizedQueryData(sql, parameterCheckActiveLeave);
            if (dt.Rows.Count > 0)
            {
                // Populate fields with existing leave details
                var row = dt.Rows[0];
                cboLeaveType.SelectedItem = row["leave_type"].ToString();
                dtpLeaveStartDate.Value = Convert.ToDateTime(row["start_date"]);
                dtpLeaveEndDate.Value = Convert.ToDateTime(row["end_date"]);
                dtpLeaveRequestDate.Value = Convert.ToDateTime(row["date_requested"]);
                dtpLeaveApprovedDate.Value = Convert.ToDateTime(row["date_approved"]);

                lblLeaveDetailsInformation.Text = "Leave Information:";
                lblActiveLeaveStatus.Visible = true;
                btnCancel.Text = "Close";

                // Disable fields to prevent modifications
                DisableFields();
            }
        }

        private void DisableFields()
        {
            cboLeaveType.Enabled = false;
            dtpLeaveStartDate.Enabled = false;
            dtpLeaveEndDate.Enabled = false;
            dtpLeaveRequestDate.Enabled = false;
            dtpLeaveApprovedDate.Enabled = false;
            btnSaveEmployeeDetails.Enabled = false;
        }


        private void btnSaveEmployeeDetails_Click(object sender, EventArgs e)
        {
            // Only proceed if no active leave exists
            if (cboLeaveType.Enabled)
            {
                DateTime leaveRequestDate = dtpLeaveRequestDate.Value.Date;
                DateTime leaveApprovedDate = dtpLeaveApprovedDate.Value.Date;
                string leaveType = cboLeaveType.SelectedItem.ToString();
                DateTime leaveStartDate = dtpLeaveStartDate.Value.Date;
                DateTime leaveEndDate = dtpLeaveEndDate.Value.Date;
                DateTime createdAt = DateTime.Now;

                string insertLeaveSchedule = @"INSERT INTO tbl_leave (emp_id, date_requested, date_approved, leave_type, start_date, end_date, created_at)
                                       VALUES (@empId, @dateRequested, @dateApproved, @leaveType, @startDate, @endDate, @createdAt)";

                var parameterInsert = new Dictionary<string, object>
                {
                    { "@empId", _id },
                    { "@dateRequested", leaveRequestDate },
                    { "@dateApproved", leaveApprovedDate },
                    { "@leaveType", leaveType },
                    { "@startDate", leaveStartDate },
                    { "@endDate", leaveEndDate },
                    { "@createdAt", createdAt },
                };

                if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(insertLeaveSchedule, parameterInsert))
                {
                    MessageBox.Show("Leave Schedule Saved Successfully.", "Success");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Setting Leave Schedule Failed.", "Failure!");
                }
            }
            else
            {
                MessageBox.Show("An active leave exists. Please resolve it before adding a new leave schedule.", "Active Leave Detected");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmployeeLeave_FormClosing(object sender, FormClosingEventArgs e)
        {
            _attendance.PopulateEmployeeList();
        }
    }
}
