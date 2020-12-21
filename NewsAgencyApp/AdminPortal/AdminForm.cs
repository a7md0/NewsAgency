using System;
using System.Collections.Generic;
using System.Windows.Forms;

using NewsAgencyApp.Helper;
using NewsAgencyApp.Models;

namespace NewsAgencyApp.AdminPortal
{
    public partial class AdminForm : Form
    {
        Form parent;
        List<Category> categoriesList = new List<Category>();

        public AdminForm(Form parent)
        {
            InitializeComponent();

            this.parent = parent;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            var observer = AuthenticationContext.Instance().AuthenticationObserverInstance();
            observer.nextDelegate = authStateChanged;

            User user = AuthenticationContext.Instance().State.CurrentUser;
            nametypeToolStripMenuItem.Text = String.Format("{0} ({1})", user.FullName, user.Username);

            tabControl.SelectedIndex = tabControl.TabPages.Count - 1;
            tabControl.SelectedIndex = 0;

            if (this.parent != null)
            {
                this.parent.Hide();
            }
        }

        private void authStateChanged(AuthenticationState state)
        {
            if (state is UnauthenticatedState)
            {
                this.Close();
            }
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.parent.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
                AuthenticationContext.Instance().Logout();
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region ManageArticlesTab
        List<Article> articlesList = new List<Article>();
        List<User> usersList = new List<User>();

        IDictionary<string, FilterItem> articlesFilters = new Dictionary<string, FilterItem>();

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
                ListViewItem item = new ListViewItem(article.Id.ToString()); // Make title the 1st col
                item.SubItems.Add(article.Title);
                item.SubItems.Add(article.NumberOfViews.ToString());
                item.SubItems.Add(article.User.FullName); // Add full name to 2nd col
                item.SubItems.Add(article.Category.Name); // Add category name to 3rd col
                item.SubItems.Add(article.CreatedAt); // Add date to 4th col
                item.SubItems.Add(article.UpdatedAt);

                articlesListView.Items.Add(item); // Add the constructed item to the list
            }
        }

        private void setupCategoriesComboBox()
        {
            categoriesComboBox.ResetText();

            categoriesComboBox.SelectedItem = null; // Default to selected null
            categoriesComboBox.SelectedText = "--Select--";  // Default to select text

            categoriesComboBox.DisplayMember = "Text"; // Update the combobox to display the Text value
            categoriesComboBox.ValueMember = "Value"; // Update the combobox to make the Value to be considred value

            categoriesList = Category.FindAll(); // Find all categories
            this.renderCategoriesComboBox(); // Render the categories combobox method
        }

        /**
         * Render the categories combobox items 
        */
        private void renderCategoriesComboBox()
        {
            categoriesComboBox.Items.Clear();
            categoriesComboBox.Items.Add(new ComboboxItem { Text = "--Select--", Value = null });

            foreach (var category in categoriesList)
                categoriesComboBox.Items.Add(new ComboboxItem { Text = category.Name, Value = category });
        }


        private void setupAuthorsComboBox()
        {
            authorsComboBox.ResetText();

            authorsComboBox.SelectedItem = null; // Default to selected null
            authorsComboBox.SelectedText = "--Select--";  // Default to select text

            authorsComboBox.DisplayMember = "Text"; // Update the combobox to display the Text value
            authorsComboBox.ValueMember = "Value"; // Update the combobox to make the Value to be considred value

            usersList = User.FindAll(); // Find all users
            this.renderAuthorsComboBox(); // Render the categories combobox method
        }

        /**
         * Render the auhtors combobox items 
        */
        private void renderAuthorsComboBox()
        {
            authorsComboBox.Items.Clear();
            authorsComboBox.Items.Add(new ComboboxItem { Text = "--Select--", Value = null });

            foreach (var user in usersList)
                authorsComboBox.Items.Add(new ComboboxItem { Text = user.FullName, Value = user });
        }

        private void categoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem selectedItem = ((ComboBox)sender).SelectedItem as ComboboxItem; // selected categoriy item

            if (selectedItem == null || selectedItem.Value == null)
                articlesFilters.Remove("categoryId");
            else
            {
                int id = (selectedItem.Value as Category).Id;
                articlesFilters["categoryId"] = new FilterItem("CategoryId", "=", id.ToString());
            }

            triggerFindArticles();
        }

        private void authorsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem selectedItem = ((ComboBox)sender).SelectedItem as ComboboxItem; // selected user item

            if (selectedItem == null || selectedItem.Value == null)
                articlesFilters.Remove("userId");
            else
            {
                int id = (selectedItem.Value as User).Id;
                articlesFilters["userId"] = new FilterItem("UserId", "=", id.ToString());
            }

            triggerFindArticles();
        }

        private void articleSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox search = (TextBox)sender;

            if (search.TextLength > 0)
                articlesFilters["search"] = new FilterItem("Keywords", "LIKE", search.Text.Trim().Replace(" ", "%"));
            else
                articlesFilters.Remove("search");

            triggerFindArticles();
        }

        private void triggerFindArticles()
        {
            articlesList = Article.FindAll(articlesFilters); // Use built filters and pass them to the findAll method and assign to the current 

            this.renderArticlesListView(); // Re-render articles list view
        }

        private Article SelectedArticle()
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

        private void createArticleButton_Click(object sender, EventArgs e)
        {
            CreateArticleForm createArticleForm = new CreateArticleForm();
            createArticleForm.ShowDialog();

            triggerFindArticles();
        }

        private void viewArticleButton_Click(object sender, EventArgs e)
        {
            Article article = this.SelectedArticle();
            if (article == null)
                return;

            this.showArticle(article);

            triggerFindArticles();
        }

        private void editArticleButton_Click(object sender, EventArgs e)
        {
            Article article = this.SelectedArticle();
            if (article == null)
                return;

            EditArticleForm editArticleForm = new EditArticleForm();
            editArticleForm.Article = article;
            editArticleForm.ShowDialog();

            triggerFindArticles();
        }

        private void removeArticleButton_Click(object sender, EventArgs e)
        {
            Article article = this.SelectedArticle();
            if (article == null)
                return;

            var response = MessageBox.Show("Are you sure that you want to delete this article?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response == DialogResult.Yes)
            {
                bool removeResult = article.Remove();
                if (removeResult)
                {
                    articlesList.Remove(article);
                    renderArticlesListView();
                }
            }
        }

        private void showArticle(Article article)
        {
            ViewArticle viewArticleForm = new ViewArticle();
            viewArticleForm.Article = article;

            viewArticleForm.ShowDialog();
        }
        #endregion

        #region ManageCateogiresTab
        private void setupCategoriesListView()
        {
            categoriesListView.View = View.Details; // Important to make the list view show details ( columns )
            categoriesListView.FullRowSelect = true; // Select the whole row
            categoriesListView.GridLines = true;

            renderCategoriesListView();
        }

        private void renderCategoriesListView()
        {
            categoriesListView.Items.Clear();

            foreach (var category in categoriesList)
            {
                ListViewItem item = new ListViewItem(category.Id.ToString()); // Make title the 1st col
                item.SubItems.Add(category.Name);

                categoriesListView.Items.Add(item); // Add the constructed item to the list
            }
        }

        private void triggerFindCategories()
        {
            categoriesList = Category.FindAll();

            this.renderCategoriesListView(); // Re-render
        }

        private void createCategoryButton_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox("Enter new category name", "New category", null, 0, 0);

            if (name.Length > 0)
            {
                Category category = new Category(name);
                category.Create();

                triggerFindCategories();
            }
        }

        private void removeCategoryButton_Click(object sender, EventArgs e)
        {
            Category category = this.SelectedCategory();
            if (category == null)
                return;

            var response = MessageBox.Show("Are you sure that you want to delete this category?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response == DialogResult.Yes)
            {
                bool removeResult = category.Remove();
                if (removeResult)
                {
                    categoriesList.Remove(category);
                    renderCategoriesListView();
                }
            }
        }

        private Category SelectedCategory()
        {
            if (categoriesListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select category first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            var selectedItem = categoriesListView.SelectedItems[0];
            Category category = categoriesList[selectedItem.Index];

            return category;
        }
        #endregion

        #region ReportsTab
        #endregion

        #region BackupRestoreTab
        private void backupButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(String.Format("Backup have been save successfully to {0}", saveFileDialog1.FileName), "Backup");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                restoreFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void pickBackupPath_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                backupFilePath.Text = saveFileDialog1.FileName;
        }
        #endregion

        private void tabControl_Selecting(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;

            Console.WriteLine(tabControl.SelectedTab.Name);
            switch (tabControl.SelectedTab.Name)
            {
                case "manageArticlesTabPage":
                    setupArticlesListView();
                    setupCategoriesComboBox();
                    setupAuthorsComboBox();
                    break;
                case "manageCategoriesTabPage":
                    setupCategoriesListView();
                    break;
                case "reportsTabPage":
                    // TODO: This line of code loads data into the 'databaseDataSet.LargestCategoryView' table. You can move, or remove it, as needed.
                    this.largestCategoryViewTableAdapter.Fill(this.databaseDataSet.LargestCategoryView);
                    // TODO: This line of code loads data into the 'databaseDataSet.Article' table. You can move, or remove it, as needed.
                    this.articleTableAdapter.Fill(this.databaseDataSet.Article);

                    this.reportViewer1.RefreshReport();
                    this.reportViewer2.RefreshReport();
                    break;
            }
        }
    }
}
