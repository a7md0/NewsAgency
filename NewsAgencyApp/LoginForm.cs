using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace NewsAgencyApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var connection = DBMgr.DatabaseFactory().Connection();

            string username = this.usernameTextBox.Text;
            string password = this.passwordTextBox.Text;

            /*SqlCommand query0 = new SqlCommand("UPDATE [User] SET Password = HashBytes('MD5', @password) WHERE Username = @username;", connection); // 
            query0.CommandType = CommandType.Text;

            query0.Parameters.AddWithValue("@username", username);
            query0.Parameters.Add("@password", SqlDbType.NVarChar, 100).Value = password;

            query0.ExecuteNonQuery();*/

            SqlCommand query = new SqlCommand("SELECT Password FROM [User] WHERE Username = @username AND Password = HashBytes('MD5', @password);", connection); // 
            query.CommandType = CommandType.Text;

            query.Parameters.AddWithValue("@username", username);
            query.Parameters.Add("@password", SqlDbType.NVarChar, 100).Value = password;

            /*SqlDataReader result = query.ExecuteReader();
            if (result == null)
            {
                Console.WriteLine(username);
                Console.WriteLine(password);
                Console.WriteLine("No user found!");
                return;
            }

            Console.WriteLine(result);*/

            /*SqlDataAdapter da = new SqlDataAdapter(query);
            if (da.)*/

            SqlDataReader sdr = query.ExecuteReader();
            Console.WriteLine(sdr.HasRows);
            
        }
    }
}
