using System;
using System.Windows.Forms;

using System.Collections.Generic;

using NewsAgencyApp.Models;

namespace NewsAgencyApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.CenterToScreen();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var observer = AuthenticationContext.Instance().AuthenticationObserverInstance();
            observer.nextDelegate = authStateChanged;

            setupArticlesListView();
        }

        #region Menu
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("(c) 2020, Ahmed Naser", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void authStateChanged(AuthenticationState state)
        {
            if (state is AuthenticatedState)
            {
                loginLogoutToolStripMenuItem.Text = "Logout";

                if (state.CurrentUser is SuperUser)
                {
                    adminPortalToolStripMenuItem.Enabled = true;
                }
            } else
            {
                loginLogoutToolStripMenuItem.Text = "Login";
                adminPortalToolStripMenuItem.Enabled = false;
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
            triggerFindArticles();
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
        private List<Article> articlesList;

        private void setupArticlesListView()
        {
            articlesListView.View = View.Details; // Important to make the list view show details ( columns )
            articlesListView.FullRowSelect = true; // Select the whole row
            articlesListView.GridLines = true;

            triggerFindArticles();
        }

        private void renderArticlesListView()
        {
            articlesListView.Items.Clear(); // Clear articles list view items

            foreach (var article in articlesList)
            {
                ListViewItem item = new ListViewItem(article.Title); // Make title the 1st col
                item.SubItems.Add(article.NumberOfViews.ToString());
                item.SubItems.Add(article.User.FullName); // Add full name to 2nd col
                item.SubItems.Add(article.Category.Name); // Add category name to 3rd col
                item.SubItems.Add(article.CreatedAt); // Add date to 4th col

                articlesListView.Items.Add(item); // Add the constructed item to the list
            }
        }

        private void triggerFindArticles()
        {
            articlesList = Article.FindAll(null);

            this.renderArticlesListView(); // Re-render articles list view
        }

        private Article selectedArticle()
        {
            if (articlesListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select article first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            var selectedItem = articlesListView.SelectedItems[0];
            Article article = articlesList[selectedItem.Index];

            return article;
        }

        private void viewArticleButton_Click(object sender, EventArgs e)
        {
            Article article = selectedArticle();

            if (article == null)
                return;

            this.showArticle(article);
            renderArticlesListView();
        }

        private void articlesListView_DoubleClick(object sender, EventArgs e)
        {
            Article article = selectedArticle();

            if (article == null)
                return;

            this.showArticle(article);
        }

        private void showArticle(Article article)
        {
            ViewArticle viewArticleForm = new ViewArticle();
            viewArticleForm.Article = article;

            viewArticleForm.ShowDialog();
        }
        #endregion
    }
}
