using System;
using System.Collections.Generic;
using System.Windows.Forms;

using NewsAgencyApp.Helper;
using NewsAgencyApp.Models;

namespace NewsAgencyApp.AdminPortal
{
    public partial class CreateArticleForm : Form
    {
        List<Category> categoriesList = new List<Category>();

        public CreateArticleForm()
        {
            InitializeComponent();

            this.CenterToParent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void CreateArticleForm_Load(object sender, EventArgs e)
        {
            setupCategoriesComboBox();
        }

        private void setupCategoriesComboBox()
        {
            categoryComboBox.SelectedItem = null; // Default to selected null
            categoryComboBox.SelectedText = "--Select--";  // Default to select text

            categoryComboBox.DisplayMember = "Text"; // Update the combobox to display the Text value
            categoryComboBox.ValueMember = "Value"; // Update the combobox to make the Value to be considred value

            categoriesList = Category.FindAll(); // Find all categories
            this.renderCategoriesComboBox(); // Render the categories combobox method
        }

        /**
         * Render the categories combobox items 
        */
        private void renderCategoriesComboBox()
        {
            foreach (var category in categoriesList)
                categoryComboBox.Items.Add(new ComboboxItem() { Text = category.Name, Value = category });
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            ComboboxItem selectedItem = categoryComboBox.SelectedItem as ComboboxItem; // selected categoriy item

            if (selectedItem == null)
            {
                MessageBox.Show("Please select a category first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (titleTextBox.Text.Length == 0 || contentRichTextBox.Text.Length == 0)
            {
                MessageBox.Show("Please fill the title and the content details first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Article article = new Article()
            {
                Title = titleTextBox.Text,
                Content = contentRichTextBox.Text,
                User = AuthenticationContext.Instance().State.CurrentUser, // current logged in user
                Category = selectedItem.Value as Category // find the category object from the list by id
            };
            article.GenerateKeywords();
            article.Create();

            this.Close();
        }
    }
}
