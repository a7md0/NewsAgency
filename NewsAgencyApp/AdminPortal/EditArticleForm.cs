using System;
using System.Collections.Generic;
using System.Windows.Forms;

using NewsAgencyApp.Helper;
using NewsAgencyApp.Models;

namespace NewsAgencyApp.AdminPortal
{
    partial class EditArticleForm : Form
    {
        private Article article;
        private List<Category> categoriesList;

        public EditArticleForm()
        {
            InitializeComponent();

            this.CenterToParent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void EditArticleForm_Load(object sender, EventArgs e)
        {

        }

        public Article Article
        {
            get
            {
                return article;
            }

            set
            {
                article = value;

                this.setupCategoriesComboBox();
                this.renderDetails();
            }
        }

        private void renderDetails()
        {
            idTextBox.Text = article.Id.ToString();
            titleTextBox.Text = article.Title;
            contentRichTextBox.Text = article.Content;
            keywordsTextBox.Text = article.Keywords;
            chooseCurrentCategory(article.Category);
            authorTextBox.Text = string.Format("{0} ({1})", article.User.FullName, article.User.Username);
            createdTextBox.Text = article.CreatedAt;
            lastUpdatedTextBox.Text = article.UpdatedAt;
        }

        private void setupCategoriesComboBox()
        {
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
                categoryComboBox.Items.Add(new ComboboxItem { Text = category.Name, Value = category });
        }

        private void chooseCurrentCategory(Category category)
        {
            foreach (ComboboxItem item in categoryComboBox.Items)
            {
                Category c = item.Value as Category;
                if (c.Id == category.Id)
                {
                    categoryComboBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ComboboxItem selectedItem = categoryComboBox.SelectedItem as ComboboxItem;

            article.Title = titleTextBox.Text;
            article.Content = contentRichTextBox.Text;
            article.Keywords = keywordsTextBox.Text;
            article.Category = selectedItem.Value as Category;

            article.Update();

            MessageBox.Show("Article was updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
