namespace NewsAgencyApp.AdminPortal
{
    partial class AdminForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.manageArticlesTabPage = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.authorsComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.articleSearchTextBox = new System.Windows.Forms.TextBox();
            this.categoriesComboBox = new System.Windows.Forms.ComboBox();
            this.removeArticleButton = new System.Windows.Forms.Button();
            this.createArticleButton = new System.Windows.Forms.Button();
            this.editArticleButton = new System.Windows.Forms.Button();
            this.viewArticleButton = new System.Windows.Forms.Button();
            this.articlesListView = new System.Windows.Forms.ListView();
            this.titleColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.authorColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.manageCategoriesTabPage = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.generateReportsTabPage = new System.Windows.Forms.TabPage();
            this.backupRestoreTabPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.restoreButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button9 = new System.Windows.Forms.Button();
            this.restoreFilePath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pickBackupPath = new System.Windows.Forms.Button();
            this.backupFilePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.backupButton = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.backToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nametypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.manageArticlesTabPage.SuspendLayout();
            this.manageCategoriesTabPage.SuspendLayout();
            this.backupRestoreTabPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.manageArticlesTabPage);
            this.tabControl1.Controls.Add(this.manageCategoriesTabPage);
            this.tabControl1.Controls.Add(this.generateReportsTabPage);
            this.tabControl1.Controls.Add(this.backupRestoreTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(585, 411);
            this.tabControl1.TabIndex = 0;
            // 
            // manageArticlesTabPage
            // 
            this.manageArticlesTabPage.Controls.Add(this.label7);
            this.manageArticlesTabPage.Controls.Add(this.authorsComboBox);
            this.manageArticlesTabPage.Controls.Add(this.label2);
            this.manageArticlesTabPage.Controls.Add(this.label1);
            this.manageArticlesTabPage.Controls.Add(this.articleSearchTextBox);
            this.manageArticlesTabPage.Controls.Add(this.categoriesComboBox);
            this.manageArticlesTabPage.Controls.Add(this.removeArticleButton);
            this.manageArticlesTabPage.Controls.Add(this.createArticleButton);
            this.manageArticlesTabPage.Controls.Add(this.editArticleButton);
            this.manageArticlesTabPage.Controls.Add(this.viewArticleButton);
            this.manageArticlesTabPage.Controls.Add(this.articlesListView);
            this.manageArticlesTabPage.Location = new System.Drawing.Point(4, 22);
            this.manageArticlesTabPage.Name = "manageArticlesTabPage";
            this.manageArticlesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.manageArticlesTabPage.Size = new System.Drawing.Size(577, 385);
            this.manageArticlesTabPage.TabIndex = 0;
            this.manageArticlesTabPage.Text = "Manage articles";
            this.manageArticlesTabPage.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(401, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Author:";
            // 
            // authorsComboBox
            // 
            this.authorsComboBox.FormattingEnabled = true;
            this.authorsComboBox.Items.AddRange(new object[] {
            "--Select--"});
            this.authorsComboBox.Location = new System.Drawing.Point(448, 20);
            this.authorsComboBox.Name = "authorsComboBox";
            this.authorsComboBox.Size = new System.Drawing.Size(114, 21);
            this.authorsComboBox.TabIndex = 9;
            this.authorsComboBox.SelectedIndexChanged += new System.EventHandler(this.authorsComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Category:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Search:";
            // 
            // articleSearchTextBox
            // 
            this.articleSearchTextBox.Location = new System.Drawing.Point(64, 20);
            this.articleSearchTextBox.Name = "articleSearchTextBox";
            this.articleSearchTextBox.Size = new System.Drawing.Size(147, 20);
            this.articleSearchTextBox.TabIndex = 6;
            this.articleSearchTextBox.TextChanged += new System.EventHandler(this.articleSearchTextBox_TextChanged);
            // 
            // categoriesComboBox
            // 
            this.categoriesComboBox.FormattingEnabled = true;
            this.categoriesComboBox.Items.AddRange(new object[] {
            "--Select--"});
            this.categoriesComboBox.Location = new System.Drawing.Point(285, 20);
            this.categoriesComboBox.Name = "categoriesComboBox";
            this.categoriesComboBox.Size = new System.Drawing.Size(110, 21);
            this.categoriesComboBox.TabIndex = 5;
            this.categoriesComboBox.SelectedIndexChanged += new System.EventHandler(this.categoriesComboBox_SelectedIndexChanged);
            // 
            // removeArticleButton
            // 
            this.removeArticleButton.Location = new System.Drawing.Point(487, 148);
            this.removeArticleButton.Name = "removeArticleButton";
            this.removeArticleButton.Size = new System.Drawing.Size(75, 23);
            this.removeArticleButton.TabIndex = 4;
            this.removeArticleButton.Text = "Remove";
            this.removeArticleButton.UseVisualStyleBackColor = true;
            this.removeArticleButton.Click += new System.EventHandler(this.removeArticleButton_Click);
            // 
            // createArticleButton
            // 
            this.createArticleButton.Location = new System.Drawing.Point(487, 54);
            this.createArticleButton.Name = "createArticleButton";
            this.createArticleButton.Size = new System.Drawing.Size(75, 23);
            this.createArticleButton.TabIndex = 3;
            this.createArticleButton.Text = "Create";
            this.createArticleButton.UseVisualStyleBackColor = true;
            this.createArticleButton.Click += new System.EventHandler(this.createArticleButton_Click);
            // 
            // editArticleButton
            // 
            this.editArticleButton.Location = new System.Drawing.Point(487, 119);
            this.editArticleButton.Name = "editArticleButton";
            this.editArticleButton.Size = new System.Drawing.Size(75, 23);
            this.editArticleButton.TabIndex = 2;
            this.editArticleButton.Text = "Edit";
            this.editArticleButton.UseVisualStyleBackColor = true;
            this.editArticleButton.Click += new System.EventHandler(this.editArticleButton_Click);
            // 
            // viewArticleButton
            // 
            this.viewArticleButton.Location = new System.Drawing.Point(487, 90);
            this.viewArticleButton.Name = "viewArticleButton";
            this.viewArticleButton.Size = new System.Drawing.Size(75, 23);
            this.viewArticleButton.TabIndex = 1;
            this.viewArticleButton.Text = "View";
            this.viewArticleButton.UseVisualStyleBackColor = true;
            this.viewArticleButton.Click += new System.EventHandler(this.viewArticleButton_Click);
            // 
            // articlesListView
            // 
            this.articlesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.titleColumnHeader,
            this.authorColumnHeader,
            this.categoryColumnHeader,
            this.dateColumnHeader});
            this.articlesListView.HideSelection = false;
            this.articlesListView.Location = new System.Drawing.Point(17, 55);
            this.articlesListView.Name = "articlesListView";
            this.articlesListView.Size = new System.Drawing.Size(454, 311);
            this.articlesListView.TabIndex = 0;
            this.articlesListView.UseCompatibleStateImageBehavior = false;
            // 
            // titleColumnHeader
            // 
            this.titleColumnHeader.Text = "Title";
            this.titleColumnHeader.Width = 160;
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
            // manageCategoriesTabPage
            // 
            this.manageCategoriesTabPage.Controls.Add(this.label3);
            this.manageCategoriesTabPage.Controls.Add(this.textBox2);
            this.manageCategoriesTabPage.Controls.Add(this.button5);
            this.manageCategoriesTabPage.Controls.Add(this.button6);
            this.manageCategoriesTabPage.Controls.Add(this.button7);
            this.manageCategoriesTabPage.Controls.Add(this.button8);
            this.manageCategoriesTabPage.Controls.Add(this.listView2);
            this.manageCategoriesTabPage.Location = new System.Drawing.Point(4, 22);
            this.manageCategoriesTabPage.Name = "manageCategoriesTabPage";
            this.manageCategoriesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.manageCategoriesTabPage.Size = new System.Drawing.Size(577, 385);
            this.manageCategoriesTabPage.TabIndex = 1;
            this.manageCategoriesTabPage.Text = "Manage categories";
            this.manageCategoriesTabPage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Search:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(63, 20);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(213, 20);
            this.textBox2.TabIndex = 13;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(489, 113);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "Remove";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(489, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 11;
            this.button6.Text = "Create";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(489, 84);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 10;
            this.button7.Text = "Edit";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(489, 55);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 9;
            this.button8.Text = "View";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(16, 55);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(454, 311);
            this.listView2.TabIndex = 8;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // generateReportsTabPage
            // 
            this.generateReportsTabPage.Location = new System.Drawing.Point(4, 22);
            this.generateReportsTabPage.Name = "generateReportsTabPage";
            this.generateReportsTabPage.Size = new System.Drawing.Size(577, 385);
            this.generateReportsTabPage.TabIndex = 2;
            this.generateReportsTabPage.Text = "Generate reports";
            this.generateReportsTabPage.UseVisualStyleBackColor = true;
            // 
            // backupRestoreTabPage
            // 
            this.backupRestoreTabPage.Controls.Add(this.groupBox2);
            this.backupRestoreTabPage.Controls.Add(this.groupBox1);
            this.backupRestoreTabPage.Location = new System.Drawing.Point(4, 22);
            this.backupRestoreTabPage.Name = "backupRestoreTabPage";
            this.backupRestoreTabPage.Size = new System.Drawing.Size(577, 385);
            this.backupRestoreTabPage.TabIndex = 3;
            this.backupRestoreTabPage.Text = "Backup/Restore";
            this.backupRestoreTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.restoreButton);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.restoreFilePath);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(292, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 359);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Restore";
            // 
            // restoreButton
            // 
            this.restoreButton.Location = new System.Drawing.Point(6, 177);
            this.restoreButton.Name = "restoreButton";
            this.restoreButton.Size = new System.Drawing.Size(257, 23);
            this.restoreButton.TabIndex = 4;
            this.restoreButton.Text = "Restore";
            this.restoreButton.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(10, 62);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(116, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Purge existing data";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(217, 35);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(50, 22);
            this.button9.TabIndex = 0;
            this.button9.Text = "Pick";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // restoreFilePath
            // 
            this.restoreFilePath.Location = new System.Drawing.Point(10, 36);
            this.restoreFilePath.Name = "restoreFilePath";
            this.restoreFilePath.Size = new System.Drawing.Size(206, 20);
            this.restoreFilePath.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "File path:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pickBackupPath);
            this.groupBox1.Controls.Add(this.backupFilePath);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.backupButton);
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 359);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Backup";
            // 
            // pickBackupPath
            // 
            this.pickBackupPath.Location = new System.Drawing.Point(213, 133);
            this.pickBackupPath.Name = "pickBackupPath";
            this.pickBackupPath.Size = new System.Drawing.Size(50, 22);
            this.pickBackupPath.TabIndex = 5;
            this.pickBackupPath.Text = "Pick";
            this.pickBackupPath.UseVisualStyleBackColor = true;
            this.pickBackupPath.Click += new System.EventHandler(this.pickBackupPath_Click);
            // 
            // backupFilePath
            // 
            this.backupFilePath.Location = new System.Drawing.Point(6, 134);
            this.backupFilePath.Name = "backupFilePath";
            this.backupFilePath.Size = new System.Drawing.Size(206, 20);
            this.backupFilePath.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "File path:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(110, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Export as:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "SQL",
            "JSON",
            "XML",
            "CSV"});
            this.comboBox2.Location = new System.Drawing.Point(113, 37);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(153, 21);
            this.comboBox2.TabIndex = 3;
            // 
            // backupButton
            // 
            this.backupButton.Location = new System.Drawing.Point(6, 177);
            this.backupButton.Name = "backupButton";
            this.backupButton.Size = new System.Drawing.Size(261, 23);
            this.backupButton.TabIndex = 2;
            this.backupButton.Text = "Backup";
            this.backupButton.UseVisualStyleBackColor = true;
            this.backupButton.Click += new System.EventHandler(this.backupButton_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Articles",
            "Categories",
            "Users"});
            this.checkedListBox1.Location = new System.Drawing.Point(6, 19);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(98, 94);
            this.checkedListBox1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem,
            this.nametypeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(604, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.backToolStripMenuItem1});
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.backToolStripMenuItem.Text = "Portal";
            // 
            // logoutToolStripMenuItem1
            // 
            this.logoutToolStripMenuItem1.Name = "logoutToolStripMenuItem1";
            this.logoutToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem1.Text = "Logout";
            this.logoutToolStripMenuItem1.Click += new System.EventHandler(this.logoutToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(109, 6);
            // 
            // backToolStripMenuItem1
            // 
            this.backToolStripMenuItem1.Name = "backToolStripMenuItem1";
            this.backToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.backToolStripMenuItem1.Text = "Leave";
            this.backToolStripMenuItem1.Click += new System.EventHandler(this.backToolStripMenuItem1_Click);
            // 
            // nametypeToolStripMenuItem
            // 
            this.nametypeToolStripMenuItem.Name = "nametypeToolStripMenuItem";
            this.nametypeToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.nametypeToolStripMenuItem.Text = "$name ($type)";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 450);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminForm";
            this.Text = "Administrator Portal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdminForm_FormClosing);
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.manageArticlesTabPage.ResumeLayout(false);
            this.manageArticlesTabPage.PerformLayout();
            this.manageCategoriesTabPage.ResumeLayout(false);
            this.manageCategoriesTabPage.PerformLayout();
            this.backupRestoreTabPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage manageArticlesTabPage;
        private System.Windows.Forms.TabPage manageCategoriesTabPage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nametypeToolStripMenuItem;
        private System.Windows.Forms.ListView articlesListView;
        private System.Windows.Forms.TabPage generateReportsTabPage;
        private System.Windows.Forms.TabPage backupRestoreTabPage;
        private System.Windows.Forms.Button removeArticleButton;
        private System.Windows.Forms.Button createArticleButton;
        private System.Windows.Forms.Button editArticleButton;
        private System.Windows.Forms.Button viewArticleButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox articleSearchTextBox;
        private System.Windows.Forms.ComboBox categoriesComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button backupButton;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox restoreFilePath;
        private System.Windows.Forms.Button pickBackupPath;
        private System.Windows.Forms.TextBox backupFilePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button restoreButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox authorsComboBox;
        private System.Windows.Forms.ColumnHeader titleColumnHeader;
        private System.Windows.Forms.ColumnHeader authorColumnHeader;
        private System.Windows.Forms.ColumnHeader categoryColumnHeader;
        private System.Windows.Forms.ColumnHeader dateColumnHeader;
    }
}