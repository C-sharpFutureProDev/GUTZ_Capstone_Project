using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GUTZ_Capstone_Project
{
    public partial class FormLogin : Form
    {
        private int attemptCount = 0;
        private bool isLockedOut = false;
        private int lockoutDuration = 30;
        private string currentLoginAdminID;

        public FormLogin()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;

            timer2.Interval = 2000;
            timer2.Tick += timer2_Tick;

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FormLogin_KeyDown);
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
            lblMessage.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (isLockedOut)
            {
                MessageBox.Show("Please wait before trying again.", "Locked Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();

                return;
            }

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
                string sqlLogin = "SELECT emp_id FROM tbl_users WHERE username = @username AND password = @password";
                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@username", txtUsername.Text },
                    { "@password", txtPassword.Text }
                };

                DataTable dt = DB_OperationHelperClass.ParameterizedQueryData(sqlLogin, parameters);

                if (dt.Rows.Count > 0)
                {
                    currentLoginAdminID = dt.Rows[0]["emp_id"].ToString();
                    FormLoading formLoading = new FormLoading(currentLoginAdminID);
                    formLoading.Show();
                    this.Hide();
                }
                else
                {
                    attemptCount++;

                    if (attemptCount >= 3)
                    {
                        isLockedOut = true;
                        btnLogin.Enabled = false;
                        lockoutDuration = 30;
                        lblMessage.Text = "Too many failed attempts! Please wait 30 seconds.";
                        timer1.Start();
                    }
                    else
                    {
                        lblMessage.Text = $"Invalid username or password. Attempts left: {3 - attemptCount}";
                        timer2.Stop();
                        timer2.Start();
                    }

                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
            catch
            {
                MessageBox.Show("An error occurred while processing the login request.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lockoutDuration > 0)
            {
                lblMessage.Text = $"Please wait: {lockoutDuration--} seconds left.";
            }
            else
            {
                timer1.Stop();
                isLockedOut = false;
                attemptCount = 0;

                lblMessage.Text = "You can try logging in again.";
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
                btnLogin.Enabled = true;

                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            timer2.Stop();
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.X)
            {
                Application.Exit();
            }
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer1.Dispose();
            timer2.Dispose();
        }
    }
}
