namespace GUTZ_Capstone_Project
{
    partial class EmployeeAttendanceCard
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
            this.panelEmployeeAttendanceDetails = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAttendanceStatus = new Guna.UI2.WinForms.Guna2Button();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.EmployeeListCardEmployeeDetailsCard = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClockOut = new Guna.UI2.WinForms.Guna2Button();
            this.btnStatus = new Guna.UI2.WinForms.Guna2Button();
            this.btnClockIn = new Guna.UI2.WinForms.Guna2Button();
            this.lblClockOut = new System.Windows.Forms.Label();
            this.lblClockInStatus = new System.Windows.Forms.Label();
            this.lblClockIn = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.employeeProfilePicture = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panelEmployeeAttendanceDetails.SuspendLayout();
            this.EmployeeListCardEmployeeDetailsCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEmployeeAttendanceDetails
            // 
            this.panelEmployeeAttendanceDetails.BackColor = System.Drawing.Color.Transparent;
            this.panelEmployeeAttendanceDetails.BorderColor = System.Drawing.Color.Ivory;
            this.panelEmployeeAttendanceDetails.BorderRadius = 15;
            this.panelEmployeeAttendanceDetails.Controls.Add(this.btnAttendanceStatus);
            this.panelEmployeeAttendanceDetails.Controls.Add(this.lblCurrentDate);
            this.panelEmployeeAttendanceDetails.Controls.Add(this.EmployeeListCardEmployeeDetailsCard);
            this.panelEmployeeAttendanceDetails.Controls.Add(this.lblName);
            this.panelEmployeeAttendanceDetails.Controls.Add(this.employeeProfilePicture);
            this.panelEmployeeAttendanceDetails.FillColor = System.Drawing.Color.Ivory;
            this.panelEmployeeAttendanceDetails.Location = new System.Drawing.Point(25, 24);
            this.panelEmployeeAttendanceDetails.Margin = new System.Windows.Forms.Padding(0);
            this.panelEmployeeAttendanceDetails.Name = "panelEmployeeAttendanceDetails";
            this.panelEmployeeAttendanceDetails.ShadowDecoration.BorderRadius = 15;
            this.panelEmployeeAttendanceDetails.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(194)))), ((int)(((byte)(155)))));
            this.panelEmployeeAttendanceDetails.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.panelEmployeeAttendanceDetails.Size = new System.Drawing.Size(486, 233);
            this.panelEmployeeAttendanceDetails.TabIndex = 2;
            // 
            // btnAttendanceStatus
            // 
            this.btnAttendanceStatus.AutoRoundedCorners = true;
            this.btnAttendanceStatus.BackColor = System.Drawing.Color.Transparent;
            this.btnAttendanceStatus.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnAttendanceStatus.BorderRadius = 16;
            this.btnAttendanceStatus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAttendanceStatus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAttendanceStatus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAttendanceStatus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAttendanceStatus.FillColor = System.Drawing.Color.ForestGreen;
            this.btnAttendanceStatus.Font = new System.Drawing.Font("Roboto", 8.5F);
            this.btnAttendanceStatus.ForeColor = System.Drawing.Color.White;
            this.btnAttendanceStatus.HoverState.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnAttendanceStatus.HoverState.FillColor = System.Drawing.Color.ForestGreen;
            this.btnAttendanceStatus.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAttendanceStatus.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAttendanceStatus.ImageSize = new System.Drawing.Size(17, 17);
            this.btnAttendanceStatus.Location = new System.Drawing.Point(359, 10);
            this.btnAttendanceStatus.Name = "btnAttendanceStatus";
            this.btnAttendanceStatus.Padding = new System.Windows.Forms.Padding(3, 0, 0, 1);
            this.btnAttendanceStatus.PressedColor = System.Drawing.Color.ForestGreen;
            this.btnAttendanceStatus.PressedDepth = 0;
            this.btnAttendanceStatus.Size = new System.Drawing.Size(100, 35);
            this.btnAttendanceStatus.TabIndex = 76;
            this.btnAttendanceStatus.Text = "Status";
            this.btnAttendanceStatus.Visible = false;
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblCurrentDate.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentDate.Location = new System.Drawing.Point(12, 193);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblCurrentDate.Size = new System.Drawing.Size(176, 27);
            this.lblCurrentDate.TabIndex = 75;
            this.lblCurrentDate.Text = "Attendance Date";
            // 
            // EmployeeListCardEmployeeDetailsCard
            // 
            this.EmployeeListCardEmployeeDetailsCard.BackColor = System.Drawing.Color.Transparent;
            this.EmployeeListCardEmployeeDetailsCard.BorderColor = System.Drawing.Color.ForestGreen;
            this.EmployeeListCardEmployeeDetailsCard.BorderRadius = 12;
            this.EmployeeListCardEmployeeDetailsCard.Controls.Add(this.btnClockOut);
            this.EmployeeListCardEmployeeDetailsCard.Controls.Add(this.btnStatus);
            this.EmployeeListCardEmployeeDetailsCard.Controls.Add(this.btnClockIn);
            this.EmployeeListCardEmployeeDetailsCard.Controls.Add(this.lblClockOut);
            this.EmployeeListCardEmployeeDetailsCard.Controls.Add(this.lblClockInStatus);
            this.EmployeeListCardEmployeeDetailsCard.Controls.Add(this.lblClockIn);
            this.EmployeeListCardEmployeeDetailsCard.FillColor = System.Drawing.Color.ForestGreen;
            this.EmployeeListCardEmployeeDetailsCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.EmployeeListCardEmployeeDetailsCard.Location = new System.Drawing.Point(127, 70);
            this.EmployeeListCardEmployeeDetailsCard.Name = "EmployeeListCardEmployeeDetailsCard";
            this.EmployeeListCardEmployeeDetailsCard.ShadowDecoration.BorderRadius = 15;
            this.EmployeeListCardEmployeeDetailsCard.ShadowDecoration.Color = System.Drawing.Color.MistyRose;
            this.EmployeeListCardEmployeeDetailsCard.ShadowDecoration.Enabled = true;
            this.EmployeeListCardEmployeeDetailsCard.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.EmployeeListCardEmployeeDetailsCard.Size = new System.Drawing.Size(340, 105);
            this.EmployeeListCardEmployeeDetailsCard.TabIndex = 62;
            // 
            // btnClockOut
            // 
            this.btnClockOut.BackColor = System.Drawing.Color.Transparent;
            this.btnClockOut.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(217)))), ((int)(((byte)(0)))));
            this.btnClockOut.BorderRadius = 4;
            this.btnClockOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClockOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClockOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClockOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClockOut.FillColor = System.Drawing.Color.ForestGreen;
            this.btnClockOut.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClockOut.ForeColor = System.Drawing.Color.White;
            this.btnClockOut.HoverState.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnClockOut.HoverState.FillColor = System.Drawing.Color.ForestGreen;
            this.btnClockOut.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnClockOut.Location = new System.Drawing.Point(228, 55);
            this.btnClockOut.Name = "btnClockOut";
            this.btnClockOut.Padding = new System.Windows.Forms.Padding(0, 0, 6, 1);
            this.btnClockOut.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnClockOut.PressedDepth = 0;
            this.btnClockOut.Size = new System.Drawing.Size(105, 38);
            this.btnClockOut.TabIndex = 79;
            this.btnClockOut.Text = "Time-In";
            // 
            // btnStatus
            // 
            this.btnStatus.BackColor = System.Drawing.Color.Transparent;
            this.btnStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnStatus.BorderRadius = 4;
            this.btnStatus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStatus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStatus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStatus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStatus.FillColor = System.Drawing.Color.ForestGreen;
            this.btnStatus.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatus.ForeColor = System.Drawing.Color.White;
            this.btnStatus.HoverState.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnStatus.HoverState.FillColor = System.Drawing.Color.ForestGreen;
            this.btnStatus.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnStatus.Location = new System.Drawing.Point(118, 55);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Padding = new System.Windows.Forms.Padding(3, 0, 4, 0);
            this.btnStatus.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnStatus.PressedDepth = 0;
            this.btnStatus.Size = new System.Drawing.Size(105, 38);
            this.btnStatus.TabIndex = 78;
            this.btnStatus.Text = "STATUS";
            // 
            // btnClockIn
            // 
            this.btnClockIn.BackColor = System.Drawing.Color.Transparent;
            this.btnClockIn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(217)))), ((int)(((byte)(0)))));
            this.btnClockIn.BorderRadius = 4;
            this.btnClockIn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClockIn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClockIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClockIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClockIn.FillColor = System.Drawing.Color.ForestGreen;
            this.btnClockIn.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClockIn.ForeColor = System.Drawing.Color.White;
            this.btnClockIn.HoverState.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnClockIn.HoverState.FillColor = System.Drawing.Color.ForestGreen;
            this.btnClockIn.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnClockIn.Location = new System.Drawing.Point(8, 55);
            this.btnClockIn.Name = "btnClockIn";
            this.btnClockIn.Padding = new System.Windows.Forms.Padding(7, 0, 0, 1);
            this.btnClockIn.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnClockIn.PressedDepth = 0;
            this.btnClockIn.Size = new System.Drawing.Size(105, 38);
            this.btnClockIn.TabIndex = 77;
            this.btnClockIn.Text = "Time-Out";
            // 
            // lblClockOut
            // 
            this.lblClockOut.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.lblClockOut.ForeColor = System.Drawing.Color.White;
            this.lblClockOut.Location = new System.Drawing.Point(228, 19);
            this.lblClockOut.Name = "lblClockOut";
            this.lblClockOut.Size = new System.Drawing.Size(100, 21);
            this.lblClockOut.TabIndex = 76;
            this.lblClockOut.Text = "Clock-Out";
            this.lblClockOut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblClockInStatus
            // 
            this.lblClockInStatus.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.lblClockInStatus.ForeColor = System.Drawing.Color.White;
            this.lblClockInStatus.Location = new System.Drawing.Point(120, 19);
            this.lblClockInStatus.Name = "lblClockInStatus";
            this.lblClockInStatus.Size = new System.Drawing.Size(100, 21);
            this.lblClockInStatus.TabIndex = 75;
            this.lblClockInStatus.Text = "STATUS";
            this.lblClockInStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblClockIn
            // 
            this.lblClockIn.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.lblClockIn.ForeColor = System.Drawing.Color.White;
            this.lblClockIn.Location = new System.Drawing.Point(15, 19);
            this.lblClockIn.Name = "lblClockIn";
            this.lblClockIn.Size = new System.Drawing.Size(97, 21);
            this.lblClockIn.TabIndex = 74;
            this.lblClockIn.Text = "Clock-In";
            this.lblClockIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Roboto", 14F);
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(16, 14);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(224, 31);
            this.lblName.TabIndex = 60;
            this.lblName.Text = "Full Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // employeeProfilePicture
            // 
            this.employeeProfilePicture.AutoRoundedCorners = true;
            this.employeeProfilePicture.BackColor = System.Drawing.Color.Ivory;
            this.employeeProfilePicture.BorderRadius = 48;
            this.employeeProfilePicture.FillColor = System.Drawing.Color.MistyRose;
            this.employeeProfilePicture.ImageRotate = 0F;
            this.employeeProfilePicture.Location = new System.Drawing.Point(17, 73);
            this.employeeProfilePicture.Name = "employeeProfilePicture";
            this.employeeProfilePicture.Size = new System.Drawing.Size(100, 99);
            this.employeeProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.employeeProfilePicture.TabIndex = 50;
            this.employeeProfilePicture.TabStop = false;
            // 
            // EmployeeAttendanceCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.panelEmployeeAttendanceDetails);
            this.Font = new System.Drawing.Font("Cambria", 8.9F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Name = "EmployeeAttendanceCard";
            this.Size = new System.Drawing.Size(512, 259);
            this.panelEmployeeAttendanceDetails.ResumeLayout(false);
            this.panelEmployeeAttendanceDetails.PerformLayout();
            this.EmployeeListCardEmployeeDetailsCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeeProfilePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public Guna.UI2.WinForms.Guna2Panel EmployeeListCardEmployeeDetailsCard;
        private System.Windows.Forms.Label lblName;
        private Guna.UI2.WinForms.Guna2PictureBox employeeProfilePicture;
        public Guna.UI2.WinForms.Guna2Button btnClockOut;
        public Guna.UI2.WinForms.Guna2Button btnStatus;
        public Guna.UI2.WinForms.Guna2Button btnClockIn;
        private System.Windows.Forms.Label lblCurrentDate;
        public Guna.UI2.WinForms.Guna2Button btnAttendanceStatus;
        public Guna.UI2.WinForms.Guna2Panel panelEmployeeAttendanceDetails;
        public System.Windows.Forms.Label lblClockInStatus;
        public System.Windows.Forms.Label lblClockIn;
        public System.Windows.Forms.Label lblClockOut;
    }
}
