namespace GUTZ_Capstone_Project.Forms
{
    partial class FormTimeInTimeOut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnStartScan = new Guna.UI2.WinForms.Guna2Button();
            this.lblFARStatus = new System.Windows.Forms.Label();
            this.txtCaptureStatusLog = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtScannerPrompt = new Guna.UI2.WinForms.Guna2TextBox();
            this.employeeFingerprintImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeFingerprintImage)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnStartScan);
            this.groupBox4.Controls.Add(this.lblFARStatus);
            this.groupBox4.Controls.Add(this.txtCaptureStatusLog);
            this.groupBox4.Controls.Add(this.txtScannerPrompt);
            this.groupBox4.Controls.Add(this.employeeFingerprintImage);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(83, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(635, 477);
            this.groupBox4.TabIndex = 56;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Time-In \' Time-Out";
            // 
            // btnStartScan
            // 
            this.btnStartScan.BackColor = System.Drawing.Color.Transparent;
            this.btnStartScan.BorderColor = System.Drawing.Color.White;
            this.btnStartScan.BorderRadius = 5;
            this.btnStartScan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStartScan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStartScan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStartScan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStartScan.FillColor = System.Drawing.Color.White;
            this.btnStartScan.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartScan.ForeColor = System.Drawing.Color.Black;
            this.btnStartScan.Location = new System.Drawing.Point(454, 394);
            this.btnStartScan.Name = "btnStartScan";
            this.btnStartScan.Size = new System.Drawing.Size(154, 45);
            this.btnStartScan.TabIndex = 57;
            this.btnStartScan.Text = "Start Scan";
            this.btnStartScan.Click += new System.EventHandler(this.btnStartScan_Click);
            // 
            // lblFARStatus
            // 
            this.lblFARStatus.AutoSize = true;
            this.lblFARStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFARStatus.Location = new System.Drawing.Point(39, 360);
            this.lblFARStatus.Name = "lblFARStatus";
            this.lblFARStatus.Size = new System.Drawing.Size(175, 25);
            this.lblFARStatus.TabIndex = 59;
            this.lblFARStatus.Text = "[False Accept Rate]";
            // 
            // txtCaptureStatusLog
            // 
            this.txtCaptureStatusLog.BorderColor = System.Drawing.Color.White;
            this.txtCaptureStatusLog.BorderRadius = 4;
            this.txtCaptureStatusLog.BorderThickness = 0;
            this.txtCaptureStatusLog.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCaptureStatusLog.DefaultText = "";
            this.txtCaptureStatusLog.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCaptureStatusLog.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCaptureStatusLog.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCaptureStatusLog.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCaptureStatusLog.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCaptureStatusLog.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaptureStatusLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtCaptureStatusLog.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCaptureStatusLog.Location = new System.Drawing.Point(278, 90);
            this.txtCaptureStatusLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCaptureStatusLog.Multiline = true;
            this.txtCaptureStatusLog.Name = "txtCaptureStatusLog";
            this.txtCaptureStatusLog.PasswordChar = '\0';
            this.txtCaptureStatusLog.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtCaptureStatusLog.PlaceholderText = "";
            this.txtCaptureStatusLog.SelectedText = "";
            this.txtCaptureStatusLog.Size = new System.Drawing.Size(330, 256);
            this.txtCaptureStatusLog.TabIndex = 43;
            // 
            // txtScannerPrompt
            // 
            this.txtScannerPrompt.BackColor = System.Drawing.Color.Transparent;
            this.txtScannerPrompt.BorderColor = System.Drawing.Color.White;
            this.txtScannerPrompt.BorderRadius = 4;
            this.txtScannerPrompt.BorderThickness = 0;
            this.txtScannerPrompt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtScannerPrompt.DefaultText = "";
            this.txtScannerPrompt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtScannerPrompt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtScannerPrompt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtScannerPrompt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtScannerPrompt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtScannerPrompt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtScannerPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtScannerPrompt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtScannerPrompt.Location = new System.Drawing.Point(40, 46);
            this.txtScannerPrompt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtScannerPrompt.Name = "txtScannerPrompt";
            this.txtScannerPrompt.PasswordChar = '\0';
            this.txtScannerPrompt.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtScannerPrompt.PlaceholderText = "";
            this.txtScannerPrompt.SelectedText = "";
            this.txtScannerPrompt.Size = new System.Drawing.Size(568, 34);
            this.txtScannerPrompt.TabIndex = 43;
            // 
            // employeeFingerprintImage
            // 
            this.employeeFingerprintImage.BorderRadius = 4;
            this.employeeFingerprintImage.ImageRotate = 0F;
            this.employeeFingerprintImage.Location = new System.Drawing.Point(40, 89);
            this.employeeFingerprintImage.Name = "employeeFingerprintImage";
            this.employeeFingerprintImage.Size = new System.Drawing.Size(231, 257);
            this.employeeFingerprintImage.TabIndex = 57;
            this.employeeFingerprintImage.TabStop = false;
            // 
            // FormTimeInTimeOut
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(800, 511);
            this.Controls.Add(this.groupBox4);
            this.DoubleBuffered = true;
            this.Name = "FormTimeInTimeOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fingerprint Verification";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTimeInTimeOut_FormClosing);
            this.Load += new System.EventHandler(this.FormTimeInTimeOut_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeFingerprintImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private Guna.UI2.WinForms.Guna2Button btnStartScan;
        private System.Windows.Forms.Label lblFARStatus;
        private Guna.UI2.WinForms.Guna2TextBox txtCaptureStatusLog;
        private Guna.UI2.WinForms.Guna2TextBox txtScannerPrompt;
        private Guna.UI2.WinForms.Guna2PictureBox employeeFingerprintImage;
    }
}