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
            this.cboEndAMOrPM = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboStartAMOrPM = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSaveSchedule = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartNumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndNumUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormLabel
            // 
            this.lblFormLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.lblFormLabel.Font = new System.Drawing.Font("Cambria", 15.5F, System.Drawing.FontStyle.Bold);
            this.lblFormLabel.ForeColor = System.Drawing.Color.White;
            this.lblFormLabel.Location = new System.Drawing.Point(34, 34);
            this.lblFormLabel.Name = "lblFormLabel";
            this.lblFormLabel.Size = new System.Drawing.Size(407, 43);
            this.lblFormLabel.TabIndex = 54;
            this.lblFormLabel.Text = "SET CLASS SCHEDULE";
            this.lblFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkBoxMonday
            // 
            this.chkBoxMonday.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxMonday.Location = new System.Drawing.Point(29, 38);
            this.chkBoxMonday.Name = "chkBoxMonday";
            this.chkBoxMonday.Size = new System.Drawing.Size(145, 39);
            this.chkBoxMonday.TabIndex = 74;
            this.chkBoxMonday.Text = "Monday";
            this.chkBoxMonday.UseVisualStyleBackColor = true;
            this.chkBoxMonday.CheckedChanged += new System.EventHandler(this.chkBoxMonday_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBoxFriday);
            this.groupBox1.Controls.Add(this.chkBoxThursday);
            this.groupBox1.Controls.Add(this.chkBoxWednesday);
            this.groupBox1.Controls.Add(this.chkBoxTuesday);
            this.groupBox1.Controls.Add(this.chkBoxMonday);
            this.groupBox1.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.groupBox1.Location = new System.Drawing.Point(34, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 277);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Work Days";
            // 
            // chkBoxFriday
            // 
            this.chkBoxFriday.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxFriday.Location = new System.Drawing.Point(29, 226);
            this.chkBoxFriday.Name = "chkBoxFriday";
            this.chkBoxFriday.Size = new System.Drawing.Size(145, 39);
            this.chkBoxFriday.TabIndex = 78;
            this.chkBoxFriday.Text = "Friday";
            this.chkBoxFriday.UseVisualStyleBackColor = true;
            this.chkBoxFriday.CheckedChanged += new System.EventHandler(this.chkBoxFriday_CheckedChanged);
            // 
            // chkBoxThursday
            // 
            this.chkBoxThursday.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxThursday.Location = new System.Drawing.Point(29, 179);
            this.chkBoxThursday.Name = "chkBoxThursday";
            this.chkBoxThursday.Size = new System.Drawing.Size(145, 39);
            this.chkBoxThursday.TabIndex = 77;
            this.chkBoxThursday.Text = "Thursday";
            this.chkBoxThursday.UseVisualStyleBackColor = true;
            this.chkBoxThursday.CheckedChanged += new System.EventHandler(this.chkBoxThursday_CheckedChanged);
            // 
            // chkBoxWednesday
            // 
            this.chkBoxWednesday.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxWednesday.Location = new System.Drawing.Point(29, 132);
            this.chkBoxWednesday.Name = "chkBoxWednesday";
            this.chkBoxWednesday.Size = new System.Drawing.Size(145, 39);
            this.chkBoxWednesday.TabIndex = 76;
            this.chkBoxWednesday.Text = "Wednesday";
            this.chkBoxWednesday.UseVisualStyleBackColor = true;
            this.chkBoxWednesday.CheckedChanged += new System.EventHandler(this.chkBoxWednesday_CheckedChanged);
            // 
            // chkBoxTuesday
            // 
            this.chkBoxTuesday.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoxTuesday.Location = new System.Drawing.Point(29, 85);
            this.chkBoxTuesday.Name = "chkBoxTuesday";
            this.chkBoxTuesday.Size = new System.Drawing.Size(145, 39);
            this.chkBoxTuesday.TabIndex = 75;
            this.chkBoxTuesday.Text = "Tuesday";
            this.chkBoxTuesday.UseVisualStyleBackColor = true;
            this.chkBoxTuesday.CheckedChanged += new System.EventHandler(this.chkBoxTuesday_CheckedChanged);
            // 
            // StartNumUpDown
            // 
            this.StartNumUpDown.BackColor = System.Drawing.Color.Transparent;
            this.StartNumUpDown.BorderRadius = 4;
            this.StartNumUpDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.StartNumUpDown.FocusedState.BorderColor = System.Drawing.Color.Green;
            this.StartNumUpDown.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartNumUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.StartNumUpDown.Location = new System.Drawing.Point(18, 85);
            this.StartNumUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartNumUpDown.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.StartNumUpDown.Name = "StartNumUpDown";
            this.StartNumUpDown.Size = new System.Drawing.Size(75, 38);
            this.StartNumUpDown.TabIndex = 79;
            this.StartNumUpDown.UpDownButtonFillColor = System.Drawing.Color.White;
            this.StartNumUpDown.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.StartNumUpDown.ValueChanged += new System.EventHandler(this.StartNumUpDown_ValueChanged);
            // 
            // EndNumUpDown
            // 
            this.EndNumUpDown.BackColor = System.Drawing.Color.Transparent;
            this.EndNumUpDown.BorderRadius = 4;
            this.EndNumUpDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EndNumUpDown.FocusedState.BorderColor = System.Drawing.Color.Green;
            this.EndNumUpDown.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndNumUpDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.EndNumUpDown.Location = new System.Drawing.Point(18, 168);
            this.EndNumUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.EndNumUpDown.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.EndNumUpDown.Name = "EndNumUpDown";
            this.EndNumUpDown.Size = new System.Drawing.Size(75, 38);
            this.EndNumUpDown.TabIndex = 80;
            this.EndNumUpDown.UpDownButtonFillColor = System.Drawing.Color.White;
            this.EndNumUpDown.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.EndNumUpDown.ValueChanged += new System.EventHandler(this.EndNumUpDown_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.label15.Location = new System.Drawing.Point(14, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 21);
            this.label15.TabIndex = 81;
            this.label15.Text = "Start At:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.label1.Location = new System.Drawing.Point(14, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 21);
            this.label1.TabIndex = 82;
            this.label1.Text = "End At:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboEndAMOrPM);
            this.groupBox2.Controls.Add(this.cboStartAMOrPM);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.StartNumUpDown);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.EndNumUpDown);
            this.groupBox2.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.groupBox2.Location = new System.Drawing.Point(238, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(203, 277);
            this.groupBox2.TabIndex = 79;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Class Hours";
            // 
            // cboEndAMOrPM
            // 
            this.cboEndAMOrPM.BackColor = System.Drawing.Color.Transparent;
            this.cboEndAMOrPM.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboEndAMOrPM.BorderRadius = 4;
            this.cboEndAMOrPM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEndAMOrPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEndAMOrPM.FocusedColor = System.Drawing.Color.Green;
            this.cboEndAMOrPM.FocusedState.BorderColor = System.Drawing.Color.Green;
            this.cboEndAMOrPM.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.cboEndAMOrPM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.cboEndAMOrPM.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboEndAMOrPM.HoverState.FillColor = System.Drawing.Color.White;
            this.cboEndAMOrPM.IntegralHeight = false;
            this.cboEndAMOrPM.ItemHeight = 32;
            this.cboEndAMOrPM.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.cboEndAMOrPM.Location = new System.Drawing.Point(117, 168);
            this.cboEndAMOrPM.Name = "cboEndAMOrPM";
            this.cboEndAMOrPM.Size = new System.Drawing.Size(75, 38);
            this.cboEndAMOrPM.TabIndex = 84;
            // 
            // cboStartAMOrPM
            // 
            this.cboStartAMOrPM.BackColor = System.Drawing.Color.Transparent;
            this.cboStartAMOrPM.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboStartAMOrPM.BorderRadius = 4;
            this.cboStartAMOrPM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboStartAMOrPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartAMOrPM.FocusedColor = System.Drawing.Color.Green;
            this.cboStartAMOrPM.FocusedState.BorderColor = System.Drawing.Color.Green;
            this.cboStartAMOrPM.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.cboStartAMOrPM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(92)))), ((int)(((byte)(61)))));
            this.cboStartAMOrPM.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cboStartAMOrPM.HoverState.FillColor = System.Drawing.Color.White;
            this.cboStartAMOrPM.IntegralHeight = false;
            this.cboStartAMOrPM.ItemHeight = 32;
            this.cboStartAMOrPM.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.cboStartAMOrPM.Location = new System.Drawing.Point(117, 85);
            this.cboStartAMOrPM.Name = "cboStartAMOrPM";
            this.cboStartAMOrPM.Size = new System.Drawing.Size(75, 38);
            this.cboStartAMOrPM.TabIndex = 83;
            // 
            // btnSaveSchedule
            // 
            this.btnSaveSchedule.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveSchedule.BorderColor = System.Drawing.Color.MistyRose;
            this.btnSaveSchedule.BorderRadius = 5;
            this.btnSaveSchedule.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveSchedule.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveSchedule.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveSchedule.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveSchedule.FillColor = System.Drawing.Color.Green;
            this.btnSaveSchedule.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveSchedule.ForeColor = System.Drawing.Color.White;
            this.btnSaveSchedule.HoverState.BorderColor = System.Drawing.Color.MistyRose;
            this.btnSaveSchedule.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(58)))), ((int)(((byte)(14)))));
            this.btnSaveSchedule.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnSaveSchedule.Location = new System.Drawing.Point(34, 396);
            this.btnSaveSchedule.Name = "btnSaveSchedule";
            this.btnSaveSchedule.Size = new System.Drawing.Size(113, 42);
            this.btnSaveSchedule.TabIndex = 80;
            this.btnSaveSchedule.Text = "SAVE";
            this.btnSaveSchedule.Click += new System.EventHandler(this.btnSaveSchedule_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderColor = System.Drawing.Color.MistyRose;
            this.btnClose.BorderRadius = 5;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.btnClose.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.BorderColor = System.Drawing.Color.MistyRose;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.Red;
            this.btnClose.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(328, 396);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 42);
            this.btnClose.TabIndex = 81;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // EmployeeSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(475, 462);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveSchedule);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblFormLabel);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EmployeeSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmployeeSchedule_FormClosing);
            this.Load += new System.EventHandler(this.EmployeeSchedule_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StartNumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndNumUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private Guna.UI2.WinForms.Guna2ComboBox cboStartAMOrPM;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}