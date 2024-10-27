namespace GUTZ_Capstone_Project
{
    partial class EmployeeLeave
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
            this.panelEmploymentDetails = new Guna.UI2.WinForms.Guna2Panel();
            this.EmployeeListCardEmployeeDetailsCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblID = new System.Windows.Forms.Label();
            this.EmployeeListCardEmployeeDetailsCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEmploymentDetails
            // 
            this.panelEmploymentDetails.BackColor = System.Drawing.Color.White;
            this.panelEmploymentDetails.BorderColor = System.Drawing.Color.Gainsboro;
            this.panelEmploymentDetails.BorderRadius = 8;
            this.panelEmploymentDetails.BorderThickness = 1;
            this.panelEmploymentDetails.FillColor = System.Drawing.Color.White;
            this.panelEmploymentDetails.Location = new System.Drawing.Point(48, 120);
            this.panelEmploymentDetails.Margin = new System.Windows.Forms.Padding(0);
            this.panelEmploymentDetails.Name = "panelEmploymentDetails";
            this.panelEmploymentDetails.ShadowDecoration.BorderRadius = 15;
            this.panelEmploymentDetails.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(194)))), ((int)(((byte)(155)))));
            this.panelEmploymentDetails.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(2);
            this.panelEmploymentDetails.Size = new System.Drawing.Size(708, 430);
            this.panelEmploymentDetails.TabIndex = 87;
            // 
            // EmployeeListCardEmployeeDetailsCard
            // 
            this.EmployeeListCardEmployeeDetailsCard.BackColor = System.Drawing.Color.Transparent;
            this.EmployeeListCardEmployeeDetailsCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(60)))), ((int)(((byte)(50)))));
            this.EmployeeListCardEmployeeDetailsCard.BorderRadius = 4;
            this.EmployeeListCardEmployeeDetailsCard.Controls.Add(this.lblID);
            this.EmployeeListCardEmployeeDetailsCard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(60)))), ((int)(((byte)(50)))));
            this.EmployeeListCardEmployeeDetailsCard.ForeColor = System.Drawing.Color.White;
            this.EmployeeListCardEmployeeDetailsCard.Location = new System.Drawing.Point(48, 42);
            this.EmployeeListCardEmployeeDetailsCard.Name = "EmployeeListCardEmployeeDetailsCard";
            this.EmployeeListCardEmployeeDetailsCard.ShadowDecoration.BorderRadius = 15;
            this.EmployeeListCardEmployeeDetailsCard.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.EmployeeListCardEmployeeDetailsCard.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(1);
            this.EmployeeListCardEmployeeDetailsCard.Size = new System.Drawing.Size(708, 55);
            this.EmployeeListCardEmployeeDetailsCard.TabIndex = 63;
            // 
            // lblID
            // 
            this.lblID.Font = new System.Drawing.Font("Roboto", 15F);
            this.lblID.ForeColor = System.Drawing.Color.White;
            this.lblID.Location = new System.Drawing.Point(60, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(582, 53);
            this.lblID.TabIndex = 61;
            this.lblID.Text = "Manage Employee Leave";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmployeeLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(803, 582);
            this.Controls.Add(this.EmployeeListCardEmployeeDetailsCard);
            this.Controls.Add(this.panelEmploymentDetails);
            this.Name = "EmployeeLeave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EmployeeLeave_Load);
            this.EmployeeListCardEmployeeDetailsCard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public Guna.UI2.WinForms.Guna2Panel panelEmploymentDetails;
        public Guna.UI2.WinForms.Guna2Panel EmployeeListCardEmployeeDetailsCard;
        private System.Windows.Forms.Label lblID;
    }
}