using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewsAgencyApp.AdminPortal
{
    public partial class AdminForm : Form
    {
        Form parent;

        List<Models.Article> articles = new List<Models.Article>();
        List<Models.Category> categories = new List<Models.Category>();
        List<Models.User> users = new List<Models.User>();

        IDictionary<string, string> filters = new Dictionary<string, string>();

        public AdminForm(Form parent)
        {
            InitializeComponent();

            this.parent = parent;
            if (this.parent != null)
            {
                this.parent.Hide();
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            var observer = AuthenticationContext.Instance().AuthenticationObserverInstance();
            observer.nextDelegate = authStateChanged;

            Models.User user = AuthenticationContext.Instance().State.CurrentUser;
            nametypeToolStripMenuItem.Text = String.Format("{0} ({1})", user.FullName, user.Username);

            loadArticlesList();
            loadCategoriesList();
            loadUsersList();
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

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
                AuthenticationContext.Instance().Logout();
        }

        private void backToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadArticlesList()
        {
            //articlesListView

            articles = Models.Article.FindAll();
            foreach (var article in articles)
            {
                ListViewItem item = new ListViewItem(article.Title);
                item.SubItems.Add(article.User.FullName);
                item.SubItems.Add(article.Category.Name);
                item.SubItems.Add(article.CreatedAt);

                articlesListView.Items.Add(item);

                articlesListView.View = View.Details;
            }
        }

        private void loadCategoriesList()
        {
            categories = Models.Category.FindAll();
            foreach (var category in categories)
            {
                categoriesComboBox.DisplayMember = "Text";
                categoriesComboBox.ValueMember = "Value";

                categoriesComboBox.Items.Add(new { Text = category.Name, Value = category.Id });
            }

            categoriesComboBox.SelectedItem = null;
            categoriesComboBox.SelectedText = "--Select--";
        }

        private void loadUsersList()
        {
            users = Models.User.FindAll();

            foreach (var user in users)
            {
                authorsComboBox.DisplayMember = "Text";
                authorsComboBox.ValueMember = "Value";

                authorsComboBox.Items.Add(new { Text = user.FullName, Value = user.Id });
            }

            authorsComboBox.SelectedItem = null;
            authorsComboBox.SelectedText = "--Select--";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

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

        private void categoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedItem = ((ComboBox)sender).SelectedItem;
            var propertyInfo = selectedItem.GetType().GetProperty("Value");

            if (selectedItem != null && propertyInfo != null)
            {
                int id = (int)propertyInfo.GetValue(selectedItem);
                filters["categoryId"] = string.Format("CategoryId = {0}", id);
            }
            else
            {
                filters.Remove("categoryId");
            }

            triggerFindArticles();
        }

        private void authorsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedItem = ((ComboBox)sender).SelectedItem;
            var propertyInfo = selectedItem.GetType().GetProperty("Value");

            if (selectedItem != null && propertyInfo != null)
            {
                int id = (int)propertyInfo.GetValue(selectedItem);
                filters["userId"] = string.Format("UserId = {0}", id);
            }
            else
            {
                filters.Remove("userId");
            }

            triggerFindArticles();
        }

        private void articleSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox search = articleSearchTextBox;

            if (search.TextLength > 0)
            {
                filters["search"] = string.Format("Title LIKE '%{0}%'", search.Text);
            }
            else
            {
                filters.Remove("search");
            }

            triggerFindArticles();
        }

        private void triggerFindArticles()
        {
            articlesListView.Items.Clear();
            articles = Models.Article.FindAll(filters);

            foreach (var article in articles)
            {
                ListViewItem item = new ListViewItem(article.Title);
                item.SubItems.Add(article.User.FullName);
                item.SubItems.Add(article.Category.Name);
                item.SubItems.Add(article.CreatedAt);

                articlesListView.Items.Add(item);

                articlesListView.View = View.Details;
            }
        }

        private void createArticleButton_Click(object sender, EventArgs e)
        {

        }

        private void viewArticleButton_Click(object sender, EventArgs e)
        {

        }

        private void editArticleButton_Click(object sender, EventArgs e)
        {

        }

        private void removeArticleButton_Click(object sender, EventArgs e)
        {

        }
    }
}
