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

            User user = AuthenticationContext.Instance().State.CurrentUser;
            nametypeToolStripMenuItem.Text = String.Format("{0} ({1})", user.FullName, user.Username);
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
    }
}
