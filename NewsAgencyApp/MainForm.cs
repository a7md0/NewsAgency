using System;
using System.Windows.Forms;

using System.Collections.Generic;

namespace NewsAgencyApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var observer = AuthenticationContext.Instance().AuthenticationObserverInstance();
            observer.nextDelegate = authStateChanged;

            loadArticles();
        }

        #region Menu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("(c) 2020, Ahmed Naser", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void authStateChanged(AuthenticationState state)
        {
            if (state is AuthenticatedState)
            {
                loginLogoutToolStripMenuItem.Text = "Logout";

                if (state.CurrentUser is Models.SuperUser)
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
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var connection = DBMgr.DatabaseFactory().Connection();
            if (connection != null && connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        #region Articles
        private List<Models.Article> articles;

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

                articlesListView.View = View.Details; // Important to make the list view show details ( columns )
                articlesListView.FullRowSelect = true; // Select the whole row
                articlesListView.GridLines = true;
            }
        }

        private Models.Article selectedArticle()
        {
            if (articlesListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select article first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            var selectedItem = articlesListView.SelectedItems[0];
            Models.Article article = articles[selectedItem.Index];

            return article;
        }

        private void viewArticleButton_Click(object sender, EventArgs e)
        {
            Models.Article article = selectedArticle();

            if (article == null)
                return;

            this.showArticle(article);
        }

        private void articlesListView_DoubleClick(object sender, EventArgs e)
        {
            Models.Article article = selectedArticle();

            if (article == null)
                return;

            this.showArticle(article);
        }

        private void showArticle(Models.Article article)
        {
            ViewArticle viewArticleForm = new ViewArticle();
            viewArticleForm.Article = article;

            viewArticleForm.ShowDialog();
        }
        #endregion
    }
}
