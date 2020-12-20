using System;
using System.Data;
using System.Windows.Forms;


namespace NewsAgencyApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = this.usernameTextBox.Text;
            string password = this.passwordTextBox.Text;

            Models.User user = AuthenticationContext.Instance().Login(username, password);

            if (user != null)
                this.Close();
            else
                MessageBox.Show("Invalid username or password, try again.");
        }
    }
}
