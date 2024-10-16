namespace GUTZ_Capstone_Project
{
    partial class EmployeeAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeAttendance));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.dtpEmpSelectDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnViewPastAttendanceRecord = new Guna.UI2.WinForms.Guna2Button();
            this.panelAttendanceManagement = new Guna.UI2.WinForms.Guna2Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLate = new Guna.UI2.WinForms.Guna2Button();
            this.btnOnTime = new Guna.UI2.WinForms.Guna2Button();
            this.btnPresent = new Guna.UI2.WinForms.Guna2Button();
            this.dateOfCurrentAttendanceRecord = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.panelAttendanceManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Controls.Add(this.panelAttendanceManagement);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Font = new System.Drawing.Font("Symbol", 8.25F);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 1;
            this.guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.Green;
            this.guna2Panel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Size = new System.Drawing.Size(1914, 202);
            this.guna2Panel1.TabIndex = 3;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2Panel2.BorderRadius = 8;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.dtpEmpSelectDate);
            this.guna2Panel2.Controls.Add(this.btnViewPastAttendanceRecord);
            this.guna2Panel2.FillColor = System.Drawing.Color.White;
            this.guna2Panel2.ForeColor = System.Drawing.Color.Black;
            this.guna2Panel2.Location = new System.Drawing.Point(1177, 35);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.BorderRadius = 8;
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.Green;
            this.guna2Panel2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.guna2Panel2.Size = new System.Drawing.Size(391, 133);
            this.guna2Panel2.TabIndex = 36;
            // 
            // dtpEmpSelectDate
            // 
            this.dtpEmpSelectDate.AutoRoundedCorners = true;
            this.dtpEmpSelectDate.BackColor = System.Drawing.Color.Transparent;
            this.dtpEmpSelectDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.dtpEmpSelectDate.BorderRadius = 19;
            this.dtpEmpSelectDate.BorderThickness = 1;
            this.dtpEmpSelectDate.Checked = true;
            this.dtpEmpSelectDate.CustomFormat = "MMMM dd, yyyy";
            this.dtpEmpSelectDate.FillColor = System.Drawing.Color.White;
            this.dtpEmpSelectDate.FocusedColor = System.Drawing.Color.Green;
            this.dtpEmpSelectDate.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.dtpEmpSelectDate.ForeColor = System.Drawing.Color.Black;
            this.dtpEmpSelectDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEmpSelectDate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.dtpEmpSelectDate.HoverState.FillColor = System.Drawing.Color.White;
            this.dtpEmpSelectDate.Location = new System.Drawing.Point(77, 75);
            this.dtpEmpSelectDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEmpSelectDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEmpSelectDate.Name = "dtpEmpSelectDate";
            this.dtpEmpSelectDate.Size = new System.Drawing.Size(248, 40);
            this.dtpEmpSelectDate.TabIndex = 82;
            this.dtpEmpSelectDate.Value = new System.DateTime(2024, 10, 10, 0, 0, 0, 0);
            this.dtpEmpSelectDate.Visible = false;
            this.dtpEmpSelectDate.ValueChanged += new System.EventHandler(this.dtpEmpSelectDate_ValueChanged);
            // 
            // btnViewPastAttendanceRecord
            // 
            this.btnViewPastAttendanceRecord.AutoRoundedCorners = true;
            this.btnViewPastAttendanceRecord.BackColor = System.Drawing.Color.Transparent;
            this.btnViewPastAttendanceRecord.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.btnViewPastAttendanceRecord.BorderRadius = 21;
            this.btnViewPastAttendanceRecord.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewPastAttendanceRecord.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewPastAttendanceRecord.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewPastAttendanceRecord.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewPastAttendanceRecord.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.btnViewPastAttendanceRecord.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewPastAttendanceRecord.ForeColor = System.Drawing.Color.White;
            this.btnViewPastAttendanceRecord.HoverState.BorderColor = System.Drawing.Color.Green;
            this.btnViewPastAttendanceRecord.HoverState.FillColor = System.Drawing.Color.Green;
            this.btnViewPastAttendanceRecord.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnViewPastAttendanceRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnViewPastAttendanceRecord.Image")));
            this.btnViewPastAttendanceRecord.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnViewPastAttendanceRecord.ImageSize = new System.Drawing.Size(25, 25);
            this.btnViewPastAttendanceRecord.Location = new System.Drawing.Point(50, 19);
            this.btnViewPastAttendanceRecord.Name = "btnViewPastAttendanceRecord";
            this.btnViewPastAttendanceRecord.Padding = new System.Windows.Forms.Padding(17, 0, 0, 0);
            this.btnViewPastAttendanceRecord.PressedColor = System.Drawing.Color.LightGreen;
            this.btnViewPastAttendanceRecord.Size = new System.Drawing.Size(292, 45);
            this.btnViewPastAttendanceRecord.TabIndex = 74;
            this.btnViewPastAttendanceRecord.Text = "Past Attendance Record";
            this.btnViewPastAttendanceRecord.Click += new System.EventHandler(this.btnViewPastAttendanceRecord_Click);
            // 
            // panelAttendanceManagement
            // 
            this.panelAttendanceManagement.BackColor = System.Drawing.Color.Transparent;
            this.panelAttendanceManagement.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.panelAttendanceManagement.BorderRadius = 15;
            this.panelAttendanceManagement.Controls.Add(this.label4);
            this.panelAttendanceManagement.Controls.Add(this.label2);
            this.panelAttendanceManagement.Controls.Add(this.label3);
            this.panelAttendanceManagement.Controls.Add(this.btnLate);
            this.panelAttendanceManagement.Controls.Add(this.btnOnTime);
            this.panelAttendanceManagement.Controls.Add(this.btnPresent);
            this.panelAttendanceManagement.Controls.Add(this.dateOfCurrentAttendanceRecord);
            this.panelAttendanceManagement.FillColor = System.Drawing.Color.White;
            this.panelAttendanceManagement.ForeColor = System.Drawing.Color.Black;
            this.panelAttendanceManagement.Location = new System.Drawing.Point(30, 23);
            this.panelAttendanceManagement.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelAttendanceManagement.Name = "panelAttendanceManagement";
            this.panelAttendanceManagement.ShadowDecoration.BorderRadius = 15;
            this.panelAttendanceManagement.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.panelAttendanceManagement.Size = new System.Drawing.Size(485, 154);
            this.panelAttendanceManagement.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(362, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 26);
            this.label4.TabIndex = 35;
            this.label4.Text = "Late";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(14, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 26);
            this.label2.TabIndex = 33;
            this.label2.Text = "Present";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(188, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 28);
            this.label3.TabIndex = 34;
            this.label3.Text = "On Time";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLate
            // 
            this.btnLate.BackColor = System.Drawing.Color.Transparent;
            this.btnLate.BorderColor = System.Drawing.Color.Red;
            this.btnLate.BorderRadius = 8;
            this.btnLate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLate.FillColor = System.Drawing.Color.Red;
            this.btnLate.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.btnLate.ForeColor = System.Drawing.Color.White;
            this.btnLate.HoverState.FillColor = System.Drawing.Color.Red;
            this.btnLate.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnLate.ImageSize = new System.Drawing.Size(35, 32);
            this.btnLate.Location = new System.Drawing.Point(362, 61);
            this.btnLate.Margin = new System.Windows.Forms.Padding(5);
            this.btnLate.Name = "btnLate";
            this.btnLate.Padding = new System.Windows.Forms.Padding(15, 5, 10, 3);
            this.btnLate.PressedColor = System.Drawing.Color.Red;
            this.btnLate.PressedDepth = 0;
            this.btnLate.ShadowDecoration.BorderRadius = 8;
            this.btnLate.ShadowDecoration.Color = System.Drawing.Color.Red;
            this.btnLate.ShadowDecoration.Enabled = true;
            this.btnLate.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.btnLate.Size = new System.Drawing.Size(108, 50);
            this.btnLate.TabIndex = 27;
            this.btnLate.Text = "0";
            // 
            // btnOnTime
            // 
            this.btnOnTime.BackColor = System.Drawing.Color.Transparent;
            this.btnOnTime.BorderColor = System.Drawing.Color.Green;
            this.btnOnTime.BorderRadius = 8;
            this.btnOnTime.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOnTime.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOnTime.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOnTime.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOnTime.FillColor = System.Drawing.Color.Green;
            this.btnOnTime.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.btnOnTime.ForeColor = System.Drawing.Color.White;
            this.btnOnTime.HoverState.FillColor = System.Drawing.Color.Green;
            this.btnOnTime.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnOnTime.ImageSize = new System.Drawing.Size(35, 32);
            this.btnOnTime.Location = new System.Drawing.Point(188, 61);
            this.btnOnTime.Margin = new System.Windows.Forms.Padding(5);
            this.btnOnTime.Name = "btnOnTime";
            this.btnOnTime.Padding = new System.Windows.Forms.Padding(15, 5, 10, 3);
            this.btnOnTime.PressedColor = System.Drawing.Color.Green;
            this.btnOnTime.PressedDepth = 0;
            this.btnOnTime.ShadowDecoration.BorderRadius = 8;
            this.btnOnTime.ShadowDecoration.Color = System.Drawing.Color.Green;
            this.btnOnTime.ShadowDecoration.Enabled = true;
            this.btnOnTime.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.btnOnTime.Size = new System.Drawing.Size(108, 50);
            this.btnOnTime.TabIndex = 26;
            this.btnOnTime.Text = "0";
            // 
            // btnPresent
            // 
            this.btnPresent.BackColor = System.Drawing.Color.Transparent;
            this.btnPresent.BorderColor = System.Drawing.Color.Orange;
            this.btnPresent.BorderRadius = 8;
            this.btnPresent.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPresent.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPresent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPresent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPresent.FillColor = System.Drawing.Color.Orange;
            this.btnPresent.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.btnPresent.ForeColor = System.Drawing.Color.White;
            this.btnPresent.HoverState.FillColor = System.Drawing.Color.Orange;
            this.btnPresent.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnPresent.ImageSize = new System.Drawing.Size(35, 32);
            this.btnPresent.Location = new System.Drawing.Point(14, 61);
            this.btnPresent.Margin = new System.Windows.Forms.Padding(5);
            this.btnPresent.Name = "btnPresent";
            this.btnPresent.Padding = new System.Windows.Forms.Padding(15, 5, 10, 3);
            this.btnPresent.PressedColor = System.Drawing.Color.Orange;
            this.btnPresent.PressedDepth = 0;
            this.btnPresent.ShadowDecoration.BorderRadius = 8;
            this.btnPresent.ShadowDecoration.Color = System.Drawing.Color.Orange;
            this.btnPresent.ShadowDecoration.Enabled = true;
            this.btnPresent.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.btnPresent.Size = new System.Drawing.Size(108, 50);
            this.btnPresent.TabIndex = 25;
            this.btnPresent.Text = "0";
            // 
            // dateOfCurrentAttendanceRecord
            // 
            this.dateOfCurrentAttendanceRecord.AutoSize = true;
            this.dateOfCurrentAttendanceRecord.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Bold);
            this.dateOfCurrentAttendanceRecord.ForeColor = System.Drawing.Color.Black;
            this.dateOfCurrentAttendanceRecord.Location = new System.Drawing.Point(10, 12);
            this.dateOfCurrentAttendanceRecord.Name = "dateOfCurrentAttendanceRecord";
            this.dateOfCurrentAttendanceRecord.Size = new System.Drawing.Size(192, 24);
            this.dateOfCurrentAttendanceRecord.TabIndex = 24;
            this.dateOfCurrentAttendanceRecord.Text = "Attendance Today";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1714, 202);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 774);
            this.flowLayoutPanel2.TabIndex = 5;
            this.flowLayoutPanel2.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 202);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1714, 774);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // EmployeeAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(1914, 976);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "EmployeeAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Attendance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployeeAttendance_FormClosing);
            this.Load += new System.EventHandler(this.EmployeeAttendance_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.panelAttendanceManagement.ResumeLayout(false);
            this.panelAttendanceManagement.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Guna.UI2.WinForms.Guna2Panel panelAttendanceManagement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button btnLate;
        private Guna.UI2.WinForms.Guna2Button btnOnTime;
        private Guna.UI2.WinForms.Guna2Button btnPresent;
        private System.Windows.Forms.Label dateOfCurrentAttendanceRecord;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        public Guna.UI2.WinForms.Guna2Button btnViewPastAttendanceRecord;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEmpSelectDate;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.Timer timer1;
    }
}