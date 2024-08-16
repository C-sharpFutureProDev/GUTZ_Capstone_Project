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
        //private DPFP.Template Template;
        private DPFP.Verification.Verification Verifier;
        private DPFP.Capture.Capture Capturer;
        private string sqlRetrieve = @"SELECT fingerprint_id, fingerprint_data, tbl_fingerprint.emp_id, l_name,
                                      CONCAT(f_name, ' ', LEFT(m_name, 1), '. ', l_name) AS full_name
                                      FROM tbl_fingerprint
                                      INNER JOIN tbl_employee
                                      ON tbl_fingerprint.emp_id = tbl_employee.emp_id;";
        private int f_id;
        private int emp_id;
        private string emp_name;
        private string att_id;
        private string l_name;
        private string work_shift = "";

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

            DataTable dt = DB_OperationHelperClass.QueryData(sqlRetrieve);
            foreach (DataRow dr in dt.Rows)
            {
                f_id = int.Parse(dr["fingerprint_id"].ToString());
                emp_id = int.Parse(dr["emp_id"].ToString());
                emp_name = dr["full_name"].ToString();
                l_name = dr["l_name"].ToString();
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
            MakeReport("HID Digital Persona fingerprint reader was connected.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("HID Digital Persona fingerprint was disconnected!");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                MakeReport("The fingerprint sample is good.");
            else
                MakeReport("The fingerprint sample is poor!");
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

        // Method:: Process for fingerprint verification and saving attendance logs
        private void Process(DPFP.Sample Sample)
        {
            DateTime timeIn = DateTime.Now;
            DateTime timeOut = DateTime.Now;
            try
            {
                string sql = "SELECT * FROM tbl_fingerprint";
                DataTable dataTable = DB_OperationHelperClass.QueryData(sql);
                foreach (DataRow row in dataTable.Rows)
                {
                    byte[] f_data = (byte[])row["fingerprint_data"];
                    MemoryStream memoryStream = new MemoryStream(f_data);

                    DPFP.Template Template = new DPFP.Template();
                    Template.DeSerialize(memoryStream);

                    DrawPicture(ConvertSampleToBitmap(Sample));

                    DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

                    if (features != null)
                    {
                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                        Verifier.Verify(features, Template, ref result);
                        UpdateStatus(result.FARAchieved);
                        if (result.Verified == true)
                        {
                            AnnounceVerification(true); // call voice over authentication feedback

                            att_id = emp_id + "-" + l_name; // generate custom attendance id for each employee

                            // Check if the employee has an existing time-in record
                            string checkTimeInQuery = "SELECT * FROM tbl_attendance WHERE emp_id = '" + emp_id + "' AND time_out IS NULL";
                            DataTable timeInRecord = DB_OperationHelperClass.QueryData(checkTimeInQuery);
                            if (timeInRecord.Rows.Count > 0)
                            {
                                // Employee has an existing time-in record, so perform time-out
                                string updateTimeOutQuery = "UPDATE tbl_attendance SET time_out = @time_out WHERE emp_id = @emp_id AND time_out IS NULL";
                                var parameters = new Dictionary<string, object>
                                {
                                    { "@time_out", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") },
                                    { "@emp_id", emp_id }
                                };
                                if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(updateTimeOutQuery, parameters))
                                    MessageBox.Show($"Employee with ID: {emp_id} Time out at {DateTime.Now} Verified.", "Time Out Successful");
                                else
                                    MessageBox.Show("Please try again.", "Unverified");
                            }
                            else
                            {
                                if (DB_OperationHelperClass.IsInMorningShift(timeIn))
                                    work_shift = "MORNING";
                                else
                                    work_shift = "NIGHT";

                                string insertInto = @"INSERT INTO tbl_attendance (attendance_id, emp_id, fingerprint_id, time_in, time_out, work_shift) 
                                                      VALUES (@attendance_id, @emp_id, @fingerprint_id, @time_in, NULL, @work_shift)";

                                var parameters = new Dictionary<string, object>
                                {
                                    { "@attendance_id", att_id },
                                    { "@emp_id", emp_id },
                                    { "@fingerprint_id", f_id },
                                    { "@time_in", timeIn.ToString("yyyy-MM-dd HH:mm:ss") },
                                    { "@work_shift", work_shift }
                                };

                                if (DB_OperationHelperClass.ExecuteCRUDSQLQuery(insertInto, parameters))
                                {
                                    if (work_shift == "MORNING")
                                        MessageBox.Show($"Employee with ID: {emp_id} Time in at {timeIn} Verified. MORNING Shift.", "Time In Successful");
                                    else
                                        MessageBox.Show($"Employee with ID: {emp_id} Time in at {timeIn} Verified. NIGHT Shift.", "Time In Successful");
                                }
                                else
                                    MessageBox.Show("Please try again.", "Unverified");
                            }
                            break;
                        }
                        else
                        {
                            AnnounceVerification(false);
                        }// end if else
                    }// end if
                }// end foreach
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }// end Process
    }
}
