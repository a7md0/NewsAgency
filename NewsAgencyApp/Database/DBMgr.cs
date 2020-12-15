using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NewsAgencyApp
{
    public enum DatabaseType
    {
        SqlServer2008,
        MySQL,
        OracleDB
    }

    public class DBMgr
    {
        protected DBMgr()
        {

        }

        public static Database DatabaseFactory(DatabaseType type = DatabaseType.SqlServer2008)
        {
            switch (type)
            {
                case DatabaseType.SqlServer2008:
                    return SqlServer2008.Instance();
                case DatabaseType.MySQL:
                    throw new Exception("Unhandled database type.");
                case DatabaseType.OracleDB:
                    throw new Exception("Unhandled database type.");
                default:
                    return null;
            }
        }

    }
}