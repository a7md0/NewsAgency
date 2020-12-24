using System;
using System.Windows.Forms;

using NewsAgencyApp.Models;

namespace NewsAgencyApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            this.CenterToParent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = this.usernameTextBox.Text;
            string password = this.passwordTextBox.Text;

            User user = AuthenticationContext.Instance().Login(username, password);

            if (user != null)
            {
                MessageBox.Show(string.Format("Welcome {0}!", user.FullName), "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                var response = MessageBox.Show("Invalid username or password", "Invalid credentials", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if (response == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
