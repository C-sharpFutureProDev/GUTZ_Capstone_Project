using Org.BouncyCastle.Asn1.Ocsp;
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
    public partial class SampleEmployeeListCardForReport : UserControl
    {
        private string _name;
        private Image _image;
        private int _empID;
        public event EventHandler CheckboxChanged;
        public CheckBox chkSelect;

        public SampleEmployeeListCardForReport()
        {
            InitializeComponent();
            chkSelectEmployee.CheckedChanged += chkSelect_CheckedChanged;
        }

        [Category("Custom Control")]
        public Image EmployeeProfilePic
        {
            get => _image;
            set
            {
                _image = value;
                employeeProfilePicture.Image = value;
            }
        }

        [Category("Custom Control")]
        public string EmployeeName
        {
            get => _name;
            set
            {
                _name = value;
                lblName.Text = value;
            }
        }

        [Category("Custom Control")]
        public int EmployeeID
        {
            get => _empID;
            set
            {
                _empID = value;
            }
        }

        // New property for the checkbox
        [Category("Custom Control")]
        public bool IsChecked
        {
            get => chkSelectEmployee.Checked;
            set => chkSelectEmployee.Checked = value;
        }

        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            CheckboxChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

