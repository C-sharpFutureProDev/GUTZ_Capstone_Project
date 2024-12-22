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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnViewEmployeeList = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.dtpEmpSelectDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnTotalAttendance = new System.Windows.Forms.Label();
            this.btnAbsent = new Guna.UI2.WinForms.Guna2Button();
            this.btnClockIn = new Guna.UI2.WinForms.Guna2Button();
            this.btnClockOut = new Guna.UI2.WinForms.Guna2Button();
            this.btnOnLeave = new Guna.UI2.WinForms.Guna2Button();
            this.cboFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pastdtpBottomBorder = new Guna.UI2.WinForms.Guna2Separator();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSelectDate = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.panelEmployeeDetails = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel7 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblScheduledEmployee = new System.Windows.Forms.Label();
            this.guna2Panel6 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLateEmployee = new System.Windows.Forms.Label();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblOnTimeEmployee = new System.Windows.Forms.Label();
            this.btnViewAnDownloadReport = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTutoringHours = new System.Windows.Forms.Label();
            this.lblAccumulatedTutoringHours = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAttendancePercentage = new System.Windows.Forms.Label();
            this.lblAttendancePercent = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblScheduledEmployeeToday = new System.Windows.Forms.Label();
            this.lblExpectedClockIn = new System.Windows.Forms.Label();
            this.lblAttendanceSummaryDate = new System.Windows.Forms.Label();
            this.dateOfCurrentAttendanceRecord = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.panelEmployeeDetails.SuspendLayout();
            this.guna2Panel7.SuspendLayout();
            this.guna2Panel6.SuspendLayout();
            this.guna2Panel5.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.Gray;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1714, 290);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 686);
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
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Gray;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 290);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1714, 686);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // btnViewEmployeeList
            // 
            this.btnViewEmployeeList.BackColor = System.Drawing.Color.Transparent;
            this.btnViewEmployeeList.BorderColor = System.Drawing.Color.Teal;
            this.btnViewEmployeeList.BorderRadius = 9;
            this.btnViewEmployeeList.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewEmployeeList.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewEmployeeList.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewEmployeeList.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewEmployeeList.FillColor = System.Drawing.Color.Teal;
            this.btnViewEmployeeList.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewEmployeeList.ForeColor = System.Drawing.Color.White;
            this.btnViewEmployeeList.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnViewEmployeeList.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnViewEmployeeList.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnViewEmployeeList.Image = ((System.Drawing.Image)(resources.GetObject("btnViewEmployeeList.Image")));
            this.btnViewEmployeeList.ImageSize = new System.Drawing.Size(26, 27);
            this.btnViewEmployeeList.Location = new System.Drawing.Point(806, 17);
            this.btnViewEmployeeList.Name = "btnViewEmployeeList";
            this.btnViewEmployeeList.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnViewEmployeeList.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnViewEmployeeList.Size = new System.Drawing.Size(496, 42);
            this.btnViewEmployeeList.TabIndex = 109;
            this.btnViewEmployeeList.Text = "See Employee List";
            this.btnViewEmployeeList.Click += new System.EventHandler(this.btnViewEmployeeList_Click_1);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BorderColor = System.Drawing.Color.Coral;
            this.btnRefresh.BorderRadius = 9;
            this.btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefresh.FillColor = System.Drawing.Color.Coral;
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 10F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverState.BorderColor = System.Drawing.Color.Tomato;
            this.btnRefresh.HoverState.FillColor = System.Drawing.Color.Tomato;
            this.btnRefresh.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageSize = new System.Drawing.Size(25, 24);
            this.btnRefresh.Location = new System.Drawing.Point(1323, 17);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnRefresh.PressedColor = System.Drawing.Color.Salmon;
            this.btnRefresh.Size = new System.Drawing.Size(253, 42);
            this.btnRefresh.TabIndex = 112;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dtpEmpSelectDate
            // 
            this.dtpEmpSelectDate.BackColor = System.Drawing.Color.Transparent;
            this.dtpEmpSelectDate.BorderColor = System.Drawing.Color.Ivory;
            this.dtpEmpSelectDate.BorderThickness = 1;
            this.dtpEmpSelectDate.Checked = true;
            this.dtpEmpSelectDate.CustomFormat = "MMMM dd, yyyy";
            this.dtpEmpSelectDate.FillColor = System.Drawing.Color.Ivory;
            this.dtpEmpSelectDate.FocusedColor = System.Drawing.Color.White;
            this.dtpEmpSelectDate.Font = new System.Drawing.Font("Arial", 9F);
            this.dtpEmpSelectDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpEmpSelectDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEmpSelectDate.HoverState.BorderColor = System.Drawing.Color.Ivory;
            this.dtpEmpSelectDate.HoverState.FillColor = System.Drawing.Color.Ivory;
            this.dtpEmpSelectDate.HoverState.ForeColor = System.Drawing.Color.Black;
            this.dtpEmpSelectDate.Location = new System.Drawing.Point(514, 231);
            this.dtpEmpSelectDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEmpSelectDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEmpSelectDate.Name = "dtpEmpSelectDate";
            this.dtpEmpSelectDate.Size = new System.Drawing.Size(247, 40);
            this.dtpEmpSelectDate.TabIndex = 82;
            this.dtpEmpSelectDate.Value = new System.DateTime(2024, 12, 19, 0, 0, 0, 0);
            this.dtpEmpSelectDate.ValueChanged += new System.EventHandler(this.dtpEmpSelectDate_ValueChanged);
            // 
            // btnTotalAttendance
            // 
            this.btnTotalAttendance.BackColor = System.Drawing.Color.Transparent;
            this.btnTotalAttendance.Font = new System.Drawing.Font("Arial Narrow", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnTotalAttendance.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnTotalAttendance.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnTotalAttendance.Location = new System.Drawing.Point(25, 150);
            this.btnTotalAttendance.Name = "btnTotalAttendance";
            this.btnTotalAttendance.Size = new System.Drawing.Size(736, 30);
            this.btnTotalAttendance.TabIndex = 105;
            this.btnTotalAttendance.Text = "Total Attendance:";
            this.btnTotalAttendance.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnAbsent
            // 
            this.btnAbsent.BackColor = System.Drawing.Color.Transparent;
            this.btnAbsent.BorderColor = System.Drawing.Color.Red;
            this.btnAbsent.BorderRadius = 8;
            this.btnAbsent.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAbsent.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAbsent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAbsent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAbsent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.btnAbsent.Font = new System.Drawing.Font("Arial", 18.5F, System.Drawing.FontStyle.Bold);
            this.btnAbsent.ForeColor = System.Drawing.Color.White;
            this.btnAbsent.HoverState.BorderColor = System.Drawing.Color.Red;
            this.btnAbsent.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.btnAbsent.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAbsent.Image = ((System.Drawing.Image)(resources.GetObject("btnAbsent.Image")));
            this.btnAbsent.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAbsent.ImageSize = new System.Drawing.Size(37, 39);
            this.btnAbsent.Location = new System.Drawing.Point(404, 67);
            this.btnAbsent.Margin = new System.Windows.Forms.Padding(5);
            this.btnAbsent.Name = "btnAbsent";
            this.btnAbsent.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnAbsent.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.btnAbsent.PressedDepth = 0;
            this.btnAbsent.ShadowDecoration.BorderRadius = 0;
            this.btnAbsent.ShadowDecoration.Color = System.Drawing.Color.Red;
            this.btnAbsent.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.btnAbsent.Size = new System.Drawing.Size(170, 70);
            this.btnAbsent.TabIndex = 45;
            this.btnAbsent.Text = "0";
            this.btnAbsent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnClockIn
            // 
            this.btnClockIn.BackColor = System.Drawing.Color.Transparent;
            this.btnClockIn.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnClockIn.BorderRadius = 8;
            this.btnClockIn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClockIn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClockIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClockIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClockIn.FillColor = System.Drawing.Color.Orange;
            this.btnClockIn.Font = new System.Drawing.Font("Arial", 18.5F, System.Drawing.FontStyle.Bold);
            this.btnClockIn.ForeColor = System.Drawing.Color.White;
            this.btnClockIn.HoverState.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnClockIn.HoverState.FillColor = System.Drawing.Color.Orange;
            this.btnClockIn.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnClockIn.Image = ((System.Drawing.Image)(resources.GetObject("btnClockIn.Image")));
            this.btnClockIn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClockIn.ImageSize = new System.Drawing.Size(37, 39);
            this.btnClockIn.Location = new System.Drawing.Point(30, 67);
            this.btnClockIn.Margin = new System.Windows.Forms.Padding(5);
            this.btnClockIn.Name = "btnClockIn";
            this.btnClockIn.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnClockIn.PressedColor = System.Drawing.Color.Orange;
            this.btnClockIn.PressedDepth = 0;
            this.btnClockIn.ShadowDecoration.BorderRadius = 0;
            this.btnClockIn.ShadowDecoration.Color = System.Drawing.Color.DarkOrange;
            this.btnClockIn.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.btnClockIn.Size = new System.Drawing.Size(170, 70);
            this.btnClockIn.TabIndex = 42;
            this.btnClockIn.Text = "0";
            this.btnClockIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnClockOut
            // 
            this.btnClockOut.BackColor = System.Drawing.Color.Transparent;
            this.btnClockOut.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnClockOut.BorderRadius = 8;
            this.btnClockOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClockOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClockOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClockOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClockOut.FillColor = System.Drawing.Color.Green;
            this.btnClockOut.Font = new System.Drawing.Font("Arial", 18.5F, System.Drawing.FontStyle.Bold);
            this.btnClockOut.ForeColor = System.Drawing.Color.White;
            this.btnClockOut.HoverState.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnClockOut.HoverState.FillColor = System.Drawing.Color.Green;
            this.btnClockOut.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnClockOut.Image = ((System.Drawing.Image)(resources.GetObject("btnClockOut.Image")));
            this.btnClockOut.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClockOut.ImageSize = new System.Drawing.Size(45, 45);
            this.btnClockOut.Location = new System.Drawing.Point(217, 67);
            this.btnClockOut.Margin = new System.Windows.Forms.Padding(5);
            this.btnClockOut.Name = "btnClockOut";
            this.btnClockOut.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnClockOut.PressedColor = System.Drawing.Color.Green;
            this.btnClockOut.PressedDepth = 0;
            this.btnClockOut.ShadowDecoration.BorderRadius = 0;
            this.btnClockOut.ShadowDecoration.Color = System.Drawing.Color.DarkGreen;
            this.btnClockOut.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.btnClockOut.Size = new System.Drawing.Size(170, 70);
            this.btnClockOut.TabIndex = 40;
            this.btnClockOut.Text = "0";
            this.btnClockOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnOnLeave
            // 
            this.btnOnLeave.BackColor = System.Drawing.Color.Transparent;
            this.btnOnLeave.BorderColor = System.Drawing.Color.Blue;
            this.btnOnLeave.BorderRadius = 8;
            this.btnOnLeave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOnLeave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOnLeave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOnLeave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOnLeave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnOnLeave.Font = new System.Drawing.Font("Arial", 18.5F, System.Drawing.FontStyle.Bold);
            this.btnOnLeave.ForeColor = System.Drawing.Color.White;
            this.btnOnLeave.HoverState.BorderColor = System.Drawing.Color.Blue;
            this.btnOnLeave.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnOnLeave.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnOnLeave.Image = ((System.Drawing.Image)(resources.GetObject("btnOnLeave.Image")));
            this.btnOnLeave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnOnLeave.ImageSize = new System.Drawing.Size(37, 37);
            this.btnOnLeave.Location = new System.Drawing.Point(591, 67);
            this.btnOnLeave.Margin = new System.Windows.Forms.Padding(5);
            this.btnOnLeave.Name = "btnOnLeave";
            this.btnOnLeave.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnOnLeave.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnOnLeave.PressedDepth = 0;
            this.btnOnLeave.ShadowDecoration.BorderRadius = 0;
            this.btnOnLeave.ShadowDecoration.Color = System.Drawing.Color.Indigo;
            this.btnOnLeave.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.btnOnLeave.Size = new System.Drawing.Size(170, 70);
            this.btnOnLeave.TabIndex = 117;
            this.btnOnLeave.Text = "0";
            this.btnOnLeave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboFilter
            // 
            this.cboFilter.BackColor = System.Drawing.Color.Ivory;
            this.cboFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.cboFilter.BorderThickness = 2;
            this.cboFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FillColor = System.Drawing.Color.Ivory;
            this.cboFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboFilter.Font = new System.Drawing.Font("Arial", 10.5F);
            this.cboFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.cboFilter.ItemHeight = 35;
            this.cboFilter.Items.AddRange(new object[] {
            "On-Time",
            "Late",
            "Absent",
            "On-Leave"});
            this.cboFilter.Location = new System.Drawing.Point(30, 230);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.ShadowDecoration.BorderRadius = 4;
            this.cboFilter.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cboFilter.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.cboFilter.Size = new System.Drawing.Size(271, 41);
            this.cboFilter.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cboFilter.TabIndex = 124;
            this.cboFilter.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            // 
            // pastdtpBottomBorder
            // 
            this.pastdtpBottomBorder.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.pastdtpBottomBorder.FillThickness = 2;
            this.pastdtpBottomBorder.Location = new System.Drawing.Point(514, 269);
            this.pastdtpBottomBorder.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pastdtpBottomBorder.Name = "pastdtpBottomBorder";
            this.pastdtpBottomBorder.Size = new System.Drawing.Size(247, 2);
            this.pastdtpBottomBorder.TabIndex = 127;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(26, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 45);
            this.label1.TabIndex = 128;
            this.label1.Text = "Filter (Today\'s) Attendance Record:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(396, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(365, 45);
            this.label3.TabIndex = 130;
            this.label3.Text = "View (Past) Attendance Record:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSelectDate
            // 
            this.lblSelectDate.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectDate.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.lblSelectDate.Location = new System.Drawing.Point(396, 231);
            this.lblSelectDate.Name = "lblSelectDate";
            this.lblSelectDate.Size = new System.Drawing.Size(112, 40);
            this.lblSelectDate.TabIndex = 133;
            this.lblSelectDate.Text = "Select Date:";
            this.lblSelectDate.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Ivory;
            this.guna2Panel1.Controls.Add(this.panelEmployeeDetails);
            this.guna2Panel1.Controls.Add(this.lblSelectDate);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.pastdtpBottomBorder);
            this.guna2Panel1.Controls.Add(this.cboFilter);
            this.guna2Panel1.Controls.Add(this.btnOnLeave);
            this.guna2Panel1.Controls.Add(this.btnClockOut);
            this.guna2Panel1.Controls.Add(this.btnViewEmployeeList);
            this.guna2Panel1.Controls.Add(this.btnClockIn);
            this.guna2Panel1.Controls.Add(this.btnRefresh);
            this.guna2Panel1.Controls.Add(this.btnAbsent);
            this.guna2Panel1.Controls.Add(this.btnTotalAttendance);
            this.guna2Panel1.Controls.Add(this.dateOfCurrentAttendanceRecord);
            this.guna2Panel1.Controls.Add(this.dtpEmpSelectDate);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.Ivory;
            this.guna2Panel1.Font = new System.Drawing.Font("Symbol", 8.25F);
            this.guna2Panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 1;
            this.guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.Green;
            this.guna2Panel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Size = new System.Drawing.Size(1914, 290);
            this.guna2Panel1.TabIndex = 3;
            // 
            // panelEmployeeDetails
            // 
            this.panelEmployeeDetails.BackColor = System.Drawing.Color.Transparent;
            this.panelEmployeeDetails.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(97)))), ((int)(((byte)(112)))));
            this.panelEmployeeDetails.BorderRadius = 13;
            this.panelEmployeeDetails.Controls.Add(this.guna2Panel7);
            this.panelEmployeeDetails.Controls.Add(this.guna2Panel6);
            this.panelEmployeeDetails.Controls.Add(this.guna2Panel5);
            this.panelEmployeeDetails.Controls.Add(this.btnViewAnDownloadReport);
            this.panelEmployeeDetails.Controls.Add(this.guna2Panel4);
            this.panelEmployeeDetails.Controls.Add(this.guna2Panel3);
            this.panelEmployeeDetails.Controls.Add(this.guna2Panel2);
            this.panelEmployeeDetails.Controls.Add(this.lblAttendanceSummaryDate);
            this.panelEmployeeDetails.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(97)))), ((int)(((byte)(112)))));
            this.panelEmployeeDetails.ForeColor = System.Drawing.Color.White;
            this.panelEmployeeDetails.Location = new System.Drawing.Point(806, 67);
            this.panelEmployeeDetails.Name = "panelEmployeeDetails";
            this.panelEmployeeDetails.ShadowDecoration.BorderRadius = 15;
            this.panelEmployeeDetails.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelEmployeeDetails.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.panelEmployeeDetails.Size = new System.Drawing.Size(770, 203);
            this.panelEmployeeDetails.TabIndex = 134;
            // 
            // guna2Panel7
            // 
            this.guna2Panel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2Panel7.BorderRadius = 4;
            this.guna2Panel7.Controls.Add(this.lblScheduledEmployee);
            this.guna2Panel7.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(97)))), ((int)(((byte)(112)))));
            this.guna2Panel7.ForeColor = System.Drawing.Color.DimGray;
            this.guna2Panel7.Location = new System.Drawing.Point(21, 162);
            this.guna2Panel7.Name = "guna2Panel7";
            this.guna2Panel7.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel7.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel7.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.guna2Panel7.Size = new System.Drawing.Size(230, 35);
            this.guna2Panel7.TabIndex = 147;
            // 
            // lblScheduledEmployee
            // 
            this.lblScheduledEmployee.BackColor = System.Drawing.Color.Transparent;
            this.lblScheduledEmployee.Font = new System.Drawing.Font("Arial", 9.5F);
            this.lblScheduledEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblScheduledEmployee.Location = new System.Drawing.Point(3, 4);
            this.lblScheduledEmployee.Name = "lblScheduledEmployee";
            this.lblScheduledEmployee.Size = new System.Drawing.Size(224, 27);
            this.lblScheduledEmployee.TabIndex = 144;
            this.lblScheduledEmployee.Text = "Expected (Today): 100";
            this.lblScheduledEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Panel6
            // 
            this.guna2Panel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2Panel6.BorderRadius = 4;
            this.guna2Panel6.Controls.Add(this.lblLateEmployee);
            this.guna2Panel6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(97)))), ((int)(((byte)(112)))));
            this.guna2Panel6.ForeColor = System.Drawing.Color.DimGray;
            this.guna2Panel6.Location = new System.Drawing.Point(517, 162);
            this.guna2Panel6.Name = "guna2Panel6";
            this.guna2Panel6.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel6.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel6.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.guna2Panel6.Size = new System.Drawing.Size(230, 35);
            this.guna2Panel6.TabIndex = 146;
            // 
            // lblLateEmployee
            // 
            this.lblLateEmployee.BackColor = System.Drawing.Color.Transparent;
            this.lblLateEmployee.Font = new System.Drawing.Font("Arial", 9.5F);
            this.lblLateEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblLateEmployee.Location = new System.Drawing.Point(3, 4);
            this.lblLateEmployee.Name = "lblLateEmployee";
            this.lblLateEmployee.Size = new System.Drawing.Size(224, 27);
            this.lblLateEmployee.TabIndex = 144;
            this.lblLateEmployee.Text = "Late (Today): 100";
            this.lblLateEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2Panel5.BorderRadius = 4;
            this.guna2Panel5.Controls.Add(this.lblOnTimeEmployee);
            this.guna2Panel5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(97)))), ((int)(((byte)(112)))));
            this.guna2Panel5.ForeColor = System.Drawing.Color.DimGray;
            this.guna2Panel5.Location = new System.Drawing.Point(269, 162);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel5.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel5.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.guna2Panel5.Size = new System.Drawing.Size(230, 35);
            this.guna2Panel5.TabIndex = 145;
            // 
            // lblOnTimeEmployee
            // 
            this.lblOnTimeEmployee.BackColor = System.Drawing.Color.Transparent;
            this.lblOnTimeEmployee.Font = new System.Drawing.Font("Arial", 9.5F);
            this.lblOnTimeEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblOnTimeEmployee.Location = new System.Drawing.Point(3, 4);
            this.lblOnTimeEmployee.Name = "lblOnTimeEmployee";
            this.lblOnTimeEmployee.Size = new System.Drawing.Size(224, 27);
            this.lblOnTimeEmployee.TabIndex = 144;
            this.lblOnTimeEmployee.Text = "On-Time (Today): 100";
            this.lblOnTimeEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnViewAnDownloadReport
            // 
            this.btnViewAnDownloadReport.BackColor = System.Drawing.Color.Transparent;
            this.btnViewAnDownloadReport.BorderColor = System.Drawing.Color.Teal;
            this.btnViewAnDownloadReport.BorderRadius = 4;
            this.btnViewAnDownloadReport.BorderThickness = 4;
            this.btnViewAnDownloadReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewAnDownloadReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewAnDownloadReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewAnDownloadReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewAnDownloadReport.FillColor = System.Drawing.Color.Teal;
            this.btnViewAnDownloadReport.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewAnDownloadReport.ForeColor = System.Drawing.Color.White;
            this.btnViewAnDownloadReport.HoverState.BorderColor = System.Drawing.Color.DarkCyan;
            this.btnViewAnDownloadReport.HoverState.FillColor = System.Drawing.Color.DarkCyan;
            this.btnViewAnDownloadReport.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnViewAnDownloadReport.Image = ((System.Drawing.Image)(resources.GetObject("btnViewAnDownloadReport.Image")));
            this.btnViewAnDownloadReport.ImageSize = new System.Drawing.Size(29, 24);
            this.btnViewAnDownloadReport.Location = new System.Drawing.Point(695, 8);
            this.btnViewAnDownloadReport.Name = "btnViewAnDownloadReport";
            this.btnViewAnDownloadReport.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnViewAnDownloadReport.Size = new System.Drawing.Size(38, 37);
            this.btnViewAnDownloadReport.TabIndex = 147;
            this.btnViewAnDownloadReport.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnViewAnDownloadReport.Click += new System.EventHandler(this.btnViewAnDownloadReport_Click);
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2Panel4.BorderRadius = 12;
            this.guna2Panel4.Controls.Add(this.lblTutoringHours);
            this.guna2Panel4.Controls.Add(this.lblAccumulatedTutoringHours);
            this.guna2Panel4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2Panel4.ForeColor = System.Drawing.Color.White;
            this.guna2Panel4.Location = new System.Drawing.Point(517, 58);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel4.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel4.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.guna2Panel4.Size = new System.Drawing.Size(230, 94);
            this.guna2Panel4.TabIndex = 146;
            // 
            // lblTutoringHours
            // 
            this.lblTutoringHours.BackColor = System.Drawing.Color.Transparent;
            this.lblTutoringHours.Font = new System.Drawing.Font("Arial", 15.5F, System.Drawing.FontStyle.Bold);
            this.lblTutoringHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.lblTutoringHours.Location = new System.Drawing.Point(3, 40);
            this.lblTutoringHours.Name = "lblTutoringHours";
            this.lblTutoringHours.Size = new System.Drawing.Size(224, 45);
            this.lblTutoringHours.TabIndex = 143;
            this.lblTutoringHours.Text = "GAR!";
            this.lblTutoringHours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAccumulatedTutoringHours
            // 
            this.lblAccumulatedTutoringHours.BackColor = System.Drawing.Color.Transparent;
            this.lblAccumulatedTutoringHours.Font = new System.Drawing.Font("Arial", 8.6F);
            this.lblAccumulatedTutoringHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.lblAccumulatedTutoringHours.Location = new System.Drawing.Point(3, 6);
            this.lblAccumulatedTutoringHours.Name = "lblAccumulatedTutoringHours";
            this.lblAccumulatedTutoringHours.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.lblAccumulatedTutoringHours.Size = new System.Drawing.Size(224, 27);
            this.lblAccumulatedTutoringHours.TabIndex = 142;
            this.lblAccumulatedTutoringHours.Text = "Tutoring Hours (Today)";
            this.lblAccumulatedTutoringHours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2Panel3.BorderRadius = 12;
            this.guna2Panel3.Controls.Add(this.lblAttendancePercentage);
            this.guna2Panel3.Controls.Add(this.lblAttendancePercent);
            this.guna2Panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2Panel3.ForeColor = System.Drawing.Color.White;
            this.guna2Panel3.Location = new System.Drawing.Point(269, 58);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel3.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel3.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.guna2Panel3.Size = new System.Drawing.Size(230, 94);
            this.guna2Panel3.TabIndex = 145;
            // 
            // lblAttendancePercentage
            // 
            this.lblAttendancePercentage.BackColor = System.Drawing.Color.Transparent;
            this.lblAttendancePercentage.Font = new System.Drawing.Font("Arial", 15.5F, System.Drawing.FontStyle.Bold);
            this.lblAttendancePercentage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.lblAttendancePercentage.Location = new System.Drawing.Point(3, 40);
            this.lblAttendancePercentage.Name = "lblAttendancePercentage";
            this.lblAttendancePercentage.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblAttendancePercentage.Size = new System.Drawing.Size(224, 45);
            this.lblAttendancePercentage.TabIndex = 144;
            this.lblAttendancePercentage.Text = "NALANG";
            this.lblAttendancePercentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAttendancePercent
            // 
            this.lblAttendancePercent.BackColor = System.Drawing.Color.Transparent;
            this.lblAttendancePercent.Font = new System.Drawing.Font("Arial", 8.6F);
            this.lblAttendancePercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.lblAttendancePercent.Location = new System.Drawing.Point(3, 6);
            this.lblAttendancePercent.Name = "lblAttendancePercent";
            this.lblAttendancePercent.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.lblAttendancePercent.Size = new System.Drawing.Size(224, 27);
            this.lblAttendancePercent.TabIndex = 142;
            this.lblAttendancePercent.Text = "Attendance % (Today)";
            this.lblAttendancePercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2Panel2.BorderRadius = 12;
            this.guna2Panel2.Controls.Add(this.lblScheduledEmployeeToday);
            this.guna2Panel2.Controls.Add(this.lblExpectedClockIn);
            this.guna2Panel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2Panel2.ForeColor = System.Drawing.Color.White;
            this.guna2Panel2.Location = new System.Drawing.Point(21, 58);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Panel2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.guna2Panel2.Size = new System.Drawing.Size(230, 94);
            this.guna2Panel2.TabIndex = 144;
            // 
            // lblScheduledEmployeeToday
            // 
            this.lblScheduledEmployeeToday.BackColor = System.Drawing.Color.Transparent;
            this.lblScheduledEmployeeToday.Font = new System.Drawing.Font("Arial", 15.5F, System.Drawing.FontStyle.Bold);
            this.lblScheduledEmployeeToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblScheduledEmployeeToday.Location = new System.Drawing.Point(3, 40);
            this.lblScheduledEmployeeToday.Name = "lblScheduledEmployeeToday";
            this.lblScheduledEmployeeToday.Size = new System.Drawing.Size(224, 45);
            this.lblScheduledEmployeeToday.TabIndex = 143;
            this.lblScheduledEmployeeToday.Text = "KONTI";
            this.lblScheduledEmployeeToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExpectedClockIn
            // 
            this.lblExpectedClockIn.BackColor = System.Drawing.Color.Transparent;
            this.lblExpectedClockIn.Font = new System.Drawing.Font("Arial", 8.6F);
            this.lblExpectedClockIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.lblExpectedClockIn.Location = new System.Drawing.Point(3, 6);
            this.lblExpectedClockIn.Name = "lblExpectedClockIn";
            this.lblExpectedClockIn.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblExpectedClockIn.Size = new System.Drawing.Size(224, 27);
            this.lblExpectedClockIn.TabIndex = 142;
            this.lblExpectedClockIn.Text = "Clocked-In (Today)";
            this.lblExpectedClockIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAttendanceSummaryDate
            // 
            this.lblAttendanceSummaryDate.BackColor = System.Drawing.Color.Transparent;
            this.lblAttendanceSummaryDate.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttendanceSummaryDate.ForeColor = System.Drawing.Color.White;
            this.lblAttendanceSummaryDate.Location = new System.Drawing.Point(21, 13);
            this.lblAttendanceSummaryDate.Name = "lblAttendanceSummaryDate";
            this.lblAttendanceSummaryDate.Size = new System.Drawing.Size(636, 32);
            this.lblAttendanceSummaryDate.TabIndex = 142;
            this.lblAttendanceSummaryDate.Text = "Real-Time Att. Sum. Today - ";
            this.lblAttendanceSummaryDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateOfCurrentAttendanceRecord
            // 
            this.dateOfCurrentAttendanceRecord.BackColor = System.Drawing.Color.Transparent;
            this.dateOfCurrentAttendanceRecord.Font = new System.Drawing.Font("Arial Narrow", 11.5F, System.Drawing.FontStyle.Bold);
            this.dateOfCurrentAttendanceRecord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dateOfCurrentAttendanceRecord.Location = new System.Drawing.Point(25, 15);
            this.dateOfCurrentAttendanceRecord.Name = "dateOfCurrentAttendanceRecord";
            this.dateOfCurrentAttendanceRecord.Size = new System.Drawing.Size(549, 32);
            this.dateOfCurrentAttendanceRecord.TabIndex = 36;
            this.dateOfCurrentAttendanceRecord.Text = "Real Time Attendance Today";
            this.dateOfCurrentAttendanceRecord.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
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
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.Name = "EmployeeAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Attendance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployeeAttendance_FormClosing);
            this.Load += new System.EventHandler(this.EmployeeAttendance_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.panelEmployeeDetails.ResumeLayout(false);
            this.guna2Panel7.ResumeLayout(false);
            this.guna2Panel6.ResumeLayout(false);
            this.guna2Panel5.ResumeLayout(false);
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEmpSelectDate;
        private System.Windows.Forms.Label btnTotalAttendance;
        private Guna.UI2.WinForms.Guna2Button btnAbsent;
        private Guna.UI2.WinForms.Guna2Button btnClockIn;
        private Guna.UI2.WinForms.Guna2Button btnClockOut;
        private Guna.UI2.WinForms.Guna2Button btnOnLeave;
        private Guna.UI2.WinForms.Guna2ComboBox cboFilter;
        private Guna.UI2.WinForms.Guna2Separator pastdtpBottomBorder;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private System.Windows.Forms.Label label3;
        public Guna.UI2.WinForms.Guna2Button btnViewEmployeeList;
        private System.Windows.Forms.Label lblSelectDate;
        public Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        public Guna.UI2.WinForms.Guna2Panel panelEmployeeDetails;
        private System.Windows.Forms.Label lblAttendanceSummaryDate;
        public Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label lblExpectedClockIn;
        private System.Windows.Forms.Label lblScheduledEmployeeToday;
        public Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Label lblAttendancePercent;
        private System.Windows.Forms.Label lblAttendancePercentage;
        public Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.Label lblTutoringHours;
        private System.Windows.Forms.Label lblAccumulatedTutoringHours;
        private Guna.UI2.WinForms.Guna2Button btnViewAnDownloadReport;
        public Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private System.Windows.Forms.Label lblOnTimeEmployee;
        public Guna.UI2.WinForms.Guna2Panel guna2Panel7;
        private System.Windows.Forms.Label lblScheduledEmployee;
        public Guna.UI2.WinForms.Guna2Panel guna2Panel6;
        private System.Windows.Forms.Label lblLateEmployee;
        private System.Windows.Forms.Label dateOfCurrentAttendanceRecord;
    }
}