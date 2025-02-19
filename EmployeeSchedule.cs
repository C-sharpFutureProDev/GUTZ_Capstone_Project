using Guna.UI2.WinForms;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    public partial class EmployeeSchedule : Form
    {
        public string[] SelectedDays { get; private set; }
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }

        string _empId = "";
        private bool isModified = false;

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

        // Override the OnFormClosing method
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (string.IsNullOrEmpty(_empId))
            {
                // Check if selectedDays is null or empty
                if (SelectedDays == null || SelectedDays.Length == 0)
                {
                    DialogResult result = MessageBox.Show("No work days selected. Are you sure you want to close?",
                        "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        e.Cancel = true; // Cancel the closing event
                    }
                }
            }
        }

        private void EmployeeSchedule_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_empId))
            {
                lblFormLabel.Text = "UPDATE CLASS SCHEDULE";
                LoadScheduleData();
            }
        }

        private void LoadScheduleData()
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
                var row = dt.Rows[0];

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
                        case "Saturday":
                            chkBoxSaturday.Checked = true;
                            break;
                        case "Sunday":
                            chkBoxSunday.Checked = true;
                            break;
                    }
                }

                // Set start and end times with minutes
                SetTime(row["start_time"].ToString(), StartNumUpDown, StartMinutesNumUpDown, cboStartAMOrPM);
                SetTime(row["end_time"].ToString(), EndNumUpDown, EndMinutesNumUpDown, cboEndAMOrPM);
            }
        }

        private void SetTime(string timeString, Guna2NumericUpDown numUpDown, Guna2NumericUpDown minutesNumUpDown, ComboBox amPmComboBox)
        {
            if (TimeSpan.TryParse(timeString, out TimeSpan time))
            {
                decimal hours = (decimal)(time.Hours % 12 == 0 ? 12 : time.Hours % 12);
                numUpDown.Value = hours; // Set hours
                minutesNumUpDown.Value = time.Minutes; // Set minutes

                amPmComboBox.SelectedIndex = time.Hours >= 12 ? 1 : 0; // AM/PM selection
            }
        }

        private void btnSaveSchedule_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }

            var selectedDaysList = new List<string>();

            if (chkBoxMonday.Checked) selectedDaysList.Add("Monday");
            if (chkBoxTuesday.Checked) selectedDaysList.Add("Tuesday");
            if (chkBoxWednesday.Checked) selectedDaysList.Add("Wednesday");
            if (chkBoxThursday.Checked) selectedDaysList.Add("Thursday");
            if (chkBoxFriday.Checked) selectedDaysList.Add("Friday");
            if (chkBoxSaturday.Checked) selectedDaysList.Add("Saturday");
            if (chkBoxSunday.Checked) selectedDaysList.Add("Sunday");

            SelectedDays = selectedDaysList.ToArray();
            StartTime = GetTimeFromControls(StartNumUpDown, StartMinutesNumUpDown, cboStartAMOrPM);
            EndTime = GetTimeFromControls(EndNumUpDown, EndMinutesNumUpDown, cboEndAMOrPM);

            MessageBox.Show("Schedule saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;

            isModified = false; // Reset modification flag after saving
            this.Close();
        }

        private bool ValidateInputs()
        {
            if (!chkBoxMonday.Checked && !chkBoxTuesday.Checked && !chkBoxWednesday.Checked &&
                !chkBoxThursday.Checked && !chkBoxFriday.Checked)
            {
                MessageBox.Show("Please select at least one working day from Monday to Sunday.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (StartNumUpDown.Value == 0 && StartMinutesNumUpDown.Value == 0)
            {
                MessageBox.Show("Please enter a valid start time schedule.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (EndNumUpDown.Value == 0 && EndMinutesNumUpDown.Value == 0)
            {
                MessageBox.Show("Please enter a valid end time schedule.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private TimeSpan GetTimeFromControls(Guna2NumericUpDown numUpDown, Guna2NumericUpDown minutesNumUpDown, ComboBox amPmComboBox)
        {
            int hour = (int)numUpDown.Value;
            int minutes = (int)minutesNumUpDown.Value;

            if (amPmComboBox.SelectedIndex == 1 && hour < 12)
            {
                hour += 12; // Convert PM hour to 24-hour format
            }
            else if (amPmComboBox.SelectedIndex == 0 && hour == 12)
            {
                hour = 0; // Convert 12 AM to 0 hours
            }

            return new TimeSpan(hour, minutes, 0); // Return TimeSpan with hours and minutes
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmployeeSchedule_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isModified)
            {
                DialogResult result = MessageBox.Show("You have unsaved changes. Would you like to save before closing?",
                    "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    btnSaveSchedule_Click(sender, e);
                }
                else if (result == DialogResult.No)
                {
                    MessageBox.Show("No changes were made to the current schedule.", "Current Schedule Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSaveSchedule_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void chkBoxMonday_CheckedChanged(object sender, EventArgs e)
        {
            isModified = true;
        }

        private void chkBoxTuesday_CheckedChanged(object sender, EventArgs e)
        {
            isModified = true;
        }

        private void chkBoxWednesday_CheckedChanged(object sender, EventArgs e)
        {
            isModified = true;
        }

        private void chkBoxThursday_CheckedChanged(object sender, EventArgs e)
        {
            isModified = true;
        }

        private void chkBoxFriday_CheckedChanged(object sender, EventArgs e)
        {
            isModified = true;
        }

        private void chkBoxSaturday_CheckedChanged(object sender, EventArgs e)
        {
            isModified = true;
        }

        private void chkBoxSunday_CheckedChanged(object sender, EventArgs e)
        {
            isModified = true;
        }

        private void StartNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            isModified = true;
        }

        private void EndNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            isModified = true;
        }
    }
}