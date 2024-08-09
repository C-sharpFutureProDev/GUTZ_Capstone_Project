﻿namespace GUTZ_Capstone_Project.Forms
{
    partial class FormEmployeeEnrollment
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
            this.dtpEmployeeDateOfBirth = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEmployeeMiddleInitial = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmployeeDept = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmployeeAge = new Guna.UI2.WinForms.Guna2TextBox();
            this.dptEmployeeHiredDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmployeeGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmployeeContactNumber = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmployeeAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmployeeEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUploadImage = new Guna.UI2.WinForms.Guna2Button();
            this.employeeProfilePicture = new Guna.UI2.WinForms.Guna2PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblSampleNeededStatus = new System.Windows.Forms.Label();
            this.captureStatusLog = new Guna.UI2.WinForms.Guna2TextBox();
            this.scannerPrompt = new Guna.UI2.WinForms.Guna2TextBox();
            this.scanningProgressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.employeeFingerprintImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnSaveEmployeeDetails = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnResetInputFields = new Guna.UI2.WinForms.Guna2Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.cboEmployeeCityMunicipality = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtEmployeeBrgyAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnStartScan = new Guna.UI2.WinForms.Guna2Button();
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
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.label1.Location = new System.Drawing.Point(28, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 26);
            this.label1.TabIndex = 27;
            this.label1.Text = "Firstname:";
            // 
            // txtEmployeeJobDesc
            // 
            this.txtEmployeeJobDesc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeJobDesc.BorderRadius = 3;
            this.txtEmployeeJobDesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeJobDesc.DefaultText = "";
            this.txtEmployeeJobDesc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeJobDesc.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeJobDesc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeJobDesc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeJobDesc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeJobDesc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeJobDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeJobDesc.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeJobDesc.Location = new System.Drawing.Point(137, 172);
            this.txtEmployeeJobDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmployeeJobDesc.Name = "txtEmployeeJobDesc";
            this.txtEmployeeJobDesc.PasswordChar = '\0';
            this.txtEmployeeJobDesc.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtEmployeeJobDesc.PlaceholderText = "";
            this.txtEmployeeJobDesc.SelectedText = "";
            this.txtEmployeeJobDesc.Size = new System.Drawing.Size(290, 34);
            this.txtEmployeeJobDesc.TabIndex = 52;
            // 
            // txtEmployeeFirstName
            // 
            this.txtEmployeeFirstName.BackColor = System.Drawing.Color.Transparent;
            this.txtEmployeeFirstName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeFirstName.BorderRadius = 3;
            this.txtEmployeeFirstName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeFirstName.DefaultText = "";
            this.txtEmployeeFirstName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeFirstName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeFirstName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeFirstName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeFirstName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeFirstName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeFirstName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeFirstName.Location = new System.Drawing.Point(137, 29);
            this.txtEmployeeFirstName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmployeeFirstName.Name = "txtEmployeeFirstName";
            this.txtEmployeeFirstName.PasswordChar = '\0';
            this.txtEmployeeFirstName.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtEmployeeFirstName.PlaceholderText = "";
            this.txtEmployeeFirstName.SelectedText = "";
            this.txtEmployeeFirstName.Size = new System.Drawing.Size(386, 34);
            this.txtEmployeeFirstName.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.label13.Location = new System.Drawing.Point(38, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 26);
            this.label13.TabIndex = 51;
            this.label13.Text = "Job Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.label2.Location = new System.Drawing.Point(28, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 26);
            this.label2.TabIndex = 29;
            this.label2.Text = "Lastname:";
            // 
            // txtEmployeeLastName
            // 
            this.txtEmployeeLastName.BackColor = System.Drawing.Color.Transparent;
            this.txtEmployeeLastName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeLastName.BorderRadius = 3;
            this.txtEmployeeLastName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeLastName.DefaultText = "";
            this.txtEmployeeLastName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeLastName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeLastName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeLastName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeLastName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeLastName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeLastName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeLastName.Location = new System.Drawing.Point(137, 89);
            this.txtEmployeeLastName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmployeeLastName.Name = "txtEmployeeLastName";
            this.txtEmployeeLastName.PasswordChar = '\0';
            this.txtEmployeeLastName.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtEmployeeLastName.PlaceholderText = "";
            this.txtEmployeeLastName.SelectedText = "";
            this.txtEmployeeLastName.Size = new System.Drawing.Size(386, 34);
            this.txtEmployeeLastName.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.label3.Location = new System.Drawing.Point(82, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 26);
            this.label3.TabIndex = 31;
            this.label3.Text = "M.I.:";
            // 
            // dtpEmployeeDateOfBirth
            // 
            this.dtpEmployeeDateOfBirth.BorderRadius = 3;
            this.dtpEmployeeDateOfBirth.Checked = true;
            this.dtpEmployeeDateOfBirth.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.dtpEmployeeDateOfBirth.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEmployeeDateOfBirth.ForeColor = System.Drawing.Color.White;
            this.dtpEmployeeDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpEmployeeDateOfBirth.Location = new System.Drawing.Point(672, 29);
            this.dtpEmployeeDateOfBirth.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEmployeeDateOfBirth.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEmployeeDateOfBirth.Name = "dtpEmployeeDateOfBirth";
            this.dtpEmployeeDateOfBirth.Size = new System.Drawing.Size(290, 35);
            this.dtpEmployeeDateOfBirth.TabIndex = 48;
            this.dtpEmployeeDateOfBirth.Value = new System.DateTime(2024, 8, 8, 15, 3, 2, 237);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.label11.Location = new System.Drawing.Point(541, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 26);
            this.label11.TabIndex = 47;
            this.label11.Text = "Date of Birth:";
            // 
            // txtEmployeeMiddleInitial
            // 
            this.txtEmployeeMiddleInitial.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeMiddleInitial.BorderRadius = 3;
            this.txtEmployeeMiddleInitial.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeMiddleInitial.DefaultText = "";
            this.txtEmployeeMiddleInitial.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeMiddleInitial.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeMiddleInitial.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeMiddleInitial.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeMiddleInitial.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeMiddleInitial.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeMiddleInitial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeMiddleInitial.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeMiddleInitial.Location = new System.Drawing.Point(137, 149);
            this.txtEmployeeMiddleInitial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmployeeMiddleInitial.Name = "txtEmployeeMiddleInitial";
            this.txtEmployeeMiddleInitial.PasswordChar = '\0';
            this.txtEmployeeMiddleInitial.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtEmployeeMiddleInitial.PlaceholderText = "";
            this.txtEmployeeMiddleInitial.SelectedText = "";
            this.txtEmployeeMiddleInitial.Size = new System.Drawing.Size(89, 34);
            this.txtEmployeeMiddleInitial.TabIndex = 32;
            this.txtEmployeeMiddleInitial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEmployeeDept
            // 
            this.txtEmployeeDept.BackColor = System.Drawing.Color.Transparent;
            this.txtEmployeeDept.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeDept.BorderRadius = 3;
            this.txtEmployeeDept.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtEmployeeDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtEmployeeDept.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeDept.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeDept.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeDept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeDept.ItemHeight = 30;
            this.txtEmployeeDept.Items.AddRange(new object[] {
            "BPO Dept.",
            "ESL Dept.",
            "Exe. Dept."});
            this.txtEmployeeDept.Location = new System.Drawing.Point(137, 110);
            this.txtEmployeeDept.Name = "txtEmployeeDept";
            this.txtEmployeeDept.Size = new System.Drawing.Size(132, 36);
            this.txtEmployeeDept.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.label4.Location = new System.Drawing.Point(613, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 26);
            this.label4.TabIndex = 33;
            this.label4.Text = "Age:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.label10.Location = new System.Drawing.Point(12, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 26);
            this.label10.TabIndex = 45;
            this.label10.Text = "Department:";
            // 
            // txtEmployeeAge
            // 
            this.txtEmployeeAge.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeAge.BorderRadius = 3;
            this.txtEmployeeAge.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeAge.DefaultText = "";
            this.txtEmployeeAge.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeAge.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeAge.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeAge.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeAge.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeAge.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeAge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeAge.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeAge.Location = new System.Drawing.Point(672, 89);
            this.txtEmployeeAge.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmployeeAge.Name = "txtEmployeeAge";
            this.txtEmployeeAge.PasswordChar = '\0';
            this.txtEmployeeAge.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtEmployeeAge.PlaceholderText = "";
            this.txtEmployeeAge.SelectedText = "";
            this.txtEmployeeAge.Size = new System.Drawing.Size(89, 34);
            this.txtEmployeeAge.TabIndex = 34;
            this.txtEmployeeAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dptEmployeeHiredDate
            // 
            this.dptEmployeeHiredDate.BorderRadius = 3;
            this.dptEmployeeHiredDate.Checked = true;
            this.dptEmployeeHiredDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.dptEmployeeHiredDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptEmployeeHiredDate.ForeColor = System.Drawing.Color.White;
            this.dptEmployeeHiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dptEmployeeHiredDate.Location = new System.Drawing.Point(137, 50);
            this.dptEmployeeHiredDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dptEmployeeHiredDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dptEmployeeHiredDate.Name = "dptEmployeeHiredDate";
            this.dptEmployeeHiredDate.Size = new System.Drawing.Size(290, 34);
            this.dptEmployeeHiredDate.TabIndex = 44;
            this.dptEmployeeHiredDate.Value = new System.DateTime(2024, 8, 8, 15, 3, 2, 237);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.label5.Location = new System.Drawing.Point(51, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 26);
            this.label5.TabIndex = 35;
            this.label5.Text = "Gender:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.label9.Location = new System.Drawing.Point(22, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 26);
            this.label9.TabIndex = 43;
            this.label9.Text = "Hired Date:";
            // 
            // txtEmployeeGender
            // 
            this.txtEmployeeGender.BackColor = System.Drawing.Color.Transparent;
            this.txtEmployeeGender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeGender.BorderRadius = 3;
            this.txtEmployeeGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.txtEmployeeGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtEmployeeGender.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeGender.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeGender.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeGender.ItemHeight = 30;
            this.txtEmployeeGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.txtEmployeeGender.Location = new System.Drawing.Point(137, 209);
            this.txtEmployeeGender.Name = "txtEmployeeGender";
            this.txtEmployeeGender.Size = new System.Drawing.Size(132, 36);
            this.txtEmployeeGender.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.label6.Location = new System.Drawing.Point(93, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 26);
            this.label6.TabIndex = 37;
            this.label6.Text = "Address:";
            // 
            // txtEmployeeContactNumber
            // 
            this.txtEmployeeContactNumber.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeContactNumber.BorderRadius = 3;
            this.txtEmployeeContactNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeContactNumber.DefaultText = "";
            this.txtEmployeeContactNumber.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeContactNumber.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeContactNumber.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeContactNumber.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeContactNumber.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeContactNumber.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeContactNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeContactNumber.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeContactNumber.Location = new System.Drawing.Point(672, 149);
            this.txtEmployeeContactNumber.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmployeeContactNumber.Name = "txtEmployeeContactNumber";
            this.txtEmployeeContactNumber.PasswordChar = '\0';
            this.txtEmployeeContactNumber.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtEmployeeContactNumber.PlaceholderText = "";
            this.txtEmployeeContactNumber.SelectedText = "";
            this.txtEmployeeContactNumber.Size = new System.Drawing.Size(266, 34);
            this.txtEmployeeContactNumber.TabIndex = 42;
            // 
            // txtEmployeeAddress
            // 
            this.txtEmployeeAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeAddress.BorderRadius = 3;
            this.txtEmployeeAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeAddress.DefaultText = "";
            this.txtEmployeeAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeAddress.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeAddress.Location = new System.Drawing.Point(195, 158);
            this.txtEmployeeAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmployeeAddress.Name = "txtEmployeeAddress";
            this.txtEmployeeAddress.PasswordChar = '\0';
            this.txtEmployeeAddress.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtEmployeeAddress.PlaceholderText = "";
            this.txtEmployeeAddress.SelectedText = "";
            this.txtEmployeeAddress.Size = new System.Drawing.Size(328, 34);
            this.txtEmployeeAddress.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.label8.Location = new System.Drawing.Point(565, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 26);
            this.label8.TabIndex = 41;
            this.label8.Text = "Contact #:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.label7.Location = new System.Drawing.Point(599, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 26);
            this.label7.TabIndex = 39;
            this.label7.Text = "Email:";
            // 
            // txtEmployeeEmail
            // 
            this.txtEmployeeEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeEmail.BorderRadius = 3;
            this.txtEmployeeEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeEmail.DefaultText = "";
            this.txtEmployeeEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeEmail.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeEmail.Location = new System.Drawing.Point(672, 209);
            this.txtEmployeeEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmployeeEmail.Name = "txtEmployeeEmail";
            this.txtEmployeeEmail.PasswordChar = '\0';
            this.txtEmployeeEmail.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtEmployeeEmail.PlaceholderText = "";
            this.txtEmployeeEmail.SelectedText = "";
            this.txtEmployeeEmail.Size = new System.Drawing.Size(266, 34);
            this.txtEmployeeEmail.TabIndex = 40;
            // 
            // groupBox1
            // 
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
            this.groupBox1.Controls.Add(this.txtEmployeeMiddleInitial);
            this.groupBox1.Controls.Add(this.dtpEmployeeDateOfBirth);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtEmployeeAge);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtEmployeeGender);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(26, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1241, 277);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Personal Details";
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.AutoRoundedCorners = true;
            this.btnUploadImage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.btnUploadImage.BorderRadius = 21;
            this.btnUploadImage.BorderThickness = 2;
            this.btnUploadImage.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUploadImage.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUploadImage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUploadImage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUploadImage.FillColor = System.Drawing.Color.Ivory;
            this.btnUploadImage.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadImage.ForeColor = System.Drawing.Color.Black;
            this.btnUploadImage.Location = new System.Drawing.Point(1037, 218);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(177, 45);
            this.btnUploadImage.TabIndex = 56;
            this.btnUploadImage.Text = "Upload Image";
            // 
            // employeeProfilePicture
            // 
            this.employeeProfilePicture.AutoRoundedCorners = true;
            this.employeeProfilePicture.BorderRadius = 87;
            this.employeeProfilePicture.ImageRotate = 0F;
            this.employeeProfilePicture.Location = new System.Drawing.Point(1037, 27);
            this.employeeProfilePicture.Name = "employeeProfilePicture";
            this.employeeProfilePicture.Size = new System.Drawing.Size(177, 176);
            this.employeeProfilePicture.TabIndex = 49;
            this.employeeProfilePicture.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtEmployeeBrgyAddress);
            this.groupBox2.Controls.Add(this.cboEmployeeCityMunicipality);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtEmployeeAddress);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(26, 361);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(557, 201);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Employee Address";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dptEmployeeHiredDate);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtEmployeeJobDesc);
            this.groupBox3.Controls.Add(this.txtEmployeeDept);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(26, 582);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(557, 250);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Job Description";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnStartScan);
            this.groupBox4.Controls.Add(this.lblSampleNeededStatus);
            this.groupBox4.Controls.Add(this.captureStatusLog);
            this.groupBox4.Controls.Add(this.scannerPrompt);
            this.groupBox4.Controls.Add(this.scanningProgressBar);
            this.groupBox4.Controls.Add(this.employeeFingerprintImage);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox4.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Black;
            this.groupBox4.Location = new System.Drawing.Point(632, 361);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(635, 471);
            this.groupBox4.TabIndex = 55;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Biometrics Capturing and Enrollment";
            // 
            // lblSampleNeededStatus
            // 
            this.lblSampleNeededStatus.AutoSize = true;
            this.lblSampleNeededStatus.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSampleNeededStatus.Location = new System.Drawing.Point(39, 341);
            this.lblSampleNeededStatus.Name = "lblSampleNeededStatus";
            this.lblSampleNeededStatus.Size = new System.Drawing.Size(214, 22);
            this.lblSampleNeededStatus.TabIndex = 59;
            this.lblSampleNeededStatus.Text = "[SAMPLE NEEDED STATUS]";
            // 
            // captureStatusLog
            // 
            this.captureStatusLog.BorderRadius = 3;
            this.captureStatusLog.BorderThickness = 0;
            this.captureStatusLog.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.captureStatusLog.DefaultText = "";
            this.captureStatusLog.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.captureStatusLog.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.captureStatusLog.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.captureStatusLog.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.captureStatusLog.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.captureStatusLog.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captureStatusLog.ForeColor = System.Drawing.Color.Black;
            this.captureStatusLog.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.captureStatusLog.Location = new System.Drawing.Point(278, 90);
            this.captureStatusLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.captureStatusLog.Multiline = true;
            this.captureStatusLog.Name = "captureStatusLog";
            this.captureStatusLog.PasswordChar = '\0';
            this.captureStatusLog.PlaceholderForeColor = System.Drawing.Color.Black;
            this.captureStatusLog.PlaceholderText = "";
            this.captureStatusLog.SelectedText = "";
            this.captureStatusLog.Size = new System.Drawing.Size(330, 239);
            this.captureStatusLog.TabIndex = 43;
            // 
            // scannerPrompt
            // 
            this.scannerPrompt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.scannerPrompt.BorderRadius = 3;
            this.scannerPrompt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.scannerPrompt.DefaultText = "";
            this.scannerPrompt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.scannerPrompt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.scannerPrompt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.scannerPrompt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.scannerPrompt.FillColor = System.Drawing.Color.WhiteSmoke;
            this.scannerPrompt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.scannerPrompt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scannerPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.scannerPrompt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.scannerPrompt.Location = new System.Drawing.Point(40, 46);
            this.scannerPrompt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.scannerPrompt.Name = "scannerPrompt";
            this.scannerPrompt.PasswordChar = '\0';
            this.scannerPrompt.PlaceholderForeColor = System.Drawing.Color.Black;
            this.scannerPrompt.PlaceholderText = "";
            this.scannerPrompt.SelectedText = "";
            this.scannerPrompt.Size = new System.Drawing.Size(568, 34);
            this.scannerPrompt.TabIndex = 43;
            // 
            // scanningProgressBar
            // 
            this.scanningProgressBar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.scanningProgressBar.BorderRadius = 3;
            this.scanningProgressBar.BorderThickness = 1;
            this.scanningProgressBar.FillColor = System.Drawing.Color.White;
            this.scanningProgressBar.Location = new System.Drawing.Point(43, 382);
            this.scanningProgressBar.Name = "scanningProgressBar";
            this.scanningProgressBar.Size = new System.Drawing.Size(568, 25);
            this.scanningProgressBar.TabIndex = 58;
            this.scanningProgressBar.Text = "guna2ProgressBar1";
            this.scanningProgressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // employeeFingerprintImage
            // 
            this.employeeFingerprintImage.BorderRadius = 3;
            this.employeeFingerprintImage.ImageRotate = 0F;
            this.employeeFingerprintImage.Location = new System.Drawing.Point(40, 89);
            this.employeeFingerprintImage.Name = "employeeFingerprintImage";
            this.employeeFingerprintImage.Size = new System.Drawing.Size(231, 240);
            this.employeeFingerprintImage.TabIndex = 57;
            this.employeeFingerprintImage.TabStop = false;
            // 
            // btnSaveEmployeeDetails
            // 
            this.btnSaveEmployeeDetails.BorderRadius = 5;
            this.btnSaveEmployeeDetails.BorderThickness = 2;
            this.btnSaveEmployeeDetails.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveEmployeeDetails.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveEmployeeDetails.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveEmployeeDetails.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveEmployeeDetails.FillColor = System.Drawing.Color.White;
            this.btnSaveEmployeeDetails.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEmployeeDetails.ForeColor = System.Drawing.Color.Black;
            this.btnSaveEmployeeDetails.Location = new System.Drawing.Point(24, 864);
            this.btnSaveEmployeeDetails.Name = "btnSaveEmployeeDetails";
            this.btnSaveEmployeeDetails.Size = new System.Drawing.Size(132, 45);
            this.btnSaveEmployeeDetails.TabIndex = 57;
            this.btnSaveEmployeeDetails.Text = "Save";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(1135, 864);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(132, 45);
            this.btnCancel.TabIndex = 58;
            this.btnCancel.Text = "Cancel";
            // 
            // btnResetInputFields
            // 
            this.btnResetInputFields.BorderRadius = 5;
            this.btnResetInputFields.BorderThickness = 1;
            this.btnResetInputFields.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnResetInputFields.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnResetInputFields.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnResetInputFields.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnResetInputFields.FillColor = System.Drawing.Color.White;
            this.btnResetInputFields.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetInputFields.ForeColor = System.Drawing.Color.Black;
            this.btnResetInputFields.Location = new System.Drawing.Point(632, 864);
            this.btnResetInputFields.Name = "btnResetInputFields";
            this.btnResetInputFields.Size = new System.Drawing.Size(132, 45);
            this.btnResetInputFields.TabIndex = 59;
            this.btnResetInputFields.Text = "Reset";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.label15.Location = new System.Drawing.Point(19, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(362, 38);
            this.label15.TabIndex = 53;
            this.label15.Text = "Employee Enrollment Form";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.label16.Location = new System.Drawing.Point(22, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(161, 26);
            this.label16.TabIndex = 39;
            this.label16.Text = "City/Municipality:";
            // 
            // cboEmployeeCityMunicipality
            // 
            this.cboEmployeeCityMunicipality.BackColor = System.Drawing.Color.Transparent;
            this.cboEmployeeCityMunicipality.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.cboEmployeeCityMunicipality.BorderRadius = 3;
            this.cboEmployeeCityMunicipality.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEmployeeCityMunicipality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmployeeCityMunicipality.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboEmployeeCityMunicipality.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboEmployeeCityMunicipality.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmployeeCityMunicipality.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.cboEmployeeCityMunicipality.ItemHeight = 30;
            this.cboEmployeeCityMunicipality.Location = new System.Drawing.Point(195, 36);
            this.cboEmployeeCityMunicipality.Name = "cboEmployeeCityMunicipality";
            this.cboEmployeeCityMunicipality.Size = new System.Drawing.Size(328, 36);
            this.cboEmployeeCityMunicipality.TabIndex = 57;
            // 
            // txtEmployeeBrgyAddress
            // 
            this.txtEmployeeBrgyAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeBrgyAddress.BorderRadius = 3;
            this.txtEmployeeBrgyAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeBrgyAddress.DefaultText = "";
            this.txtEmployeeBrgyAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeBrgyAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeBrgyAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeBrgyAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeBrgyAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeBrgyAddress.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeBrgyAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.txtEmployeeBrgyAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeBrgyAddress.Location = new System.Drawing.Point(195, 98);
            this.txtEmployeeBrgyAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmployeeBrgyAddress.Name = "txtEmployeeBrgyAddress";
            this.txtEmployeeBrgyAddress.PasswordChar = '\0';
            this.txtEmployeeBrgyAddress.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtEmployeeBrgyAddress.PlaceholderText = "";
            this.txtEmployeeBrgyAddress.SelectedText = "";
            this.txtEmployeeBrgyAddress.Size = new System.Drawing.Size(328, 34);
            this.txtEmployeeBrgyAddress.TabIndex = 58;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.label17.Location = new System.Drawing.Point(119, 106);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 26);
            this.label17.TabIndex = 59;
            this.label17.Text = "Brgy.:";
            // 
            // btnStartScan
            // 
            this.btnStartScan.AutoRoundedCorners = true;
            this.btnStartScan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(23)))), ((int)(((byte)(37)))));
            this.btnStartScan.BorderRadius = 21;
            this.btnStartScan.BorderThickness = 2;
            this.btnStartScan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStartScan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStartScan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStartScan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStartScan.FillColor = System.Drawing.Color.Ivory;
            this.btnStartScan.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartScan.ForeColor = System.Drawing.Color.Black;
            this.btnStartScan.Location = new System.Drawing.Point(457, 413);
            this.btnStartScan.Name = "btnStartScan";
            this.btnStartScan.Size = new System.Drawing.Size(154, 45);
            this.btnStartScan.TabIndex = 57;
            this.btnStartScan.Text = "Start Scan";
            // 
            // FormEmployeeEnrollment
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1297, 950);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnResetInputFields);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveEmployeeDetails);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEmployeeEnrollment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Employee Enrollment Form";
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
        private Guna.UI2.WinForms.Guna2TextBox txtEmployeeFirstName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtEmployeeLastName;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEmployeeDateOfBirth;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2TextBox txtEmployeeMiddleInitial;
        private Guna.UI2.WinForms.Guna2ComboBox txtEmployeeDept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox txtEmployeeAge;
        private Guna.UI2.WinForms.Guna2DateTimePicker dptEmployeeHiredDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2ComboBox txtEmployeeGender;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtEmployeeContactNumber;
        private Guna.UI2.WinForms.Guna2TextBox txtEmployeeAddress;
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
        private Guna.UI2.WinForms.Guna2TextBox captureStatusLog;
        private Guna.UI2.WinForms.Guna2TextBox scannerPrompt;
        private System.Windows.Forms.Label lblSampleNeededStatus;
        private Guna.UI2.WinForms.Guna2Button btnSaveEmployeeDetails;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnResetInputFields;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private Guna.UI2.WinForms.Guna2TextBox txtEmployeeBrgyAddress;
        private Guna.UI2.WinForms.Guna2ComboBox cboEmployeeCityMunicipality;
        private System.Windows.Forms.Label label16;
        private Guna.UI2.WinForms.Guna2Button btnStartScan;
    }
}