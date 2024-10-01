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
    public partial class EmployeePreviousWorkingExperience : Form
    {
        string _id_ = "";

        public EmployeePreviousWorkingExperience(string id_)
        {
            InitializeComponent();
            if (id_ != null)
            {
                this._id_ = id_;
            }
        }

        private void EmployeePreviousWorkingExperience_Load(object sender, EventArgs e)
        {
            
        }
    }
}
