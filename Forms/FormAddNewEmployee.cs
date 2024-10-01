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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using DPFP.Processing;

namespace GUTZ_Capstone_Project.Forms
{
    public partial class FormAddNewEmployee : Form, DPFP.Capture.EventHandler
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
        private bool isImageSelected = false;
        bool isFingerprintReEnrollNeeded = false;

        public FormAddNewEmployee(string empId_)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(empId_))
            {
                this._empId = empId_;
            }

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            progressPecentageStatus.Text = "[ + {0} + ' %' ]";
            cboEmployeeRateAccount.SelectedIndexChanged += cboEmployeeRateAccount_SelectedIndexChanged;
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
            txtScannerPrompt.Text = "Click <Start> to proceed with fingerprint enrollment.";
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
                string sql = @"SELECT emp_profilePic, tbl_account.account_id, account_name, fingerprint_data, f_name, m_name, l_name, b_day, age, gender, civil_status, address, email, phone, emerg_contact, hired_date,
                                        employment_type, work_arrangement, start_date, end_date, position_desc
                                        FROM tbl_employee
                                        INNER JOIN tbl_fingerprint 
                                        ON tbl_employee.emp_id = tbl_fingerprint.emp_id
                                        INNER JOIN tbl_department
                                        ON tbl_employee.department_id = tbl_department.department_id
                                        INNER JOIN tbl_position
                                        ON tbl_employee.position_id = tbl_position.position_id
                                        INNER JOIN tbl_account
                                        ON tbl_employee.account_id = tbl_account.account_id
                                        WHERE tbl_employee.emp_id = '" + _empId + "' AND is_deleted = 0";

                DataTable dt = DB_OperationHelperClass.QueryData(sql);
                if (dt.Rows.Count > 0)
                {
                    lblFormLabel.Text = "Update Existing Record";
                    btnSaveEmployeeDetails.Text = "SAVE CHANGES";
                    btnSaveEmployeeDetails.Size = new Size(190, 47);
                    btnReEnrollFingerPrint.Visible = true;
                    btnReEnrollFingerPrint.Location = new Point(250, 360);
                    txtScannerPrompt.Visible = false;
                    employeeFingerprintImage.Visible = false;
                    txtCaptureStatusLog.Visible = false;
                    lblSampleNeededStatus.Visible = false;
                    progressPecentageStatus.Visible = false;
                    scanningProgressBar.Visible = false;
                    btnStartScan.Visible = false;

                    txtEmployeeFirstName.Text = dt.Rows[0]["f_name"].ToString();

                    string middleName = dt.Rows[0]["m_name"].ToString();
                    txtEmployeeMiddleIName.Text = middleName == "N/A" ? "N/A" : middleName;

                    txtEmployeeLastName.Text = dt.Rows[0]["l_name"].ToString();
                    string savedGender = dt.Rows[0]["gender"].ToString();

                    rdbMale.Checked = (savedGender == "Male");
                    rdbFemale.Checked = (savedGender != "Male");

                    cboCivilStatus.SelectedItem = dt.Rows[0]["civil_status"].ToString();
                    txtEmployeeAge.Text = dt.Rows[0]["age"].ToString();
                    dtpEmployeeDateOfBirth.Value = Convert.ToDateTime(dt.Rows[0]["b_day"]);
                    txtEmployeeContactNumber.Text = dt.Rows[0]["phone"].ToString();
                    txtEmployeeEmail.Text = dt.Rows[0]["email"].ToString();
                    txtEmergContact.Text = dt.Rows[0]["emerg_contact"].ToString();

                    string image_path = dt.Rows[0]["emp_profilePic"].ToString();
                    employeeProfilePicture.Image = System.Drawing.Image.FromFile(image_path);

                    string[] addressParts = dt.Rows[0]["address"].ToString().Split(',');
                    cboEmployeeCityMunicipality.SelectedItem = (addressParts.Length == 2) ? addressParts[1].Trim() : null;
                    txtEmployeeBrgyAddress.Text = (addressParts.Length == 2) ? addressParts[0].Trim() : string.Empty;

                    dtpEmployeeHiredDate.Value = Convert.ToDateTime(dt.Rows[0]["hired_date"]);
                    int accID = int.Parse(dt.Rows[0]["account_id"].ToString());
                    switch (accID)
                    {
                        case 1:
                            cboEmployeeRateAccount.SelectedIndex = 0;
                            break;
                        case 2:
                            cboEmployeeRateAccount.SelectedIndex = 1;
                            break;
                        case 3:
                            cboEmployeeRateAccount.SelectedIndex = 2;
                            break;
                    }

                    string employmentType = dt.Rows[0]["employment_type"].ToString();
                    switch (employmentType)
                    {
                        case "Tenured":
                            cboEmploymentType.SelectedIndex = 1;
                            break;
                        case "Non-Tenured":
                            cboEmploymentType.SelectedIndex = 0;
                            break;
                    }

                    txtEmployeeAccountName.Text = dt.Rows[0]["account_name"].ToString();
                    cboWorkArrangement.SelectedItem = dt.Rows[0]["work_arrangement"].ToString();
                    dtpEmpStartDate.Value = Convert.ToDateTime(dt.Rows[0]["start_date"]);
                    txtStartDate.Text = dtpEmpStartDate.Value.ToString("MMMM dd, yyyy");
                    dtpEmpEndDate.Value = Convert.ToDateTime(dt.Rows[0]["end_date"]);
                    string positionLevel = dt.Rows[0]["position_desc"].ToString();
                    switch (positionLevel) 
                    {
                        case "ESL Department Head":
                            cboPositionLevel.SelectedIndex = 0;
                        break;
                        case "ESL Tutor":
                            cboPositionLevel.SelectedIndex = 1;
                        break;
                    }
                }
            } // end if
            else
            {
                MessageBox.Show("No records found to update.", "No Records Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
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
                SetStatus(String.Format("Fingerprint sample needed: {0}", samplesNeeded));

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
                    SetPrompt("Using the fingerprint scanner. Please scan right index finger 4 times.");
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
                bool isVerified = false;

                if (string.IsNullOrEmpty(_empId))
                {
                    // Verify First logic to check if the fingerprint data is already existing during addition of new record
                    string sql = @"SELECT fingerprint_data, fingerprint_id, tbl_fingerprint.emp_id, l_name 
                           FROM tbl_fingerprint 
                           INNER JOIN tbl_employee ON tbl_fingerprint.emp_id = tbl_employee.emp_id
                           WHERE is_deleted = 0";

                    DataTable dataTable = DB_OperationHelperClass.QueryData(sql);

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

                            if (result.Verified)
                            {
                                isVerified = true;
                                MessageBox.Show($"Fingerprint matched with employee:\n" +
                                                $"(Last Name: {l_name})\n" +
                                                $"(Employee ID: {emp_id})\n" +
                                                $"(Fingerprint ID: {f_id})",
                                                "Employee Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                        }
                    }
                }

                // Proceed with Enrollment to update existing biometrics data
                if (!isVerified || !string.IsNullOrEmpty(_empId))
                {
                    DrawPicture(ConvertSampleToBitmap(Sample));

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
                                    {
                                        MessageBox.Show("The fingerprint template was ready for fingerprint verification.", "Enrollment Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        // Prepare acquired fingerprint data for saving to the database
                                        using (MemoryStream fingerprintStream = new MemoryStream())
                                        {
                                            template.Serialize(fingerprintStream);
                                            fingerprintData = fingerprintStream.ToArray();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Fingerprint Enrollment was unsuccessful!", "Enrollment Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MakeReport("HID Digital Persona fingerprint scanner is disconnected!");
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

        private void btnUploadImage_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                // Load the selected image into the PictureBox
                employeeProfilePicture.Image = Image.FromFile(openFileDialog2.FileName);

                // Get the file path
                employeeProfilePicPath = openFileDialog2.FileName;

                // Set the flag to true
                isImageSelected = true;
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
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtDateOfBirth, "Birth Date"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeAge, "Age"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxAsNumber(txtEmployeeAge, "Age"),
                 () => User_InputsValidatorHelperClass.ValidateGenderSelection(rdbMale, rdbFemale),
                 () => User_InputsValidatorHelperClass.ValidateGunaComboBoxSelection(cboCivilStatus, "Civil Status"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeContactNumber, "Contact Number"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeEmail, "Email Address"),
                 () => User_InputsValidatorHelperClass.ValidateEmailFormat(txtEmployeeEmail),
                 () => User_InputsValidatorHelperClass.ValidateGunaComboBoxSelection(cboEmployeeCityMunicipality, "City/Municipality"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeBrgyAddress, "Barangay Address"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmergContact, "Emergency Contact Number"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtHireDate, "Hired Date"),
                 () => User_InputsValidatorHelperClass.ValidateGunaComboBoxSelection(cboEmployeeRateAccount, "Account Rate"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeAccountName, "Account Name"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtStartDate, "Start Date"),
                 () => User_InputsValidatorHelperClass.ValidateGunaComboBoxSelection(cboEmploymentType, "Employee Type"),
                 () => User_InputsValidatorHelperClass.ValidateGunaComboBoxSelection(cboWorkArrangement, "Employee Work Arrangement"),
                 () => User_InputsValidatorHelperClass.ValidateGunaComboBoxSelection(cboPositionLevel, "Employee Position Level"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEndDate, "End Date"),
                 () => User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEndDate, "End Date"),
            };

            // Add profile picture and fingerprint data validation only if adding a new employee
            if (string.IsNullOrEmpty(_empId))
            {
                validationChecks.Add(() => User_InputsValidatorHelperClass.ValidateProfilePicture(employeeProfilePicPath));
                validationChecks.Add(() => User_InputsValidatorHelperClass.ValidateFingerprintPicture(fingerprintData));
            }

            // Add fingerprint validation only if re-enrollment is needed during update
            if (isFingerprintReEnrollNeeded)
            {
                validationChecks.Add(() => User_InputsValidatorHelperClass.ValidateFingerprintPicture(fingerprintData));
            }

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
            int deptID = 1111;
            int posID = 0;
            int accountID = 0;
            string employmentType = "";
            string workArrangement = "";
            string civilStatus = "";
            string emergencyContactNo = txtEmergContact.Text;
            DateTime employeeStartDate = dtpEmpStartDate.Value.Date;
            DateTime employeeEndDate = dtpEmpEndDate.Value.Date;

            switch (cboCivilStatus.SelectedIndex)
            {
                case 0:
                    civilStatus = "Single";
                    break;
                case 1:
                    civilStatus = "Married";
                    break;
            }

            switch (cboEmploymentType.SelectedIndex)
            {
                case 0:
                    employmentType = "Non-Tenured";
                    break;
                case 1:
                    employmentType = "Tenured";
                    break;
            }

            switch (cboWorkArrangement.SelectedIndex)
            {
                case 0:
                    workArrangement = "Full-Time";
                    break;
                case 1:
                    workArrangement = "Part-Time";
                    break;
            }

            switch (cboPositionLevel.SelectedIndex)
            {
                case 0:
                    posID = 1101;
                    break;
                case 1:
                    posID = 2202;
                    break;
            }

            switch (cboEmployeeRateAccount.SelectedIndex)
            {
                case 0:
                    accountID = 1;
                    break;
                case 1:
                    accountID = 2;
                    break;
                case 2:
                    accountID = 3;
                    break;
            }

            string address = txtEmployeeBrgyAddress.Text + ", " + cboEmployeeCityMunicipality.SelectedItem;

            string sql = "";

            if (_empId == "") // add new employee record
            {
                sql = @"INSERT INTO tbl_employee (department_id, position_id, account_id, emp_profilePic, f_name, m_name, l_name, b_day,
                                        age, gender, civil_status, address, email, phone, emerg_contact, hired_date, employment_type, work_arrangement, start_date, end_date) 
                                 VALUES (@deptID, @posID, @accID, @empProPicPath, @fName, @mName, @lName, @bDay, @age, @gender, @civilStatus, @address, @email, 
                                        @phone, @emergencyContact, @hiredDate, @employmentType, @workArrangement, @startDate, @endDate )";

                var parameterInsert = new Dictionary<string, object>
                {
                    { "@deptID", deptID },
                    { "@posID",  posID },
                    { "@accID",  accountID },
                    { "@empProPicPath", employeeProfilePicPath},
                    { "@fName", fName },
                    { "@mName", midName },
                    { "@lName", lName },
                    { "@bDay", birthDate },
                    { "@age", age },
                    { "@gender", gender },
                    { "@civilStatus", civilStatus },
                    { "@address", address },
                    { "@email", email },
                    { "@phone", contactNo },
                    { "@emergencyContact", emergencyContactNo },
                    { "@hiredDate", hiredDate },
                    { "@employmentType", employmentType },
                    { "@workArrangement", workArrangement},
                    { "@startDate", employeeStartDate },
                    { "@endDate", employeeEndDate }
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
                        { "@FingerprintData", fingerprintData as byte[]},
                        { "@EmpId", emp_id }
                    };
                    if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(insertIntoFingerprintTable, param))
                    {
                        // Insert into the tbl_profile table
                        string insertIntoProfileTable = @"INSERT INTO tbl_profile (emp_id)
                                                          VALUES (@EmpId)";

                        var profileParam = new Dictionary<string, object>
                        {
                            { "@EmpId", emp_id }
                        };

                        if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(insertIntoProfileTable, profileParam))
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
                            }
                            else
                                this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add new record.", "Failed Adding New Profile!",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                        MessageBox.Show("Failed to add new record.", "Failed Adding New Employee!",
                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else // update existing employee record
            {
                string sqlUpdate;

                if (isImageSelected)
                {
                    sqlUpdate = @"UPDATE tbl_employee SET department_id = @deptID, position_id = @posID, account_id = @accID, emp_profilePic = @empProPicPath,
                     f_name = @fName, m_name = @mName, l_name = @lName, b_day = @bDay,
                     age = @age, civil_status = @civilStatus, gender = @gender, address = @address, email = @email, 
                     phone = @phone, emerg_contact = @emergencyContact, hired_date = @hiredDate, employment_type = @employmentType, 
                     work_arrangement = @workArrangement, start_date = @startDate, end_date = @endDate
                     WHERE emp_id = @empId";
                }
                else
                {
                    sqlUpdate = @"UPDATE tbl_employee SET department_id = @deptID, position_id = @posID, account_id = @accID,
                     f_name = @fName, m_name = @mName, l_name = @lName, b_day = @bDay,
                     age = @age, civil_status = @civilStatus, gender = @gender, address = @address, email = @email, 
                     phone = @phone, emerg_contact = @emergencyContact, hired_date = @hiredDate, employment_type = @employmentType, work_arrangement = @workArrangement,
                     start_date = @startDate, end_date = @endDate
                     WHERE emp_id = @empId";
                }

                var parameterUpdate = new Dictionary<string, object>
                {
                    { "@deptID", deptID },
                    { "@posID",  posID },
                    { "@accID",  accountID },
                    { "@fName", fName },
                    { "@mName", midName },
                    { "@lName", lName },
                    { "@bDay", birthDate },
                    { "@age", age },
                    { "@civilStatus", civilStatus },
                    { "@gender", gender },
                    { "@address", address },
                    { "@email", email },
                    { "@phone", contactNo },
                    { "@emergencyContact", emergencyContactNo},
                    { "@hiredDate", hiredDate },
                    { "@employmentType", employmentType },
                    { "@workArrangement", workArrangement },
                    { "@startDate", employeeStartDate },
                    { "@endDate", employeeEndDate },
                    { "@empId", _empId }
                };

                if (isImageSelected)
                {
                    parameterUpdate.Add("@empProPicPath", employeeProfilePicPath);
                }

                // Check if there is new fingerprint data
                byte[] newFingerprintData = fingerprintData as byte[];
                byte[] existingFingerprintData = null;

                if (newFingerprintData == null || newFingerprintData.Length == 0)
                {
                    // Retrieve existing fingerprint data from the database
                    string getFingerprintSql = @"SELECT fingerprint_data FROM tbl_fingerprint WHERE emp_id = @EmpId";
                    var param = new Dictionary<string, object> { { "@EmpId", _empId } };
                    DataTable dt = DB_OperationHelperClass.ParameterizedQueryData(getFingerprintSql, param);
                    if (dt.Rows.Count > 0)
                    {
                        existingFingerprintData = (byte[])dt.Rows[0]["fingerprint_data"];
                    }
                }

                if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(sqlUpdate, parameterUpdate))
                {
                    // Use new fingerprint data if available; otherwise, use existing data
                    byte[] fingerprintDataToUse = newFingerprintData ?? existingFingerprintData;

                    if (fingerprintDataToUse != null)
                    {
                        string updateFingerprintTable = @"UPDATE tbl_fingerprint SET fingerprint_data = @FingerprintData WHERE emp_id = @EmpId";

                        var param = new Dictionary<string, object>
                        {
                            { "@FingerprintData", fingerprintDataToUse },
                            { "@EmpId", _empId }
                        };

                        if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(updateFingerprintTable, param))
                        {
                            MessageBox.Show($"Employee record for Employee with ID {_empId} has been updated successfully.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to update fingerprint data.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No fingerprint data available to update.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to update employee record.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void ClearForm()
        {
            txtEmployeeFirstName.Clear();
            txtEmployeeLastName.Clear();
            txtEmployeeMiddleIName.Clear();
            txtDateOfBirth.Clear();
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            txtEmployeeAge.Clear();
            txtEmployeeContactNumber.Clear();
            txtEmployeeEmail.Clear();
            employeeProfilePicture.Image = null;
            cboEmployeeCityMunicipality.SelectedItem = null;
            txtEmployeeBrgyAddress.Clear();
            txtEmergContact.Clear();
            txtHireDate.Clear();
            cboEmployeeRateAccount.SelectedItem = null;
            txtEmployeeAccountName.Clear();
            txtStartDate.Clear();
            txtScannerPrompt.Clear();
            txtCaptureStatusLog.Clear();
            employeeFingerprintImage.Image = null;
            scanningProgressBar.Value = 0;
            cboCivilStatus.SelectedItem = null;
            cboEmploymentType.SelectedItem = null;
            cboWorkArrangement.SelectedItem = null;
            cboPositionLevel.SelectedItem = null;
            txtEndDate.Clear();
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
            txtCaptureStatusLog.Clear();
        }

        private void FormEmployeeEnrollment_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
        }

        private void cboEmployeeRateAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboEmployeeRateAccount.SelectedItem)
            {
                case "ESO RATE":
                    txtEmployeeAccountName.Text = "ESO";
                    break;
                case "RKESI RATE":
                    txtEmployeeAccountName.Text = "RKESI";
                    break;
                case "VUIHOC RATE":
                    txtEmployeeAccountName.Text = "VUIHOC";
                    break;
                default:
                    cboEmployeeRateAccount.SelectedItem = "";
                    txtEmployeeAccountName.Text = "";
                    break;
            }
        }

        private void btnReEnrollFingerPrint_Click(object sender, EventArgs e)
        {
            btnReEnrollFingerPrint.Visible = false;
            txtScannerPrompt.Visible = true;
            employeeFingerprintImage.Visible = true;
            txtCaptureStatusLog.Visible = true;
            txtCaptureStatusLog.Focus();
            lblSampleNeededStatus.Visible = true;
            progressPecentageStatus.Visible = true;
            scanningProgressBar.Visible = true;
            btnStartScan.Visible = true;

            isFingerprintReEnrollNeeded = true;
        }

        //REGION: DateTimePicker ValueChanged and Textbox Click
        #region
        private void dtpEmployeeDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            txtDateOfBirth.Visible = true;
            txtDateOfBirth.Text = dtpEmployeeDateOfBirth.Value.ToString("MMMM dd, yyyy");
        }

        private void txtDateOfBirth_Click(object sender, EventArgs e)
        {
            txtDateOfBirth.Visible = false;
            dtpEmployeeDateOfBirth.Visible = true;
            dtpEmployeeDateOfBirth.Focus();
        }

        private void dtpEmployeeHiredDate_ValueChanged(object sender, EventArgs e)
        {
            txtHireDate.Visible = true;
            txtHireDate.Text = dtpEmployeeHiredDate.Value.ToString("MMMM dd, yyyy");
        }

        private void txtHireDate_Click(object sender, EventArgs e)
        {
            txtHireDate.Visible = false;
            dtpEmployeeHiredDate.Visible = true;
            dtpEmployeeHiredDate.Focus();
        }

        private void dtpEmpStartDate_ValueChanged(object sender, EventArgs e)
        {
            txtStartDate.Visible = true;
            txtStartDate.Text = dtpEmpStartDate.Value.ToString("MMMM dd, yyyy");
        }

        private void txtStartDate_Click(object sender, EventArgs e)
        {
            txtStartDate.Visible = false;
            dtpEmpStartDate.Visible = true;
            dtpEmpStartDate.Focus();
        }

        private void dtpEmpEndDate_ValueChanged(object sender, EventArgs e)
        {
            txtEndDate.Visible = true;
            txtEndDate.Text = dtpEmpEndDate.Value.ToString("MMMM dd, yyyy");
        }

        private void txtEndDate_Click(object sender, EventArgs e)
        {
            txtEndDate.Visible = false;
            dtpEmpEndDate.Visible = true;
            dtpEmpEndDate.Focus();
        }
        #endregion
    }
}
