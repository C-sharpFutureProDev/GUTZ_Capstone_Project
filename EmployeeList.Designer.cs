namespace GUTZ_Capstone_Project
{
    partial class EmployeeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeList));
            this.cboFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.iconActive = new FontAwesome.Sharp.IconButton();
            this.iconInactive = new FontAwesome.Sharp.IconButton();
            this.lblActiveEmployee = new System.Windows.Forms.Label();
            this.lblInactiveEmployee = new System.Windows.Forms.Label();
            this.btnAddNewEmployee = new Guna.UI2.WinForms.Guna2Button();
            this.panelEmployeeListFeatures = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel6 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblVUIHOC = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRKESI = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblESO = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPartTime = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFullTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFemaleEmployee = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelTotalEmployee = new Guna.UI2.WinForms.Guna2Panel();
            this.lblMaleEmployee = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSort = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnExport = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.cboSearch = new Guna.UI2.WinForms.Guna2ComboBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelEmployeeListFeatures.SuspendLayout();
            this.guna2Panel6.SuspendLayout();
            this.guna2Panel5.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.panelTotalEmployee.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboFilter
            // 
            this.cboFilter.AutoRoundedCorners = true;
            this.cboFilter.BackColor = System.Drawing.Color.Ivory;
            this.cboFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.cboFilter.BorderRadius = 19;
            this.cboFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FillColor = System.Drawing.Color.Ivory;
            this.cboFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboFilter.Font = new System.Drawing.Font("Bookman Old Style", 10.5F);
            this.cboFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboFilter.ItemHeight = 35;
            this.cboFilter.Items.AddRange(new object[] {
            "Filter By",
            "Active",
            "Inactive",
            "Male",
            "Female",
            "Full Time",
            "Part Time"});
            this.cboFilter.Location = new System.Drawing.Point(988, 138);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.ShadowDecoration.BorderRadius = 4;
            this.cboFilter.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cboFilter.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.cboFilter.Size = new System.Drawing.Size(210, 41);
            this.cboFilter.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cboFilter.TabIndex = 58;
            this.cboFilter.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            this.cboFilter.Click += new System.EventHandler(this.cboFilter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Ivory;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 9.5F);
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(66, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 67;
            this.label1.Text = "Active:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Ivory;
            this.label2.Font = new System.Drawing.Font("Bookman Old Style", 9.5F);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(212, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 21);
            this.label2.TabIndex = 68;
            this.label2.Text = "Inactive:";
            // 
            // iconActive
            // 
            this.iconActive.BackColor = System.Drawing.Color.Ivory;
            this.iconActive.FlatAppearance.BorderSize = 0;
            this.iconActive.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconActive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconActive.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconActive.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            this.iconActive.IconColor = System.Drawing.Color.DarkGreen;
            this.iconActive.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconActive.IconSize = 35;
            this.iconActive.Location = new System.Drawing.Point(20, 15);
            this.iconActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.iconActive.Name = "iconActive";
            this.iconActive.Size = new System.Drawing.Size(45, 30);
            this.iconActive.TabIndex = 69;
            this.iconActive.UseVisualStyleBackColor = false;
            // 
            // iconInactive
            // 
            this.iconInactive.BackColor = System.Drawing.Color.Ivory;
            this.iconInactive.FlatAppearance.BorderSize = 0;
            this.iconInactive.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconInactive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconInactive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconInactive.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconInactive.IconChar = FontAwesome.Sharp.IconChar.Pause;
            this.iconInactive.IconColor = System.Drawing.Color.Gray;
            this.iconInactive.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconInactive.IconSize = 30;
            this.iconInactive.Location = new System.Drawing.Point(166, 14);
            this.iconInactive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.iconInactive.Name = "iconInactive";
            this.iconInactive.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.iconInactive.Size = new System.Drawing.Size(45, 30);
            this.iconInactive.TabIndex = 70;
            this.iconInactive.UseVisualStyleBackColor = false;
            // 
            // lblActiveEmployee
            // 
            this.lblActiveEmployee.AutoSize = true;
            this.lblActiveEmployee.BackColor = System.Drawing.Color.Ivory;
            this.lblActiveEmployee.Font = new System.Drawing.Font("Bookman Old Style", 9.5F);
            this.lblActiveEmployee.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblActiveEmployee.Location = new System.Drawing.Point(138, 16);
            this.lblActiveEmployee.Name = "lblActiveEmployee";
            this.lblActiveEmployee.Size = new System.Drawing.Size(22, 21);
            this.lblActiveEmployee.TabIndex = 71;
            this.lblActiveEmployee.Text = "0";
            // 
            // lblInactiveEmployee
            // 
            this.lblInactiveEmployee.AutoSize = true;
            this.lblInactiveEmployee.BackColor = System.Drawing.Color.Ivory;
            this.lblInactiveEmployee.Font = new System.Drawing.Font("Bookman Old Style", 9.5F);
            this.lblInactiveEmployee.ForeColor = System.Drawing.Color.Gray;
            this.lblInactiveEmployee.Location = new System.Drawing.Point(298, 16);
            this.lblInactiveEmployee.Name = "lblInactiveEmployee";
            this.lblInactiveEmployee.Size = new System.Drawing.Size(22, 21);
            this.lblInactiveEmployee.TabIndex = 72;
            this.lblInactiveEmployee.Text = "0";
            // 
            // btnAddNewEmployee
            // 
            this.btnAddNewEmployee.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewEmployee.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddNewEmployee.BorderRadius = 4;
            this.btnAddNewEmployee.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewEmployee.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewEmployee.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewEmployee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewEmployee.FillColor = System.Drawing.Color.Green;
            this.btnAddNewEmployee.Font = new System.Drawing.Font("Bookman Old Style", 9.5F);
            this.btnAddNewEmployee.ForeColor = System.Drawing.Color.White;
            this.btnAddNewEmployee.HoverState.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnAddNewEmployee.HoverState.FillColor = System.Drawing.Color.DarkGreen;
            this.btnAddNewEmployee.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAddNewEmployee.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewEmployee.Image")));
            this.btnAddNewEmployee.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddNewEmployee.ImageSize = new System.Drawing.Size(25, 25);
            this.btnAddNewEmployee.Location = new System.Drawing.Point(1395, 17);
            this.btnAddNewEmployee.Name = "btnAddNewEmployee";
            this.btnAddNewEmployee.Padding = new System.Windows.Forms.Padding(0, 2, 0, 1);
            this.btnAddNewEmployee.Size = new System.Drawing.Size(145, 40);
            this.btnAddNewEmployee.TabIndex = 73;
            this.btnAddNewEmployee.Text = "Employee";
            this.btnAddNewEmployee.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddNewEmployee.Click += new System.EventHandler(this.btnAddNewEmployee_Click);
            // 
            // panelEmployeeListFeatures
            // 
            this.panelEmployeeListFeatures.BackColor = System.Drawing.Color.Gray;
            this.panelEmployeeListFeatures.BorderColor = System.Drawing.Color.Ivory;
            this.panelEmployeeListFeatures.Controls.Add(this.guna2Panel6);
            this.panelEmployeeListFeatures.Controls.Add(this.guna2Panel5);
            this.panelEmployeeListFeatures.Controls.Add(this.guna2Panel4);
            this.panelEmployeeListFeatures.Controls.Add(this.guna2Panel3);
            this.panelEmployeeListFeatures.Controls.Add(this.guna2Panel2);
            this.panelEmployeeListFeatures.Controls.Add(this.guna2Panel1);
            this.panelEmployeeListFeatures.Controls.Add(this.panelTotalEmployee);
            this.panelEmployeeListFeatures.Controls.Add(this.cboSort);
            this.panelEmployeeListFeatures.Controls.Add(this.guna2Button4);
            this.panelEmployeeListFeatures.Controls.Add(this.guna2Button3);
            this.panelEmployeeListFeatures.Controls.Add(this.btnEdit);
            this.panelEmployeeListFeatures.Controls.Add(this.btnRefresh);
            this.panelEmployeeListFeatures.Controls.Add(this.txtSearch);
            this.panelEmployeeListFeatures.Controls.Add(this.btnExport);
            this.panelEmployeeListFeatures.Controls.Add(this.guna2Button1);
            this.panelEmployeeListFeatures.Controls.Add(this.btnAddNewEmployee);
            this.panelEmployeeListFeatures.Controls.Add(this.lblInactiveEmployee);
            this.panelEmployeeListFeatures.Controls.Add(this.lblActiveEmployee);
            this.panelEmployeeListFeatures.Controls.Add(this.iconInactive);
            this.panelEmployeeListFeatures.Controls.Add(this.iconActive);
            this.panelEmployeeListFeatures.Controls.Add(this.label2);
            this.panelEmployeeListFeatures.Controls.Add(this.label1);
            this.panelEmployeeListFeatures.Controls.Add(this.cboFilter);
            this.panelEmployeeListFeatures.Controls.Add(this.cboSearch);
            this.panelEmployeeListFeatures.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEmployeeListFeatures.FillColor = System.Drawing.Color.Ivory;
            this.panelEmployeeListFeatures.Font = new System.Drawing.Font("Bookman Old Style", 9.5F);
            this.panelEmployeeListFeatures.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.panelEmployeeListFeatures.Location = new System.Drawing.Point(0, 0);
            this.panelEmployeeListFeatures.Name = "panelEmployeeListFeatures";
            this.panelEmployeeListFeatures.ShadowDecoration.BorderRadius = 5;
            this.panelEmployeeListFeatures.ShadowDecoration.Color = System.Drawing.Color.Green;
            this.panelEmployeeListFeatures.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.panelEmployeeListFeatures.Size = new System.Drawing.Size(1914, 203);
            this.panelEmployeeListFeatures.TabIndex = 2;
            // 
            // guna2Panel6
            // 
            this.guna2Panel6.BackColor = System.Drawing.Color.Ivory;
            this.guna2Panel6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Panel6.Controls.Add(this.lblVUIHOC);
            this.guna2Panel6.Controls.Add(this.label15);
            this.guna2Panel6.FillColor = System.Drawing.Color.Ivory;
            this.guna2Panel6.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Panel6.Location = new System.Drawing.Point(742, 109);
            this.guna2Panel6.Name = "guna2Panel6";
            this.guna2Panel6.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel6.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.guna2Panel6.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.guna2Panel6.Size = new System.Drawing.Size(140, 40);
            this.guna2Panel6.TabIndex = 29;
            // 
            // lblVUIHOC
            // 
            this.lblVUIHOC.BackColor = System.Drawing.Color.Ivory;
            this.lblVUIHOC.Font = new System.Drawing.Font("Bookman Old Style", 9.5F);
            this.lblVUIHOC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblVUIHOC.Location = new System.Drawing.Point(67, 5);
            this.lblVUIHOC.Name = "lblVUIHOC";
            this.lblVUIHOC.Padding = new System.Windows.Forms.Padding(5, 1, 0, 0);
            this.lblVUIHOC.Size = new System.Drawing.Size(70, 30);
            this.lblVUIHOC.TabIndex = 27;
            this.lblVUIHOC.Text = "0";
            this.lblVUIHOC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Bookman Old Style", 9F);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label15.Location = new System.Drawing.Point(3, 5);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label15.Size = new System.Drawing.Size(68, 31);
            this.label15.TabIndex = 27;
            this.label15.Text = "VUI - ";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.BackColor = System.Drawing.Color.Ivory;
            this.guna2Panel5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Panel5.Controls.Add(this.lblRKESI);
            this.guna2Panel5.Controls.Add(this.label13);
            this.guna2Panel5.FillColor = System.Drawing.Color.Ivory;
            this.guna2Panel5.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Panel5.Location = new System.Drawing.Point(742, 63);
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel5.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.guna2Panel5.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.guna2Panel5.Size = new System.Drawing.Size(140, 40);
            this.guna2Panel5.TabIndex = 29;
            // 
            // lblRKESI
            // 
            this.lblRKESI.BackColor = System.Drawing.Color.Ivory;
            this.lblRKESI.Font = new System.Drawing.Font("Bookman Old Style", 9.5F);
            this.lblRKESI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRKESI.Location = new System.Drawing.Point(67, 5);
            this.lblRKESI.Name = "lblRKESI";
            this.lblRKESI.Padding = new System.Windows.Forms.Padding(5, 1, 0, 0);
            this.lblRKESI.Size = new System.Drawing.Size(70, 30);
            this.lblRKESI.TabIndex = 27;
            this.lblRKESI.Text = "0";
            this.lblRKESI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Bookman Old Style", 9F);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(3, 5);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label13.Size = new System.Drawing.Size(68, 31);
            this.label13.TabIndex = 27;
            this.label13.Text = "RKE - ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.Ivory;
            this.guna2Panel4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Panel4.Controls.Add(this.lblESO);
            this.guna2Panel4.Controls.Add(this.label11);
            this.guna2Panel4.FillColor = System.Drawing.Color.Ivory;
            this.guna2Panel4.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Panel4.Location = new System.Drawing.Point(742, 15);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel4.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.guna2Panel4.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.guna2Panel4.Size = new System.Drawing.Size(140, 40);
            this.guna2Panel4.TabIndex = 28;
            // 
            // lblESO
            // 
            this.lblESO.BackColor = System.Drawing.Color.Ivory;
            this.lblESO.Font = new System.Drawing.Font("Bookman Old Style", 9.5F);
            this.lblESO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblESO.Location = new System.Drawing.Point(67, 5);
            this.lblESO.Name = "lblESO";
            this.lblESO.Padding = new System.Windows.Forms.Padding(5, 1, 0, 0);
            this.lblESO.Size = new System.Drawing.Size(70, 30);
            this.lblESO.TabIndex = 27;
            this.lblESO.Text = "0";
            this.lblESO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Bookman Old Style", 9F);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(3, 5);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label11.Size = new System.Drawing.Size(68, 31);
            this.label11.TabIndex = 27;
            this.label11.Text = "ESO - ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Ivory;
            this.guna2Panel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Panel3.Controls.Add(this.lblPartTime);
            this.guna2Panel3.Controls.Add(this.label9);
            this.guna2Panel3.FillColor = System.Drawing.Color.Ivory;
            this.guna2Panel3.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Panel3.ForeColor = System.Drawing.Color.Teal;
            this.guna2Panel3.Location = new System.Drawing.Point(534, 63);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel3.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.guna2Panel3.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.guna2Panel3.Size = new System.Drawing.Size(190, 40);
            this.guna2Panel3.TabIndex = 82;
            // 
            // lblPartTime
            // 
            this.lblPartTime.BackColor = System.Drawing.Color.Ivory;
            this.lblPartTime.Font = new System.Drawing.Font("Bookman Old Style", 9.5F);
            this.lblPartTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPartTime.Location = new System.Drawing.Point(113, 5);
            this.lblPartTime.Name = "lblPartTime";
            this.lblPartTime.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.lblPartTime.Size = new System.Drawing.Size(74, 30);
            this.lblPartTime.TabIndex = 27;
            this.lblPartTime.Text = "0";
            this.lblPartTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Bookman Old Style", 9F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(3, 5);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label9.Size = new System.Drawing.Size(124, 31);
            this.label9.TabIndex = 27;
            this.label9.Text = "Part-Time : ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Ivory;
            this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Panel2.Controls.Add(this.lblFullTime);
            this.guna2Panel2.Controls.Add(this.label7);
            this.guna2Panel2.FillColor = System.Drawing.Color.Ivory;
            this.guna2Panel2.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Panel2.Location = new System.Drawing.Point(534, 15);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel2.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.guna2Panel2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.guna2Panel2.Size = new System.Drawing.Size(190, 40);
            this.guna2Panel2.TabIndex = 81;
            // 
            // lblFullTime
            // 
            this.lblFullTime.BackColor = System.Drawing.Color.Ivory;
            this.lblFullTime.Font = new System.Drawing.Font("Bookman Old Style", 9.5F);
            this.lblFullTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFullTime.Location = new System.Drawing.Point(113, 5);
            this.lblFullTime.Name = "lblFullTime";
            this.lblFullTime.Padding = new System.Windows.Forms.Padding(5, 2, 0, 0);
            this.lblFullTime.Size = new System.Drawing.Size(74, 30);
            this.lblFullTime.TabIndex = 27;
            this.lblFullTime.Text = "0";
            this.lblFullTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Bookman Old Style", 9F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(3, 5);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label7.Size = new System.Drawing.Size(124, 31);
            this.label7.TabIndex = 27;
            this.label7.Text = "Full-Time : ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Ivory;
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2Panel1.Controls.Add(this.lblFemaleEmployee);
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.FillColor = System.Drawing.Color.Ivory;
            this.guna2Panel1.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Panel1.ForeColor = System.Drawing.Color.Teal;
            this.guna2Panel1.Location = new System.Drawing.Point(376, 63);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 15;
            this.guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.guna2Panel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.guna2Panel1.Size = new System.Drawing.Size(140, 40);
            this.guna2Panel1.TabIndex = 28;
            // 
            // lblFemaleEmployee
            // 
            this.lblFemaleEmployee.BackColor = System.Drawing.Color.Ivory;
            this.lblFemaleEmployee.Font = new System.Drawing.Font("Bookman Old Style", 9.5F);
            this.lblFemaleEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFemaleEmployee.Location = new System.Drawing.Point(50, 5);
            this.lblFemaleEmployee.Name = "lblFemaleEmployee";
            this.lblFemaleEmployee.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblFemaleEmployee.Size = new System.Drawing.Size(86, 30);
            this.lblFemaleEmployee.TabIndex = 27;
            this.lblFemaleEmployee.Text = "0";
            this.lblFemaleEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Bookman Old Style", 9F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(3, 4);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label5.Size = new System.Drawing.Size(56, 31);
            this.label5.TabIndex = 27;
            this.label5.Text = "F - ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelTotalEmployee
            // 
            this.panelTotalEmployee.BackColor = System.Drawing.Color.Ivory;
            this.panelTotalEmployee.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelTotalEmployee.Controls.Add(this.lblMaleEmployee);
            this.panelTotalEmployee.Controls.Add(this.label3);
            this.panelTotalEmployee.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTotalEmployee.Location = new System.Drawing.Point(376, 15);
            this.panelTotalEmployee.Name = "panelTotalEmployee";
            this.panelTotalEmployee.ShadowDecoration.BorderRadius = 15;
            this.panelTotalEmployee.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panelTotalEmployee.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.panelTotalEmployee.Size = new System.Drawing.Size(140, 40);
            this.panelTotalEmployee.TabIndex = 3;
            // 
            // lblMaleEmployee
            // 
            this.lblMaleEmployee.BackColor = System.Drawing.Color.Ivory;
            this.lblMaleEmployee.Font = new System.Drawing.Font("Bookman Old Style", 9.5F);
            this.lblMaleEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMaleEmployee.Location = new System.Drawing.Point(50, 5);
            this.lblMaleEmployee.Name = "lblMaleEmployee";
            this.lblMaleEmployee.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblMaleEmployee.Size = new System.Drawing.Size(86, 30);
            this.lblMaleEmployee.TabIndex = 27;
            this.lblMaleEmployee.Text = "0";
            this.lblMaleEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(56, 31);
            this.label3.TabIndex = 27;
            this.label3.Text = "M - ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboSort
            // 
            this.cboSort.BackColor = System.Drawing.Color.Ivory;
            this.cboSort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.cboSort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSort.FillColor = System.Drawing.Color.Ivory;
            this.cboSort.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSort.Font = new System.Drawing.Font("Bookman Old Style", 10.5F);
            this.cboSort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboSort.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.cboSort.ItemHeight = 35;
            this.cboSort.Items.AddRange(new object[] {
            "Sort By",
            "Non-Tenured",
            "Tenured",
            "ESO",
            "RKESI",
            "VUIHOC"});
            this.cboSort.Location = new System.Drawing.Point(988, 78);
            this.cboSort.Name = "cboSort";
            this.cboSort.ShadowDecoration.BorderRadius = 4;
            this.cboSort.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cboSort.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.cboSort.Size = new System.Drawing.Size(210, 41);
            this.cboSort.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cboSort.TabIndex = 80;
            this.cboSort.SelectedIndexChanged += new System.EventHandler(this.cboSort_SelectedIndexChanged);
            this.cboSort.Click += new System.EventHandler(this.cboSort_Click);
            // 
            // guna2Button4
            // 
            this.guna2Button4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button4.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.guna2Button4.BorderRadius = 1;
            this.guna2Button4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.guna2Button4.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.guna2Button4.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.guna2Button4.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.guna2Button4.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button4.Image")));
            this.guna2Button4.ImageSize = new System.Drawing.Size(25, 25);
            this.guna2Button4.Location = new System.Drawing.Point(935, 84);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.guna2Button4.PressedDepth = 0;
            this.guna2Button4.Size = new System.Drawing.Size(35, 35);
            this.guna2Button4.TabIndex = 79;
            this.guna2Button4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // guna2Button3
            // 
            this.guna2Button3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.guna2Button3.BorderRadius = 1;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.guna2Button3.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.guna2Button3.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.guna2Button3.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button3.Image")));
            this.guna2Button3.ImageSize = new System.Drawing.Size(25, 25);
            this.guna2Button3.Location = new System.Drawing.Point(935, 144);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.guna2Button3.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.guna2Button3.PressedDepth = 0;
            this.guna2Button3.Size = new System.Drawing.Size(35, 35);
            this.guna2Button3.TabIndex = 78;
            this.guna2Button3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btnEdit.BorderRadius = 1;
            this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.btnEdit.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.btnEdit.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.btnEdit.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageSize = new System.Drawing.Size(30, 34);
            this.btnEdit.Location = new System.Drawing.Point(266, 142);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.btnEdit.PressedDepth = 0;
            this.btnEdit.Size = new System.Drawing.Size(35, 35);
            this.btnEdit.TabIndex = 77;
            this.btnEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BorderColor = System.Drawing.Color.Coral;
            this.btnRefresh.BorderRadius = 4;
            this.btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefresh.FillColor = System.Drawing.Color.Coral;
            this.btnRefresh.Font = new System.Drawing.Font("Bookman Old Style", 9.5F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverState.BorderColor = System.Drawing.Color.Tomato;
            this.btnRefresh.HoverState.FillColor = System.Drawing.Color.Tomato;
            this.btnRefresh.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRefresh.ImageSize = new System.Drawing.Size(25, 25);
            this.btnRefresh.Location = new System.Drawing.Point(1410, 137);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(1, 2, 0, 1);
            this.btnRefresh.PressedColor = System.Drawing.Color.Salmon;
            this.btnRefresh.Size = new System.Drawing.Size(130, 40);
            this.btnRefresh.TabIndex = 77;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AutoRoundedCorners = true;
            this.txtSearch.BackColor = System.Drawing.Color.Ivory;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.txtSearch.BorderRadius = 19;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FillColor = System.Drawing.Color.Ivory;
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSearch.Font = new System.Drawing.Font("Bookman Old Style", 10.5F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.txtSearch.Location = new System.Drawing.Point(309, 136);
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
            this.txtSearch.Size = new System.Drawing.Size(335, 41);
            this.txtSearch.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtSearch.TabIndex = 76;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnExport.BorderRadius = 4;
            this.btnExport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExport.FillColor = System.Drawing.Color.Green;
            this.btnExport.Font = new System.Drawing.Font("Bookman Old Style", 9.5F);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.HoverState.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnExport.HoverState.FillColor = System.Drawing.Color.DarkGreen;
            this.btnExport.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnExport.ImageSize = new System.Drawing.Size(25, 25);
            this.btnExport.Location = new System.Drawing.Point(935, 17);
            this.btnExport.Name = "btnExport";
            this.btnExport.Padding = new System.Windows.Forms.Padding(5, 2, 0, 1);
            this.btnExport.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(177)))), ((int)(((byte)(65)))));
            this.btnExport.Size = new System.Drawing.Size(130, 40);
            this.btnExport.TabIndex = 75;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.guna2Button1.BorderRadius = 4;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Green;
            this.guna2Button1.Font = new System.Drawing.Font("Bookman Old Style", 9.5F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.BorderColor = System.Drawing.Color.DarkGreen;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.DarkGreen;
            this.guna2Button1.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.ImageSize = new System.Drawing.Size(25, 25);
            this.guna2Button1.Location = new System.Drawing.Point(1070, 17);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 1);
            this.guna2Button1.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(177)))), ((int)(((byte)(65)))));
            this.guna2Button1.Size = new System.Drawing.Size(130, 40);
            this.guna2Button1.TabIndex = 74;
            this.guna2Button1.Text = "Import";
            this.guna2Button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // cboSearch
            // 
            this.cboSearch.BackColor = System.Drawing.Color.Ivory;
            this.cboSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.cboSearch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearch.FillColor = System.Drawing.Color.Ivory;
            this.cboSearch.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSearch.Font = new System.Drawing.Font("Bookman Old Style", 10.5F);
            this.cboSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.cboSearch.ItemHeight = 35;
            this.cboSearch.Items.AddRange(new object[] {
            "Search By",
            "ID Number",
            "Employee Name",
            "Email Address"});
            this.cboSearch.Location = new System.Drawing.Point(38, 137);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.ShadowDecoration.BorderRadius = 4;
            this.cboSearch.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cboSearch.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.cboSearch.Size = new System.Drawing.Size(220, 41);
            this.cboSearch.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cboSearch.TabIndex = 56;
            this.cboSearch.Click += new System.EventHandler(this.cboSearch_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1714, 203);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 773);
            this.flowLayoutPanel2.TabIndex = 0;
            this.flowLayoutPanel2.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Gray;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 203);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1914, 773);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // EmployeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1914, 976);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelEmployeeListFeatures);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Cambria", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EmployeeList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee List";
            this.Load += new System.EventHandler(this.EmployeeList_Load);
            this.panelEmployeeListFeatures.ResumeLayout(false);
            this.panelEmployeeListFeatures.PerformLayout();
            this.guna2Panel6.ResumeLayout(false);
            this.guna2Panel5.ResumeLayout(false);
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.panelTotalEmployee.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ComboBox cboFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton iconActive;
        private FontAwesome.Sharp.IconButton iconInactive;
        private System.Windows.Forms.Label lblActiveEmployee;
        private System.Windows.Forms.Label lblInactiveEmployee;
        private Guna.UI2.WinForms.Guna2Button btnAddNewEmployee;
        private Guna.UI2.WinForms.Guna2Button btnExport;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        public Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2ComboBox cboSort;
        public Guna.UI2.WinForms.Guna2Panel panelEmployeeListFeatures;
        private Guna.UI2.WinForms.Guna2ComboBox cboSearch;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel panelTotalEmployee;
        private System.Windows.Forms.Label lblMaleEmployee;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label lblFemaleEmployee;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label lblFullTime;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Label lblPartTime;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.Label lblESO;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel6;
        private System.Windows.Forms.Label lblVUIHOC;
        private System.Windows.Forms.Label label15;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private System.Windows.Forms.Label lblRKESI;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}