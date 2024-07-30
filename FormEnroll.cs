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
    public partial class FormEnroll : Form
    {
        public FormEnroll()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1200, 800);
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void FormEnroll_Load(object sender, EventArgs e)
        {

        }
    }
}
