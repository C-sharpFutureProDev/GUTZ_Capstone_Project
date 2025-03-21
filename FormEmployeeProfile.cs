﻿using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    public partial class FormEmployeeProfile : Form
    {
        private string _empId = "";
        public FormEmployeeProfile(string empId_)
        {
            InitializeComponent();
            if (empId_ != null)
            {
                this._empId = empId_;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        // Method to set the rounded rectangle region
        /*private void SetFormRegion()
        {
            int radius = 25; // Border radius
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(0, 0, radius, radius, 180, 90); // Top-left
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90); // Top-right
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90); // Bottom-right
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90); // Bottom-left
            path.CloseFigure();
            this.Region = new Region(path);
        }*/

        private void FormEmployeeProfile_Load(object sender, EventArgs e)
        {
            if (_empId != null)
            {

            }
        }
    }
}
