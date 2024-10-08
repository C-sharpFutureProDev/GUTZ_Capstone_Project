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
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Button8 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button7 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button6 = new Guna.UI2.WinForms.Guna2Button();
            this.btnLate = new Guna.UI2.WinForms.Guna2Button();
            this.btnOnTime = new Guna.UI2.WinForms.Guna2Button();
            this.btnPresent = new Guna.UI2.WinForms.Guna2Button();
            this.shiftLabelStatus = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.panelAttendanceManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Controls.Add(this.panelAttendanceManagement);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel1.Font = new System.Drawing.Font("Symbol", 8.25F);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 5;
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
            this.guna2Panel2.Location = new System.Drawing.Point(1169, 35);
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
            this.dtpEmpSelectDate.Value = new System.DateTime(2024, 9, 23, 0, 0, 0, 0);
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
            this.panelAttendanceManagement.BorderColor = System.Drawing.Color.Gainsboro;
            this.panelAttendanceManagement.BorderRadius = 8;
            this.panelAttendanceManagement.BorderThickness = 1;
            this.panelAttendanceManagement.Controls.Add(this.guna2Button2);
            this.panelAttendanceManagement.Controls.Add(this.label1);
            this.panelAttendanceManagement.Controls.Add(this.guna2Button1);
            this.panelAttendanceManagement.Controls.Add(this.label4);
            this.panelAttendanceManagement.Controls.Add(this.label3);
            this.panelAttendanceManagement.Controls.Add(this.label2);
            this.panelAttendanceManagement.Controls.Add(this.guna2Button8);
            this.panelAttendanceManagement.Controls.Add(this.guna2Button7);
            this.panelAttendanceManagement.Controls.Add(this.guna2Button6);
            this.panelAttendanceManagement.Controls.Add(this.btnLate);
            this.panelAttendanceManagement.Controls.Add(this.btnOnTime);
            this.panelAttendanceManagement.Controls.Add(this.btnPresent);
            this.panelAttendanceManagement.Controls.Add(this.shiftLabelStatus);
            this.panelAttendanceManagement.FillColor = System.Drawing.Color.White;
            this.panelAttendanceManagement.ForeColor = System.Drawing.Color.Black;
            this.panelAttendanceManagement.Location = new System.Drawing.Point(32, 35);
            this.panelAttendanceManagement.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelAttendanceManagement.Name = "panelAttendanceManagement";
            this.panelAttendanceManagement.ShadowDecoration.BorderRadius = 8;
            this.panelAttendanceManagement.ShadowDecoration.Color = System.Drawing.Color.Green;
            this.panelAttendanceManagement.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.panelAttendanceManagement.Size = new System.Drawing.Size(1079, 133);
            this.panelAttendanceManagement.TabIndex = 24;
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderColor = System.Drawing.Color.Blue;
            this.guna2Button2.BorderRadius = 5;
            this.guna2Button2.BorderThickness = 1;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.White;
            this.guna2Button2.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.guna2Button2.ForeColor = System.Drawing.Color.Blue;
            this.guna2Button2.HoverState.FillColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.ForeColor = System.Drawing.Color.Blue;
            this.guna2Button2.ImageSize = new System.Drawing.Size(35, 32);
            this.guna2Button2.Location = new System.Drawing.Point(93, 60);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Padding = new System.Windows.Forms.Padding(15, 5, 10, 3);
            this.guna2Button2.PressedColor = System.Drawing.Color.White;
            this.guna2Button2.ShadowDecoration.BorderRadius = 8;
            this.guna2Button2.ShadowDecoration.Color = System.Drawing.Color.Blue;
            this.guna2Button2.ShadowDecoration.Enabled = true;
            this.guna2Button2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.guna2Button2.Size = new System.Drawing.Size(108, 48);
            this.guna2Button2.TabIndex = 38;
            this.guna2Button2.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(839, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 19);
            this.label1.TabIndex = 37;
            this.label1.Text = "Expected";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.Orange;
            this.guna2Button1.BorderRadius = 4;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Blue;
            this.guna2Button1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.Gray;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.Orange;
            this.guna2Button1.HoverState.ForeColor = System.Drawing.Color.Gray;
            this.guna2Button1.ImageSize = new System.Drawing.Size(35, 32);
            this.guna2Button1.Location = new System.Drawing.Point(801, 19);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Padding = new System.Windows.Forms.Padding(15, 5, 10, 3);
            this.guna2Button1.PressedColor = System.Drawing.Color.Blue;
            this.guna2Button1.ShadowDecoration.BorderRadius = 30;
            this.guna2Button1.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.guna2Button1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.guna2Button1.Size = new System.Drawing.Size(30, 19);
            this.guna2Button1.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(994, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 19);
            this.label4.TabIndex = 35;
            this.label4.Text = "Late";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(839, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 34;
            this.label3.Text = "On Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(994, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "Present";
            // 
            // guna2Button8
            // 
            this.guna2Button8.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button8.BorderColor = System.Drawing.Color.Red;
            this.guna2Button8.BorderRadius = 4;
            this.guna2Button8.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button8.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button8.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button8.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button8.FillColor = System.Drawing.Color.Red;
            this.guna2Button8.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.guna2Button8.ForeColor = System.Drawing.Color.Gray;
            this.guna2Button8.HoverState.FillColor = System.Drawing.Color.Red;
            this.guna2Button8.HoverState.ForeColor = System.Drawing.Color.Gray;
            this.guna2Button8.ImageSize = new System.Drawing.Size(35, 32);
            this.guna2Button8.Location = new System.Drawing.Point(956, 89);
            this.guna2Button8.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Button8.Name = "guna2Button8";
            this.guna2Button8.Padding = new System.Windows.Forms.Padding(15, 5, 10, 3);
            this.guna2Button8.PressedColor = System.Drawing.Color.Red;
            this.guna2Button8.ShadowDecoration.BorderRadius = 30;
            this.guna2Button8.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.guna2Button8.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.guna2Button8.Size = new System.Drawing.Size(30, 19);
            this.guna2Button8.TabIndex = 31;
            // 
            // guna2Button7
            // 
            this.guna2Button7.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button7.BorderColor = System.Drawing.Color.Green;
            this.guna2Button7.BorderRadius = 4;
            this.guna2Button7.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button7.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button7.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button7.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button7.FillColor = System.Drawing.Color.Green;
            this.guna2Button7.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.guna2Button7.ForeColor = System.Drawing.Color.Gray;
            this.guna2Button7.HoverState.FillColor = System.Drawing.Color.Green;
            this.guna2Button7.HoverState.ForeColor = System.Drawing.Color.Gray;
            this.guna2Button7.ImageSize = new System.Drawing.Size(35, 32);
            this.guna2Button7.Location = new System.Drawing.Point(801, 89);
            this.guna2Button7.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Button7.Name = "guna2Button7";
            this.guna2Button7.Padding = new System.Windows.Forms.Padding(15, 5, 10, 3);
            this.guna2Button7.PressedColor = System.Drawing.Color.Green;
            this.guna2Button7.ShadowDecoration.BorderRadius = 30;
            this.guna2Button7.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.guna2Button7.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.guna2Button7.Size = new System.Drawing.Size(30, 19);
            this.guna2Button7.TabIndex = 30;
            // 
            // guna2Button6
            // 
            this.guna2Button6.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button6.BorderColor = System.Drawing.Color.Orange;
            this.guna2Button6.BorderRadius = 4;
            this.guna2Button6.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button6.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button6.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button6.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button6.FillColor = System.Drawing.Color.Orange;
            this.guna2Button6.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.guna2Button6.ForeColor = System.Drawing.Color.Gray;
            this.guna2Button6.HoverState.FillColor = System.Drawing.Color.Orange;
            this.guna2Button6.HoverState.ForeColor = System.Drawing.Color.Gray;
            this.guna2Button6.ImageSize = new System.Drawing.Size(35, 32);
            this.guna2Button6.Location = new System.Drawing.Point(956, 19);
            this.guna2Button6.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Button6.Name = "guna2Button6";
            this.guna2Button6.Padding = new System.Windows.Forms.Padding(15, 5, 10, 3);
            this.guna2Button6.PressedColor = System.Drawing.Color.Orange;
            this.guna2Button6.ShadowDecoration.BorderRadius = 30;
            this.guna2Button6.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.guna2Button6.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.guna2Button6.Size = new System.Drawing.Size(30, 19);
            this.guna2Button6.TabIndex = 29;
            // 
            // btnLate
            // 
            this.btnLate.BackColor = System.Drawing.Color.Transparent;
            this.btnLate.BorderColor = System.Drawing.Color.Red;
            this.btnLate.BorderRadius = 5;
            this.btnLate.BorderThickness = 1;
            this.btnLate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLate.FillColor = System.Drawing.Color.White;
            this.btnLate.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.btnLate.ForeColor = System.Drawing.Color.Red;
            this.btnLate.HoverState.FillColor = System.Drawing.Color.White;
            this.btnLate.HoverState.ForeColor = System.Drawing.Color.Red;
            this.btnLate.ImageSize = new System.Drawing.Size(35, 32);
            this.btnLate.Location = new System.Drawing.Point(594, 60);
            this.btnLate.Margin = new System.Windows.Forms.Padding(5);
            this.btnLate.Name = "btnLate";
            this.btnLate.Padding = new System.Windows.Forms.Padding(15, 5, 10, 3);
            this.btnLate.PressedColor = System.Drawing.Color.White;
            this.btnLate.ShadowDecoration.BorderRadius = 8;
            this.btnLate.ShadowDecoration.Color = System.Drawing.Color.Red;
            this.btnLate.ShadowDecoration.Enabled = true;
            this.btnLate.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.btnLate.Size = new System.Drawing.Size(108, 48);
            this.btnLate.TabIndex = 27;
            this.btnLate.Text = "0";
            // 
            // btnOnTime
            // 
            this.btnOnTime.BackColor = System.Drawing.Color.Transparent;
            this.btnOnTime.BorderColor = System.Drawing.Color.Green;
            this.btnOnTime.BorderRadius = 5;
            this.btnOnTime.BorderThickness = 1;
            this.btnOnTime.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOnTime.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOnTime.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOnTime.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOnTime.FillColor = System.Drawing.Color.White;
            this.btnOnTime.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.btnOnTime.ForeColor = System.Drawing.Color.Green;
            this.btnOnTime.HoverState.FillColor = System.Drawing.Color.White;
            this.btnOnTime.HoverState.ForeColor = System.Drawing.Color.Green;
            this.btnOnTime.ImageSize = new System.Drawing.Size(35, 32);
            this.btnOnTime.Location = new System.Drawing.Point(427, 60);
            this.btnOnTime.Margin = new System.Windows.Forms.Padding(5);
            this.btnOnTime.Name = "btnOnTime";
            this.btnOnTime.Padding = new System.Windows.Forms.Padding(15, 5, 10, 3);
            this.btnOnTime.PressedColor = System.Drawing.Color.White;
            this.btnOnTime.ShadowDecoration.BorderRadius = 8;
            this.btnOnTime.ShadowDecoration.Color = System.Drawing.Color.Green;
            this.btnOnTime.ShadowDecoration.Enabled = true;
            this.btnOnTime.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.btnOnTime.Size = new System.Drawing.Size(108, 48);
            this.btnOnTime.TabIndex = 26;
            this.btnOnTime.Text = "0";
            // 
            // btnPresent
            // 
            this.btnPresent.BackColor = System.Drawing.Color.Transparent;
            this.btnPresent.BorderColor = System.Drawing.Color.Orange;
            this.btnPresent.BorderRadius = 5;
            this.btnPresent.BorderThickness = 1;
            this.btnPresent.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPresent.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPresent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPresent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPresent.FillColor = System.Drawing.Color.White;
            this.btnPresent.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.btnPresent.ForeColor = System.Drawing.Color.Orange;
            this.btnPresent.HoverState.FillColor = System.Drawing.Color.White;
            this.btnPresent.HoverState.ForeColor = System.Drawing.Color.Orange;
            this.btnPresent.ImageSize = new System.Drawing.Size(35, 32);
            this.btnPresent.Location = new System.Drawing.Point(260, 60);
            this.btnPresent.Margin = new System.Windows.Forms.Padding(5);
            this.btnPresent.Name = "btnPresent";
            this.btnPresent.Padding = new System.Windows.Forms.Padding(15, 5, 10, 3);
            this.btnPresent.PressedColor = System.Drawing.Color.White;
            this.btnPresent.ShadowDecoration.BorderRadius = 8;
            this.btnPresent.ShadowDecoration.Color = System.Drawing.Color.Orange;
            this.btnPresent.ShadowDecoration.Enabled = true;
            this.btnPresent.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.btnPresent.Size = new System.Drawing.Size(108, 48);
            this.btnPresent.TabIndex = 25;
            this.btnPresent.Text = "0";
            // 
            // shiftLabelStatus
            // 
            this.shiftLabelStatus.AutoSize = true;
            this.shiftLabelStatus.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.shiftLabelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.shiftLabelStatus.Location = new System.Drawing.Point(20, 10);
            this.shiftLabelStatus.Name = "shiftLabelStatus";
            this.shiftLabelStatus.Size = new System.Drawing.Size(178, 22);
            this.shiftLabelStatus.TabIndex = 24;
            this.shiftLabelStatus.Text = "Attendance Today";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 202);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1914, 774);
            this.flowLayoutPanel1.TabIndex = 4;
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
            // EmployeeAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(1914, 976);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
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
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Panel panelAttendanceManagement;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button guna2Button8;
        private Guna.UI2.WinForms.Guna2Button guna2Button7;
        private Guna.UI2.WinForms.Guna2Button guna2Button6;
        private Guna.UI2.WinForms.Guna2Button btnLate;
        private Guna.UI2.WinForms.Guna2Button btnOnTime;
        private Guna.UI2.WinForms.Guna2Button btnPresent;
        private System.Windows.Forms.Label shiftLabelStatus;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        public Guna.UI2.WinForms.Guna2Button btnViewPastAttendanceRecord;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEmpSelectDate;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}