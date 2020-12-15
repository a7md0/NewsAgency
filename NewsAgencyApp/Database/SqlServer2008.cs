using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Data.SqlClient;

namespace NewsAgencyApp
{
    public class SqlServer2008 : Database
    {
        private static Database instance;
        private SqlConnection connection;

        protected SqlServer2008()
        {
            connection = new SqlConnection(Properties.Settings.Default.DatabaseConnectionString);
            connection.Open();
            Console.WriteLine("New connection created");
        }

        ~SqlServer2008()
        {
            if (connection != null && connection.State != System.Data.ConnectionState.Closed)
            {
                //connection.Close();
            }
        }

        public static Database Instance()
        {
            if (instance == null)
            {
                instance = new SqlServer2008();
            }

            return instance;
        }

        public SqlConnection Connection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            return connection;
        }
    }
}