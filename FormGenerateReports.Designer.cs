namespace GUTZ_Capstone_Project
{
    partial class FormGenerateReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGenerateReports));
            this.panelEmployeeListCard = new Guna.UI2.WinForms.Guna2Panel();
            this.cboReportType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelPayrollPeriods = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGenerateReports = new Guna.UI2.WinForms.Guna2Button();
            this.panelAttendanceAndPayrollDetails = new Guna.UI2.WinForms.Guna2Panel();
            this.btnDownloadGeneratedReports = new Guna.UI2.WinForms.Guna2Button();
            this.lblSelectedEmployeeCount = new System.Windows.Forms.Label();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.flowLayoutPanelReportDetails = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.chkSelectAllEmployee = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanelEmployeeListForReports = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.panelEmployeeListCard.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.panelAttendanceAndPayrollDetails.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEmployeeListCard
            // 
            this.panelEmployeeListCard.BorderColor = System.Drawing.Color.Ivory;
            this.panelEmployeeListCard.BorderRadius = 10;
            this.panelEmployeeListCard.Controls.Add(this.cboReportType);
            this.panelEmployeeListCard.Controls.Add(this.label3);
            this.panelEmployeeListCard.Controls.Add(this.guna2Panel3);
            this.panelEmployeeListCard.Controls.Add(this.btnGenerateReports);
            this.panelEmployeeListCard.Controls.Add(this.panelAttendanceAndPayrollDetails);
            this.panelEmployeeListCard.Controls.Add(this.guna2Panel2);
            this.panelEmployeeListCard.FillColor = System.Drawing.Color.White;
            this.panelEmployeeListCard.ForeColor = System.Drawing.Color.White;
            this.panelEmployeeListCard.Location = new System.Drawing.Point(23, 22);
            this.panelEmployeeListCard.Name = "panelEmployeeListCard";
            this.panelEmployeeListCard.ShadowDecoration.BorderRadius = 15;
            this.panelEmployeeListCard.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelEmployeeListCard.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.panelEmployeeListCard.Size = new System.Drawing.Size(1556, 860);
            this.panelEmployeeListCard.TabIndex = 64;
            // 
            // cboReportType
            // 
            this.cboReportType.BackColor = System.Drawing.Color.White;
            this.cboReportType.BorderColor = System.Drawing.Color.Black;
            this.cboReportType.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.cboReportType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportType.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.cboReportType.FocusedColor = System.Drawing.Color.Black;
            this.cboReportType.FocusedState.BorderColor = System.Drawing.Color.Black;
            this.cboReportType.Font = new System.Drawing.Font("Arial", 10F);
            this.cboReportType.ForeColor = System.Drawing.Color.Black;
            this.cboReportType.HoverState.BorderColor = System.Drawing.Color.Black;
            this.cboReportType.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.cboReportType.IntegralHeight = false;
            this.cboReportType.ItemHeight = 30;
            this.cboReportType.Items.AddRange(new object[] {
            "Attendance",
            "Payroll"});
            this.cboReportType.Location = new System.Drawing.Point(432, 72);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Size = new System.Drawing.Size(206, 36);
            this.cboReportType.TabIndex = 148;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Bell MT", 10.5F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(432, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 26);
            this.label3.TabIndex = 149;
            this.label3.Text = "Choose Report Type:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.White;
            this.guna2Panel3.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel3.BorderRadius = 8;
            this.guna2Panel3.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.guna2Panel3.Controls.Add(this.label1);
            this.guna2Panel3.Controls.Add(this.flowLayoutPanelPayrollPeriods);
            this.guna2Panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.guna2Panel3.ForeColor = System.Drawing.Color.White;
            this.guna2Panel3.Location = new System.Drawing.Point(666, 34);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel3.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel3.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.guna2Panel3.Size = new System.Drawing.Size(846, 94);
            this.guna2Panel3.TabIndex = 150;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.label1.Font = new System.Drawing.Font("Bell MT", 9.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 59);
            this.label1.TabIndex = 153;
            this.label1.Text = "Choose Period Date:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanelPayrollPeriods
            // 
            this.flowLayoutPanelPayrollPeriods.AutoScroll = true;
            this.flowLayoutPanelPayrollPeriods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.flowLayoutPanelPayrollPeriods.ForeColor = System.Drawing.Color.Black;
            this.flowLayoutPanelPayrollPeriods.Location = new System.Drawing.Point(227, 15);
            this.flowLayoutPanelPayrollPeriods.Name = "flowLayoutPanelPayrollPeriods";
            this.flowLayoutPanelPayrollPeriods.Size = new System.Drawing.Size(594, 65);
            this.flowLayoutPanelPayrollPeriods.TabIndex = 148;
            // 
            // btnGenerateReports
            // 
            this.btnGenerateReports.AutoRoundedCorners = true;
            this.btnGenerateReports.BackColor = System.Drawing.Color.White;
            this.btnGenerateReports.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.btnGenerateReports.BorderRadius = 23;
            this.btnGenerateReports.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerateReports.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerateReports.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGenerateReports.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGenerateReports.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.btnGenerateReports.Font = new System.Drawing.Font("Arial", 10F);
            this.btnGenerateReports.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReports.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(64)))));
            this.btnGenerateReports.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(64)))));
            this.btnGenerateReports.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReports.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerateReports.Image")));
            this.btnGenerateReports.ImageSize = new System.Drawing.Size(30, 30);
            this.btnGenerateReports.Location = new System.Drawing.Point(35, 786);
            this.btnGenerateReports.Name = "btnGenerateReports";
            this.btnGenerateReports.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnGenerateReports.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnGenerateReports.Size = new System.Drawing.Size(349, 48);
            this.btnGenerateReports.TabIndex = 152;
            this.btnGenerateReports.Text = "Generate Reports";
            this.btnGenerateReports.Click += new System.EventHandler(this.btnGenerateReports_Click);
            // 
            // panelAttendanceAndPayrollDetails
            // 
            this.panelAttendanceAndPayrollDetails.BackColor = System.Drawing.Color.Ivory;
            this.panelAttendanceAndPayrollDetails.BorderColor = System.Drawing.Color.Black;
            this.panelAttendanceAndPayrollDetails.BorderRadius = 8;
            this.panelAttendanceAndPayrollDetails.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            this.panelAttendanceAndPayrollDetails.BorderThickness = 2;
            this.panelAttendanceAndPayrollDetails.Controls.Add(this.btnDownloadGeneratedReports);
            this.panelAttendanceAndPayrollDetails.Controls.Add(this.lblSelectedEmployeeCount);
            this.panelAttendanceAndPayrollDetails.Controls.Add(this.guna2Panel4);
            this.panelAttendanceAndPayrollDetails.FillColor = System.Drawing.Color.White;
            this.panelAttendanceAndPayrollDetails.ForeColor = System.Drawing.Color.White;
            this.panelAttendanceAndPayrollDetails.Location = new System.Drawing.Point(432, 134);
            this.panelAttendanceAndPayrollDetails.Name = "panelAttendanceAndPayrollDetails";
            this.panelAttendanceAndPayrollDetails.ShadowDecoration.BorderRadius = 15;
            this.panelAttendanceAndPayrollDetails.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelAttendanceAndPayrollDetails.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.panelAttendanceAndPayrollDetails.Size = new System.Drawing.Size(1080, 700);
            this.panelAttendanceAndPayrollDetails.TabIndex = 151;
            // 
            // btnDownloadGeneratedReports
            // 
            this.btnDownloadGeneratedReports.BackColor = System.Drawing.Color.White;
            this.btnDownloadGeneratedReports.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.btnDownloadGeneratedReports.BorderRadius = 4;
            this.btnDownloadGeneratedReports.BorderThickness = 4;
            this.btnDownloadGeneratedReports.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDownloadGeneratedReports.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDownloadGeneratedReports.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDownloadGeneratedReports.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDownloadGeneratedReports.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(121)))), ((int)(((byte)(107)))));
            this.btnDownloadGeneratedReports.Font = new System.Drawing.Font("Times New Roman", 9.5F);
            this.btnDownloadGeneratedReports.ForeColor = System.Drawing.Color.White;
            this.btnDownloadGeneratedReports.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(64)))));
            this.btnDownloadGeneratedReports.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(64)))));
            this.btnDownloadGeneratedReports.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnDownloadGeneratedReports.Image = ((System.Drawing.Image)(resources.GetObject("btnDownloadGeneratedReports.Image")));
            this.btnDownloadGeneratedReports.ImageSize = new System.Drawing.Size(24, 24);
            this.btnDownloadGeneratedReports.Location = new System.Drawing.Point(855, 15);
            this.btnDownloadGeneratedReports.Name = "btnDownloadGeneratedReports";
            this.btnDownloadGeneratedReports.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btnDownloadGeneratedReports.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDownloadGeneratedReports.Size = new System.Drawing.Size(200, 40);
            this.btnDownloadGeneratedReports.TabIndex = 152;
            this.btnDownloadGeneratedReports.Text = "Download Reports";
            this.btnDownloadGeneratedReports.Click += new System.EventHandler(this.btnDownloadGeneratedReports_Click);
            // 
            // lblSelectedEmployeeCount
            // 
            this.lblSelectedEmployeeCount.BackColor = System.Drawing.Color.White;
            this.lblSelectedEmployeeCount.Font = new System.Drawing.Font("Bell MT", 10.5F);
            this.lblSelectedEmployeeCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSelectedEmployeeCount.Location = new System.Drawing.Point(20, 25);
            this.lblSelectedEmployeeCount.Name = "lblSelectedEmployeeCount";
            this.lblSelectedEmployeeCount.Size = new System.Drawing.Size(437, 30);
            this.lblSelectedEmployeeCount.TabIndex = 150;
            this.lblSelectedEmployeeCount.Text = "Selected: 0";
            this.lblSelectedEmployeeCount.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.White;
            this.guna2Panel4.BorderColor = System.Drawing.Color.Ivory;
            this.guna2Panel4.BorderRadius = 5;
            this.guna2Panel4.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2Panel4.Controls.Add(this.flowLayoutPanelReportDetails);
            this.guna2Panel4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.guna2Panel4.ForeColor = System.Drawing.Color.White;
            this.guna2Panel4.Location = new System.Drawing.Point(24, 75);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel4.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel4.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.guna2Panel4.Size = new System.Drawing.Size(1031, 590);
            this.guna2Panel4.TabIndex = 151;
            // 
            // flowLayoutPanelReportDetails
            // 
            this.flowLayoutPanelReportDetails.AutoScroll = true;
            this.flowLayoutPanelReportDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.flowLayoutPanelReportDetails.ForeColor = System.Drawing.Color.Black;
            this.flowLayoutPanelReportDetails.Location = new System.Drawing.Point(27, 26);
            this.flowLayoutPanelReportDetails.Name = "flowLayoutPanelReportDetails";
            this.flowLayoutPanelReportDetails.Size = new System.Drawing.Size(977, 548);
            this.flowLayoutPanelReportDetails.TabIndex = 150;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.BorderColor = System.Drawing.Color.Ivory;
            this.guna2Panel2.BorderRadius = 5;
            this.guna2Panel2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2Panel2.Controls.Add(this.chkSelectAllEmployee);
            this.guna2Panel2.Controls.Add(this.flowLayoutPanelEmployeeListForReports);
            this.guna2Panel2.Controls.Add(this.label5);
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.guna2Panel2.ForeColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(35, 34);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.guna2Panel2.Size = new System.Drawing.Size(349, 734);
            this.guna2Panel2.TabIndex = 149;
            // 
            // chkSelectAllEmployee
            // 
            this.chkSelectAllEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.chkSelectAllEmployee.Font = new System.Drawing.Font("Bell MT", 10.5F);
            this.chkSelectAllEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkSelectAllEmployee.Location = new System.Drawing.Point(205, 44);
            this.chkSelectAllEmployee.Name = "chkSelectAllEmployee";
            this.chkSelectAllEmployee.Size = new System.Drawing.Size(141, 30);
            this.chkSelectAllEmployee.TabIndex = 150;
            this.chkSelectAllEmployee.Text = "Select ALL";
            this.chkSelectAllEmployee.UseVisualStyleBackColor = false;
            this.chkSelectAllEmployee.CheckedChanged += new System.EventHandler(this.chkSelectAllEmployee_CheckedChanged);
            // 
            // flowLayoutPanelEmployeeListForReports
            // 
            this.flowLayoutPanelEmployeeListForReports.AutoScroll = true;
            this.flowLayoutPanelEmployeeListForReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.flowLayoutPanelEmployeeListForReports.ForeColor = System.Drawing.Color.Black;
            this.flowLayoutPanelEmployeeListForReports.Location = new System.Drawing.Point(13, 80);
            this.flowLayoutPanelEmployeeListForReports.Name = "flowLayoutPanelEmployeeListForReports";
            this.flowLayoutPanelEmployeeListForReports.Size = new System.Drawing.Size(336, 639);
            this.flowLayoutPanelEmployeeListForReports.TabIndex = 149;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.label5.Font = new System.Drawing.Font("Bell MT", 11F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(9, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(337, 30);
            this.label5.TabIndex = 149;
            this.label5.Text = "Choose Employee:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormGenerateReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1914, 976);
            this.Controls.Add(this.panelEmployeeListCard);
            this.Name = "FormGenerateReports";
            this.Text = "Attendance and Payroll Reports";
            this.Load += new System.EventHandler(this.FormGenerateReports_Load);
            this.panelEmployeeListCard.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.panelAttendanceAndPayrollDetails.ResumeLayout(false);
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2Panel panelEmployeeListCard;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPayrollPeriods;
        public Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        public Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox cboReportType;
        public Guna.UI2.WinForms.Guna2Panel panelAttendanceAndPayrollDetails;
        public Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        public Guna.UI2.WinForms.Guna2Button btnGenerateReports;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelEmployeeListForReports;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelReportDetails;
        private System.Windows.Forms.Label lblSelectedEmployeeCount;
        private System.Windows.Forms.CheckBox chkSelectAllEmployee;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnDownloadGeneratedReports;
    }
}