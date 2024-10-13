using Org.BouncyCastle.Asn1.Cms;
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
    public partial class EmployeeSchedule : Form
    {

        public string[] SelectedDays { get; private set; }
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }

        string _empId = "";

        public EmployeeSchedule(string _empId_)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(_empId_))
            {
                this._empId = _empId_;
            }

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            cboStartAMOrPM.SelectedIndex = 0;
            cboEndAMOrPM.SelectedIndex = 0;
        }

        private void EmployeeSchedule_Load(object sender, EventArgs e)
        {
            if(_empId != null)
            {
                string sql = @"SELECT work_days, start_time, end_time
                   FROM tbl_schedule
                   WHERE emp_id = @EmpId";

                var parameters = new Dictionary<string, object>
    {
        { "@EmpId", _empId }
    };

                DataTable dt = DB_OperationHelperClass.ParameterizedQueryData(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    // Assume only one schedule per employee for simplicity
                    var row = dt.Rows[0];

                    // Populate the checkboxes for work days
                    string workDays = row["work_days"].ToString();
                    string[] daysArray = workDays.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var day in daysArray)
                    {
                        switch (day.Trim())
                        {
                            case "Monday":
                                chkBoxMonday.Checked = true;
                                break;
                            case "Tuesday":
                                chkBoxTuesday.Checked = true;
                                break;
                            case "Wednesday":
                                chkBoxWednesday.Checked = true;
                                break;
                            case "Thursday":
                                chkBoxThursday.Checked = true;
                                break;
                            case "Friday":
                                chkBoxFriday.Checked = true;
                                break;
                        }
                    }

                    // Populate start and end time
                    if (TimeSpan.TryParse(row["start_time"].ToString(), out TimeSpan startTime))
                    {
                        // Convert to 12-hour format
                        decimal startHours = (decimal)(startTime.Hours % 12 == 0 ? 12 : startTime.Hours % 12);
                        StartNumUpDown.Value = startHours + (decimal)(startTime.Minutes / 60.0); // Set up-down value with minutes

                        // Set AM/PM
                        cboStartAMOrPM.SelectedIndex = startTime.Hours >= 12 ? 1 : 0; // 1 for PM, 0 for AM
                    }

                    if (TimeSpan.TryParse(row["end_time"].ToString(), out TimeSpan endTime))
                    {
                        // Convert to 12-hour format
                        decimal endHours = (decimal)(endTime.Hours % 12 == 0 ? 12 : endTime.Hours % 12);
                        EndNumUpDown.Value = endHours + (decimal)(endTime.Minutes / 60.0); // Set up-down value with minutes

                        // Set AM/PM
                        cboEndAMOrPM.SelectedIndex = endTime.Hours >= 12 ? 1 : 0; // 1 for PM, 0 for AM
                    }
                }
            }
        }

        private void btnSaveSchedule_Click(object sender, EventArgs e)
        {
            var selectedDaysList = new List<string>();

            if (chkBoxMonday.Checked) selectedDaysList.Add("Monday");
            if (chkBoxTuesday.Checked) selectedDaysList.Add("Tuesday");
            if (chkBoxWednesday.Checked) selectedDaysList.Add("Wednesday");
            if (chkBoxThursday.Checked) selectedDaysList.Add("Thursday");
            if (chkBoxFriday.Checked) selectedDaysList.Add("Friday");

            SelectedDays = selectedDaysList.ToArray();

            // Convert Start Time
            int startHour = (int)StartNumUpDown.Value;
            if (cboStartAMOrPM.SelectedIndex == 1 && startHour < 12) // PM selected
            {
                startHour += 12;
            }
            else if (cboStartAMOrPM.SelectedIndex == 0 && startHour == 12) // AM selected and hour is 12
            {
                startHour = 0; // Convert 12 AM to 0 hours
            }
            StartTime = new TimeSpan(startHour, 0, 0); // Set minutes and seconds to 0

            // Convert End Time
            int endHour = (int)EndNumUpDown.Value;
            if (cboEndAMOrPM.SelectedIndex == 1 && endHour < 12) // PM selected
            {
                endHour += 12;
            }
            else if (cboEndAMOrPM.SelectedIndex == 0 && endHour == 12) // AM selected and hour is 12
            {
                endHour = 0; // Convert 12 AM to 0 hours
            }
            EndTime = new TimeSpan(endHour, 0, 0); // Set minutes and seconds to 0

            MessageBox.Show("Schedule saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
