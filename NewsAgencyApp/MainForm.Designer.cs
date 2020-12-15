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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.portalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginLogoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.adminPortalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portalToolStripMenuItem,
            this.adminPortalToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(368, 24);
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
            this.loginLogoutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loginLogoutToolStripMenuItem.Text = "Login";
            this.loginLogoutToolStripMenuItem.Click += new System.EventHandler(this.loginLogoutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 36);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(318, 206);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(336, 113);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "⇈";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(336, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "⇊";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 257);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(317, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "View Article";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // adminPortalToolStripMenuItem
            // 
            this.adminPortalToolStripMenuItem.Name = "adminPortalToolStripMenuItem";
            this.adminPortalToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.adminPortalToolStripMenuItem.Text = "Admin Portal";
            this.adminPortalToolStripMenuItem.Visible = false;
            this.adminPortalToolStripMenuItem.Click += new System.EventHandler(this.adminPortalToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 292);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "News Agency";
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem adminPortalToolStripMenuItem;
    }
}

