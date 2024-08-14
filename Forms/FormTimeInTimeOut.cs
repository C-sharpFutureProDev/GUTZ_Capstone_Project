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

namespace GUTZ_Capstone_Project.Forms
{
    public partial class FormTimeInTimeOut : Form, DPFP.Capture.EventHandler
    {
        private DPFP.Template Template;
        private DPFP.Verification.Verification Verifier;
        private DPFP.Capture.Capture Capturer;
        public FormTimeInTimeOut()
        {
            InitializeComponent();
            Verifier = new DPFP.Verification.Verification();
            //UpdateStatus(0);
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
                    //Start(); on load
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

        private void Process(DPFP.Sample Sample)
        {
            try
            {
                string connectionString = "SERVER=localhost;UID=root;PWD=;DATABASE=attendancepayrolldb;";
                string sql = "SELECT * FROM tbl_fingerprint";

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    MySqlCommand mySqlCommand = new MySqlCommand(sql, con);
                    MySqlDataAdapter adapter = new MySqlDataAdapter();
                    adapter.SelectCommand = mySqlCommand;

                    DataTable dataTable = new DataTable();
                    con.Open();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        byte[] _fingerprint_ = (byte[])row["fingerprint_data"];

                        MemoryStream memoryStream = new MemoryStream(_fingerprint_);

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
                                MakeReport("Verified");
                               //MessageBox.Show("Verified");
                                break;
                            }
                            else
                            {
                                //MessageBox.Show("NOT Verified");
                                MakeReport("NOT Verified!");
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
    }
}
