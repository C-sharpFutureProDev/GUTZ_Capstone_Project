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
    public partial class FormLoading : Form
    {
        private FormDashboard formDashboard;
        private FormLogin formLogin;

        public FormLoading(FormLogin formLogin)
        {
            InitializeComponent();
            InitializeComponent();
            this.Size = new Size(575, 30);
            formDashboard = new FormDashboard();
            this.formLogin = formLogin;
        }

        private void FormLoading_Load(object sender, EventArgs e)
        {
            // Set the initial size of the panel to 0
            panel2.Width = 0;

            // Start the timer
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Increase the width of the panel by 3 pixels
            panel2.Width += 3;

            // Check if the panel has reached the desired width
            if (panel2.Width >= 599)
            {
                // Stop the timer
                timer1.Stop();

                // Show the FormDashboard and close the FormLogin
                formDashboard.Show();
                //formLogin.Close(); // Close the login form instead of hiding
                //this.Close();
            }
        }

        private void FormLoading_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Dispose();
        }
    }
}