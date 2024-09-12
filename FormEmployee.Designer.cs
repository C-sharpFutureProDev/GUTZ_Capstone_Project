namespace GUTZ_Capstone_Project
{
    partial class FormEmployee
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEmployeeList = new Guna.UI2.WinForms.Guna2Panel();
            this.DGVEmployee = new System.Windows.Forms.DataGridView();
            this.btnAddNewEmployee = new Guna.UI2.WinForms.Guna2Button();
            this.cboSort = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.iconSort = new FontAwesome.Sharp.IconButton();
            this.iconSearch = new FontAwesome.Sharp.IconButton();
            this.iconFilter = new FontAwesome.Sharp.IconButton();
            this.cboFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboSearch = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEmployeeProfile = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.panelEmployeeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployee)).BeginInit();
            this.panelEmployeeProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEmployeeList
            // 
            this.panelEmployeeList.BackColor = System.Drawing.Color.Transparent;
            this.panelEmployeeList.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.panelEmployeeList.BorderRadius = 15;
            this.panelEmployeeList.Controls.Add(this.guna2Button1);
            this.panelEmployeeList.Controls.Add(this.cboSearch);
            this.panelEmployeeList.Controls.Add(this.DGVEmployee);
            this.panelEmployeeList.Controls.Add(this.btnAddNewEmployee);
            this.panelEmployeeList.Controls.Add(this.cboSort);
            this.panelEmployeeList.Controls.Add(this.txtSearch);
            this.panelEmployeeList.Controls.Add(this.iconSort);
            this.panelEmployeeList.Controls.Add(this.iconSearch);
            this.panelEmployeeList.Controls.Add(this.iconFilter);
            this.panelEmployeeList.Controls.Add(this.cboFilter);
            this.panelEmployeeList.FillColor = System.Drawing.Color.White;
            this.panelEmployeeList.Location = new System.Drawing.Point(29, 39);
            this.panelEmployeeList.Name = "panelEmployeeList";
            this.panelEmployeeList.ShadowDecoration.BorderRadius = 15;
            this.panelEmployeeList.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panelEmployeeList.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.panelEmployeeList.Size = new System.Drawing.Size(651, 826);
            this.panelEmployeeList.TabIndex = 50;
            // 
            // DGVEmployee
            // 
            this.DGVEmployee.AllowUserToAddRows = false;
            this.DGVEmployee.AllowUserToDeleteRows = false;
            this.DGVEmployee.AllowUserToResizeColumns = false;
            this.DGVEmployee.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.DGVEmployee.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVEmployee.BackgroundColor = System.Drawing.Color.White;
            this.DGVEmployee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGVEmployee.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVEmployee.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVEmployee.ColumnHeadersHeight = 41;
            this.DGVEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVEmployee.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVEmployee.EnableHeadersVisualStyles = false;
            this.DGVEmployee.GridColor = System.Drawing.Color.Gainsboro;
            this.DGVEmployee.Location = new System.Drawing.Point(27, 291);
            this.DGVEmployee.Name = "DGVEmployee";
            this.DGVEmployee.ReadOnly = true;
            this.DGVEmployee.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVEmployee.RowHeadersVisible = false;
            this.DGVEmployee.RowHeadersWidth = 60;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.DGVEmployee.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVEmployee.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.DGVEmployee.RowTemplate.Height = 38;
            this.DGVEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVEmployee.Size = new System.Drawing.Size(597, 517);
            this.DGVEmployee.TabIndex = 3;
            this.DGVEmployee.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVEmployee_CellClick);
            // 
            // btnAddNewEmployee
            // 
            this.btnAddNewEmployee.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNewEmployee.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.btnAddNewEmployee.BorderRadius = 4;
            this.btnAddNewEmployee.BorderThickness = 1;
            this.btnAddNewEmployee.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewEmployee.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewEmployee.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewEmployee.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewEmployee.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.btnAddNewEmployee.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnAddNewEmployee.ForeColor = System.Drawing.Color.White;
            this.btnAddNewEmployee.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(194)))), ((int)(((byte)(155)))));
            this.btnAddNewEmployee.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(194)))), ((int)(((byte)(155)))));
            this.btnAddNewEmployee.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.btnAddNewEmployee.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddNewEmployee.ImageSize = new System.Drawing.Size(32, 32);
            this.btnAddNewEmployee.Location = new System.Drawing.Point(469, 226);
            this.btnAddNewEmployee.Margin = new System.Windows.Forms.Padding(5);
            this.btnAddNewEmployee.Name = "btnAddNewEmployee";
            this.btnAddNewEmployee.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btnAddNewEmployee.PressedColor = System.Drawing.Color.Green;
            this.btnAddNewEmployee.ShadowDecoration.BorderRadius = 20;
            this.btnAddNewEmployee.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.btnAddNewEmployee.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.btnAddNewEmployee.Size = new System.Drawing.Size(155, 42);
            this.btnAddNewEmployee.TabIndex = 29;
            this.btnAddNewEmployee.Text = "ADD NEW";
            this.btnAddNewEmployee.Click += new System.EventHandler(this.btnAddNewEmployee_Click_1);
            // 
            // cboSort
            // 
            this.cboSort.BackColor = System.Drawing.Color.Transparent;
            this.cboSort.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSort.BorderRadius = 4;
            this.cboSort.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSort.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSort.Font = new System.Drawing.Font("Arial", 8.5F, System.Drawing.FontStyle.Bold);
            this.cboSort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cboSort.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSort.ItemHeight = 35;
            this.cboSort.Items.AddRange(new object[] {
            "Sort By"});
            this.cboSort.Location = new System.Drawing.Point(77, 227);
            this.cboSort.Name = "cboSort";
            this.cboSort.ShadowDecoration.BorderRadius = 4;
            this.cboSort.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.cboSort.ShadowDecoration.Enabled = true;
            this.cboSort.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.cboSort.Size = new System.Drawing.Size(211, 41);
            this.cboSort.TabIndex = 45;
            // 
            // txtSearch
            // 
            this.txtSearch.AutoSize = true;
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSearch.BorderRadius = 4;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSearch.Location = new System.Drawing.Point(303, 106);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.LightGray;
            this.txtSearch.PlaceholderText = "Enter Search Criteria";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.BorderRadius = 4;
            this.txtSearch.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.txtSearch.ShadowDecoration.Enabled = true;
            this.txtSearch.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.txtSearch.Size = new System.Drawing.Size(321, 41);
            this.txtSearch.TabIndex = 41;
            // 
            // iconSort
            // 
            this.iconSort.BackColor = System.Drawing.Color.White;
            this.iconSort.FlatAppearance.BorderSize = 0;
            this.iconSort.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconSort.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconSort.IconChar = FontAwesome.Sharp.IconChar.Unsorted;
            this.iconSort.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.iconSort.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSort.IconSize = 33;
            this.iconSort.Location = new System.Drawing.Point(27, 226);
            this.iconSort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.iconSort.Name = "iconSort";
            this.iconSort.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.iconSort.Size = new System.Drawing.Size(42, 42);
            this.iconSort.TabIndex = 47;
            this.iconSort.UseVisualStyleBackColor = false;
            // 
            // iconSearch
            // 
            this.iconSearch.BackColor = System.Drawing.Color.White;
            this.iconSearch.FlatAppearance.BorderSize = 0;
            this.iconSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconSearch.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.iconSearch.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.iconSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconSearch.IconSize = 38;
            this.iconSearch.Location = new System.Drawing.Point(27, 106);
            this.iconSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.iconSearch.Name = "iconSearch";
            this.iconSearch.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.iconSearch.Size = new System.Drawing.Size(42, 41);
            this.iconSearch.TabIndex = 42;
            this.iconSearch.UseVisualStyleBackColor = false;
            // 
            // iconFilter
            // 
            this.iconFilter.BackColor = System.Drawing.Color.White;
            this.iconFilter.FlatAppearance.BorderSize = 0;
            this.iconFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconFilter.IconChar = FontAwesome.Sharp.IconChar.Filter;
            this.iconFilter.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.iconFilter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconFilter.IconSize = 33;
            this.iconFilter.Location = new System.Drawing.Point(27, 166);
            this.iconFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.iconFilter.Name = "iconFilter";
            this.iconFilter.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.iconFilter.Size = new System.Drawing.Size(42, 42);
            this.iconFilter.TabIndex = 46;
            this.iconFilter.UseVisualStyleBackColor = false;
            // 
            // cboFilter
            // 
            this.cboFilter.BackColor = System.Drawing.Color.Transparent;
            this.cboFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboFilter.BorderRadius = 4;
            this.cboFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboFilter.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.cboFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cboFilter.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboFilter.ItemHeight = 35;
            this.cboFilter.Items.AddRange(new object[] {
            "Filter By"});
            this.cboFilter.Location = new System.Drawing.Point(77, 167);
            this.cboFilter.Name = "cboFilter";
            this.cboFilter.ShadowDecoration.BorderRadius = 4;
            this.cboFilter.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.cboFilter.ShadowDecoration.Enabled = true;
            this.cboFilter.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.cboFilter.Size = new System.Drawing.Size(211, 41);
            this.cboFilter.TabIndex = 44;
            // 
            // cboSearch
            // 
            this.cboSearch.BackColor = System.Drawing.Color.Transparent;
            this.cboSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSearch.BorderRadius = 4;
            this.cboSearch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearch.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.cboSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cboSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboSearch.ItemHeight = 35;
            this.cboSearch.Items.AddRange(new object[] {
            "Search By"});
            this.cboSearch.Location = new System.Drawing.Point(77, 106);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.ShadowDecoration.BorderRadius = 4;
            this.cboSearch.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.cboSearch.ShadowDecoration.Enabled = true;
            this.cboSearch.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.cboSearch.Size = new System.Drawing.Size(211, 41);
            this.cboSearch.TabIndex = 48;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.guna2Button1.BorderRadius = 5;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.guna2Button1.Font = new System.Drawing.Font("Cooper Black", 14F);
            this.guna2Button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.guna2Button1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.ImageSize = new System.Drawing.Size(32, 32);
            this.guna2Button1.Location = new System.Drawing.Point(27, 20);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.guna2Button1.PressedColor = System.Drawing.Color.White;
            this.guna2Button1.ShadowDecoration.BorderRadius = 5;
            this.guna2Button1.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.guna2Button1.ShadowDecoration.Enabled = true;
            this.guna2Button1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.guna2Button1.Size = new System.Drawing.Size(597, 52);
            this.guna2Button1.TabIndex = 50;
            this.guna2Button1.Text = "Employee List";
            // 
            // Column1
            // 
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
            this.Column2.HeaderText = "Name";
            this.Column2.MinimumWidth = 8;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.Width = 210;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "emp_id";
            this.Column3.HeaderText = "ID";
            this.Column3.MinimumWidth = 8;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 126;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "agent_code";
            this.Column4.HeaderText = "Agent Code";
            this.Column4.MinimumWidth = 8;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 208;
            // 
            // panelEmployeeProfile
            // 
            this.panelEmployeeProfile.BackColor = System.Drawing.Color.Transparent;
            this.panelEmployeeProfile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.panelEmployeeProfile.BorderRadius = 15;
            this.panelEmployeeProfile.Controls.Add(this.guna2Button2);
            this.panelEmployeeProfile.FillColor = System.Drawing.Color.White;
            this.panelEmployeeProfile.Location = new System.Drawing.Point(708, 39);
            this.panelEmployeeProfile.Name = "panelEmployeeProfile";
            this.panelEmployeeProfile.ShadowDecoration.BorderRadius = 15;
            this.panelEmployeeProfile.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.panelEmployeeProfile.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.panelEmployeeProfile.Size = new System.Drawing.Size(873, 826);
            this.panelEmployeeProfile.TabIndex = 51;
            this.panelEmployeeProfile.Visible = false;
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.guna2Button2.BorderRadius = 5;
            this.guna2Button2.BorderThickness = 1;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.White;
            this.guna2Button2.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.guna2Button2.Font = new System.Drawing.Font("Cooper Black", 14F);
            this.guna2Button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.guna2Button2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.guna2Button2.HoverState.FillColor = System.Drawing.Color.White;
            this.guna2Button2.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.guna2Button2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button2.ImageSize = new System.Drawing.Size(32, 32);
            this.guna2Button2.Location = new System.Drawing.Point(25, 20);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.guna2Button2.PressedColor = System.Drawing.Color.White;
            this.guna2Button2.ShadowDecoration.BorderRadius = 5;
            this.guna2Button2.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.guna2Button2.ShadowDecoration.Enabled = true;
            this.guna2Button2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3);
            this.guna2Button2.Size = new System.Drawing.Size(822, 52);
            this.guna2Button2.TabIndex = 50;
            this.guna2Button2.Text = "Employee Profile";
            // 
            // FormEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(1609, 977);
            this.Controls.Add(this.panelEmployeeProfile);
            this.Controls.Add(this.panelEmployeeList);
            this.Name = "FormEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Management";
            this.Load += new System.EventHandler(this.FormEmployee_Load);
            this.panelEmployeeList.ResumeLayout(false);
            this.panelEmployeeList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVEmployee)).EndInit();
            this.panelEmployeeProfile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelEmployeeList;
        private System.Windows.Forms.DataGridView DGVEmployee;
        private Guna.UI2.WinForms.Guna2Button btnAddNewEmployee;
        private Guna.UI2.WinForms.Guna2ComboBox cboSort;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private FontAwesome.Sharp.IconButton iconSort;
        private FontAwesome.Sharp.IconButton iconSearch;
        private FontAwesome.Sharp.IconButton iconFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cboFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cboSearch;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private Guna.UI2.WinForms.Guna2Panel panelEmployeeProfile;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
    }
}