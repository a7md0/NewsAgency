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
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) // Handle menu exit option
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) // Handle menu about option
        {
            MessageBox.Show("(c) 2020, Ahmed Naser", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void authStateChanged(AuthenticationState state) // Handle auth state change (called from the observer class)
        {
            if (state is AuthenticatedState) // if the state is authenticted
            {
                loginLogoutToolStripMenuItem.Text = "Logout"; // Change the option to logout

                if (state.CurrentUser is SuperUser) // if the current user is superuser then enable the admin portal option
                {
                    adminPortalToolStripMenuItem.Enabled = true;
                }
            } else // if the state is not authenticted
            {
                loginLogoutToolStripMenuItem.Text = "Login"; // Make the option login
                adminPortalToolStripMenuItem.Enabled = false; // Disable the admin portal
            }
        }

        private void loginLogoutToolStripMenuItem_Click(object sender, EventArgs e) // Handle menu login/logout option
        {
            if (AuthenticationContext.Instance().State is UnauthenticatedState) // if currently unauthencitated
            {
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog(); // show the login form as dialog
            } else
            {
                // prompt for logout
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes) // if response was yes
                    AuthenticationContext.Instance().Logout(); // Logout using the auth context
            }
        }

        private void adminPortalToolStripMenuItem_Click(object sender, EventArgs e) // Handle menu admin portal option
        {
            AdminPortal.AdminForm adminForm = new AdminPortal.AdminForm(this);
            adminForm.ShowDialog();
            triggerFindArticles();
        }
        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) // FormClosing event handle
        {
            var connection = DBMgr.DatabaseFactory().Connection(); // Get the db connection
            if (connection != null && connection.State != System.Data.ConnectionState.Closed) // if the connection is not closed
            {
                connection.Close(); // Close the connection
            }
        }

        #region Articles
        private List<Article> articlesList; // list of articles to display

        private void setupArticlesListView() // Setup the articles list
        {
            articlesListView.View = View.Details; // Important to make the list view show details ( columns )
            articlesListView.FullRowSelect = true; // Select the whole row
            articlesListView.GridLines = true; // Show grid lines on the list view

            triggerFindArticles(); // trigger the query
        }

        private void renderArticlesListView() // render the artciels
        {
            articlesListView.Items.Clear(); // Clear articles list view items

            foreach (var article in articlesList) // for each article in the list 
            {
                ListViewItem item = new ListViewItem(article.Title); // Make title the 1st col
                item.SubItems.Add(article.NumberOfViews.ToString()); // Add number of views
                item.SubItems.Add(article.User.FullName); // Add full name
                item.SubItems.Add(article.Category.Name); // Add category name
                item.SubItems.Add(article.CreatedAt); // Add date

                articlesListView.Items.Add(item); // Add the constructed item to the list
            }
        }

        private void triggerFindArticles() // Trigger the select query
        {
            articlesList = Article.FindAll(null); // find all

            this.renderArticlesListView(); // Re-render articles list view
        }

        private Article selectedArticle() // Get the selected article or show error message
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

        private void viewArticleButton_Click(object sender, EventArgs e) // on view article button click
        {
            Article article = selectedArticle();

            if (article == null)
                return;

            this.showArticle(article);
        }

        private void articlesListView_DoubleClick(object sender, EventArgs e) // on double click on the list view
        {
            Article article = selectedArticle();

            if (article == null)
                return;

            this.showArticle(article);
        }

        private void showArticle(Article article) // the show article function to show th form
        {
            ViewArticle viewArticleForm = new ViewArticle();
            viewArticleForm.Article = article;

            viewArticleForm.ShowDialog();
            renderArticlesListView();
        }
        #endregion
    }
}
