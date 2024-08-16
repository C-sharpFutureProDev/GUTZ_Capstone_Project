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

namespace GUTZ_Capstone_Project.Forms
{
    public partial class FormEmployeeEnrollment : Form, DPFP.Capture.EventHandler
    {
        // Global variables declaration
        private DPFP.Capture.Capture Capturer;
        private DPFP.Processing.Enrollment Enroller;
        public delegate void OnTemplateEventHandler(DPFP.Template template);
        public event OnTemplateEventHandler OnTemplate;
        private byte[] fingerprintData;
        private byte[] employeeProfilePic;
        string _empId;

        public FormEmployeeEnrollment(string empId_)
        {
            InitializeComponent();
            SetFormRegion();
            this.Size = new Size(1297, 950);

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

                    byte[] employeeProfilePic = (byte[])dt.Rows[0]["emp_profilePic"];
                    {
                        using (MemoryStream ms = new MemoryStream(employeeProfilePic))
                            employeeProfilePicture.Image = Image.FromStream(ms);
                    }

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
            // Show number of fingerprint samples needed for enrollment
            SetStatus(String.Format("Fingerprint samples needed: {0}", Enroller.FeaturesNeeded));
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

        protected void Process(DPFP.Sample Sample)
        {
            DrawPicture(ConvertSampleToBitmap(Sample));
           
            // Process the sample and create a feature set for the enrollment purpose.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);

            // Check quality of the sample and add to enroller if it's good
            if (features != null)
            {
                try
                {
                    MakeReport("The fingerprint feature set was created.");
                    Enroller.AddFeatures(features); // Add feature set to template.
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
                                MessageBox.Show("The fingerprint template was ready for fingerprint verification.", "Enrollment Success");
                            else
                                MessageBox.Show("Fingerprint Enrollment was unsuccessful!", "Enrollment Failed");

                            // Prepare acquired fingerprint data for saving to the database
                            using (MemoryStream fingerprintStream = new MemoryStream())
                            {
                                template.Serialize(fingerprintStream);
                                fingerprintData = fingerprintStream.ToArray();
                            }

                            //or
                            /*
                            using (MemoryStream fingerprintStream = new MemoryStream())
                            {
                                template.Serialize(fingerprintStream);
                                fingerprintStream.Position = 0;
                                BinaryReader reader = new BinaryReader(fingerprintStream);
                                byte[] bytes = reader.ReadBytes((int)fingerprintStream.Length);
                                fingerprintData = bytes;
                            }
                            */

                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:  // report failure and restart capturing
                            Enroller.Clear();
                            Stop();
                            UpdateStatus();
                            OnTemplate?.Invoke(null);
                            Start();
                            break;
                    }
                }
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

                // Convert the image to a byte array
                using (MemoryStream ms = new MemoryStream())
                {
                    employeeProfilePicture.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    employeeProfilePic = ms.ToArray();
                }
            }
        }

        private void btnSaveEmployeeDetails_Click(object sender, EventArgs e)
        {
            if (!User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeFirstName, "First Name"))
                return;
            if (!User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeLastName, "Last Name"))
                return;
            if (!User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeMiddleIName, "Middle Name"))
                return;
            if (!User_InputsValidatorHelperClass.ValidateGenderSelection(rdbMale, rdbFemale))
                return;
            if (!User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeAge, "Age"))
                return;
            if (!User_InputsValidatorHelperClass.ValidateGunaTextBoxAsNumber(txtEmployeeAge, "Age"))
                return;
            if (!User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeContactNumber, "Contact Number"))
                return;
            if (!User_InputsValidatorHelperClass.ValidateEmailFormat(txtEmployeeEmail))
                return;
            if (!User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeEmail, "Email Address"))
                return;
            if (!User_InputsValidatorHelperClass.ValidateProfilePicture(employeeProfilePic))
                return;
            if (!User_InputsValidatorHelperClass.ValidateGunaComboBoxSelection(cboEmployeeCityMunicipality, "City/Municipality"))
                return;
            if (!User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeBrgyAddress, "Barangay Address"))
                return;
            if (!User_InputsValidatorHelperClass.ValidateGunaComboBoxSelection(cboEmployeeDept, "Department"))
                return;
            if (!User_InputsValidatorHelperClass.ValidateGunaTextBoxInput(txtEmployeeJobDesc, "Job Title"))
                return;
            if (!User_InputsValidatorHelperClass.ValidateFingerprintPicture(fingerprintData))
                return;


            // Get all user input from all the required fields
            string fName = txtEmployeeFirstName.Text;
            string lName = txtEmployeeLastName.Text;
            string midName = txtEmployeeMiddleIName.Text;

            string gender = "";
            if (rdbMale.Checked)
                gender = "Male";
            else if (rdbFemale.Checked)
                gender = "Female";

            DateTime birthDate = dtpEmployeeDateOfBirth.Value.Date;
            int age = int.Parse(txtEmployeeAge.Text);
            string contactNo = txtEmployeeContactNumber.Text;
            string email = txtEmployeeEmail.Text;
            string cityOrMunicipality = cboEmployeeCityMunicipality.SelectedItem.ToString();
            DateTime hiredDate = dtpEmployeeHiredDate.Value.Date;

            int deptID = 0;
            int posID = 0;
            switch (cboEmployeeDept.SelectedItem)
            {
                case "BPO Department":
                    deptID = 1111;
                    posID = 21615;
                    break;
                case "ESL Department":
                    deptID = 2222;
                    posID = 51912;
                    break;
            }

            string agentCode = $"GUTZ-{fName}";
            string address = txtEmployeeBrgyAddress.Text + ", " + cboEmployeeCityMunicipality.SelectedItem;

            // 
            string sql = "";

            if (_empId == "") // add
            {
                sql = @"INSERT INTO tbl_employee 
                                        (department_id, position_id, emp_profilePic, 
                                        f_name, m_name, l_name, agent_code, b_day,
                                        age, gender, address, email, phone, hired_date) 
                                 VALUES (@deptID, @posID, @empProPic, @fName, @mName, @lName,
                                        @agentCode, @bDay, @age, @gender, @address, @email, 
                                        @phone, @hiredDate)";

                var parameterInsert = new Dictionary<string, object>
                {
                    { "@deptID", deptID },
                    { "@posID",  posID },
                    { "@empProPic", employeeProfilePic},
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
                    // Get the inserted employee ID
                    dt = DB_OperationHelperClass.QueryData(selectID);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            emp_id = int.Parse(row["emp_id"].ToString());
                        }
                    }

                    // SQL query with parameters
                    string insertIntoFingerprintTable = @"INSERT INTO tbl_fingerprint (fingerprint_data, emp_id)
                                 VALUES(@FingerprintData, @EmpId)";

                    // Create a dictionary for parameters
                    var param = new Dictionary<string, object>
                    {
                        { "@FingerprintData", fingerprintData },
                        { "@EmpId", emp_id }
                    };

                    if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(insertIntoFingerprintTable, param))
                        MessageBox.Show("New record has been saved successfully.", "New Employee Added",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Failed to add new record.", "Failed Adding New Employee!",
                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }// end inner if


            } //end if for add operation
            else // update
            {

            }

            this.Close();
        }

        private void btnResetInputFields_Click(object sender, EventArgs e)
        {

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
            string selectedDepartment = cboEmployeeDept.SelectedItem.ToString();

            switch (selectedDepartment)
            {
                case "BPO Department":
                    txtEmployeeJobDesc.Text = "Call Center Agent";
                    break;
                case "ESL Department":
                    txtEmployeeJobDesc.Text = "English as a Second Language Teacher";
                    break;
                default:
                    txtEmployeeJobDesc.Text = "";
                    break;
            }
        }
    }
}
