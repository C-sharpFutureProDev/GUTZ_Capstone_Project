namespace GUTZ_Capstone_Project
{
    partial class SampleEmployeeListCardForReport
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelEmployeeListCard = new Guna.UI2.WinForms.Guna2Panel();
            this.chkSelectEmployee = new System.Windows.Forms.CheckBox();
            this.lblName = new System.Windows.Forms.Label();
            this.employeeProfilePicture = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panelEmployeeListCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEmployeeListCard
            // 
            this.panelEmployeeListCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelEmployeeListCard.BorderColor = System.Drawing.Color.Ivory;
            this.panelEmployeeListCard.BorderRadius = 8;
            this.panelEmployeeListCard.Controls.Add(this.chkSelectEmployee);
            this.panelEmployeeListCard.Controls.Add(this.lblName);
            this.panelEmployeeListCard.Controls.Add(this.employeeProfilePicture);
            this.panelEmployeeListCard.FillColor = System.Drawing.Color.White;
            this.panelEmployeeListCard.ForeColor = System.Drawing.Color.White;
            this.panelEmployeeListCard.Location = new System.Drawing.Point(0, 0);
            this.panelEmployeeListCard.Name = "panelEmployeeListCard";
            this.panelEmployeeListCard.ShadowDecoration.BorderRadius = 15;
            this.panelEmployeeListCard.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelEmployeeListCard.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.panelEmployeeListCard.Size = new System.Drawing.Size(304, 70);
            this.panelEmployeeListCard.TabIndex = 64;
            // 
            // chkSelectEmployee
            // 
            this.chkSelectEmployee.BackColor = System.Drawing.Color.White;
            this.chkSelectEmployee.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.chkSelectEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkSelectEmployee.Location = new System.Drawing.Point(265, 20);
            this.chkSelectEmployee.Name = "chkSelectEmployee";
            this.chkSelectEmployee.Size = new System.Drawing.Size(35, 35);
            this.chkSelectEmployee.TabIndex = 81;
            this.chkSelectEmployee.UseVisualStyleBackColor = false;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.White;
            this.lblName.Font = new System.Drawing.Font("Bookman Old Style", 8.5F);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblName.Location = new System.Drawing.Point(80, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(179, 27);
            this.lblName.TabIndex = 80;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // employeeProfilePicture
            // 
            this.employeeProfilePicture.AutoRoundedCorners = true;
            this.employeeProfilePicture.BackColor = System.Drawing.Color.White;
            this.employeeProfilePicture.BorderRadius = 26;
            this.employeeProfilePicture.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.employeeProfilePicture.ImageRotate = 0F;
            this.employeeProfilePicture.Location = new System.Drawing.Point(19, 8);
            this.employeeProfilePicture.Name = "employeeProfilePicture";
            this.employeeProfilePicture.Size = new System.Drawing.Size(55, 55);
            this.employeeProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.employeeProfilePicture.TabIndex = 79;
            this.employeeProfilePicture.TabStop = false;
            // 
            // SampleEmployeeListCardForReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.panelEmployeeListCard);
            this.Name = "SampleEmployeeListCardForReport";
            this.Size = new System.Drawing.Size(305, 71);
            this.panelEmployeeListCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeeProfilePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2Panel panelEmployeeListCard;
        private System.Windows.Forms.Label lblName;
        public Guna.UI2.WinForms.Guna2PictureBox employeeProfilePicture;
        private System.Windows.Forms.CheckBox chkSelectEmployee;
    }
}
