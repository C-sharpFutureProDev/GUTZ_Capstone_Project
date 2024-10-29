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
            this.SuspendLayout();
            // 
            // cboFilter
            // 
            this.cboFilter.AutoRoundedCorners = true;
            this.cboFilter.BackColor = System.Drawing.Color.Ivory;
            this.cboFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.cboFilter.BorderRadius = 19;
            this.cboFilter.BorderThickness = 2;
            this.cboFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FillColor = System.Drawing.Color.Ivory;
            this.cboFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboFilter.Font = new System.Drawing.Font("Roboto", 12F);
            this.cboFilter.ForeColor = System.Drawing.Color.Black;
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
            this.label1.Font = new System.Drawing.Font("Roboto", 10F);
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(66, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 67;
            this.label1.Text = "Active";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Ivory;
            this.label2.Font = new System.Drawing.Font("Roboto", 10F);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(226, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 25);
            this.label2.TabIndex = 68;
            this.label2.Text = "Inactive";
            // 
            // iconActive
            // 
            this.iconActive.BackColor = System.Drawing.Color.Ivory;
            this.iconActive.FlatAppearance.BorderSize = 0;
            this.iconActive.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconActive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconActive.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            this.iconActive.IconColor = System.Drawing.Color.Green;
            this.iconActive.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconActive.IconSize = 35;
            this.iconActive.Location = new System.Drawing.Point(20, 15);
            this.iconActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.iconActive.Name = "iconActive";
            this.iconActive.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
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
            this.iconInactive.IconChar = FontAwesome.Sharp.IconChar.Pause;
            this.iconInactive.IconColor = System.Drawing.Color.Gray;
            this.iconInactive.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconInactive.IconSize = 30;
            this.iconInactive.Location = new System.Drawing.Point(180, 15);
            this.iconInactive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.iconInactive.Name = "iconInactive";
            this.iconInactive.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconInactive.Size = new System.Drawing.Size(45, 30);
            this.iconInactive.TabIndex = 70;
            this.iconInactive.UseVisualStyleBackColor = false;
            // 
            // lblActiveEmployee
            // 
            this.lblActiveEmployee.AutoSize = true;
            this.lblActiveEmployee.BackColor = System.Drawing.Color.Ivory;
            this.lblActiveEmployee.Font = new System.Drawing.Font("Roboto", 10F);
            this.lblActiveEmployee.ForeColor = System.Drawing.Color.Green;
            this.lblActiveEmployee.Location = new System.Drawing.Point(136, 16);
            this.lblActiveEmployee.Name = "lblActiveEmployee";
            this.lblActiveEmployee.Size = new System.Drawing.Size(23, 25);
            this.lblActiveEmployee.TabIndex = 71;
            this.lblActiveEmployee.Text = "0";
            // 
            // lblInactiveEmployee
            // 
            this.lblInactiveEmployee.AutoSize = true;
            this.lblInactiveEmployee.BackColor = System.Drawing.Color.Ivory;
            this.lblInactiveEmployee.Font = new System.Drawing.Font("Roboto", 10F);
            this.lblInactiveEmployee.ForeColor = System.Drawing.Color.Gray;
            this.lblInactiveEmployee.Location = new System.Drawing.Point(309, 16);
            this.lblInactiveEmployee.Name = "lblInactiveEmployee";
            this.lblInactiveEmployee.Size = new System.Drawing.Size(23, 25);
            this.lblInactiveEmployee.TabIndex = 72;
            this.lblInactiveEmployee.Text = "0";
            // 
            // btnAddNewEmployee
            // 
            this.btnAddNewEmployee.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewEmployee.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddNewEmployee.BorderRadius = 5;
            this.btnAddNewEmployee.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewEmployee.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewEmployee.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewEmployee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewEmployee.FillColor = System.Drawing.Color.Green;
            this.btnAddNewEmployee.Font = new System.Drawing.Font("Roboto", 10F);
            this.btnAddNewEmployee.ForeColor = System.Drawing.Color.White;
            this.btnAddNewEmployee.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddNewEmployee.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(58)))), ((int)(((byte)(14)))));
            this.btnAddNewEmployee.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAddNewEmployee.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewEmployee.Image")));
            this.btnAddNewEmployee.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddNewEmployee.ImageSize = new System.Drawing.Size(29, 29);
            this.btnAddNewEmployee.Location = new System.Drawing.Point(1385, 15);
            this.btnAddNewEmployee.Name = "btnAddNewEmployee";
            this.btnAddNewEmployee.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnAddNewEmployee.Size = new System.Drawing.Size(189, 42);
            this.btnAddNewEmployee.TabIndex = 73;
            this.btnAddNewEmployee.Text = "New Employee";
            this.btnAddNewEmployee.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddNewEmployee.Click += new System.EventHandler(this.btnAddNewEmployee_Click);
            // 
            // panelEmployeeListFeatures
            // 
            this.panelEmployeeListFeatures.BackColor = System.Drawing.Color.Gray;
            this.panelEmployeeListFeatures.BorderColor = System.Drawing.Color.Ivory;
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
            this.panelEmployeeListFeatures.Font = new System.Drawing.Font("Symbol", 8.25F);
            this.panelEmployeeListFeatures.Location = new System.Drawing.Point(0, 0);
            this.panelEmployeeListFeatures.Name = "panelEmployeeListFeatures";
            this.panelEmployeeListFeatures.ShadowDecoration.BorderRadius = 5;
            this.panelEmployeeListFeatures.ShadowDecoration.Color = System.Drawing.Color.Green;
            this.panelEmployeeListFeatures.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.panelEmployeeListFeatures.Size = new System.Drawing.Size(1914, 202);
            this.panelEmployeeListFeatures.TabIndex = 2;
           
            // 
            // cboSort
            // 
            this.cboSort.BackColor = System.Drawing.Color.Ivory;
            this.cboSort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.cboSort.BorderThickness = 2;
            this.cboSort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSort.FillColor = System.Drawing.Color.Ivory;
            this.cboSort.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSort.Font = new System.Drawing.Font("Roboto", 12F);
            this.cboSort.ForeColor = System.Drawing.Color.Black;
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
            this.guna2Button4.BorderColor = System.Drawing.Color.ForestGreen;
            this.guna2Button4.BorderRadius = 4;
            this.guna2Button4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button4.FillColor = System.Drawing.Color.ForestGreen;
            this.guna2Button4.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.guna2Button4.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.HoverState.BorderColor = System.Drawing.Color.ForestGreen;
            this.guna2Button4.HoverState.FillColor = System.Drawing.Color.ForestGreen;
            this.guna2Button4.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button4.Image")));
            this.guna2Button4.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2Button4.Location = new System.Drawing.Point(935, 81);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.PressedColor = System.Drawing.Color.ForestGreen;
            this.guna2Button4.PressedDepth = 0;
            this.guna2Button4.Size = new System.Drawing.Size(37, 37);
            this.guna2Button4.TabIndex = 79;
            this.guna2Button4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // guna2Button3
            // 
            this.guna2Button3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderColor = System.Drawing.Color.ForestGreen;
            this.guna2Button3.BorderRadius = 4;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.ForestGreen;
            this.guna2Button3.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.HoverState.BorderColor = System.Drawing.Color.ForestGreen;
            this.guna2Button3.HoverState.FillColor = System.Drawing.Color.ForestGreen;
            this.guna2Button3.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button3.Image")));
            this.guna2Button3.ImageSize = new System.Drawing.Size(30, 30);
            this.guna2Button3.Location = new System.Drawing.Point(935, 142);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.guna2Button3.PressedColor = System.Drawing.Color.ForestGreen;
            this.guna2Button3.PressedDepth = 0;
            this.guna2Button3.Size = new System.Drawing.Size(37, 37);
            this.guna2Button3.TabIndex = 78;
            this.guna2Button3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnEdit.BorderRadius = 4;
            this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEdit.FillColor = System.Drawing.Color.ForestGreen;
            this.btnEdit.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.HoverState.BorderColor = System.Drawing.Color.ForestGreen;
            this.btnEdit.HoverState.FillColor = System.Drawing.Color.ForestGreen;
            this.btnEdit.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageSize = new System.Drawing.Size(38, 38);
            this.btnEdit.Location = new System.Drawing.Point(261, 140);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PressedColor = System.Drawing.Color.ForestGreen;
            this.btnEdit.PressedDepth = 0;
            this.btnEdit.Size = new System.Drawing.Size(37, 37);
            this.btnEdit.TabIndex = 77;
            this.btnEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BorderColor = System.Drawing.Color.Green;
            this.btnRefresh.BorderRadius = 5;
            this.btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefresh.FillColor = System.Drawing.Color.Green;
            this.btnRefresh.Font = new System.Drawing.Font("Roboto", 10F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverState.BorderColor = System.Drawing.Color.Green;
            this.btnRefresh.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(58)))), ((int)(((byte)(14)))));
            this.btnRefresh.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRefresh.ImageSize = new System.Drawing.Size(25, 25);
            this.btnRefresh.Location = new System.Drawing.Point(1385, 133);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnRefresh.PressedColor = System.Drawing.Color.ForestGreen;
            this.btnRefresh.Size = new System.Drawing.Size(129, 42);
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
            this.txtSearch.BorderThickness = 2;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FillColor = System.Drawing.Color.Ivory;
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSearch.Font = new System.Drawing.Font("Roboto", 11F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.txtSearch.Location = new System.Drawing.Point(311, 138);
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
            this.txtSearch.Size = new System.Drawing.Size(360, 40);
            this.txtSearch.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtSearch.TabIndex = 76;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnExport.BorderRadius = 5;
            this.btnExport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.btnExport.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnExport.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(58)))), ((int)(((byte)(14)))));
            this.btnExport.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnExport.ImageSize = new System.Drawing.Size(29, 29);
            this.btnExport.Location = new System.Drawing.Point(936, 15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.btnExport.Size = new System.Drawing.Size(129, 42);
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
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.guna2Button1.Font = new System.Drawing.Font("Roboto", 10F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(58)))), ((int)(((byte)(14)))));
            this.guna2Button1.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.ImageSize = new System.Drawing.Size(29, 29);
            this.guna2Button1.Location = new System.Drawing.Point(1071, 15);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.guna2Button1.Size = new System.Drawing.Size(129, 42);
            this.guna2Button1.TabIndex = 74;
            this.guna2Button1.Text = "Import";
            this.guna2Button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // cboSearch
            // 
            this.cboSearch.BackColor = System.Drawing.Color.Ivory;
            this.cboSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.cboSearch.BorderThickness = 2;
            this.cboSearch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearch.FillColor = System.Drawing.Color.Ivory;
            this.cboSearch.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSearch.Font = new System.Drawing.Font("Roboto", 12F);
            this.cboSearch.ForeColor = System.Drawing.Color.Black;
            this.cboSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.cboSearch.ItemHeight = 35;
            this.cboSearch.Items.AddRange(new object[] {
            "Search By",
            "ID Number",
            "Name",
            "Email Address"});
            this.cboSearch.Location = new System.Drawing.Point(38, 137);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.ShadowDecoration.BorderRadius = 4;
            this.cboSearch.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cboSearch.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.cboSearch.Size = new System.Drawing.Size(210, 41);
            this.cboSearch.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.cboSearch.TabIndex = 56;
            this.cboSearch.Click += new System.EventHandler(this.cboSearch_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(1714, 202);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 774);
            this.flowLayoutPanel2.TabIndex = 0;
            this.flowLayoutPanel2.Visible = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Gray;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 202);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1914, 774);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // EmployeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1914, 976);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelEmployeeListFeatures);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EmployeeList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee List";
            this.Load += new System.EventHandler(this.EmployeeList_Load);
            this.panelEmployeeListFeatures.ResumeLayout(false);
            this.panelEmployeeListFeatures.PerformLayout();
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
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
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
    }
}