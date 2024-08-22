using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Windows.Controls.Primitives;
using System.Xml.Linq;
using DPFP;
using System.Drawing.Text;
using Org.BouncyCastle.Crypto;

namespace GUTZ_Capstone_Project.Forms
{
    public partial class FormEmployeeEnrollment : Form, DPFP.Capture.EventHandler
    {
        // Global variables declaration
        private DPFP.Capture.Capture Capturer;
        private DPFP.Processing.Enrollment Enroller;
        private DPFP.Verification.Verification Verifier = new DPFP.Verification.Verification();
        public delegate void OnTemplateEventHandler(DPFP.Template template);
        public event OnTemplateEventHandler OnTemplate;
        private byte[] fingerprintData;
        private string employeeProfilePicPath = "";
        private string _empId = "";
        private bool isResetButtonClicked = false;

        public FormEmployeeEnrollment(string empId_)
        {
            InitializeComponent();
            SetFormRegion();
            this.Size = new Size(1297, 950);
            progressPecentageStatus.Text = "[ + {0} + ' %' ]";

            // Add event handler for the department combo box SelectedIndexChanged event
            cboEmployeeDept.SelectedIndexChanged += cboEmployeeDept_SelectedIndexChanged;
            if (empId_ != null)
            {
                _empId = empId_;
            }
        }

        // Method to set the rounded rectangle region
        private void SetFormRegion()
        {
            int radius = 25; // Border radius
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90); // Top-left
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90); // Top-right
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90); // Bottom-right
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90); // Bottom-left
            path.CloseFigure();
            this.Region = new Region(path);
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

        private void FormEmployeeEnrollment_Load(object sender, EventArgs e)
        {
            try
            {
                Capturer = new DPFP.Capture.Capture(); // Create a capture operation 

                if (Capturer != null)
                    Capturer.EventHandler = this; // Subscribe for capturing events.
                else
                    SetPrompt("Can't initiate capture operation!");
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!");
            }

            Enroller = new DPFP.Processing.Enrollment();
            UpdateStatus();

            if (_empId != null)
            {
                string sql = @"SELECT emp_profilePic, fingerprint_data, f_name, m_name, l_name, agent_code, b_day, age, gender, address, email, phone, hired_date, department_name,
                                        position_type
                                        FROM tbl_employee
                                        INNER JOIN tbl_fingerprint 
                                        ON tbl_employee.emp_id = tbl_fingerprint.emp_id
                                        INNER JOIN tbl_department
                                        ON tbl_employee.department_id = tbl_department.department_id
                                        INNER JOIN tbl_position
                                        ON tbl_employee.position_id = tbl_position.position_id
                                        WHERE tbl_employee.emp_id = '" + _empId + "'";

                DataTable dt = DB_OperationHelperClass.QueryData(sql);
                if (dt.Rows.Count > 0)
                {
                    lblFormLabel.Text = "Update Employee Record";
                    //groupBox4.Visible = false;
                    txtEmployeeFirstName.Text = dt.Rows[0]["f_name"].ToString();
                    txtEmployeeMiddleIName.Text = dt.Rows[0]["m_name"].ToString();
                    txtEmployeeLastName.Text = dt.Rows[0]["l_name"].ToString();
                    string savedGender = txtEmployeeMiddleIName.Text = dt.Rows[0]["gender"].ToString();

                    rdbMale.Checked = (savedGender == "Male") ? true : false;
                    rdbFemale.Checked = (savedGender == "Male") ? false : true;

                    txtEmployeeAge.Text = dt.Rows[0]["age"].ToString();
                    dtpEmployeeDateOfBirth.Value = Convert.ToDateTime(dt.Rows[0]["b_day"]);
                    txtEmployeeContactNumber.Text = dt.Rows[0]["phone"].ToString();
                    txtEmployeeEmail.Text = dt.Rows[0]["email"].ToString();

                    string image_path = dt.Rows[0]["emp_profilePic"].ToString();
                    employeeProfilePicture.Image = System.Drawing.Image.FromFile(image_path);

                    byte[] f_data = (byte[])dt.Rows[0]["fingerprint_data"];
                    //display to picture box

                    string[] addressParts = dt.Rows[0]["address"].ToString().Split(',');
                    cboEmployeeCityMunicipality.SelectedItem = (addressParts.Length == 2) ? addressParts[1].Trim() : null;
                    txtEmployeeBrgyAddress.Text = (addressParts.Length == 2) ? addressParts[0].Trim() : string.Empty;

                    dtpEmployeeHiredDate.Value = Convert.ToDateTime(dt.Rows[0]["hired_date"]);
                    cboEmployeeDept.SelectedItem = dt.Rows[0]["department_name"].ToString();
                    txtEmployeeJobDesc.Text = dt.Rows[0]["position_type"].ToString();
                }
            }
        }

        // Finger Capturing, Enrollment Implementation
        #region
        private void UpdateStatus()
        {
            if (isResetButtonClicked)
            {
                // Reset the status and progress percentage to zero
                SetStatus("Fingerprint samples needed: 0");
                scanningProgressBar.Value = 0;
                progressPecentageStatus.Text = "0%";
            }
            else
            {
                // Show number of fingerprint samples needed for enrollment
                int samplesNeeded = (int)Enroller.FeaturesNeeded;
                SetStatus(String.Format("Fingerprint samples needed: {0}", samplesNeeded));

                // Update the progress bar
                int progressPercentage = (int)((float)(4 - samplesNeeded) / 4 * 100);
                scanningProgressBar.Value = progressPercentage;
                // Update the progress label status
                this.Invoke(new Action(() =>
                {
                    progressPecentageStatus.Text = $"{progressPercentage}%";
                }));
            }
        }

        private void MakeReport(string message)
        {
            this.Invoke(new Action(delegate ()
            {
                txtCaptureStatusLog.AppendText(message + "\r\n");
            }));
        }

        protected void SetPrompt(string prompt)
        {
            this.Invoke(new Action(delegate ()
            {
                txtScannerPrompt.Text = prompt;
            }));
        }

        protected void SetStatus(string status)
        {
            this.Invoke(new Action(delegate ()
            {
                lblSampleNeededStatus.Text = status;
            }));
        }

        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    SetPrompt("Using the fingerprint scanner. Please scan the employee finger.");
                }
                catch
                {
                    SetPrompt("Can't initiate capture operation!");
                }
            }
        }

        protected void Stop()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                    SetPrompt("Can't terminate capturer!");
                }
            }
        }

        private void UpdateStatus(int FAR)
        {
            SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
        }

        protected void Process(DPFP.Sample Sample)
        {
            try
            {
                string sql = @"SELECT fingerprint_data, fingerprint_id, tbl_fingerprint.emp_id, l_name 
                               FROM tbl_fingerprint 
                               INNER JOIN tbl_employee ON tbl_fingerprint.emp_id = tbl_employee.emp_id
                               WHERE is_deleted = 0";

                DataTable dataTable = DB_OperationHelperClass.QueryData(sql);
                bool isVerified = false;

                DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

                if (features == null)
                {
                    MessageBox.Show("Failed to extract features from the sample.", "Unverified");
                    return;
                }

                DrawPicture(ConvertSampleToBitmap(Sample));

                foreach (DataRow row in dataTable.Rows)
                {
                    byte[] f_data = (byte[])row["fingerprint_data"];
                    string emp_id = row["emp_id"].ToString();
                    string f_id = row["fingerprint_id"].ToString();
                    string l_name = row["l_name"].ToString();

                    using (MemoryStream memoryStream = new MemoryStream(f_data))
                    {
                        DPFP.Template Template = new DPFP.Template();
                        Template.DeSerialize(memoryStream);

                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                        Verifier.Verify(features, Template, ref result);
                        UpdateStatus(result.FARAchieved);

                        if (result.Verified)
                        {
                            isVerified = true;
                            if (isVerified)
                            {
                                MessageBox.Show($"Fingerprint matched with employee:\n" +
                                                 $"(Last Name: {l_name})\n" +
                                                 $"(Employee ID: {emp_id})\n" +
                                                 $"(Fingerprint ID: {f_id})",
                                                 "Employee Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        }
                    }
                }

                if (!isVerified)
                {
                    // Proceed with the enrollment process
                    DPFP.FeatureSet enrollmentFeatures = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);

                    if (enrollmentFeatures != null)
                    {
                        try
                        {
                            MakeReport("The fingerprint feature set was created.");
                            Enroller.AddFeatures(enrollmentFeatures); // Add feature set to template.
                        }
                        finally
                        {
                            UpdateStatus();

                            // Check if template has been created.
                            switch (Enroller.TemplateStatus)
                            {
                                case DPFP.Processing.Enrollment.Status.Ready: // report success and stop capturing
                                    DPFP.Template template = Enroller.Template;
                                    Enroller.Clear();
                                    OnTemplate?.Invoke(template);

                                    if (template != null)
                                        MessageBox.Show("The fingerprint template was ready for fingerprint verification.", "Enrollment Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                        MessageBox.Show("Fingerprint Enrollment was unsuccessful!", "Enrollment Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    // Prepare acquired fingerprint data for saving to the database
                                    using (MemoryStream fingerprintStream = new MemoryStream())
                                    {
                                        template.Serialize(fingerprintStream);
                                        fingerprintData = fingerprintStream.ToArray();
                                    }
                                    break;

                                case DPFP.Processing.Enrollment.Status.Failed:  // report failure and restart capturing
                                    Enroller.Clear();
                                    txtCaptureStatusLog.Clear();
                                    Stop();
                                    UpdateStatus();
                                    OnTemplate?.Invoke(null);
                                    Start();
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DrawPicture(Bitmap bitmap)
        {
            this.Invoke(new Action(delegate ()
            {
                employeeFingerprintImage.Image = new Bitmap(bitmap, employeeFingerprintImage.Size); // fit the image into the picture box
            }));
        }

        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();  // Create a sample convertor.
            Bitmap bitmap = null;                                                           // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);                                // TODO: return bitmap as a result
            return bitmap;
        }

        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction(); // Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features); // TODO: return features as a result
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
        }
        #endregion

        // Default Digital Persona Event Handler Members
        #region

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            MakeReport("The fingerprint sample was captured.");
            Process(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            //MakeReport("The finger was removed from the reader.");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The fingerprint reader was touched.");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("HID Digital Persona fingerprint scanner was connected.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("HID Digital Persona fingerprint scanner was disconnected!");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                MakeReport("The fingerprint sample is good.");
            else
                MakeReport("The fingerprint sample is poor!");
        }
        #endregion

        private OpenFileDialog openFileDialog2 = new OpenFileDialog
        {
            Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif) | *.jpg; *.jpeg; *.png; *.gif",
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        };

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                // Load the selected image into the PictureBox
                employeeProfilePicture.Image = Image.FromFile(openFileDialog2.FileName);

                // Get the file path
                employeeProfilePicPath = openFileDialog2.FileName;
            }
        }

        private void btnSaveEmployeeDetails_Click(object sender, EventArgs e)
        {
            // Create a list of validation checks foreach required input fields
            var validationChecks = new List<Func<bool>>
            {
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeFirstName, "First Name"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeLastName, "Last Name"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeMiddleIName, "Middle Name"),
                () => User_InputsValidatorHelperClass.ValidateGenderSelection(rdbMale, rdbFemale),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeAge, "Age"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxAsNumber(txtEmployeeAge, "Age"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeContactNumber, "Contact Number"),
                () => User_InputsValidatorHelperClass.ValidateEmailFormat(txtEmployeeEmail),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeEmail, "Email Address"),
                () => User_InputsValidatorHelperClass.ValidateProfilePicture(employeeProfilePicPath),
                () => User_InputsValidatorHelperClass.ValidateGunaComboBoxSelection(cboEmployeeCityMunicipality, "City/Municipality"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeBrgyAddress, "Barangay Address"),
                () => User_InputsValidatorHelperClass.ValidateGunaComboBoxSelection(cboEmployeeDept, "Department"),
                () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeJobDesc, "Job Title"),
                () => User_InputsValidatorHelperClass.ValidateFingerprintPicture(fingerprintData)
            };

            // Iterate through the validation checks and return if any fail
            foreach (var check in validationChecks)
            {
                if (!check())
                    return;
            }

            // Get all user input from all the required fields
            string fName = txtEmployeeFirstName.Text;
            string lName = txtEmployeeLastName.Text;
            string midName = txtEmployeeMiddleIName.Text;
            string gender = rdbMale.Checked ? "Male" : "Female";
            DateTime birthDate = dtpEmployeeDateOfBirth.Value.Date;
            int age = int.Parse(txtEmployeeAge.Text);
            string contactNo = txtEmployeeContactNumber.Text;
            string email = txtEmployeeEmail.Text;
            string cityOrMunicipality = cboEmployeeCityMunicipality.SelectedItem.ToString();
            DateTime hiredDate = dtpEmployeeHiredDate.Value.Date;

            Dictionary<string, (int deptID, int posID)> deptLookup = new Dictionary<string, (int, int)>
            {
                { "BPO Department", (1111, 21615) },
                { "ESL Department", (2222, 51912) }
            };
            (int deptID, int posID) = deptLookup[cboEmployeeDept.SelectedItem.ToString()];

            string agentCode = $"GUTZ-{fName}";
            string address = txtEmployeeBrgyAddress.Text + ", " + cboEmployeeCityMunicipality.SelectedItem;
            string sql = "";

            if (_empId == "") // add
            {
                sql = @"INSERT INTO tbl_employee (department_id, position_id, emp_profilePic, f_name, m_name, l_name, agent_code, b_day,
                                        age, gender, address, email, phone, hired_date) 
                                 VALUES (@deptID, @posID, @empProPicPath, @fName, @mName, @lName,
                                        @agentCode, @bDay, @age, @gender, @address, @email, 
                                        @phone, @hiredDate)";

                var parameterInsert = new Dictionary<string, object>
                {
                    { "@deptID", deptID },
                    { "@posID",  posID },
                    { "@empProPicPath", employeeProfilePicPath},
                    { "@fName", fName },
                    { "@mName", midName },
                    { "@lName", lName },
                    { "@agentCode", agentCode},
                    { "@bDay", birthDate },
                    { "@age", age },
                    { "@gender", gender },
                    { "@address", address },
                    { "@email", email },
                    { "@phone", contactNo },
                    { "@hiredDate", hiredDate }
                };

                int emp_id = 0;
                if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(sql, parameterInsert))
                {
                    DataTable dt = new DataTable();
                    string selectID = "SELECT emp_id FROM tbl_employee";
                    dt = DB_OperationHelperClass.QueryData(selectID);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            emp_id = int.Parse(row["emp_id"].ToString());
                        }
                    }

                    string insertIntoFingerprintTable = @"INSERT INTO tbl_fingerprint (fingerprint_data, emp_id)
                                 VALUES(@FingerprintData, @EmpId)";

                    var param = new Dictionary<string, object>
                    {
                        { "@FingerprintData", fingerprintData },
                        { "@EmpId", emp_id }
                    };

                    if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(insertIntoFingerprintTable, param))
                    {
                        DialogResult result = MessageBox.Show("New record has been saved successfully. Do you want to add another employee?",
                            "New Employee Added", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            // Clear the form and show it again for adding a new employee
                            Stop();
                            ClearForm();
                            this.Show();
                            Start();
                            btnStartScan.Enabled = false;
                        }
                        else
                            this.Close();
                    }
                    else
                        MessageBox.Show("Failed to add new record.", "Failed Adding New Employee!",
                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } // end if for add operation
            else // update
            {
                //pending
            }
        }

        private void ClearForm()
        {
            txtEmployeeFirstName.Clear();
            txtEmployeeLastName.Clear();
            txtEmployeeMiddleIName.Clear();
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            dtpEmployeeDateOfBirth.Value = DateTime.Now;
            txtEmployeeAge.Clear();
            txtEmployeeContactNumber.Clear();
            txtEmployeeEmail.Clear();
            employeeProfilePicture.Image = null;
            cboEmployeeCityMunicipality.SelectedItem = null;
            txtEmployeeBrgyAddress.Clear();
            dtpEmployeeHiredDate.Value = DateTime.Now;
            cboEmployeeDept.SelectedItem = null;
            txtEmployeeJobDesc.Clear();
            txtScannerPrompt.Clear();
            txtCaptureStatusLog.Clear();
            employeeFingerprintImage.Image = null;
            scanningProgressBar.Value = 0;
            isResetButtonClicked = true;
            UpdateStatus();
            isResetButtonClicked = false;
        }

        private void btnResetInputFields_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStartScan_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void FormEmployeeEnrollment_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
        }

        private void cboEmployeeDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboEmployeeDept.SelectedItem)
            {
                case "BPO Department":
                    txtEmployeeJobDesc.Text = "Call Center Agent";
                    break;
                case "ESL Department":
                    txtEmployeeJobDesc.Text = "English as a Second Language Teacher";
                    break;
                default:
                    cboEmployeeDept.SelectedItem = "";
                    txtEmployeeJobDesc.Text = "";
                    break;
            }
        }
    }
}
