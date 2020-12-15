using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.SqlClient;

namespace NewsAgencyApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("(c) 2020, Ahmed Naser");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Properties.Settings.Default.DatabaseConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [User];";

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                var value1 = reader.GetValue(0);
                var value2 = reader.GetValue(1);
                var value3 = reader.GetValue(2);

                Console.WriteLine(value1);
                Console.WriteLine(value2);
                Console.WriteLine(value3);
            }
            

            con.Close();
        }
    }
}
