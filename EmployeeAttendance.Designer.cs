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
            this.dateOfCurrentAttendanceRecord = new System.Windows.Forms.Label();
            this.btnTotalAttendance = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboSearch = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAbsent = new Guna.UI2.WinForms.Guna2Button();
            this.btnClockIn = new Guna.UI2.WinForms.Guna2Button();
            this.btnClockOut = new Guna.UI2.WinForms.Guna2Button();
            this.btnOnLeave = new Guna.UI2.WinForms.Guna2Button();
            this.cboFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Panel1.SuspendLayout();
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
            this.btnViewEmployeeList.BorderColor = System.Drawing.Color.Green;
            this.btnViewEmployeeList.BorderRadius = 5;
            this.btnViewEmployeeList.BorderThickness = 5;
            this.btnViewEmployeeList.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewEmployeeList.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewEmployeeList.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewEmployeeList.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewEmployeeList.FillColor = System.Drawing.Color.Green;
            this.btnViewEmployeeList.Font = new System.Drawing.Font("Roboto", 9F);
            this.btnViewEmployeeList.ForeColor = System.Drawing.Color.White;
            this.btnViewEmployeeList.HoverState.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnViewEmployeeList.HoverState.FillColor = System.Drawing.Color.DarkGreen;
            this.btnViewEmployeeList.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnViewEmployeeList.Image = ((System.Drawing.Image)(resources.GetObject("btnViewEmployeeList.Image")));
            this.btnViewEmployeeList.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnViewEmployeeList.ImageSize = new System.Drawing.Size(20, 25);
            this.btnViewEmployeeList.Location = new System.Drawing.Point(1270, 140);
            this.btnViewEmployeeList.Name = "btnViewEmployeeList";
            this.btnViewEmployeeList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnViewEmployeeList.PressedColor = System.Drawing.Color.LightGreen;
            this.btnViewEmployeeList.Size = new System.Drawing.Size(38, 38);
            this.btnViewEmployeeList.TabIndex = 109;
            this.btnViewEmployeeList.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnViewEmployeeList.Click += new System.EventHandler(this.btnViewEmployeeList_Click_1);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnRefresh.BorderRadius = 4;
            this.btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnRefresh.Font = new System.Drawing.Font("Roboto", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnRefresh.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnRefresh.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRefresh.ImageSize = new System.Drawing.Size(23, 23);
            this.btnRefresh.Location = new System.Drawing.Point(1429, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnRefresh.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnRefresh.Size = new System.Drawing.Size(129, 40);
            this.btnRefresh.TabIndex = 112;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dtpEmpSelectDate
            // 
            this.dtpEmpSelectDate.BackColor = System.Drawing.Color.Transparent;
            this.dtpEmpSelectDate.BorderColor = System.Drawing.Color.Ivory;
            this.dtpEmpSelectDate.BorderRadius = 5;
            this.dtpEmpSelectDate.BorderThickness = 1;
            this.dtpEmpSelectDate.Checked = true;
            this.dtpEmpSelectDate.CustomFormat = "MMMM dd, yyyy";
            this.dtpEmpSelectDate.FillColor = System.Drawing.Color.Ivory;
            this.dtpEmpSelectDate.FocusedColor = System.Drawing.Color.White;
            this.dtpEmpSelectDate.Font = new System.Drawing.Font("Arial", 9.5F);
            this.dtpEmpSelectDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtpEmpSelectDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEmpSelectDate.HoverState.BorderColor = System.Drawing.Color.Ivory;
            this.dtpEmpSelectDate.HoverState.FillColor = System.Drawing.Color.Ivory;
            this.dtpEmpSelectDate.HoverState.ForeColor = System.Drawing.Color.Black;
            this.dtpEmpSelectDate.Location = new System.Drawing.Point(477, 231);
            this.dtpEmpSelectDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEmpSelectDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEmpSelectDate.Name = "dtpEmpSelectDate";
            this.dtpEmpSelectDate.Size = new System.Drawing.Size(231, 40);
            this.dtpEmpSelectDate.TabIndex = 82;
            this.dtpEmpSelectDate.Value = new System.DateTime(2024, 12, 10, 0, 0, 0, 0);
            this.dtpEmpSelectDate.ValueChanged += new System.EventHandler(this.dtpEmpSelectDate_ValueChanged);
            // 
            // dateOfCurrentAttendanceRecord
            // 
            this.dateOfCurrentAttendanceRecord.AutoSize = true;
            this.dateOfCurrentAttendanceRecord.BackColor = System.Drawing.Color.Transparent;
            this.dateOfCurrentAttendanceRecord.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateOfCurrentAttendanceRecord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dateOfCurrentAttendanceRecord.Location = new System.Drawing.Point(40, 21);
            this.dateOfCurrentAttendanceRecord.Name = "dateOfCurrentAttendanceRecord";
            this.dateOfCurrentAttendanceRecord.Size = new System.Drawing.Size(216, 33);
            this.dateOfCurrentAttendanceRecord.TabIndex = 36;
            this.dateOfCurrentAttendanceRecord.Text = "Attendance Today";
            // 
            // btnTotalAttendance
            // 
            this.btnTotalAttendance.BackColor = System.Drawing.Color.Transparent;
            this.btnTotalAttendance.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotalAttendance.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnTotalAttendance.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnTotalAttendance.Location = new System.Drawing.Point(45, 150);
            this.btnTotalAttendance.Name = "btnTotalAttendance";
            this.btnTotalAttendance.Size = new System.Drawing.Size(663, 30);
            this.btnTotalAttendance.TabIndex = 105;
            this.btnTotalAttendance.Text = "Total Attendance:";
            this.btnTotalAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.Ivory;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearch.BorderRadius = 5;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FillColor = System.Drawing.Color.Ivory;
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSearch.Font = new System.Drawing.Font("Arial", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.txtSearch.Location = new System.Drawing.Point(1332, 230);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(0, 0, 0, 7);
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.LightGray;
            this.txtSearch.PlaceholderText = "Type here";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.BorderRadius = 4;
            this.txtSearch.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtSearch.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.txtSearch.Size = new System.Drawing.Size(226, 41);
            this.txtSearch.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtSearch.TabIndex = 111;
            // 
            // cboSearch
            // 
            this.cboSearch.BackColor = System.Drawing.Color.Ivory;
            this.cboSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboSearch.BorderRadius = 5;
            this.cboSearch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearch.FillColor = System.Drawing.Color.Ivory;
            this.cboSearch.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSearch.Font = new System.Drawing.Font("Arial", 10F);
            this.cboSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.cboSearch.ItemHeight = 35;
            this.cboSearch.Items.AddRange(new object[] {
            "Search By",
            "ID",
            "Name"});
            this.cboSearch.Location = new System.Drawing.Point(1332, 139);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.ShadowDecoration.BorderRadius = 4;
            this.cboSearch.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cboSearch.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.cboSearch.Size = new System.Drawing.Size(227, 41);
            this.cboSearch.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cboSearch.TabIndex = 110;
            // 
            // btnAbsent
            // 
            this.btnAbsent.BackColor = System.Drawing.Color.Transparent;
            this.btnAbsent.BorderColor = System.Drawing.Color.Red;
            this.btnAbsent.BorderThickness = 5;
            this.btnAbsent.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAbsent.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAbsent.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAbsent.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAbsent.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.btnAbsent.Font = new System.Drawing.Font("LCD", 15F, System.Drawing.FontStyle.Bold);
            this.btnAbsent.ForeColor = System.Drawing.Color.White;
            this.btnAbsent.HoverState.BorderColor = System.Drawing.Color.Red;
            this.btnAbsent.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.btnAbsent.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAbsent.Image = ((System.Drawing.Image)(resources.GetObject("btnAbsent.Image")));
            this.btnAbsent.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAbsent.ImageSize = new System.Drawing.Size(36, 36);
            this.btnAbsent.Location = new System.Drawing.Point(387, 64);
            this.btnAbsent.Margin = new System.Windows.Forms.Padding(5);
            this.btnAbsent.Name = "btnAbsent";
            this.btnAbsent.Padding = new System.Windows.Forms.Padding(15, 5, 0, 3);
            this.btnAbsent.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.btnAbsent.PressedDepth = 0;
            this.btnAbsent.ShadowDecoration.BorderRadius = 0;
            this.btnAbsent.ShadowDecoration.Color = System.Drawing.Color.Red;
            this.btnAbsent.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.btnAbsent.Size = new System.Drawing.Size(150, 68);
            this.btnAbsent.TabIndex = 45;
            this.btnAbsent.Text = "10000";
            this.btnAbsent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnClockIn
            // 
            this.btnClockIn.BackColor = System.Drawing.Color.Transparent;
            this.btnClockIn.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnClockIn.BorderThickness = 5;
            this.btnClockIn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClockIn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClockIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClockIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClockIn.FillColor = System.Drawing.Color.Orange;
            this.btnClockIn.Font = new System.Drawing.Font("LCD", 15F, System.Drawing.FontStyle.Bold);
            this.btnClockIn.ForeColor = System.Drawing.Color.White;
            this.btnClockIn.HoverState.BorderColor = System.Drawing.Color.DarkOrange;
            this.btnClockIn.HoverState.FillColor = System.Drawing.Color.Orange;
            this.btnClockIn.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnClockIn.Image = ((System.Drawing.Image)(resources.GetObject("btnClockIn.Image")));
            this.btnClockIn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClockIn.ImageSize = new System.Drawing.Size(40, 40);
            this.btnClockIn.Location = new System.Drawing.Point(45, 64);
            this.btnClockIn.Margin = new System.Windows.Forms.Padding(5);
            this.btnClockIn.Name = "btnClockIn";
            this.btnClockIn.Padding = new System.Windows.Forms.Padding(15, 5, 0, 3);
            this.btnClockIn.PressedColor = System.Drawing.Color.Orange;
            this.btnClockIn.PressedDepth = 0;
            this.btnClockIn.ShadowDecoration.BorderRadius = 0;
            this.btnClockIn.ShadowDecoration.Color = System.Drawing.Color.DarkOrange;
            this.btnClockIn.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.btnClockIn.Size = new System.Drawing.Size(150, 68);
            this.btnClockIn.TabIndex = 42;
            this.btnClockIn.Text = "10000";
            this.btnClockIn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnClockOut
            // 
            this.btnClockOut.BackColor = System.Drawing.Color.Transparent;
            this.btnClockOut.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnClockOut.BorderThickness = 5;
            this.btnClockOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClockOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClockOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClockOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClockOut.FillColor = System.Drawing.Color.Green;
            this.btnClockOut.Font = new System.Drawing.Font("LCD", 15F, System.Drawing.FontStyle.Bold);
            this.btnClockOut.ForeColor = System.Drawing.Color.White;
            this.btnClockOut.HoverState.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnClockOut.HoverState.FillColor = System.Drawing.Color.Green;
            this.btnClockOut.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnClockOut.Image = ((System.Drawing.Image)(resources.GetObject("btnClockOut.Image")));
            this.btnClockOut.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClockOut.ImageSize = new System.Drawing.Size(40, 40);
            this.btnClockOut.Location = new System.Drawing.Point(216, 64);
            this.btnClockOut.Margin = new System.Windows.Forms.Padding(5);
            this.btnClockOut.Name = "btnClockOut";
            this.btnClockOut.Padding = new System.Windows.Forms.Padding(15, 5, 0, 3);
            this.btnClockOut.PressedColor = System.Drawing.Color.Green;
            this.btnClockOut.PressedDepth = 0;
            this.btnClockOut.ShadowDecoration.BorderRadius = 0;
            this.btnClockOut.ShadowDecoration.Color = System.Drawing.Color.DarkGreen;
            this.btnClockOut.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.btnClockOut.Size = new System.Drawing.Size(150, 68);
            this.btnClockOut.TabIndex = 40;
            this.btnClockOut.Text = "10000";
            this.btnClockOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnOnLeave
            // 
            this.btnOnLeave.BackColor = System.Drawing.Color.Transparent;
            this.btnOnLeave.BorderColor = System.Drawing.Color.Blue;
            this.btnOnLeave.BorderThickness = 5;
            this.btnOnLeave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOnLeave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOnLeave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOnLeave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOnLeave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnOnLeave.Font = new System.Drawing.Font("LCD", 15F, System.Drawing.FontStyle.Bold);
            this.btnOnLeave.ForeColor = System.Drawing.Color.White;
            this.btnOnLeave.HoverState.BorderColor = System.Drawing.Color.Blue;
            this.btnOnLeave.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnOnLeave.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnOnLeave.Image = ((System.Drawing.Image)(resources.GetObject("btnOnLeave.Image")));
            this.btnOnLeave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnOnLeave.ImageSize = new System.Drawing.Size(36, 36);
            this.btnOnLeave.Location = new System.Drawing.Point(558, 64);
            this.btnOnLeave.Margin = new System.Windows.Forms.Padding(5);
            this.btnOnLeave.Name = "btnOnLeave";
            this.btnOnLeave.Padding = new System.Windows.Forms.Padding(15, 5, 0, 3);
            this.btnOnLeave.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnOnLeave.PressedDepth = 0;
            this.btnOnLeave.ShadowDecoration.BorderRadius = 0;
            this.btnOnLeave.ShadowDecoration.Color = System.Drawing.Color.Indigo;
            this.btnOnLeave.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.btnOnLeave.Size = new System.Drawing.Size(150, 68);
            this.btnOnLeave.TabIndex = 117;
            this.btnOnLeave.Text = "10000";
            this.btnOnLeave.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboFilter
            // 
            this.cboFilter.BackColor = System.Drawing.Color.Ivory;
            this.cboFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FillColor = System.Drawing.Color.Ivory;
            this.cboFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboFilter.Font = new System.Drawing.Font("Arial", 10F);
            this.cboFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.cboFilter.ItemHeight = 35;
            this.cboFilter.Items.AddRange(new object[] {
            "Filter By",
            "On-Time",
            "Late",
            "Absent",
            "On-Leave"});
            this.cboFilter.Location = new System.Drawing.Point(46, 230);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.ShadowDecoration.BorderRadius = 4;
            this.cboFilter.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cboFilter.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.cboFilter.Size = new System.Drawing.Size(170, 41);
            this.cboFilter.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cboFilter.TabIndex = 124;
            this.cboFilter.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            this.cboFilter.Click += new System.EventHandler(this.cboFilter_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Black;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Ivory;
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Controls.Add(this.btnViewEmployeeList);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.btnRefresh);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.guna2Separator1);
            this.guna2Panel1.Controls.Add(this.cboFilter);
            this.guna2Panel1.Controls.Add(this.btnOnLeave);
            this.guna2Panel1.Controls.Add(this.btnClockOut);
            this.guna2Panel1.Controls.Add(this.btnClockIn);
            this.guna2Panel1.Controls.Add(this.btnAbsent);
            this.guna2Panel1.Controls.Add(this.cboSearch);
            this.guna2Panel1.Controls.Add(this.txtSearch);
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
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(346, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 31);
            this.label5.TabIndex = 133;
            this.label5.Text = "Select Date:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(346, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(362, 31);
            this.label3.TabIndex = 130;
            this.label3.Text = "View Past Attendance Record:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(45, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 31);
            this.label1.TabIndex = 128;
            this.label1.Text = "Filter Attendance:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Separator1.Location = new System.Drawing.Point(477, 270);
            this.guna2Separator1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(231, 1);
            this.guna2Separator1.TabIndex = 127;
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
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEmpSelectDate;
        private System.Windows.Forms.Label dateOfCurrentAttendanceRecord;
        private System.Windows.Forms.Label btnTotalAttendance;
        public Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cboSearch;
        public Guna.UI2.WinForms.Guna2Button btnViewEmployeeList;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnAbsent;
        private Guna.UI2.WinForms.Guna2Button btnClockIn;
        private Guna.UI2.WinForms.Guna2Button btnClockOut;
        private Guna.UI2.WinForms.Guna2Button btnOnLeave;
        private Guna.UI2.WinForms.Guna2ComboBox cboFilter;
        public Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
    }
}