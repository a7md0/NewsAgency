using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Data.SqlClient;

namespace NewsAgencyApp
{
    /// <summary>Class <c>SqlServer2008</c> implements Database class and offer the connectivity to a SQL Server</summary>
    public class SqlServer2008 : Database
    {
        private static Database instance; // Singelton pattern
        private SqlConnection connection; // Reference to the DB

        protected SqlServer2008()
        {
            connection = new SqlConnection(Properties.Settings.Default.DatabaseConnectionString); // Setup connection and use Settings db connection string
            connection.Open(); // Open the connection
            Console.WriteLine("New connection created");
        }

        public static Database Instance() // Singelton pattern
        {
            if (instance == null)
            {
                instance = new SqlServer2008();
            }

            return instance;
        }

        public SqlConnection Connection()  // Getter for the connection
        {
            if (connection.State == System.Data.ConnectionState.Closed) // if the connection was closed
            {
                connection.Open(); // Re-open the connection
            }

            return connection; // return the instance
        }

        /// <summary>This method will backup the database to the given file</summary>
        public bool BackupDatabase(FileInfo outputFile)
        {
            using (var connection = Connection())
            {
                using (var command = new SqlCommand("BACKUP DATABASE [master] TO DISK = @outputFileName;", connection))
                {
                    command.Parameters.AddWithValue("outputFileName", outputFile.FullName);
                    command.ExecuteNonQuery();

                    return true;
                }
            }
        }

        /// <summary>This method will restore a backup to the database from the given file</summary>
        public bool RestoreDatabase(FileInfo inputFile)
        {
            using (var connection = Connection())
            {
                using (var command = new SqlCommand("RESTORE DATABASE [master] FROM DISK = @inputFileName WITH REPLACE;", connection))
                {
                    command.Parameters.AddWithValue("inputFileName", inputFile.FullName);
                    command.ExecuteNonQuery();

                    return true;
                }
            }
        }
    }
}