using System;
using System.Windows.Forms;

using System.Collections.Generic;

namespace NewsAgencyApp
{
    public partial class MainForm : Form
    {
        private List<Models.Article> articles;

        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("(c) 2020, Ahmed Naser");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            /*User user = AuthenticationContext.Instance().Login("admin", "admin");
            Console.WriteLine(user.Id);
            Console.WriteLine(user.FullName);
            Console.WriteLine(user.Email);*/

            var observer = AuthenticationContext.Instance().AuthenticationObserverInstance();
            observer.nextDelegate = authStateChanged;

            //Models.Article article = new Models.Article("", "", null, null, "");
            loadArticles();
        }

        private void authStateChanged(AuthenticationState state)
        {
            if (state is AuthenticatedState)
            {
                loginLogoutToolStripMenuItem.Text = "Logout";

                if (state.CurrentUser is SuperUser)
                {
                    adminPortalToolStripMenuItem.Visible = true;
                }
            } else
            {
                loginLogoutToolStripMenuItem.Text = "Login";
                adminPortalToolStripMenuItem.Visible = false;
            }
        }

        private void loginLogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AuthenticationContext.Instance().State is UnauthenticatedState)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
            } else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                    AuthenticationContext.Instance().Logout();
            }
        }

        private void adminPortalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminPortal.AdminForm adminForm = new AdminPortal.AdminForm(this);
            adminForm.ShowDialog();
        }

        private void loadArticles()
        {
            articles = Models.Article.FindAll();
            foreach (var article in articles)
            {
                Console.WriteLine(article.Id);
                ListViewItem item = new ListViewItem(article.Title);
                item.SubItems.Add(article.User.FullName);
                item.SubItems.Add(article.Category.Name);
                item.SubItems.Add(article.CreatedAt);

                articlesListView.Items.Add(item);

                articlesListView.View = View.Details;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var connection = DBMgr.DatabaseFactory().Connection();
            if (connection != null && connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}
