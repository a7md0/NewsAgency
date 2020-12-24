using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Data.SqlClient;

namespace NewsAgencyApp
{
    /// <summary>Interface <c>Database</c> define the availbile methods that any database class should offer</summary>
    public interface Database
    {
        SqlConnection Connection();
        bool BackupDatabase(FileInfo outputFile);
        bool RestoreDatabase(FileInfo inputFile);
    }
}
