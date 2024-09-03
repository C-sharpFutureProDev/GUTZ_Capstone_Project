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
            this.groupBox4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.groupBox4.Location = new System.Drawing.Point(30, 36);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(528, 406);
            this.groupBox4.TabIndex = 56;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Time-In \' Time-Out";
            // 
            // btnStartScan
            // 
            this.btnStartScan.BackColor = System.Drawing.Color.Transparent;
            this.btnStartScan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnStartScan.BorderRadius = 5;
            this.btnStartScan.BorderThickness = 1;
            this.btnStartScan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStartScan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStartScan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStartScan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStartScan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnStartScan.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btnStartScan.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStartScan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnStartScan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnStartScan.HoverState.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStartScan.Location = new System.Drawing.Point(372, 356);
            this.btnStartScan.Name = "btnStartScan";
            this.btnStartScan.Size = new System.Drawing.Size(132, 37);
            this.btnStartScan.TabIndex = 57;
            this.btnStartScan.Text = "Start Scan";
            this.btnStartScan.Click += new System.EventHandler(this.btnStartScan_Click);
            // 
            // lblFARStatus
            // 
            this.lblFARStatus.AutoSize = true;
            this.lblFARStatus.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold);
            this.lblFARStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblFARStatus.Location = new System.Drawing.Point(17, 322);
            this.lblFARStatus.Name = "lblFARStatus";
            this.lblFARStatus.Size = new System.Drawing.Size(179, 26);
            this.lblFARStatus.TabIndex = 59;
            this.lblFARStatus.Text = "[False Accept Rate]";
            // 
            // txtCaptureStatusLog
            // 
            this.txtCaptureStatusLog.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtCaptureStatusLog.BorderRadius = 4;
            this.txtCaptureStatusLog.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCaptureStatusLog.DefaultText = "";
            this.txtCaptureStatusLog.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCaptureStatusLog.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCaptureStatusLog.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCaptureStatusLog.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCaptureStatusLog.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtCaptureStatusLog.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.txtCaptureStatusLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtCaptureStatusLog.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtCaptureStatusLog.Location = new System.Drawing.Point(234, 81);
            this.txtCaptureStatusLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCaptureStatusLog.Multiline = true;
            this.txtCaptureStatusLog.Name = "txtCaptureStatusLog";
            this.txtCaptureStatusLog.PasswordChar = '\0';
            this.txtCaptureStatusLog.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtCaptureStatusLog.PlaceholderText = "";
            this.txtCaptureStatusLog.SelectedText = "";
            this.txtCaptureStatusLog.Size = new System.Drawing.Size(270, 227);
            this.txtCaptureStatusLog.TabIndex = 43;
            // 
            // txtScannerPrompt
            // 
            this.txtScannerPrompt.BackColor = System.Drawing.Color.Transparent;
            this.txtScannerPrompt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtScannerPrompt.BorderRadius = 4;
            this.txtScannerPrompt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtScannerPrompt.DefaultText = "";
            this.txtScannerPrompt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtScannerPrompt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtScannerPrompt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtScannerPrompt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtScannerPrompt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtScannerPrompt.Font = new System.Drawing.Font("Arial", 11.5F, System.Drawing.FontStyle.Bold);
            this.txtScannerPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtScannerPrompt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtScannerPrompt.Location = new System.Drawing.Point(22, 38);
            this.txtScannerPrompt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtScannerPrompt.Name = "txtScannerPrompt";
            this.txtScannerPrompt.PasswordChar = '\0';
            this.txtScannerPrompt.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtScannerPrompt.PlaceholderText = "";
            this.txtScannerPrompt.SelectedText = "";
            this.txtScannerPrompt.Size = new System.Drawing.Size(482, 30);
            this.txtScannerPrompt.TabIndex = 43;
            // 
            // employeeFingerprintImage
            // 
            this.employeeFingerprintImage.BorderRadius = 4;
            this.employeeFingerprintImage.ImageRotate = 0F;
            this.employeeFingerprintImage.Location = new System.Drawing.Point(22, 81);
            this.employeeFingerprintImage.Name = "employeeFingerprintImage";
            this.employeeFingerprintImage.Size = new System.Drawing.Size(205, 227);
            this.employeeFingerprintImage.TabIndex = 57;
            this.employeeFingerprintImage.TabStop = false;
            // 
            // FormTimeInTimeOut
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(589, 476);
            this.Controls.Add(this.groupBox4);
            this.DoubleBuffered = true;
            this.Name = "FormTimeInTimeOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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