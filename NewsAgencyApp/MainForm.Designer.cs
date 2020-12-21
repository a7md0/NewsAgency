namespace NewsAgencyApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ColumnHeader titleColumnHeader;
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.portalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginLogoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminPortalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.articlesListView = new System.Windows.Forms.ListView();
            this.authorColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewArticleButton = new System.Windows.Forms.Button();
            titleColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleColumnHeader
            // 
            titleColumnHeader.Text = "Title";
            titleColumnHeader.Width = 160;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portalToolStripMenuItem,
            this.adminPortalToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(567, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // portalToolStripMenuItem
            // 
            this.portalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginLogoutToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.portalToolStripMenuItem.Name = "portalToolStripMenuItem";
            this.portalToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.portalToolStripMenuItem.Text = "App";
            // 
            // loginLogoutToolStripMenuItem
            // 
            this.loginLogoutToolStripMenuItem.DoubleClickEnabled = true;
            this.loginLogoutToolStripMenuItem.Name = "loginLogoutToolStripMenuItem";
            this.loginLogoutToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.loginLogoutToolStripMenuItem.Text = "Login";
            this.loginLogoutToolStripMenuItem.Click += new System.EventHandler(this.loginLogoutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(101, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // adminPortalToolStripMenuItem
            // 
            this.adminPortalToolStripMenuItem.Name = "adminPortalToolStripMenuItem";
            this.adminPortalToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.adminPortalToolStripMenuItem.Text = "Admin Portal";
            this.adminPortalToolStripMenuItem.Visible = false;
            this.adminPortalToolStripMenuItem.Click += new System.EventHandler(this.adminPortalToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // articlesListView
            // 
            this.articlesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            titleColumnHeader,
            this.authorColumnHeader,
            this.categoryColumnHeader,
            this.dateColumnHeader});
            this.articlesListView.HideSelection = false;
            this.articlesListView.Location = new System.Drawing.Point(12, 36);
            this.articlesListView.Name = "articlesListView";
            this.articlesListView.Size = new System.Drawing.Size(540, 206);
            this.articlesListView.TabIndex = 1;
            this.articlesListView.UseCompatibleStateImageBehavior = false;
            this.articlesListView.DoubleClick += new System.EventHandler(this.articlesListView_DoubleClick);
            // 
            // authorColumnHeader
            // 
            this.authorColumnHeader.Text = "Author";
            this.authorColumnHeader.Width = 100;
            // 
            // categoryColumnHeader
            // 
            this.categoryColumnHeader.Text = "Category";
            this.categoryColumnHeader.Width = 120;
            // 
            // dateColumnHeader
            // 
            this.dateColumnHeader.Text = "Date";
            this.dateColumnHeader.Width = 140;
            // 
            // viewArticleButton
            // 
            this.viewArticleButton.Location = new System.Drawing.Point(205, 257);
            this.viewArticleButton.Name = "viewArticleButton";
            this.viewArticleButton.Size = new System.Drawing.Size(161, 23);
            this.viewArticleButton.TabIndex = 4;
            this.viewArticleButton.Text = "View Article";
            this.viewArticleButton.UseVisualStyleBackColor = true;
            this.viewArticleButton.Click += new System.EventHandler(this.viewArticleButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 292);
            this.Controls.Add(this.viewArticleButton);
            this.Controls.Add(this.articlesListView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "News Agency";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem portalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginLogoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ListView articlesListView;
        private System.Windows.Forms.Button viewArticleButton;
        private System.Windows.Forms.ToolStripMenuItem adminPortalToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader authorColumnHeader;
        private System.Windows.Forms.ColumnHeader categoryColumnHeader;
        private System.Windows.Forms.ColumnHeader dateColumnHeader;
    }
}

