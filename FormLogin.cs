using Guna.UI2.WinForms;
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
    public partial class FormLogin : Form
    {
        public int currentLoginAdminID;
        public FormLogin()
        {
            InitializeComponent();
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

        private void FormLogin_Load(object sender, EventArgs e)
        {
            iconUsername.IconSize = 45;
            iconPassword.IconSize = 40;
            iconUsername.Padding = new System.Windows.Forms.Padding(2, 16, 0, 0);
            iconPassword.Padding = new System.Windows.Forms.Padding(2, 16, 0, 0);
            txtPassword.PasswordChar = '•';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
                return;
            }

            try
            {
                // Query the database for the user
                string sqlLogin = "SELECT emp_id FROM tbl_users WHERE username = @username AND password = @password";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@username", txtUsername.Text },
                    { "@password", txtPassword.Text }
                };
                DataTable dt = DB_OperationHelperClass.ParameterizedQueryData(sqlLogin, parameters);

                // Check if a user is found
                if (dt.Rows.Count > 0)
                { 
                    currentLoginAdminID = int.Parse(dt.Rows[0]["emp_id"].ToString());
                    FormDashboard formDashboard = new FormDashboard(currentLoginAdminID);
                    formDashboard.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("An error occurred while processing the login request.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
    }
}
