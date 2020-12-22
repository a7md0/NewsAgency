using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using System.Data.SqlClient;

namespace NewsAgencyApp
{
    public interface Database
    {
        SqlConnection Connection();
        bool BackupDatabase(FileInfo outputFile);
        bool RestoreDatabase(FileInfo inputFile);
    }
}
