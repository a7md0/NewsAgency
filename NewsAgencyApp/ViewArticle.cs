using System;
using System.Windows.Forms;

using NewsAgencyApp.Models;

namespace NewsAgencyApp
{
    partial class ViewArticle : Form
    {
        private Article article;

        public ViewArticle()
        {
            InitializeComponent();

            this.CenterToParent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void ViewArticle_Load(object sender, EventArgs e)
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
                this.renderArticle();
                this.updateViewCount();
            }
        }

        private void renderArticle()
        {
            titleLabel.Text = article.Title;
            contentRichTextBox.Text = article.Content;
            detailsLabel.Text = string.Format("Posted by: {0} On {1} | Viewed {2} times", article.User.FullName, article.CreatedAt, article.NumberOfViews + 1);
        }

        private void updateViewCount()
        {
            this.article.Viewed();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
