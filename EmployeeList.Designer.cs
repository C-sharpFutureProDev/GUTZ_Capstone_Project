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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.iconFilter = new FontAwesome.Sharp.IconButton();
            this.iconSearch = new FontAwesome.Sharp.IconButton();
            this.iconSort = new FontAwesome.Sharp.IconButton();
            this.cboSearch = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboSort = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.iconActive = new FontAwesome.Sharp.IconButton();
            this.iconInactive = new FontAwesome.Sharp.IconButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddNewEmployee = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(237)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 202);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1914, 774);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // iconFilter
            // 
            this.iconFilter.BackColor = System.Drawing.Color.White;
            this.iconFilter.FlatAppearance.BorderSize = 0;
            this.iconFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconFilter.IconChar = FontAwesome.Sharp.IconChar.Filter;
            this.iconFilter.IconColor = System.Drawing.SystemColors.AppWorkspace;
            this.iconFilter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconFilter.IconSize = 39;
            this.iconFilter.Location = new System.Drawing.Point(957, 141);
            this.iconFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.iconFilter.Name = "iconFilter";
            this.iconFilter.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.iconFilter.Size = new System.Drawing.Size(42, 41);
            this.iconFilter.TabIndex = 54;
            this.iconFilter.UseVisualStyleBackColor = false;
            // 
            // iconSearch
            // 
            this.iconSearch.BackColor = System.Drawing.Color.White;
            this.iconSearch.FlatAppearance.BorderSize = 0;
            this.iconSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconSearch.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconSearch.IconColor = System.Drawing.SystemColors.AppWorkspace;
            this.iconSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSearch.IconSize = 44;
            this.iconSearch.Location = new System.Drawing.Point(251, 138);
            this.iconSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.iconSearch.Name = "iconSearch";
            this.iconSearch.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.iconSearch.Size = new System.Drawing.Size(42, 41);
            this.iconSearch.TabIndex = 51;
            this.iconSearch.UseVisualStyleBackColor = false;
            // 
            // iconSort
            // 
            this.iconSort.BackColor = System.Drawing.Color.White;
            this.iconSort.FlatAppearance.BorderSize = 0;
            this.iconSort.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconSort.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconSort.IconChar = FontAwesome.Sharp.IconChar.Unsorted;
            this.iconSort.IconColor = System.Drawing.SystemColors.AppWorkspace;
            this.iconSort.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSort.IconSize = 39;
            this.iconSort.Location = new System.Drawing.Point(681, 140);
            this.iconSort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.iconSort.Name = "iconSort";
            this.iconSort.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.iconSort.Size = new System.Drawing.Size(42, 41);
            this.iconSort.TabIndex = 55;
            this.iconSort.UseVisualStyleBackColor = false;
            // 
            // cboSearch
            // 
            this.cboSearch.BackColor = System.Drawing.Color.Transparent;
            this.cboSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSearch.BorderRadius = 4;
            this.cboSearch.BorderThickness = 2;
            this.cboSearch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearch.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSearch.Font = new System.Drawing.Font("Lucida Fax", 9F, System.Drawing.FontStyle.Bold);
            this.cboSearch.ForeColor = System.Drawing.Color.Black;
            this.cboSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSearch.ItemHeight = 38;
            this.cboSearch.Items.AddRange(new object[] {
            "SEARCH BY",
            "Emp. ID no.",
            "Emp. Name",
            "Emp. Code"});
            this.cboSearch.Location = new System.Drawing.Point(29, 138);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.ShadowDecoration.BorderRadius = 4;
            this.cboSearch.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cboSearch.ShadowDecoration.Enabled = true;
            this.cboSearch.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.cboSearch.Size = new System.Drawing.Size(211, 44);
            this.cboSearch.TabIndex = 56;
            this.cboSearch.DropDown += new System.EventHandler(this.cboSearch_DropDown);
            // 
            // cboSort
            // 
            this.cboSort.BackColor = System.Drawing.Color.Transparent;
            this.cboSort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSort.BorderRadius = 4;
            this.cboSort.BorderThickness = 2;
            this.cboSort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSort.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSort.Font = new System.Drawing.Font("Lucida Fax", 9F, System.Drawing.FontStyle.Bold);
            this.cboSort.ForeColor = System.Drawing.Color.Black;
            this.cboSort.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSort.ItemHeight = 38;
            this.cboSort.Items.AddRange(new object[] {
            "SORT BY"});
            this.cboSort.Location = new System.Drawing.Point(734, 138);
            this.cboSort.Name = "cboSort";
            this.cboSort.ShadowDecoration.BorderRadius = 4;
            this.cboSort.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cboSort.ShadowDecoration.Enabled = true;
            this.cboSort.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.cboSort.Size = new System.Drawing.Size(212, 44);
            this.cboSort.TabIndex = 57;
            // 
            // cboFilter
            // 
            this.cboFilter.BackColor = System.Drawing.Color.Transparent;
            this.cboFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboFilter.BorderRadius = 4;
            this.cboFilter.BorderThickness = 2;
            this.cboFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboFilter.Font = new System.Drawing.Font("Lucida Fax", 9F, System.Drawing.FontStyle.Bold);
            this.cboFilter.ForeColor = System.Drawing.Color.Black;
            this.cboFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboFilter.ItemHeight = 38;
            this.cboFilter.Items.AddRange(new object[] {
            "FILTER BY"});
            this.cboFilter.Location = new System.Drawing.Point(1010, 137);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.ShadowDecoration.BorderRadius = 4;
            this.cboFilter.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cboFilter.ShadowDecoration.Enabled = true;
            this.cboFilter.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.cboFilter.Size = new System.Drawing.Size(212, 44);
            this.cboFilter.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(66, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 67;
            this.label1.Text = "Active";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.label2.Location = new System.Drawing.Point(226, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 68;
            this.label2.Text = "Inactive";
            // 
            // iconActive
            // 
            this.iconActive.BackColor = System.Drawing.Color.White;
            this.iconActive.FlatAppearance.BorderSize = 0;
            this.iconActive.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconActive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconActive.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            this.iconActive.IconColor = System.Drawing.Color.Green;
            this.iconActive.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconActive.IconSize = 30;
            this.iconActive.Location = new System.Drawing.Point(20, 22);
            this.iconActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.iconActive.Name = "iconActive";
            this.iconActive.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.iconActive.Size = new System.Drawing.Size(42, 25);
            this.iconActive.TabIndex = 69;
            this.iconActive.UseVisualStyleBackColor = false;
            // 
            // iconInactive
            // 
            this.iconInactive.BackColor = System.Drawing.Color.White;
            this.iconInactive.FlatAppearance.BorderSize = 0;
            this.iconInactive.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconInactive.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconInactive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconInactive.IconChar = FontAwesome.Sharp.IconChar.Pause;
            this.iconInactive.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.iconInactive.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconInactive.IconSize = 25;
            this.iconInactive.Location = new System.Drawing.Point(180, 22);
            this.iconInactive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.iconInactive.Name = "iconInactive";
            this.iconInactive.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconInactive.Size = new System.Drawing.Size(42, 25);
            this.iconInactive.TabIndex = 70;
            this.iconInactive.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(136, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 19);
            this.label3.TabIndex = 71;
            this.label3.Text = "200";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.label4.Location = new System.Drawing.Point(309, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 19);
            this.label4.TabIndex = 72;
            this.label4.Text = "0";
            // 
            // btnAddNewEmployee
            // 
            this.btnAddNewEmployee.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewEmployee.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddNewEmployee.BorderRadius = 5;
            this.btnAddNewEmployee.BorderThickness = 2;
            this.btnAddNewEmployee.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewEmployee.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewEmployee.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewEmployee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewEmployee.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnAddNewEmployee.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnAddNewEmployee.ForeColor = System.Drawing.Color.White;
            this.btnAddNewEmployee.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnAddNewEmployee.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnAddNewEmployee.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAddNewEmployee.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewEmployee.Image")));
            this.btnAddNewEmployee.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddNewEmployee.ImageSize = new System.Drawing.Size(29, 29);
            this.btnAddNewEmployee.Location = new System.Drawing.Point(1386, 12);
            this.btnAddNewEmployee.Name = "btnAddNewEmployee";
            this.btnAddNewEmployee.Size = new System.Drawing.Size(174, 45);
            this.btnAddNewEmployee.TabIndex = 73;
            this.btnAddNewEmployee.Text = "New Employee";
            this.btnAddNewEmployee.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddNewEmployee.Click += new System.EventHandler(this.btnAddNewEmployee_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.guna2Panel1.Controls.Add(this.txtSearch);
            this.guna2Panel1.Controls.Add(this.guna2Button2);
            this.guna2Panel1.Controls.Add(this.guna2Button1);
            this.guna2Panel1.Controls.Add(this.btnAddNewEmployee);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.iconInactive);
            this.guna2Panel1.Controls.Add(this.iconActive);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.cboFilter);
            this.guna2Panel1.Controls.Add(this.cboSort);
            this.guna2Panel1.Controls.Add(this.cboSearch);
            this.guna2Panel1.Controls.Add(this.iconSort);
            this.guna2Panel1.Controls.Add(this.iconSearch);
            this.guna2Panel1.Controls.Add(this.iconFilter);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(230)))), ((int)(((byte)(237)))));
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Font = new System.Drawing.Font("Symbol", 8.25F);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 4;
            this.guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.Green;
            this.guna2Panel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Size = new System.Drawing.Size(1914, 202);
            this.guna2Panel1.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.AutoSize = true;
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSearch.BorderRadius = 4;
            this.txtSearch.BorderThickness = 2;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSearch.Font = new System.Drawing.Font("Lucida Fax", 9F, System.Drawing.FontStyle.Bold);
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSearch.Location = new System.Drawing.Point(304, 138);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.LightGray;
            this.txtSearch.PlaceholderText = "Search";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.BorderRadius = 4;
            this.txtSearch.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtSearch.ShadowDecoration.Enabled = true;
            this.txtSearch.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(4);
            this.txtSearch.Size = new System.Drawing.Size(366, 44);
            this.txtSearch.TabIndex = 76;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.guna2Button2.BorderRadius = 4;
            this.guna2Button2.BorderThickness = 2;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.guna2Button2.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.guna2Button2.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.guna2Button2.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button2.Image")));
            this.guna2Button2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button2.ImageSize = new System.Drawing.Size(29, 29);
            this.guna2Button2.Location = new System.Drawing.Point(1106, 12);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(116, 45);
            this.guna2Button2.TabIndex = 75;
            this.guna2Button2.Text = "Export";
            this.guna2Button2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.guna2Button1.BorderRadius = 4;
            this.guna2Button1.BorderThickness = 2;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.guna2Button1.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.guna2Button1.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.ImageSize = new System.Drawing.Size(29, 29);
            this.guna2Button1.Location = new System.Drawing.Point(1246, 12);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(116, 45);
            this.guna2Button1.TabIndex = 74;
            this.guna2Button1.Text = "Import";
            this.guna2Button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // EmployeeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1914, 976);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.guna2Panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EmployeeList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee List";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private FontAwesome.Sharp.IconButton iconFilter;
        private FontAwesome.Sharp.IconButton iconSearch;
        private FontAwesome.Sharp.IconButton iconSort;
        private Guna.UI2.WinForms.Guna2ComboBox cboSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cboSort;
        private Guna.UI2.WinForms.Guna2ComboBox cboFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton iconActive;
        private FontAwesome.Sharp.IconButton iconInactive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button btnAddNewEmployee;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}