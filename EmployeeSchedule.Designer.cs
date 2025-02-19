namespace GUTZ_Capstone_Project
{
    partial class EmployeeSchedule
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
            this.lblFormLabel = new System.Windows.Forms.Label();
            this.chkBoxMonday = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBoxFriday = new System.Windows.Forms.CheckBox();
            this.chkBoxThursday = new System.Windows.Forms.CheckBox();
            this.chkBoxWednesday = new System.Windows.Forms.CheckBox();
            this.chkBoxTuesday = new System.Windows.Forms.CheckBox();
            this.StartNumUpDown = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.EndNumUpDown = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboStartAMOrPM = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EndMinutesNumUpDown = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.StartMinutesNumUpDown = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.cboEndAMOrPM = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSaveSchedule = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.chkBoxSaturday = new System.Windows.Forms.CheckBox();
            this.chkBoxSunday = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndNumUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndMinutesNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartMinutesNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormLabel
            // 
            this.lblFormLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFormLabel.Font = new System.Drawing.Font("Times New Roman", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormLabel.ForeColor = System.Drawing.Color.White;
            this.lblFormLabel.Location = new System.Drawing.Point(30, 29);
            this.lblFormLabel.Name = "lblFormLabel";
            this.lblFormLabel.Size = new System.Drawing.Size(685, 48);
            this.lblFormLabel.TabIndex = 54;
            this.lblFormLabel.Text = "SET CLASS SCHEDULE";
            this.lblFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkBoxMonday
            // 
            this.chkBoxMonday.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxMonday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkBoxMonday.Location = new System.Drawing.Point(29, 38);
            this.chkBoxMonday.Name = "chkBoxMonday";
            this.chkBoxMonday.Size = new System.Drawing.Size(99, 35);
            this.chkBoxMonday.TabIndex = 74;
            this.chkBoxMonday.Text = "Monday";
            this.chkBoxMonday.UseVisualStyleBackColor = true;
            this.chkBoxMonday.CheckedChanged += new System.EventHandler(this.chkBoxMonday_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.chkBoxSunday);
            this.groupBox1.Controls.Add(this.chkBoxSaturday);
            this.groupBox1.Controls.Add(this.chkBoxFriday);
            this.groupBox1.Controls.Add(this.chkBoxThursday);
            this.groupBox1.Controls.Add(this.chkBoxWednesday);
            this.groupBox1.Controls.Add(this.chkBoxTuesday);
            this.groupBox1.Controls.Add(this.chkBoxMonday);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Gray;
            this.groupBox1.Location = new System.Drawing.Point(30, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(685, 135);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Work Days";
            // 
            // chkBoxFriday
            // 
            this.chkBoxFriday.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.chkBoxFriday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkBoxFriday.Location = new System.Drawing.Point(592, 38);
            this.chkBoxFriday.Name = "chkBoxFriday";
            this.chkBoxFriday.Size = new System.Drawing.Size(85, 35);
            this.chkBoxFriday.TabIndex = 78;
            this.chkBoxFriday.Text = "Friday";
            this.chkBoxFriday.UseVisualStyleBackColor = true;
            this.chkBoxFriday.CheckedChanged += new System.EventHandler(this.chkBoxFriday_CheckedChanged);
            // 
            // chkBoxThursday
            // 
            this.chkBoxThursday.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.chkBoxThursday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkBoxThursday.Location = new System.Drawing.Point(451, 38);
            this.chkBoxThursday.Name = "chkBoxThursday";
            this.chkBoxThursday.Size = new System.Drawing.Size(111, 35);
            this.chkBoxThursday.TabIndex = 77;
            this.chkBoxThursday.Text = "Thursday";
            this.chkBoxThursday.UseVisualStyleBackColor = true;
            this.chkBoxThursday.CheckedChanged += new System.EventHandler(this.chkBoxThursday_CheckedChanged);
            // 
            // chkBoxWednesday
            // 
            this.chkBoxWednesday.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.chkBoxWednesday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkBoxWednesday.Location = new System.Drawing.Point(293, 38);
            this.chkBoxWednesday.Name = "chkBoxWednesday";
            this.chkBoxWednesday.Size = new System.Drawing.Size(128, 35);
            this.chkBoxWednesday.TabIndex = 76;
            this.chkBoxWednesday.Text = "Wednesday";
            this.chkBoxWednesday.UseVisualStyleBackColor = true;
            this.chkBoxWednesday.CheckedChanged += new System.EventHandler(this.chkBoxWednesday_CheckedChanged);
            // 
            // chkBoxTuesday
            // 
            this.chkBoxTuesday.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.chkBoxTuesday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkBoxTuesday.Location = new System.Drawing.Point(158, 38);
            this.chkBoxTuesday.Name = "chkBoxTuesday";
            this.chkBoxTuesday.Size = new System.Drawing.Size(105, 35);
            this.chkBoxTuesday.TabIndex = 75;
            this.chkBoxTuesday.Text = "Tuesday";
            this.chkBoxTuesday.UseVisualStyleBackColor = true;
            this.chkBoxTuesday.CheckedChanged += new System.EventHandler(this.chkBoxTuesday_CheckedChanged);
            // 
            // StartNumUpDown
            // 
            this.StartNumUpDown.BackColor = System.Drawing.Color.White;
            this.StartNumUpDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.StartNumUpDown.FocusedState.BorderColor = System.Drawing.Color.Green;
            this.StartNumUpDown.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartNumUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StartNumUpDown.Location = new System.Drawing.Point(18, 100);
            this.StartNumUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartNumUpDown.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.StartNumUpDown.Name = "StartNumUpDown";
            this.StartNumUpDown.Size = new System.Drawing.Size(70, 38);
            this.StartNumUpDown.TabIndex = 79;
            this.StartNumUpDown.UpDownButtonFillColor = System.Drawing.Color.White;
            this.StartNumUpDown.UpDownButtonForeColor = System.Drawing.Color.DarkOrange;
            this.StartNumUpDown.ValueChanged += new System.EventHandler(this.StartNumUpDown_ValueChanged);
            // 
            // EndNumUpDown
            // 
            this.EndNumUpDown.BackColor = System.Drawing.Color.White;
            this.EndNumUpDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EndNumUpDown.FocusedState.BorderColor = System.Drawing.Color.Green;
            this.EndNumUpDown.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndNumUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EndNumUpDown.Location = new System.Drawing.Point(398, 100);
            this.EndNumUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EndNumUpDown.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.EndNumUpDown.Name = "EndNumUpDown";
            this.EndNumUpDown.Size = new System.Drawing.Size(70, 38);
            this.EndNumUpDown.TabIndex = 80;
            this.EndNumUpDown.UpDownButtonFillColor = System.Drawing.Color.White;
            this.EndNumUpDown.UpDownButtonForeColor = System.Drawing.Color.DarkGreen;
            this.EndNumUpDown.ValueChanged += new System.EventHandler(this.EndNumUpDown_ValueChanged);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label15.Location = new System.Drawing.Point(18, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(270, 29);
            this.label15.TabIndex = 81;
            this.label15.Text = "START TIME:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 9.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(399, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 29);
            this.label1.TabIndex = 82;
            this.label1.Text = "END TIME:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cboStartAMOrPM);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.EndMinutesNumUpDown);
            this.groupBox2.Controls.Add(this.StartMinutesNumUpDown);
            this.groupBox2.Controls.Add(this.cboEndAMOrPM);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.StartNumUpDown);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.EndNumUpDown);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.Gray;
            this.groupBox2.Location = new System.Drawing.Point(30, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(685, 160);
            this.groupBox2.TabIndex = 79;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Class Hours";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Arial", 6.5F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(577, 69);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label9.Size = new System.Drawing.Size(91, 26);
            this.label9.TabIndex = 95;
            this.label9.Text = "Time of Day:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Arial", 6.5F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(197, 69);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label8.Size = new System.Drawing.Size(91, 26);
            this.label8.TabIndex = 94;
            this.label8.Text = "Time of Day:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboStartAMOrPM
            // 
            this.cboStartAMOrPM.BackColor = System.Drawing.Color.White;
            this.cboStartAMOrPM.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboStartAMOrPM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboStartAMOrPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartAMOrPM.FocusedColor = System.Drawing.Color.Green;
            this.cboStartAMOrPM.FocusedState.BorderColor = System.Drawing.Color.Green;
            this.cboStartAMOrPM.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.cboStartAMOrPM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboStartAMOrPM.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboStartAMOrPM.HoverState.FillColor = System.Drawing.Color.White;
            this.cboStartAMOrPM.IntegralHeight = false;
            this.cboStartAMOrPM.ItemHeight = 32;
            this.cboStartAMOrPM.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.cboStartAMOrPM.Location = new System.Drawing.Point(205, 100);
            this.cboStartAMOrPM.Name = "cboStartAMOrPM";
            this.cboStartAMOrPM.Size = new System.Drawing.Size(83, 38);
            this.cboStartAMOrPM.TabIndex = 93;
            this.cboStartAMOrPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(501, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 26);
            this.label7.TabIndex = 92;
            this.label7.Text = "MINS.:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(398, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 26);
            this.label6.TabIndex = 91;
            this.label6.Text = "HRS.:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(121, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 26);
            this.label5.TabIndex = 90;
            this.label5.Text = "MINS.:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(18, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 26);
            this.label4.TabIndex = 89;
            this.label4.Text = "HRS.:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(97, 103);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(15, 30);
            this.label3.TabIndex = 88;
            this.label3.Text = ":";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Roboto", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(477, 102);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(15, 30);
            this.label2.TabIndex = 87;
            this.label2.Text = ":";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EndMinutesNumUpDown
            // 
            this.EndMinutesNumUpDown.BackColor = System.Drawing.Color.White;
            this.EndMinutesNumUpDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EndMinutesNumUpDown.FocusedState.BorderColor = System.Drawing.Color.Green;
            this.EndMinutesNumUpDown.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndMinutesNumUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EndMinutesNumUpDown.Location = new System.Drawing.Point(501, 100);
            this.EndMinutesNumUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EndMinutesNumUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.EndMinutesNumUpDown.Name = "EndMinutesNumUpDown";
            this.EndMinutesNumUpDown.Size = new System.Drawing.Size(70, 38);
            this.EndMinutesNumUpDown.TabIndex = 86;
            this.EndMinutesNumUpDown.UpDownButtonFillColor = System.Drawing.Color.White;
            this.EndMinutesNumUpDown.UpDownButtonForeColor = System.Drawing.Color.DarkGreen;
            // 
            // StartMinutesNumUpDown
            // 
            this.StartMinutesNumUpDown.BackColor = System.Drawing.Color.White;
            this.StartMinutesNumUpDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.StartMinutesNumUpDown.FocusedState.BorderColor = System.Drawing.Color.Green;
            this.StartMinutesNumUpDown.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartMinutesNumUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StartMinutesNumUpDown.Location = new System.Drawing.Point(121, 100);
            this.StartMinutesNumUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartMinutesNumUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.StartMinutesNumUpDown.Name = "StartMinutesNumUpDown";
            this.StartMinutesNumUpDown.Size = new System.Drawing.Size(70, 38);
            this.StartMinutesNumUpDown.TabIndex = 85;
            this.StartMinutesNumUpDown.UpDownButtonFillColor = System.Drawing.Color.White;
            this.StartMinutesNumUpDown.UpDownButtonForeColor = System.Drawing.Color.DarkOrange;
            // 
            // cboEndAMOrPM
            // 
            this.cboEndAMOrPM.BackColor = System.Drawing.Color.White;
            this.cboEndAMOrPM.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboEndAMOrPM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEndAMOrPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEndAMOrPM.FocusedColor = System.Drawing.Color.Green;
            this.cboEndAMOrPM.FocusedState.BorderColor = System.Drawing.Color.Green;
            this.cboEndAMOrPM.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.cboEndAMOrPM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cboEndAMOrPM.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboEndAMOrPM.HoverState.FillColor = System.Drawing.Color.White;
            this.cboEndAMOrPM.IntegralHeight = false;
            this.cboEndAMOrPM.ItemHeight = 32;
            this.cboEndAMOrPM.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.cboEndAMOrPM.Location = new System.Drawing.Point(585, 100);
            this.cboEndAMOrPM.Name = "cboEndAMOrPM";
            this.cboEndAMOrPM.Size = new System.Drawing.Size(83, 38);
            this.cboEndAMOrPM.TabIndex = 84;
            this.cboEndAMOrPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSaveSchedule
            // 
            this.btnSaveSchedule.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveSchedule.BorderColor = System.Drawing.Color.Green;
            this.btnSaveSchedule.BorderRadius = 4;
            this.btnSaveSchedule.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveSchedule.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveSchedule.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveSchedule.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveSchedule.FillColor = System.Drawing.Color.Green;
            this.btnSaveSchedule.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.btnSaveSchedule.ForeColor = System.Drawing.Color.White;
            this.btnSaveSchedule.HoverState.BorderColor = System.Drawing.Color.MistyRose;
            this.btnSaveSchedule.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(58)))), ((int)(((byte)(14)))));
            this.btnSaveSchedule.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSaveSchedule.Location = new System.Drawing.Point(30, 420);
            this.btnSaveSchedule.Name = "btnSaveSchedule";
            this.btnSaveSchedule.Size = new System.Drawing.Size(100, 36);
            this.btnSaveSchedule.TabIndex = 80;
            this.btnSaveSchedule.Text = "Save";
            this.btnSaveSchedule.Click += new System.EventHandler(this.btnSaveSchedule_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.btnClose.BorderRadius = 4;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.BorderColor = System.Drawing.Color.MistyRose;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.Red;
            this.btnClose.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(615, 420);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnClose.Size = new System.Drawing.Size(100, 36);
            this.btnClose.TabIndex = 81;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // chkBoxSaturday
            // 
            this.chkBoxSaturday.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxSaturday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkBoxSaturday.Location = new System.Drawing.Point(200, 85);
            this.chkBoxSaturday.Name = "chkBoxSaturday";
            this.chkBoxSaturday.Size = new System.Drawing.Size(110, 35);
            this.chkBoxSaturday.TabIndex = 79;
            this.chkBoxSaturday.Text = "Saturday";
            this.chkBoxSaturday.UseVisualStyleBackColor = true;
            this.chkBoxSaturday.CheckedChanged += new System.EventHandler(this.chkBoxSaturday_CheckedChanged);
            // 
            // chkBoxSunday
            // 
            this.chkBoxSunday.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxSunday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkBoxSunday.Location = new System.Drawing.Point(385, 85);
            this.chkBoxSunday.Name = "chkBoxSunday";
            this.chkBoxSunday.Size = new System.Drawing.Size(110, 35);
            this.chkBoxSunday.TabIndex = 80;
            this.chkBoxSunday.Text = "Sunday";
            this.chkBoxSunday.UseVisualStyleBackColor = true;
            this.chkBoxSunday.CheckedChanged += new System.EventHandler(this.chkBoxSunday_CheckedChanged);
            // 
            // EmployeeSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(743, 474);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveSchedule);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblFormLabel);
            this.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EmployeeSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Class Schedule Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployeeSchedule_FormClosing);
            this.Load += new System.EventHandler(this.EmployeeSchedule_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StartNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndNumUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EndMinutesNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartMinutesNumUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFormLabel;
        private System.Windows.Forms.CheckBox chkBoxMonday;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBoxFriday;
        private System.Windows.Forms.CheckBox chkBoxThursday;
        private System.Windows.Forms.CheckBox chkBoxWednesday;
        private System.Windows.Forms.CheckBox chkBoxTuesday;
        private Guna.UI2.WinForms.Guna2NumericUpDown StartNumUpDown;
        private Guna.UI2.WinForms.Guna2NumericUpDown EndNumUpDown;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Guna.UI2.WinForms.Guna2Button btnSaveSchedule;
        private Guna.UI2.WinForms.Guna2ComboBox cboEndAMOrPM;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2NumericUpDown EndMinutesNumUpDown;
        private Guna.UI2.WinForms.Guna2NumericUpDown StartMinutesNumUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cboStartAMOrPM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkBoxSunday;
        private System.Windows.Forms.CheckBox chkBoxSaturday;
    }
}