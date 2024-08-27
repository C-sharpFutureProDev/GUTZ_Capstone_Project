using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            //this.Size = new Size(1550, 950);
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

        private void FormEmployeeProfile_Load(object sender, EventArgs e)
        {

        }
    }
}
