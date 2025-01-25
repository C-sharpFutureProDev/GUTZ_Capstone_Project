namespace GUTZ_Capstone_Project
{
    partial class EmployeeLeave
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
            this.components = new System.ComponentModel.Container();
            this.btnSaveEmployeeDetails = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.lblEmployeeFullName = new System.Windows.Forms.Label();
            this.lblLeaveDetailsInformation = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.dtpLeaveRequestDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpLeaveApprovedDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLeaveType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpLeaveEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpLeaveStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblActiveLeaveStatus = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblID = new System.Windows.Forms.Label();
            this.employeeProfilePicture = new Guna.UI2.WinForms.Guna2PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveEmployeeDetails
            // 
            this.btnSaveEmployeeDetails.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveEmployeeDetails.BorderColor = System.Drawing.Color.MistyRose;
            this.btnSaveEmployeeDetails.BorderRadius = 4;
            this.btnSaveEmployeeDetails.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveEmployeeDetails.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveEmployeeDetails.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveEmployeeDetails.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveEmployeeDetails.FillColor = System.Drawing.Color.Green;
            this.btnSaveEmployeeDetails.Font = new System.Drawing.Font("Times New Roman", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnSaveEmployeeDetails.ForeColor = System.Drawing.Color.White;
            this.btnSaveEmployeeDetails.HoverState.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSaveEmployeeDetails.HoverState.FillColor = System.Drawing.Color.DarkGreen;
            this.btnSaveEmployeeDetails.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSaveEmployeeDetails.Location = new System.Drawing.Point(41, 485);
            this.btnSaveEmployeeDetails.Name = "btnSaveEmployeeDetails";
            this.btnSaveEmployeeDetails.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.btnSaveEmployeeDetails.Size = new System.Drawing.Size(110, 40);
            this.btnSaveEmployeeDetails.TabIndex = 75;
            this.btnSaveEmployeeDetails.Text = "Save";
            this.btnSaveEmployeeDetails.Click += new System.EventHandler(this.btnSaveEmployeeDetails_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.MistyRose;
            this.btnCancel.BorderRadius = 4;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 10.5F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.HoverState.BorderColor = System.Drawing.Color.MistyRose;
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.Red;
            this.btnCancel.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(411, 485);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5, 3, 0, 0);
            this.btnCancel.Size = new System.Drawing.Size(110, 40);
            this.btnCancel.TabIndex = 76;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblEmployeeFullName
            // 
            this.lblEmployeeFullName.BackColor = System.Drawing.Color.White;
            this.lblEmployeeFullName.Font = new System.Drawing.Font("Arial Black", 11F, System.Drawing.FontStyle.Bold);
            this.lblEmployeeFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmployeeFullName.Location = new System.Drawing.Point(37, 27);
            this.lblEmployeeFullName.Name = "lblEmployeeFullName";
            this.lblEmployeeFullName.Size = new System.Drawing.Size(360, 40);
            this.lblEmployeeFullName.TabIndex = 77;
            this.lblEmployeeFullName.Text = "Name: Elena Koshka";
            this.lblEmployeeFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLeaveDetailsInformation
            // 
            this.lblLeaveDetailsInformation.BackColor = System.Drawing.Color.White;
            this.lblLeaveDetailsInformation.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeaveDetailsInformation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLeaveDetailsInformation.Location = new System.Drawing.Point(41, 129);
            this.lblLeaveDetailsInformation.Name = "lblLeaveDetailsInformation";
            this.lblLeaveDetailsInformation.Size = new System.Drawing.Size(229, 35);
            this.lblLeaveDetailsInformation.TabIndex = 78;
            this.lblLeaveDetailsInformation.Text = "Set Leave Schedule:";
            this.lblLeaveDetailsInformation.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.White;
            this.label21.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Gray;
            this.label21.Location = new System.Drawing.Point(14, 30);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(212, 31);
            this.label21.TabIndex = 79;
            this.label21.Text = "Request Date:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpLeaveRequestDate
            // 
            this.dtpLeaveRequestDate.BackColor = System.Drawing.Color.Ivory;
            this.dtpLeaveRequestDate.BorderRadius = 4;
            this.dtpLeaveRequestDate.Checked = true;
            this.dtpLeaveRequestDate.CustomFormat = "MMMM dd, yyyy";
            this.dtpLeaveRequestDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dtpLeaveRequestDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpLeaveRequestDate.ForeColor = System.Drawing.Color.Black;
            this.dtpLeaveRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLeaveRequestDate.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dtpLeaveRequestDate.Location = new System.Drawing.Point(14, 65);
            this.dtpLeaveRequestDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpLeaveRequestDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpLeaveRequestDate.Name = "dtpLeaveRequestDate";
            this.dtpLeaveRequestDate.Size = new System.Drawing.Size(215, 40);
            this.dtpLeaveRequestDate.TabIndex = 80;
            this.dtpLeaveRequestDate.Value = new System.DateTime(2024, 12, 2, 0, 0, 0, 0);
            // 
            // dtpLeaveApprovedDate
            // 
            this.dtpLeaveApprovedDate.BackColor = System.Drawing.Color.Ivory;
            this.dtpLeaveApprovedDate.BorderRadius = 4;
            this.dtpLeaveApprovedDate.Checked = true;
            this.dtpLeaveApprovedDate.CustomFormat = "MMMM dd, yyyy";
            this.dtpLeaveApprovedDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dtpLeaveApprovedDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpLeaveApprovedDate.ForeColor = System.Drawing.Color.Black;
            this.dtpLeaveApprovedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLeaveApprovedDate.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dtpLeaveApprovedDate.Location = new System.Drawing.Point(251, 65);
            this.dtpLeaveApprovedDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpLeaveApprovedDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpLeaveApprovedDate.Name = "dtpLeaveApprovedDate";
            this.dtpLeaveApprovedDate.Size = new System.Drawing.Size(215, 40);
            this.dtpLeaveApprovedDate.TabIndex = 82;
            this.dtpLeaveApprovedDate.Value = new System.DateTime(2024, 12, 2, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(255, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 31);
            this.label1.TabIndex = 81;
            this.label1.Text = "Approved Date:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLeaveType
            // 
            this.cboLeaveType.BackColor = System.Drawing.Color.White;
            this.cboLeaveType.BorderRadius = 4;
            this.cboLeaveType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLeaveType.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cboLeaveType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLeaveType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboLeaveType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLeaveType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboLeaveType.ItemHeight = 35;
            this.cboLeaveType.Items.AddRange(new object[] {
            "Personal",
            "Sick",
            "Medical"});
            this.cboLeaveType.Location = new System.Drawing.Point(14, 145);
            this.cboLeaveType.Name = "cboLeaveType";
            this.cboLeaveType.Size = new System.Drawing.Size(452, 41);
            this.cboLeaveType.TabIndex = 83;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(14, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(452, 31);
            this.label2.TabIndex = 84;
            this.label2.Text = "Leave Type:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpLeaveEndDate);
            this.groupBox1.Controls.Add(this.dtpLeaveStartDate);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpLeaveApprovedDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpLeaveRequestDate);
            this.groupBox1.Controls.Add(this.cboLeaveType);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(41, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 296);
            this.groupBox1.TabIndex = 85;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(14, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 31);
            this.label3.TabIndex = 85;
            this.label3.Text = "Start Date:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(255, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 31);
            this.label4.TabIndex = 87;
            this.label4.Text = "End Date:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpLeaveEndDate
            // 
            this.dtpLeaveEndDate.BackColor = System.Drawing.Color.Ivory;
            this.dtpLeaveEndDate.BorderRadius = 4;
            this.dtpLeaveEndDate.Checked = true;
            this.dtpLeaveEndDate.CustomFormat = "MMMM dd, yyyy";
            this.dtpLeaveEndDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dtpLeaveEndDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpLeaveEndDate.ForeColor = System.Drawing.Color.Black;
            this.dtpLeaveEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLeaveEndDate.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dtpLeaveEndDate.Location = new System.Drawing.Point(251, 227);
            this.dtpLeaveEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpLeaveEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpLeaveEndDate.Name = "dtpLeaveEndDate";
            this.dtpLeaveEndDate.Size = new System.Drawing.Size(215, 40);
            this.dtpLeaveEndDate.TabIndex = 88;
            this.dtpLeaveEndDate.Value = new System.DateTime(2024, 12, 2, 0, 0, 0, 0);
            // 
            // dtpLeaveStartDate
            // 
            this.dtpLeaveStartDate.BackColor = System.Drawing.Color.Ivory;
            this.dtpLeaveStartDate.BorderRadius = 4;
            this.dtpLeaveStartDate.Checked = true;
            this.dtpLeaveStartDate.CustomFormat = "MMMM dd, yyyy";
            this.dtpLeaveStartDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dtpLeaveStartDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpLeaveStartDate.ForeColor = System.Drawing.Color.Black;
            this.dtpLeaveStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLeaveStartDate.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dtpLeaveStartDate.Location = new System.Drawing.Point(14, 227);
            this.dtpLeaveStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpLeaveStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpLeaveStartDate.Name = "dtpLeaveStartDate";
            this.dtpLeaveStartDate.Size = new System.Drawing.Size(215, 40);
            this.dtpLeaveStartDate.TabIndex = 86;
            this.dtpLeaveStartDate.Value = new System.DateTime(2024, 12, 2, 0, 0, 0, 0);
            // 
            // lblActiveLeaveStatus
            // 
            this.lblActiveLeaveStatus.BackColor = System.Drawing.Color.White;
            this.lblActiveLeaveStatus.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.lblActiveLeaveStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblActiveLeaveStatus.Location = new System.Drawing.Point(292, 130);
            this.lblActiveLeaveStatus.Name = "lblActiveLeaveStatus";
            this.lblActiveLeaveStatus.Size = new System.Drawing.Size(229, 35);
            this.lblActiveLeaveStatus.TabIndex = 86;
            this.lblActiveLeaveStatus.Text = "Status: Active";
            this.lblActiveLeaveStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblActiveLeaveStatus.Visible = false;
            // 
            // lblID
            // 
            this.lblID.BackColor = System.Drawing.Color.White;
            this.lblID.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblID.Location = new System.Drawing.Point(37, 71);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(233, 37);
            this.lblID.TabIndex = 87;
            this.lblID.Text = "ID: Number";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // employeeProfilePicture
            // 
            this.employeeProfilePicture.AutoRoundedCorners = true;
            this.employeeProfilePicture.BackColor = System.Drawing.Color.White;
            this.employeeProfilePicture.BorderRadius = 49;
            this.employeeProfilePicture.FillColor = System.Drawing.Color.MistyRose;
            this.employeeProfilePicture.ImageRotate = 0F;
            this.employeeProfilePicture.Location = new System.Drawing.Point(407, 27);
            this.employeeProfilePicture.Name = "employeeProfilePicture";
            this.employeeProfilePicture.Size = new System.Drawing.Size(100, 100);
            this.employeeProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.employeeProfilePicture.TabIndex = 88;
            this.employeeProfilePicture.TabStop = false;
            // 
            // EmployeeLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(558, 543);
            this.Controls.Add(this.employeeProfilePicture);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblActiveLeaveStatus);
            this.Controls.Add(this.lblLeaveDetailsInformation);
            this.Controls.Add(this.lblEmployeeFullName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveEmployeeDetails);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EmployeeLeave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leave Schedule Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployeeLeave_FormClosing);
            this.Load += new System.EventHandler(this.EmployeeLeave_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeeProfilePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnSaveEmployeeDetails;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private System.Windows.Forms.Label lblEmployeeFullName;
        private System.Windows.Forms.Label lblLeaveDetailsInformation;
        private System.Windows.Forms.Label label21;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpLeaveRequestDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpLeaveApprovedDate;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cboLeaveType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpLeaveEndDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpLeaveStartDate;
        private System.Windows.Forms.Label lblActiveLeaveStatus;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblID;
        public Guna.UI2.WinForms.Guna2PictureBox employeeProfilePicture;
    }
}