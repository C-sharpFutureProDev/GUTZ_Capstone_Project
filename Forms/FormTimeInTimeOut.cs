using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Data.SqlClient;

namespace GUTZ_Capstone_Project.Forms
{
    public partial class FormTimeInTimeOut : Form, DPFP.Capture.EventHandler
    {
        private DPFP.Verification.Verification Verifier;
        private DPFP.Capture.Capture Capturer;

        public FormTimeInTimeOut()
        {
            InitializeComponent();
            Verifier = new DPFP.Verification.Verification();
        }

        private void UpdateStatus(int FAR)
        {
            SetStatus(String.Format("False Accept Rate (FAR) = {0}", FAR));
        }

        protected void SetStatus(string status)
        {
            this.Invoke(new Action(delegate ()
            {
                lblFARStatus.Text = status;
            }));
        }

        protected void SetPrompt(string prompt)
        {
            this.Invoke(new Action(delegate ()
            {
                txtScannerPrompt.Text = prompt;
            }));
        }

        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    SetPrompt("Using the fingerprint reader. Please scan your finger.");
                }
                catch
                {
                    SetPrompt("Can't initiate capture!");
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

        private void btnStartScan_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void FormTimeInTimeOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
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
            Convertor.ConvertToPicture(Sample, ref bitmap);                                 // TODO: return bitmap as a result
            return bitmap;
        }

        private void FormTimeInTimeOut_Load(object sender, EventArgs e)
        {
            try
            {
                Capturer = new DPFP.Capture.Capture(); // Create a capture operation 
                if (null != Capturer)
                {
                    Capturer.EventHandler = this; // Subscribe for capturing events.
                    //Start(); // on load
                    UpdateStatus(0);
                }
                else
                    SetPrompt("Can't initiate capture operation!");
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!");
            }
        }

        protected void MakeReport(string message)
        {
            this.Invoke(new Action(delegate ()
            {
                txtCaptureStatusLog.Text = message;
            }));
        }

        // Default Digital Persona Event Handlers
        #region
        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            //MakeReport("Fingerprint was Verified.");
            Process(Sample);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            //MakeReport("The finger was removed from the reader.");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            //MakeReport("The fingerprint reader was touched.");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("HID Digital Persona fingerprint reader was connected.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("HID Digital Persona fingerprint was disconnected!");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            //if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
            //MakeReport("The fingerprint sample is good.");
            //else
            //MakeReport("The fingerprint sample is poor!");
        }
        #endregion

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

        // Method:: Voice Verification Feedback
        public void AnnounceVerification(bool isVerified)
        {
            using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            {
                string message = isVerified ? "Verified" : "Not Verified";
                synthesizer.Speak(message);
            }
        }

        private void Process(DPFP.Sample Sample)
        {
            DateTime timeIn = DateTime.Now;

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
                    ShowMessage("Failed to extract features from the sample.", "Unverified", MessageBoxIcon.Warning);
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

                        if (result.Verified == true)
                        {
                            MakeReport("Fingerprint Verified.");
                            AnnounceVerification(true);
                            isVerified = true;
                            Stop();

                            string att_id = emp_id + "-" + l_name;

                            string checkTimeInQuery = "SELECT * FROM tbl_attendance WHERE emp_id = '" + emp_id + "' AND time_out IS NULL";
                            DataTable timeInRecord = DB_OperationHelperClass.QueryData(checkTimeInQuery);

                            if (timeInRecord.Rows.Count > 0)
                            {
                                // Perform time-out
                                DateTime existingTimeIn = DateTime.Parse(timeInRecord.Rows[0]["time_in"].ToString());
                                TimeSpan workingHours = DateTime.Now - existingTimeIn;

                                string updateTimeOutQuery = "UPDATE tbl_attendance SET time_out = @time_out, working_hours = @working_hours WHERE emp_id = @emp_id AND time_out IS NULL";
                                var updateTimeOutParams = new Dictionary<string, object>
                                {
                                    { "@time_out", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                                    { "@working_hours", workingHours.ToString(@"hh\:mm\:ss") },
                                    { "@emp_id", emp_id }
                                };

                                if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(updateTimeOutQuery, updateTimeOutParams) == true)
                                    ShowMessage($"Employee with ID: {emp_id} Time out at {DateTime.Now} Verified.", "Time Out Successful", MessageBoxIcon.Information);
                            }
                            else
                            {
                                // Perform time-in
                                string work_shift = DB_OperationHelperClass.IsInMorningShift(timeIn) ? "MORNING" : "NIGHT";
                                string time_in_status = CalculateTimeInStatus(work_shift, timeIn);
                                TimeSpan lateTime = CalculateLateTime(work_shift, timeIn);

                                string insertInto = @"INSERT INTO tbl_attendance (attendance_id, emp_id, fingerprint_id, time_in, time_out, work_shift, time_in_status, late_time, working_hours) 
                                              VALUES (@attendance_id, @emp_id, @fingerprint_id, @time_in, NULL, @work_shift, @time_in_status, @late_time, NULL)";

                                var insertParams = new Dictionary<string, object>
                                {
                                    { "@attendance_id", att_id },
                                    { "@emp_id", emp_id },
                                    { "@fingerprint_id", f_id },
                                    { "@time_in", timeIn.ToString("yyyy-MM-dd HH:mm:ss") },
                                    { "@work_shift", work_shift },
                                    { "@time_in_status", time_in_status },
                                    { "@late_time", lateTime.ToString(@"hh\:mm\:ss") }
                                };

                                if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(insertInto, insertParams) == true)
                                {
                                    string shiftMessage = work_shift == "MORNING" ? "MORNING Shift." : "NIGHT Shift.";
                                    ShowMessage($"Employee with ID: {emp_id} Time in at {timeIn} Verified. {shiftMessage}", "Time In Successful", MessageBoxIcon.Information);
                                }
                            }
                            break;
                        }// end if verified
                    }
                }// end foreach
                Start();
                if (!isVerified)
                {
                    MakeReport("Fingerprint Not Verified!");
                    AnnounceVerification(false);
                    ShowMessage("Fingerprint not recognized.", "Unverified", MessageBoxIcon.Warning);
                    Stop();
                    Start();
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, "Error", MessageBoxIcon.Error);
            }
        }

        private void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            // Ensure this runs on the UI thread
            Invoke(new Action(() =>
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
            }));
        }


        private string CalculateTimeInStatus(string workShift, DateTime timeIn)
        {
            DateTime morningShiftStart = new DateTime(timeIn.Year, timeIn.Month, timeIn.Day, 6, 0, 0);
            DateTime eveningShiftStart = new DateTime(timeIn.Year, timeIn.Month, timeIn.Day, 18, 0, 0);
            TimeSpan gracePeriod = TimeSpan.FromMinutes(15);

            if (workShift == "MORNING")
            {
                return timeIn <= morningShiftStart.Add(gracePeriod) ? "On Time" : "Late";
            }
            else if (workShift == "NIGHT")
            {
                return timeIn <= eveningShiftStart.Add(gracePeriod) ? "On Time" : "Late";
            }

            return "Unknown";
        }

        private TimeSpan CalculateLateTime(string workShift, DateTime timeIn)
        {
            DateTime morningShiftStart = new DateTime(timeIn.Year, timeIn.Month, timeIn.Day, 6, 0, 0);
            DateTime eveningShiftStart = new DateTime(timeIn.Year, timeIn.Month, timeIn.Day, 18, 0, 0);
            TimeSpan gracePeriod = TimeSpan.FromMinutes(15);

            if (workShift == "MORNING" && timeIn > morningShiftStart.Add(gracePeriod))
            {
                return timeIn - morningShiftStart;
            }
            else if (workShift == "NIGHT" && timeIn > eveningShiftStart.Add(gracePeriod))
            {
                return timeIn - eveningShiftStart;
            }

            return TimeSpan.Zero;
        }
    }
}
