namespace GUTZ_Capstone_Project.Forms
{
    partial class FormAddNewEmployee
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmployeeJobDesc = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmployeeFirstName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmployeeLastName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEmployeeMiddleIName = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboEmployeeDept = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmployeeAge = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmployeeContactNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmployeeEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbFemale = new System.Windows.Forms.RadioButton();
            this.rdbMale = new System.Windows.Forms.RadioButton();
            this.dtpEmployeeDateOfBirth = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnUploadImage = new Guna.UI2.WinForms.Guna2Button();
            this.employeeProfilePicture = new Guna.UI2.WinForms.Guna2PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtEmployeeBrgyAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboEmployeeCityMunicipality = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtpEmployeeHiredDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.progressPecentageStatus = new System.Windows.Forms.Label();
            this.btnStartScan = new Guna.UI2.WinForms.Guna2Button();
            this.lblSampleNeededStatus = new System.Windows.Forms.Label();
            this.txtCaptureStatusLog = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtScannerPrompt = new Guna.UI2.WinForms.Guna2TextBox();
            this.scanningProgressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.employeeFingerprintImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnSaveEmployeeDetails = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnResetInputFields = new Guna.UI2.WinForms.Guna2Button();
            this.lblFormLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeProfilePicture)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeFingerprintImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 26);
            this.label1.TabIndex = 27;
            this.label1.Text = "Firstname:";
            // 
            // txtEmployeeJobDesc
            // 
            this.txtEmployeeJobDesc.BackColor = System.Drawing.Color.Transparent;
            this.txtEmployeeJobDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtEmployeeJobDesc.BorderRadius = 4;
            this.txtEmployeeJobDesc.BorderThickness = 0;
            this.txtEmployeeJobDesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeJobDesc.DefaultText = "";
            this.txtEmployeeJobDesc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeJobDesc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeJobDesc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeJobDesc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeJobDesc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeJobDesc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtEmployeeJobDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtEmployeeJobDesc.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeJobDesc.Location = new System.Drawing.Point(137, 185);
            this.txtEmployeeJobDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmployeeJobDesc.Name = "txtEmployeeJobDesc";
            this.txtEmployeeJobDesc.PasswordChar = '\0';
            this.txtEmployeeJobDesc.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtEmployeeJobDesc.PlaceholderText = "";
            this.txtEmployeeJobDesc.ReadOnly = true;
            this.txtEmployeeJobDesc.SelectedText = "";
            this.txtEmployeeJobDesc.Size = new System.Drawing.Size(310, 34);
            this.txtEmployeeJobDesc.TabIndex = 52;
            // 
            // txtEmployeeFirstName
            // 
            this.txtEmployeeFirstName.BackColor = System.Drawing.Color.Transparent;
            this.txtEmployeeFirstName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtEmployeeFirstName.BorderRadius = 4;
            this.txtEmployeeFirstName.BorderThickness = 0;
            this.txtEmployeeFirstName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeFirstName.DefaultText = "";
            this.txtEmployeeFirstName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeFirstName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeFirstName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeFirstName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeFirstName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeFirstName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtEmployeeFirstName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeFirstName.Location = new System.Drawing.Point(137, 40);
            this.txtEmployeeFirstName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmployeeFirstName.Name = "txtEmployeeFirstName";
            this.txtEmployeeFirstName.PasswordChar = '\0';
            this.txtEmployeeFirstName.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtEmployeeFirstName.PlaceholderText = "";
            this.txtEmployeeFirstName.SelectedText = "";
            this.txtEmployeeFirstName.Size = new System.Drawing.Size(310, 34);
            this.txtEmployeeFirstName.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(35, 194);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 26);
            this.label13.TabIndex = 51;
            this.label13.Text = "Job Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 26);
            this.label2.TabIndex = 29;
            this.label2.Text = "Lastname:";
            // 
            // txtEmployeeLastName
            // 
            this.txtEmployeeLastName.BackColor = System.Drawing.Color.Transparent;
            this.txtEmployeeLastName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtEmployeeLastName.BorderRadius = 4;
            this.txtEmployeeLastName.BorderThickness = 0;
            this.txtEmployeeLastName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeLastName.DefaultText = "";
            this.txtEmployeeLastName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeLastName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeLastName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeLastName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeLastName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeLastName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtEmployeeLastName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeLastName.Location = new System.Drawing.Point(137, 100);
            this.txtEmployeeLastName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmployeeLastName.Name = "txtEmployeeLastName";
            this.txtEmployeeLastName.PasswordChar = '\0';
            this.txtEmployeeLastName.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtEmployeeLastName.PlaceholderText = "";
            this.txtEmployeeLastName.SelectedText = "";
            this.txtEmployeeLastName.Size = new System.Drawing.Size(310, 34);
            this.txtEmployeeLastName.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(69, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 26);
            this.label3.TabIndex = 31;
            this.label3.Text = "M. N.:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(514, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 26);
            this.label11.TabIndex = 47;
            this.label11.Text = "Date of Birth:";
            // 
            // txtEmployeeMiddleIName
            // 
            this.txtEmployeeMiddleIName.BackColor = System.Drawing.Color.Transparent;
            this.txtEmployeeMiddleIName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtEmployeeMiddleIName.BorderRadius = 4;
            this.txtEmployeeMiddleIName.BorderThickness = 0;
            this.txtEmployeeMiddleIName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeMiddleIName.DefaultText = "";
            this.txtEmployeeMiddleIName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeMiddleIName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeMiddleIName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeMiddleIName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeMiddleIName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeMiddleIName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeMiddleIName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtEmployeeMiddleIName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeMiddleIName.Location = new System.Drawing.Point(137, 160);
            this.txtEmployeeMiddleIName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmployeeMiddleIName.Name = "txtEmployeeMiddleIName";
            this.txtEmployeeMiddleIName.PasswordChar = '\0';
            this.txtEmployeeMiddleIName.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtEmployeeMiddleIName.PlaceholderText = "";
            this.txtEmployeeMiddleIName.SelectedText = "";
            this.txtEmployeeMiddleIName.Size = new System.Drawing.Size(310, 34);
            this.txtEmployeeMiddleIName.TabIndex = 32;
            // 
            // cboEmployeeDept
            // 
            this.cboEmployeeDept.BackColor = System.Drawing.Color.Transparent;
            this.cboEmployeeDept.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.cboEmployeeDept.BorderRadius = 4;
            this.cboEmployeeDept.BorderThickness = 0;
            this.cboEmployeeDept.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEmployeeDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmployeeDept.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboEmployeeDept.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboEmployeeDept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboEmployeeDept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.cboEmployeeDept.ItemHeight = 30;
            this.cboEmployeeDept.Items.AddRange(new object[] {
            "BPO Department",
            "ESL Department"});
            this.cboEmployeeDept.Location = new System.Drawing.Point(137, 124);
            this.cboEmployeeDept.Name = "cboEmployeeDept";
            this.cboEmployeeDept.Size = new System.Drawing.Size(310, 36);
            this.cboEmployeeDept.TabIndex = 46;
            this.cboEmployeeDept.SelectedIndexChanged += new System.EventHandler(this.cboEmployeeDept_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(587, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 26);
            this.label4.TabIndex = 33;
            this.label4.Text = "Age:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(64, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 26);
            this.label10.TabIndex = 45;
            this.label10.Text = "Dept.:";
            // 
            // txtEmployeeAge
            // 
            this.txtEmployeeAge.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtEmployeeAge.BorderRadius = 4;
            this.txtEmployeeAge.BorderThickness = 0;
            this.txtEmployeeAge.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeAge.DefaultText = "";
            this.txtEmployeeAge.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeAge.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeAge.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeAge.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeAge.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeAge.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeAge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtEmployeeAge.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeAge.Location = new System.Drawing.Point(646, 98);
            this.txtEmployeeAge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmployeeAge.Name = "txtEmployeeAge";
            this.txtEmployeeAge.PasswordChar = '\0';
            this.txtEmployeeAge.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtEmployeeAge.PlaceholderText = "";
            this.txtEmployeeAge.SelectedText = "";
            this.txtEmployeeAge.Size = new System.Drawing.Size(89, 36);
            this.txtEmployeeAge.TabIndex = 34;
            this.txtEmployeeAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(51, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 26);
            this.label5.TabIndex = 35;
            this.label5.Text = "Gender:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(19, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 26);
            this.label9.TabIndex = 43;
            this.label9.Text = "Hired Date:";
            // 
            // txtEmployeeContactNumber
            // 
            this.txtEmployeeContactNumber.BackColor = System.Drawing.Color.Transparent;
            this.txtEmployeeContactNumber.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtEmployeeContactNumber.BorderRadius = 4;
            this.txtEmployeeContactNumber.BorderThickness = 0;
            this.txtEmployeeContactNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeContactNumber.DefaultText = "";
            this.txtEmployeeContactNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeContactNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeContactNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeContactNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeContactNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeContactNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeContactNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtEmployeeContactNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeContactNumber.Location = new System.Drawing.Point(646, 158);
            this.txtEmployeeContactNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmployeeContactNumber.Name = "txtEmployeeContactNumber";
            this.txtEmployeeContactNumber.PasswordChar = '\0';
            this.txtEmployeeContactNumber.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtEmployeeContactNumber.PlaceholderText = "";
            this.txtEmployeeContactNumber.SelectedText = "";
            this.txtEmployeeContactNumber.Size = new System.Drawing.Size(310, 34);
            this.txtEmployeeContactNumber.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(539, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 26);
            this.label8.TabIndex = 41;
            this.label8.Text = "Contact #:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(572, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 26);
            this.label7.TabIndex = 39;
            this.label7.Text = "Email:";
            // 
            // txtEmployeeEmail
            // 
            this.txtEmployeeEmail.BackColor = System.Drawing.Color.Transparent;
            this.txtEmployeeEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtEmployeeEmail.BorderRadius = 4;
            this.txtEmployeeEmail.BorderThickness = 0;
            this.txtEmployeeEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeEmail.DefaultText = "";
            this.txtEmployeeEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtEmployeeEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtEmployeeEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeEmail.Location = new System.Drawing.Point(645, 216);
            this.txtEmployeeEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmployeeEmail.Name = "txtEmployeeEmail";
            this.txtEmployeeEmail.PasswordChar = '\0';
            this.txtEmployeeEmail.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtEmployeeEmail.PlaceholderText = "";
            this.txtEmployeeEmail.SelectedText = "";
            this.txtEmployeeEmail.Size = new System.Drawing.Size(310, 34);
            this.txtEmployeeEmail.TabIndex = 40;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbFemale);
            this.groupBox1.Controls.Add(this.rdbMale);
            this.groupBox1.Controls.Add(this.dtpEmployeeDateOfBirth);
            this.groupBox1.Controls.Add(this.btnUploadImage);
            this.groupBox1.Controls.Add(this.employeeProfilePicture);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEmployeeContactNumber);
            this.groupBox1.Controls.Add(this.txtEmployeeEmail);
            this.groupBox1.Controls.Add(this.txtEmployeeFirstName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtEmployeeLastName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEmployeeMiddleIName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtEmployeeAge);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(26, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1241, 277);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Details";
            // 
            // rdbFemale
            // 
            this.rdbFemale.AutoSize = true;
            this.rdbFemale.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbFemale.Location = new System.Drawing.Point(252, 222);
            this.rdbFemale.Name = "rdbFemale";
            this.rdbFemale.Size = new System.Drawing.Size(102, 32);
            this.rdbFemale.TabIndex = 58;
            this.rdbFemale.TabStop = true;
            this.rdbFemale.Text = "Female";
            this.rdbFemale.UseVisualStyleBackColor = true;
            // 
            // rdbMale
            // 
            this.rdbMale.AutoSize = true;
            this.rdbMale.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMale.Location = new System.Drawing.Point(137, 222);
            this.rdbMale.Name = "rdbMale";
            this.rdbMale.Size = new System.Drawing.Size(81, 32);
            this.rdbMale.TabIndex = 57;
            this.rdbMale.TabStop = true;
            this.rdbMale.Text = "Male";
            this.rdbMale.UseVisualStyleBackColor = true;
            // 
            // dtpEmployeeDateOfBirth
            // 
            this.dtpEmployeeDateOfBirth.BackColor = System.Drawing.Color.Transparent;
            this.dtpEmployeeDateOfBirth.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.dtpEmployeeDateOfBirth.BorderRadius = 4;
            this.dtpEmployeeDateOfBirth.Checked = true;
            this.dtpEmployeeDateOfBirth.FillColor = System.Drawing.Color.White;
            this.dtpEmployeeDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEmployeeDateOfBirth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.dtpEmployeeDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpEmployeeDateOfBirth.Location = new System.Drawing.Point(646, 40);
            this.dtpEmployeeDateOfBirth.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEmployeeDateOfBirth.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEmployeeDateOfBirth.Name = "dtpEmployeeDateOfBirth";
            this.dtpEmployeeDateOfBirth.Size = new System.Drawing.Size(310, 34);
            this.dtpEmployeeDateOfBirth.TabIndex = 53;
            this.dtpEmployeeDateOfBirth.Value = new System.DateTime(2024, 8, 11, 10, 3, 30, 841);
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.AutoRoundedCorners = true;
            this.btnUploadImage.BackColor = System.Drawing.Color.Transparent;
            this.btnUploadImage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.btnUploadImage.BorderRadius = 17;
            this.btnUploadImage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUploadImage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUploadImage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUploadImage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUploadImage.FillColor = System.Drawing.Color.White;
            this.btnUploadImage.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.btnUploadImage.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.btnUploadImage.Location = new System.Drawing.Point(1031, 218);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.btnUploadImage.Size = new System.Drawing.Size(183, 37);
            this.btnUploadImage.TabIndex = 56;
            this.btnUploadImage.Text = "Choose Image";
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // employeeProfilePicture
            // 
            this.employeeProfilePicture.BorderRadius = 5;
            this.employeeProfilePicture.ImageRotate = 0F;
            this.employeeProfilePicture.Location = new System.Drawing.Point(1031, 27);
            this.employeeProfilePicture.Name = "employeeProfilePicture";
            this.employeeProfilePicture.Size = new System.Drawing.Size(183, 176);
            this.employeeProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.employeeProfilePicture.TabIndex = 49;
            this.employeeProfilePicture.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtEmployeeBrgyAddress);
            this.groupBox2.Controls.Add(this.cboEmployeeCityMunicipality);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(26, 361);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(557, 146);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Employee Address";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(66, 97);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 26);
            this.label17.TabIndex = 59;
            this.label17.Text = "Brgy.:";
            // 
            // txtEmployeeBrgyAddress
            // 
            this.txtEmployeeBrgyAddress.AutoCompleteCustomSource.AddRange(new string[] {
            "Abuyog",
            "Almendras-Cogon",
            "Balete",
            "Balogo (Bacon District)",
            "Balogo (Sorsogon East District)",
            "Barayong",
            "Basud",
            "Bato",
            "Bibincahan",
            "Bitan-o/Dalipay",
            "Bogña",
            "Bon-ot",
            "Bucalbucalan",
            "Buenavista",
            "Buenavista (Bacon District)",
            "Buhatan",
            "Bulabog",
            "Burabod",
            "Cabarbuhan",
            "Cabid-an",
            "Cambulaga",
            "Capuy",
            "Caricaran",
            "Del Rosario",
            "Gatbo",
            "Gimaloto",
            "Guinlajon",
            "Jamislagan",
            "Macabog",
            "Maricrum",
            "Marinas",
            "Osiao",
            "Pamurayan",
            "Pangpang",
            "Panlayaan",
            "Peñafrancia",
            "Piot",
            "Poblacion",
            "Polvorista",
            "Rawis",
            "Rizal",
            "Salog",
            "Salvacion",
            "Salvacion (Bacon District)",
            "Sampaloc",
            "San Isidro",
            "San Isidro (Bacon District)",
            "San Juan (Bacon District)",
            "San Juan (Roro)",
            "San Pascual",
            "San Ramon",
            "San Roque",
            "San Vicente",
            "Santa Cruz",
            "Santa Lucia",
            "Santo Domingo",
            "Santo Niño",
            "Sawanga",
            "Sirangan",
            "Sugod",
            "Sulucan",
            "Talisay",
            "Ticol",
            "Tugos"});
            this.txtEmployeeBrgyAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtEmployeeBrgyAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtEmployeeBrgyAddress.BackColor = System.Drawing.Color.Transparent;
            this.txtEmployeeBrgyAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtEmployeeBrgyAddress.BorderRadius = 4;
            this.txtEmployeeBrgyAddress.BorderThickness = 0;
            this.txtEmployeeBrgyAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeBrgyAddress.DefaultText = "";
            this.txtEmployeeBrgyAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeBrgyAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeBrgyAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeBrgyAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeBrgyAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeBrgyAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtEmployeeBrgyAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtEmployeeBrgyAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeBrgyAddress.Location = new System.Drawing.Point(137, 89);
            this.txtEmployeeBrgyAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmployeeBrgyAddress.Name = "txtEmployeeBrgyAddress";
            this.txtEmployeeBrgyAddress.PasswordChar = '\0';
            this.txtEmployeeBrgyAddress.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtEmployeeBrgyAddress.PlaceholderText = "";
            this.txtEmployeeBrgyAddress.SelectedText = "";
            this.txtEmployeeBrgyAddress.Size = new System.Drawing.Size(310, 34);
            this.txtEmployeeBrgyAddress.TabIndex = 58;
            // 
            // cboEmployeeCityMunicipality
            // 
            this.cboEmployeeCityMunicipality.BackColor = System.Drawing.Color.Transparent;
            this.cboEmployeeCityMunicipality.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.cboEmployeeCityMunicipality.BorderRadius = 4;
            this.cboEmployeeCityMunicipality.BorderThickness = 0;
            this.cboEmployeeCityMunicipality.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEmployeeCityMunicipality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmployeeCityMunicipality.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboEmployeeCityMunicipality.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboEmployeeCityMunicipality.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboEmployeeCityMunicipality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.cboEmployeeCityMunicipality.ItemHeight = 30;
            this.cboEmployeeCityMunicipality.Items.AddRange(new object[] {
            "Sorsogon City",
            "Barcelona",
            "Bulan",
            "Bulusan",
            "Casiguran",
            "Castilla",
            "Donsol",
            "Gubat",
            "Irosin",
            "Juban",
            "Magallanes",
            "Matnog",
            "Pilar",
            "Prieto Diaz",
            "Santa Magdalena"});
            this.cboEmployeeCityMunicipality.Location = new System.Drawing.Point(137, 36);
            this.cboEmployeeCityMunicipality.Name = "cboEmployeeCityMunicipality";
            this.cboEmployeeCityMunicipality.Size = new System.Drawing.Size(310, 36);
            this.cboEmployeeCityMunicipality.TabIndex = 57;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(28, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 26);
            this.label16.TabIndex = 39;
            this.label16.Text = "Cty./Mun.:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtpEmployeeHiredDate);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtEmployeeJobDesc);
            this.groupBox3.Controls.Add(this.cboEmployeeDept);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(26, 536);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(557, 322);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Job Description";
            // 
            // dtpEmployeeHiredDate
            // 
            this.dtpEmployeeHiredDate.BackColor = System.Drawing.Color.Transparent;
            this.dtpEmployeeHiredDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.dtpEmployeeHiredDate.BorderRadius = 4;
            this.dtpEmployeeHiredDate.Checked = true;
            this.dtpEmployeeHiredDate.FillColor = System.Drawing.Color.White;
            this.dtpEmployeeHiredDate.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEmployeeHiredDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.dtpEmployeeHiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpEmployeeHiredDate.Location = new System.Drawing.Point(137, 64);
            this.dtpEmployeeHiredDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEmployeeHiredDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEmployeeHiredDate.Name = "dtpEmployeeHiredDate";
            this.dtpEmployeeHiredDate.Size = new System.Drawing.Size(310, 34);
            this.dtpEmployeeHiredDate.TabIndex = 57;
            this.dtpEmployeeHiredDate.Value = new System.DateTime(2024, 8, 11, 10, 3, 30, 841);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.progressPecentageStatus);
            this.groupBox4.Controls.Add(this.btnStartScan);
            this.groupBox4.Controls.Add(this.lblSampleNeededStatus);
            this.groupBox4.Controls.Add(this.txtCaptureStatusLog);
            this.groupBox4.Controls.Add(this.txtScannerPrompt);
            this.groupBox4.Controls.Add(this.scanningProgressBar);
            this.groupBox4.Controls.Add(this.employeeFingerprintImage);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(632, 361);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(635, 497);
            this.groupBox4.TabIndex = 55;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Biometrics Capturing and Enrollment";
            // 
            // progressPecentageStatus
            // 
            this.progressPecentageStatus.AutoSize = true;
            this.progressPecentageStatus.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressPecentageStatus.ForeColor = System.Drawing.Color.White;
            this.progressPecentageStatus.Location = new System.Drawing.Point(574, 360);
            this.progressPecentageStatus.Name = "progressPecentageStatus";
            this.progressPecentageStatus.Size = new System.Drawing.Size(20, 24);
            this.progressPecentageStatus.TabIndex = 60;
            this.progressPecentageStatus.Text = "[]";
            // 
            // btnStartScan
            // 
            this.btnStartScan.AutoRoundedCorners = true;
            this.btnStartScan.BackColor = System.Drawing.Color.Transparent;
            this.btnStartScan.BorderColor = System.Drawing.Color.White;
            this.btnStartScan.BorderRadius = 17;
            this.btnStartScan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStartScan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStartScan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStartScan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStartScan.FillColor = System.Drawing.Color.White;
            this.btnStartScan.Font = new System.Drawing.Font("Malgun Gothic", 8F, System.Drawing.FontStyle.Bold);
            this.btnStartScan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.btnStartScan.Location = new System.Drawing.Point(476, 434);
            this.btnStartScan.Name = "btnStartScan";
            this.btnStartScan.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.btnStartScan.Size = new System.Drawing.Size(132, 37);
            this.btnStartScan.TabIndex = 57;
            this.btnStartScan.Text = "Start Scan";
            this.btnStartScan.Click += new System.EventHandler(this.btnStartScan_Click);
            // 
            // lblSampleNeededStatus
            // 
            this.lblSampleNeededStatus.AutoSize = true;
            this.lblSampleNeededStatus.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSampleNeededStatus.ForeColor = System.Drawing.Color.White;
            this.lblSampleNeededStatus.Location = new System.Drawing.Point(39, 360);
            this.lblSampleNeededStatus.Name = "lblSampleNeededStatus";
            this.lblSampleNeededStatus.Size = new System.Drawing.Size(232, 24);
            this.lblSampleNeededStatus.TabIndex = 59;
            this.lblSampleNeededStatus.Text = "[SAMPLE NEEDED STATUS]";
            // 
            // txtCaptureStatusLog
            // 
            this.txtCaptureStatusLog.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtCaptureStatusLog.BorderRadius = 4;
            this.txtCaptureStatusLog.BorderThickness = 0;
            this.txtCaptureStatusLog.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCaptureStatusLog.DefaultText = "";
            this.txtCaptureStatusLog.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCaptureStatusLog.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCaptureStatusLog.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCaptureStatusLog.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCaptureStatusLog.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCaptureStatusLog.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaptureStatusLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtCaptureStatusLog.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCaptureStatusLog.Location = new System.Drawing.Point(278, 90);
            this.txtCaptureStatusLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCaptureStatusLog.Multiline = true;
            this.txtCaptureStatusLog.Name = "txtCaptureStatusLog";
            this.txtCaptureStatusLog.PasswordChar = '\0';
            this.txtCaptureStatusLog.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtCaptureStatusLog.PlaceholderText = "";
            this.txtCaptureStatusLog.SelectedText = "";
            this.txtCaptureStatusLog.Size = new System.Drawing.Size(330, 256);
            this.txtCaptureStatusLog.TabIndex = 43;
            // 
            // txtScannerPrompt
            // 
            this.txtScannerPrompt.BackColor = System.Drawing.Color.Transparent;
            this.txtScannerPrompt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtScannerPrompt.BorderRadius = 4;
            this.txtScannerPrompt.BorderThickness = 0;
            this.txtScannerPrompt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtScannerPrompt.DefaultText = "";
            this.txtScannerPrompt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtScannerPrompt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtScannerPrompt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtScannerPrompt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtScannerPrompt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtScannerPrompt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtScannerPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.txtScannerPrompt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtScannerPrompt.Location = new System.Drawing.Point(40, 31);
            this.txtScannerPrompt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtScannerPrompt.Name = "txtScannerPrompt";
            this.txtScannerPrompt.PasswordChar = '\0';
            this.txtScannerPrompt.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtScannerPrompt.PlaceholderText = "";
            this.txtScannerPrompt.SelectedText = "";
            this.txtScannerPrompt.Size = new System.Drawing.Size(568, 34);
            this.txtScannerPrompt.TabIndex = 43;
            // 
            // scanningProgressBar
            // 
            this.scanningProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.scanningProgressBar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.scanningProgressBar.BorderRadius = 4;
            this.scanningProgressBar.FillColor = System.Drawing.Color.White;
            this.scanningProgressBar.Location = new System.Drawing.Point(43, 394);
            this.scanningProgressBar.Name = "scanningProgressBar";
            this.scanningProgressBar.ProgressColor = System.Drawing.Color.LawnGreen;
            this.scanningProgressBar.ProgressColor2 = System.Drawing.Color.Chartreuse;
            this.scanningProgressBar.Size = new System.Drawing.Size(565, 22);
            this.scanningProgressBar.TabIndex = 58;
            this.scanningProgressBar.Text = "guna2ProgressBar1";
            this.scanningProgressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // employeeFingerprintImage
            // 
            this.employeeFingerprintImage.BorderRadius = 4;
            this.employeeFingerprintImage.ImageRotate = 0F;
            this.employeeFingerprintImage.Location = new System.Drawing.Point(40, 89);
            this.employeeFingerprintImage.Name = "employeeFingerprintImage";
            this.employeeFingerprintImage.Size = new System.Drawing.Size(231, 257);
            this.employeeFingerprintImage.TabIndex = 57;
            this.employeeFingerprintImage.TabStop = false;
            // 
            // btnSaveEmployeeDetails
            // 
            this.btnSaveEmployeeDetails.AutoRoundedCorners = true;
            this.btnSaveEmployeeDetails.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveEmployeeDetails.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.btnSaveEmployeeDetails.BorderRadius = 21;
            this.btnSaveEmployeeDetails.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveEmployeeDetails.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveEmployeeDetails.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveEmployeeDetails.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveEmployeeDetails.FillColor = System.Drawing.Color.White;
            this.btnSaveEmployeeDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEmployeeDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.btnSaveEmployeeDetails.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.btnSaveEmployeeDetails.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSaveEmployeeDetails.Location = new System.Drawing.Point(24, 878);
            this.btnSaveEmployeeDetails.Name = "btnSaveEmployeeDetails";
            this.btnSaveEmployeeDetails.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.btnSaveEmployeeDetails.Size = new System.Drawing.Size(132, 45);
            this.btnSaveEmployeeDetails.TabIndex = 57;
            this.btnSaveEmployeeDetails.Text = "Save";
            this.btnSaveEmployeeDetails.Click += new System.EventHandler(this.btnSaveEmployeeDetails_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoRoundedCorners = true;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.btnCancel.BorderRadius = 21;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.btnCancel.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(1135, 878);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.btnCancel.Size = new System.Drawing.Size(132, 45);
            this.btnCancel.TabIndex = 58;
            this.btnCancel.Text = "Close";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnResetInputFields
            // 
            this.btnResetInputFields.AutoRoundedCorners = true;
            this.btnResetInputFields.BackColor = System.Drawing.Color.Transparent;
            this.btnResetInputFields.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.btnResetInputFields.BorderRadius = 21;
            this.btnResetInputFields.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnResetInputFields.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnResetInputFields.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnResetInputFields.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnResetInputFields.FillColor = System.Drawing.Color.White;
            this.btnResetInputFields.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetInputFields.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.btnResetInputFields.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(90)))), ((int)(((byte)(37)))));
            this.btnResetInputFields.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnResetInputFields.Location = new System.Drawing.Point(632, 878);
            this.btnResetInputFields.Name = "btnResetInputFields";
            this.btnResetInputFields.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.btnResetInputFields.Size = new System.Drawing.Size(132, 45);
            this.btnResetInputFields.TabIndex = 59;
            this.btnResetInputFields.Text = "Reset";
            this.btnResetInputFields.Click += new System.EventHandler(this.btnResetInputFields_Click);
            // 
            // lblFormLabel
            // 
            this.lblFormLabel.AutoSize = true;
            this.lblFormLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormLabel.ForeColor = System.Drawing.Color.White;
            this.lblFormLabel.Location = new System.Drawing.Point(19, 9);
            this.lblFormLabel.Name = "lblFormLabel";
            this.lblFormLabel.Size = new System.Drawing.Size(268, 38);
            this.lblFormLabel.TabIndex = 53;
            this.lblFormLabel.Text = "Add New Employee";
            // 
            // FormAddNewEmployee
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(1297, 950);
            this.Controls.Add(this.lblFormLabel);
            this.Controls.Add(this.btnResetInputFields);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveEmployeeDetails);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAddNewEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Employee Enrollment Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEmployeeEnrollment_FormClosing);
            this.Load += new System.EventHandler(this.FormEmployeeEnrollment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeProfilePicture)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeFingerprintImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtEmployeeJobDesc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtEmployeeLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2TextBox txtEmployeeMiddleIName;
        private Guna.UI2.WinForms.Guna2ComboBox cboEmployeeDept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox txtEmployeeAge;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txtEmployeeContactNumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txtEmployeeEmail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private Guna.UI2.WinForms.Guna2PictureBox employeeProfilePicture;
        private Guna.UI2.WinForms.Guna2Button btnUploadImage;
        private System.Windows.Forms.GroupBox groupBox4;
        private Guna.UI2.WinForms.Guna2ProgressBar scanningProgressBar;
        private Guna.UI2.WinForms.Guna2PictureBox employeeFingerprintImage;
        private Guna.UI2.WinForms.Guna2TextBox txtCaptureStatusLog;
        private Guna.UI2.WinForms.Guna2TextBox txtScannerPrompt;
        private System.Windows.Forms.Label lblSampleNeededStatus;
        private Guna.UI2.WinForms.Guna2Button btnSaveEmployeeDetails;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnResetInputFields;
        private System.Windows.Forms.Label lblFormLabel;
        private System.Windows.Forms.Label label17;
        private Guna.UI2.WinForms.Guna2TextBox txtEmployeeBrgyAddress;
        private Guna.UI2.WinForms.Guna2ComboBox cboEmployeeCityMunicipality;
        private System.Windows.Forms.Label label16;
        private Guna.UI2.WinForms.Guna2Button btnStartScan;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEmployeeDateOfBirth;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEmployeeHiredDate;
        private System.Windows.Forms.RadioButton rdbMale;
        private System.Windows.Forms.RadioButton rdbFemale;
        public Guna.UI2.WinForms.Guna2TextBox txtEmployeeFirstName;
        private System.Windows.Forms.Label progressPecentageStatus;
    }
}