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

            this.CenterToParent(); // Center the form to the parent form

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Make the form non-resizable
            this.MaximizeBox = false; // Disable the maximize button
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // Login using the auth context and grab the user if success
            User user = AuthenticationContext.Instance().Login(usernameTextBox.Text, passwordTextBox.Text);

            if (user != null) // if the user is not null
            {
                // Welcome message and close the login form
                MessageBox.Show(string.Format("Welcome {0}!", user.FullName), "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else // if the user is null
            {
                // Show error message, and offer retry or cancel
                var response = MessageBox.Show("Invalid username or password", "Invalid credentials", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                if (response == DialogResult.Cancel) // if the response was to cancel
                {
                    this.Close(); // Close the form
                }
            }
        }

        // Close button handle
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
