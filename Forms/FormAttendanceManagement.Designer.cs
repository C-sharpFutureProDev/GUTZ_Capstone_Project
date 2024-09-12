namespace GUTZ_Capstone_Project.Forms
{
    partial class FormAttendanceManagement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAttendanceManagement));
            this.btnAddTimeInTimeOut = new Guna.UI2.WinForms.Guna2Button();
            this.DGVAttendance = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.panelAttendanceManagement = new Guna.UI2.WinForms.Guna2Panel();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGVAttendance)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.panelAttendanceManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddTimeInTimeOut
            // 
            this.btnAddTimeInTimeOut.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnAddTimeInTimeOut.BorderRadius = 5;
            this.btnAddTimeInTimeOut.BorderThickness = 1;
            this.btnAddTimeInTimeOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddTimeInTimeOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddTimeInTimeOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddTimeInTimeOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddTimeInTimeOut.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnAddTimeInTimeOut.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTimeInTimeOut.ForeColor = System.Drawing.Color.White;
            this.btnAddTimeInTimeOut.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(94)))), ((int)(((byte)(32)))));
            this.btnAddTimeInTimeOut.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAddTimeInTimeOut.ImageSize = new System.Drawing.Size(35, 32);
            this.btnAddTimeInTimeOut.Location = new System.Drawing.Point(20, 61);
            this.btnAddTimeInTimeOut.Margin = new System.Windows.Forms.Padding(5);
            this.btnAddTimeInTimeOut.Name = "btnAddTimeInTimeOut";
            this.btnAddTimeInTimeOut.Padding = new System.Windows.Forms.Padding(10, 0, 10, 3);
            this.btnAddTimeInTimeOut.PressedColor = System.Drawing.Color.Empty;
            this.btnAddTimeInTimeOut.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(43)))), ((int)(((byte)(37)))));
            this.btnAddTimeInTimeOut.Size = new System.Drawing.Size(195, 50);
            this.btnAddTimeInTimeOut.TabIndex = 23;
            this.btnAddTimeInTimeOut.Text = "Time-In \' Time-Out";
            this.btnAddTimeInTimeOut.Click += new System.EventHandler(this.btnAddTimeInTimeOut_Click);
            // 
            // DGVAttendance
            // 
            this.DGVAttendance.AllowUserToAddRows = false;
            this.DGVAttendance.AllowUserToDeleteRows = false;
            this.DGVAttendance.AllowUserToResizeColumns = false;
            this.DGVAttendance.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.DGVAttendance.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVAttendance.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.DGVAttendance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVAttendance.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.DGVAttendance.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVAttendance.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVAttendance.ColumnHeadersHeight = 53;
            this.DGVAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVAttendance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column9,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVAttendance.DefaultCellStyle = dataGridViewCellStyle4;
            this.DGVAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVAttendance.EnableHeadersVisualStyles = false;
            this.DGVAttendance.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.DGVAttendance.Location = new System.Drawing.Point(0, 200);
            this.DGVAttendance.Name = "DGVAttendance";
            this.DGVAttendance.ReadOnly = true;
            this.DGVAttendance.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVAttendance.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DGVAttendance.RowHeadersVisible = false;
            this.DGVAttendance.RowHeadersWidth = 60;
            this.DGVAttendance.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.DGVAttendance.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGVAttendance.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.DGVAttendance.RowTemplate.Height = 45;
            this.DGVAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVAttendance.Size = new System.Drawing.Size(1924, 777);
            this.DGVAttendance.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "emp_profilePic";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle3.NullValue")));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "";
            this.Column1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "FullName";
            this.Column2.HeaderText = "Employee";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "work_shift";
            this.Column3.HeaderText = "Working Shift";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Shift Duration";
            this.Column9.MinimumWidth = 8;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Status";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "time_in_formatted";
            this.Column5.HeaderText = "Clock-In";
            this.Column5.MinimumWidth = 8;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "time_out_formatted";
            this.Column6.HeaderText = "Clock-Out";
            this.Column6.MinimumWidth = 8;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Required Time";
            this.Column7.MinimumWidth = 8;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 200;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Actual Time";
            this.Column8.MinimumWidth = 8;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 200;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.guna2Panel1.Controls.Add(this.panelAttendanceManagement);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Enabled = true;
            this.guna2Panel1.Size = new System.Drawing.Size(1924, 200);
            this.guna2Panel1.TabIndex = 2;
            // 
            // panelAttendanceManagement
            // 
            this.panelAttendanceManagement.BackColor = System.Drawing.Color.Transparent;
            this.panelAttendanceManagement.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.panelAttendanceManagement.BorderRadius = 8;
            this.panelAttendanceManagement.BorderThickness = 1;
            this.panelAttendanceManagement.Controls.Add(this.btnAddTimeInTimeOut);
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
            this.panelAttendanceManagement.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.panelAttendanceManagement.ForeColor = System.Drawing.Color.Black;
            this.panelAttendanceManagement.Location = new System.Drawing.Point(57, 45);
            this.panelAttendanceManagement.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelAttendanceManagement.Name = "panelAttendanceManagement";
            this.panelAttendanceManagement.ShadowDecoration.BorderRadius = 8;
            this.panelAttendanceManagement.ShadowDecoration.Color = System.Drawing.Color.Green;
            this.panelAttendanceManagement.ShadowDecoration.Enabled = true;
            this.panelAttendanceManagement.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.panelAttendanceManagement.Size = new System.Drawing.Size(1494, 133);
            this.panelAttendanceManagement.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(811, 16);
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
            this.label3.Location = new System.Drawing.Point(620, 16);
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
            this.label2.Location = new System.Drawing.Point(429, 16);
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
            this.guna2Button8.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.guna2Button8.HoverState.ForeColor = System.Drawing.Color.Gray;
            this.guna2Button8.ImageSize = new System.Drawing.Size(35, 32);
            this.guna2Button8.Location = new System.Drawing.Point(777, 16);
            this.guna2Button8.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Button8.Name = "guna2Button8";
            this.guna2Button8.Padding = new System.Windows.Forms.Padding(15, 5, 10, 3);
            this.guna2Button8.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
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
            this.guna2Button7.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.guna2Button7.HoverState.ForeColor = System.Drawing.Color.Gray;
            this.guna2Button7.ImageSize = new System.Drawing.Size(35, 32);
            this.guna2Button7.Location = new System.Drawing.Point(586, 16);
            this.guna2Button7.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Button7.Name = "guna2Button7";
            this.guna2Button7.Padding = new System.Windows.Forms.Padding(15, 5, 10, 3);
            this.guna2Button7.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
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
            this.guna2Button6.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.guna2Button6.HoverState.ForeColor = System.Drawing.Color.Gray;
            this.guna2Button6.ImageSize = new System.Drawing.Size(35, 32);
            this.guna2Button6.Location = new System.Drawing.Point(395, 16);
            this.guna2Button6.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Button6.Name = "guna2Button6";
            this.guna2Button6.Padding = new System.Windows.Forms.Padding(15, 5, 10, 3);
            this.guna2Button6.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
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
            this.btnLate.Location = new System.Drawing.Point(777, 63);
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
            this.btnOnTime.Location = new System.Drawing.Point(586, 63);
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
            this.btnPresent.Location = new System.Drawing.Point(395, 63);
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
            this.shiftLabelStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.shiftLabelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.shiftLabelStatus.Location = new System.Drawing.Point(14, 4);
            this.shiftLabelStatus.Name = "shiftLabelStatus";
            this.shiftLabelStatus.Size = new System.Drawing.Size(68, 28);
            this.shiftLabelStatus.TabIndex = 24;
            this.shiftLabelStatus.Text = "Today";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormAttendanceManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1924, 977);
            this.Controls.Add(this.DGVAttendance);
            this.Controls.Add(this.guna2Panel1);
            this.DoubleBuffered = true;
            this.Name = "FormAttendanceManagement";
            this.Text = "Attendance Management";
            this.Load += new System.EventHandler(this.FormAttendanceMonitoring_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVAttendance)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.panelAttendanceManagement.ResumeLayout(false);
            this.panelAttendanceManagement.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnAddTimeInTimeOut;
        private System.Windows.Forms.DataGridView DGVAttendance;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private Guna.UI2.WinForms.Guna2Panel panelAttendanceManagement;
        private System.Windows.Forms.Label shiftLabelStatus;
        private Guna.UI2.WinForms.Guna2Button btnPresent;
        private Guna.UI2.WinForms.Guna2Button btnOnTime;
        private Guna.UI2.WinForms.Guna2Button btnLate;
        private Guna.UI2.WinForms.Guna2Button guna2Button8;
        private Guna.UI2.WinForms.Guna2Button guna2Button7;
        private Guna.UI2.WinForms.Guna2Button guna2Button6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}