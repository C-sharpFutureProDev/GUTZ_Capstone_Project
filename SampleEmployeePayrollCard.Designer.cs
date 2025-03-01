namespace GUTZ_Capstone_Project
{
    partial class SampleEmployeePayrollCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.employeeProfilePicture = new Guna.UI2.WinForms.Guna2PictureBox();
            this.paneLPayrollDetailsCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTextPendingPayrollSummary = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.panelEmployeePayrollDetails = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Separator3 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.lblComputedLateTime = new System.Windows.Forms.Label();
            this.lblComputedTutoringHours = new System.Windows.Forms.Label();
            this.lblLateTime = new System.Windows.Forms.Label();
            this.lblTutoringHours = new System.Windows.Forms.Label();
            this.lblComputedWage = new System.Windows.Forms.Label();
            this.lblComputedDeductions = new System.Windows.Forms.Label();
            this.lblNetWage = new System.Windows.Forms.Label();
            this.lblDeductions = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnPayrollPeriod = new Guna.UI2.WinForms.Guna2Button();
            this.btnActivePayrollStatus = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.employeeProfilePicture)).BeginInit();
            this.paneLPayrollDetailsCard.SuspendLayout();
            this.panelEmployeePayrollDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // employeeProfilePicture
            // 
            this.employeeProfilePicture.AutoRoundedCorners = true;
            this.employeeProfilePicture.BackColor = System.Drawing.Color.Ivory;
            this.employeeProfilePicture.BorderRadius = 34;
            this.employeeProfilePicture.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(237)))));
            this.employeeProfilePicture.ImageRotate = 0F;
            this.employeeProfilePicture.Location = new System.Drawing.Point(25, 26);
            this.employeeProfilePicture.Name = "employeeProfilePicture";
            this.employeeProfilePicture.Size = new System.Drawing.Size(70, 70);
            this.employeeProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.employeeProfilePicture.TabIndex = 79;
            this.employeeProfilePicture.TabStop = false;
            // 
            // paneLPayrollDetailsCard
            // 
            this.paneLPayrollDetailsCard.BackColor = System.Drawing.Color.Gray;
            this.paneLPayrollDetailsCard.BorderColor = System.Drawing.Color.Orange;
            this.paneLPayrollDetailsCard.BorderRadius = 15;
            this.paneLPayrollDetailsCard.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.paneLPayrollDetailsCard.Controls.Add(this.lblTextPendingPayrollSummary);
            this.paneLPayrollDetailsCard.Controls.Add(this.lblID);
            this.paneLPayrollDetailsCard.Controls.Add(this.panelEmployeePayrollDetails);
            this.paneLPayrollDetailsCard.Controls.Add(this.lblName);
            this.paneLPayrollDetailsCard.Controls.Add(this.btnPayrollPeriod);
            this.paneLPayrollDetailsCard.Controls.Add(this.btnActivePayrollStatus);
            this.paneLPayrollDetailsCard.Controls.Add(this.employeeProfilePicture);
            this.paneLPayrollDetailsCard.FillColor = System.Drawing.Color.Ivory;
            this.paneLPayrollDetailsCard.ForeColor = System.Drawing.Color.White;
            this.paneLPayrollDetailsCard.Location = new System.Drawing.Point(28, 20);
            this.paneLPayrollDetailsCard.Name = "paneLPayrollDetailsCard";
            this.paneLPayrollDetailsCard.ShadowDecoration.BorderRadius = 15;
            this.paneLPayrollDetailsCard.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.paneLPayrollDetailsCard.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.paneLPayrollDetailsCard.Size = new System.Drawing.Size(480, 490);
            this.paneLPayrollDetailsCard.TabIndex = 64;
            // 
            // lblTextPendingPayrollSummary
            // 
            this.lblTextPendingPayrollSummary.BackColor = System.Drawing.Color.Ivory;
            this.lblTextPendingPayrollSummary.Font = new System.Drawing.Font("Arial Narrow", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblTextPendingPayrollSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.lblTextPendingPayrollSummary.Location = new System.Drawing.Point(25, 205);
            this.lblTextPendingPayrollSummary.Name = "lblTextPendingPayrollSummary";
            this.lblTextPendingPayrollSummary.Size = new System.Drawing.Size(433, 34);
            this.lblTextPendingPayrollSummary.TabIndex = 130;
            this.lblTextPendingPayrollSummary.Text = "Pending Payroll Summary";
            this.lblTextPendingPayrollSummary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblID
            // 
            this.lblID.BackColor = System.Drawing.Color.Ivory;
            this.lblID.Font = new System.Drawing.Font("Arial", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
            this.lblID.Location = new System.Drawing.Point(346, 19);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(119, 27);
            this.lblID.TabIndex = 127;
            this.lblID.Text = "ID - 1001";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelEmployeePayrollDetails
            // 
            this.panelEmployeePayrollDetails.BackColor = System.Drawing.Color.Ivory;
            this.panelEmployeePayrollDetails.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.panelEmployeePayrollDetails.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.panelEmployeePayrollDetails.BorderThickness = 1;
            this.panelEmployeePayrollDetails.Controls.Add(this.guna2Separator3);
            this.panelEmployeePayrollDetails.Controls.Add(this.guna2Separator2);
            this.panelEmployeePayrollDetails.Controls.Add(this.guna2Separator1);
            this.panelEmployeePayrollDetails.Controls.Add(this.lblComputedLateTime);
            this.panelEmployeePayrollDetails.Controls.Add(this.lblComputedTutoringHours);
            this.panelEmployeePayrollDetails.Controls.Add(this.lblLateTime);
            this.panelEmployeePayrollDetails.Controls.Add(this.lblTutoringHours);
            this.panelEmployeePayrollDetails.Controls.Add(this.lblComputedWage);
            this.panelEmployeePayrollDetails.Controls.Add(this.lblComputedDeductions);
            this.panelEmployeePayrollDetails.Controls.Add(this.lblNetWage);
            this.panelEmployeePayrollDetails.Controls.Add(this.lblDeductions);
            this.panelEmployeePayrollDetails.FillColor = System.Drawing.Color.White;
            this.panelEmployeePayrollDetails.ForeColor = System.Drawing.Color.White;
            this.panelEmployeePayrollDetails.Location = new System.Drawing.Point(25, 260);
            this.panelEmployeePayrollDetails.Name = "panelEmployeePayrollDetails";
            this.panelEmployeePayrollDetails.ShadowDecoration.BorderRadius = 15;
            this.panelEmployeePayrollDetails.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelEmployeePayrollDetails.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.panelEmployeePayrollDetails.Size = new System.Drawing.Size(433, 201);
            this.panelEmployeePayrollDetails.TabIndex = 126;
            // 
            // guna2Separator3
            // 
            this.guna2Separator3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.guna2Separator3.FillStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2Separator3.Location = new System.Drawing.Point(0, 140);
            this.guna2Separator3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Separator3.Name = "guna2Separator3";
            this.guna2Separator3.Size = new System.Drawing.Size(433, 1);
            this.guna2Separator3.TabIndex = 131;
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.guna2Separator2.FillStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2Separator2.Location = new System.Drawing.Point(0, 50);
            this.guna2Separator2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(433, 1);
            this.guna2Separator2.TabIndex = 131;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.guna2Separator1.FillStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2Separator1.Location = new System.Drawing.Point(0, 95);
            this.guna2Separator1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(433, 1);
            this.guna2Separator1.TabIndex = 130;
            // 
            // lblComputedLateTime
            // 
            this.lblComputedLateTime.BackColor = System.Drawing.Color.White;
            this.lblComputedLateTime.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblComputedLateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblComputedLateTime.Location = new System.Drawing.Point(276, 65);
            this.lblComputedLateTime.Name = "lblComputedLateTime";
            this.lblComputedLateTime.Size = new System.Drawing.Size(144, 27);
            this.lblComputedLateTime.TabIndex = 71;
            this.lblComputedLateTime.Text = "0h";
            this.lblComputedLateTime.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblComputedTutoringHours
            // 
            this.lblComputedTutoringHours.BackColor = System.Drawing.Color.White;
            this.lblComputedTutoringHours.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblComputedTutoringHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblComputedTutoringHours.Location = new System.Drawing.Point(276, 20);
            this.lblComputedTutoringHours.Name = "lblComputedTutoringHours";
            this.lblComputedTutoringHours.Size = new System.Drawing.Size(144, 27);
            this.lblComputedTutoringHours.TabIndex = 70;
            this.lblComputedTutoringHours.Text = "0h";
            this.lblComputedTutoringHours.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblLateTime
            // 
            this.lblLateTime.BackColor = System.Drawing.Color.White;
            this.lblLateTime.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblLateTime.Location = new System.Drawing.Point(15, 65);
            this.lblLateTime.Name = "lblLateTime";
            this.lblLateTime.Size = new System.Drawing.Size(255, 27);
            this.lblLateTime.TabIndex = 69;
            this.lblLateTime.Text = "Late Time (Cumulative):";
            this.lblLateTime.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblTutoringHours
            // 
            this.lblTutoringHours.BackColor = System.Drawing.Color.White;
            this.lblTutoringHours.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTutoringHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblTutoringHours.Location = new System.Drawing.Point(15, 20);
            this.lblTutoringHours.Name = "lblTutoringHours";
            this.lblTutoringHours.Size = new System.Drawing.Size(255, 27);
            this.lblTutoringHours.TabIndex = 68;
            this.lblTutoringHours.Text = "Tutoring Hours (Cumulative):";
            this.lblTutoringHours.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblComputedWage
            // 
            this.lblComputedWage.BackColor = System.Drawing.Color.White;
            this.lblComputedWage.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblComputedWage.ForeColor = System.Drawing.Color.Black;
            this.lblComputedWage.Location = new System.Drawing.Point(276, 160);
            this.lblComputedWage.Name = "lblComputedWage";
            this.lblComputedWage.Size = new System.Drawing.Size(144, 30);
            this.lblComputedWage.TabIndex = 67;
            this.lblComputedWage.Text = "₱ 00,000.00";
            this.lblComputedWage.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblComputedDeductions
            // 
            this.lblComputedDeductions.BackColor = System.Drawing.Color.White;
            this.lblComputedDeductions.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblComputedDeductions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblComputedDeductions.Location = new System.Drawing.Point(279, 110);
            this.lblComputedDeductions.Name = "lblComputedDeductions";
            this.lblComputedDeductions.Size = new System.Drawing.Size(141, 27);
            this.lblComputedDeductions.TabIndex = 66;
            this.lblComputedDeductions.Text = "₱ 00,000.00";
            this.lblComputedDeductions.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblNetWage
            // 
            this.lblNetWage.BackColor = System.Drawing.Color.White;
            this.lblNetWage.Font = new System.Drawing.Font("Arial Black", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNetWage.ForeColor = System.Drawing.Color.Black;
            this.lblNetWage.Location = new System.Drawing.Point(15, 160);
            this.lblNetWage.Name = "lblNetWage";
            this.lblNetWage.Size = new System.Drawing.Size(255, 30);
            this.lblNetWage.TabIndex = 65;
            this.lblNetWage.Text = "Net Wage (Cumulative):";
            this.lblNetWage.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblDeductions
            // 
            this.lblDeductions.BackColor = System.Drawing.Color.White;
            this.lblDeductions.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeductions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.lblDeductions.Location = new System.Drawing.Point(15, 110);
            this.lblDeductions.Name = "lblDeductions";
            this.lblDeductions.Size = new System.Drawing.Size(255, 27);
            this.lblDeductions.TabIndex = 64;
            this.lblDeductions.Text = "Deductions (Cumulative):";
            this.lblDeductions.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Ivory;
            this.lblName.Font = new System.Drawing.Font("Arial Black", 11F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblName.Location = new System.Drawing.Point(113, 46);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(345, 34);
            this.lblName.TabIndex = 125;
            this.lblName.Text = "Jhon Doe";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPayrollPeriod
            // 
            this.btnPayrollPeriod.BackColor = System.Drawing.Color.Ivory;
            this.btnPayrollPeriod.BorderColor = System.Drawing.Color.White;
            this.btnPayrollPeriod.BorderRadius = 3;
            this.btnPayrollPeriod.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPayrollPeriod.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPayrollPeriod.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPayrollPeriod.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPayrollPeriod.FillColor = System.Drawing.Color.Ivory;
            this.btnPayrollPeriod.Font = new System.Drawing.Font("Arial", 9F);
            this.btnPayrollPeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPayrollPeriod.HoverState.BorderColor = System.Drawing.Color.Ivory;
            this.btnPayrollPeriod.HoverState.FillColor = System.Drawing.Color.Ivory;
            this.btnPayrollPeriod.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnPayrollPeriod.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPayrollPeriod.ImageSize = new System.Drawing.Size(17, 17);
            this.btnPayrollPeriod.Location = new System.Drawing.Point(25, 163);
            this.btnPayrollPeriod.Name = "btnPayrollPeriod";
            this.btnPayrollPeriod.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnPayrollPeriod.PressedColor = System.Drawing.Color.White;
            this.btnPayrollPeriod.PressedDepth = 0;
            this.btnPayrollPeriod.Size = new System.Drawing.Size(433, 35);
            this.btnPayrollPeriod.TabIndex = 124;
            this.btnPayrollPeriod.Text = "Period: MMM. dd, yyyy - MMM. dd, yyyy";
            // 
            // btnActivePayrollStatus
            // 
            this.btnActivePayrollStatus.BackColor = System.Drawing.Color.Ivory;
            this.btnActivePayrollStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(179)))));
            this.btnActivePayrollStatus.BorderRadius = 4;
            this.btnActivePayrollStatus.BorderThickness = 4;
            this.btnActivePayrollStatus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnActivePayrollStatus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnActivePayrollStatus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnActivePayrollStatus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnActivePayrollStatus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(179)))));
            this.btnActivePayrollStatus.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.btnActivePayrollStatus.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnActivePayrollStatus.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(179)))));
            this.btnActivePayrollStatus.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(179)))));
            this.btnActivePayrollStatus.HoverState.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnActivePayrollStatus.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnActivePayrollStatus.ImageSize = new System.Drawing.Size(17, 17);
            this.btnActivePayrollStatus.Location = new System.Drawing.Point(25, 111);
            this.btnActivePayrollStatus.Name = "btnActivePayrollStatus";
            this.btnActivePayrollStatus.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnActivePayrollStatus.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(179)))));
            this.btnActivePayrollStatus.PressedDepth = 0;
            this.btnActivePayrollStatus.Size = new System.Drawing.Size(433, 45);
            this.btnActivePayrollStatus.TabIndex = 123;
            this.btnActivePayrollStatus.Text = "Status: ?";
            // 
            // SampleEmployeePayrollCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.paneLPayrollDetailsCard);
            this.Name = "SampleEmployeePayrollCard";
            this.Size = new System.Drawing.Size(510, 512);
            ((System.ComponentModel.ISupportInitialize)(this.employeeProfilePicture)).EndInit();
            this.paneLPayrollDetailsCard.ResumeLayout(false);
            this.panelEmployeePayrollDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2PictureBox employeeProfilePicture;
        public Guna.UI2.WinForms.Guna2Panel paneLPayrollDetailsCard;
        public Guna.UI2.WinForms.Guna2Button btnActivePayrollStatus;
        public Guna.UI2.WinForms.Guna2Button btnPayrollPeriod;
        private System.Windows.Forms.Label lblName;
        public Guna.UI2.WinForms.Guna2Panel panelEmployeePayrollDetails;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblComputedWage;
        private System.Windows.Forms.Label lblComputedDeductions;
        private System.Windows.Forms.Label lblComputedLateTime;
        private System.Windows.Forms.Label lblComputedTutoringHours;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator3;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        public System.Windows.Forms.Label lblTextPendingPayrollSummary;
        public System.Windows.Forms.Label lblNetWage;
        public System.Windows.Forms.Label lblDeductions;
        public System.Windows.Forms.Label lblLateTime;
        public System.Windows.Forms.Label lblTutoringHours;
    }
}
