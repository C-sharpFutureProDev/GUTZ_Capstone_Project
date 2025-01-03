using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project.Forms
{
    public partial class FormPayrollManagement : Form
    {
        public FormPayrollManagement()
        {
            InitializeComponent();
        }

        private void FormPayrollManagement_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                SampleEmployeePayrollCard card = new SampleEmployeePayrollCard();
                flowLayoutPanel1.Controls.Add(card);
            }
        }
    }
}
