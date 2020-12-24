using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace NewsAgencyApp
{
    // Enum to hold db types
    public enum DatabaseType
    {
        SqlServer2008,
        MySQL,
        OracleDB
    }

    public class DBMgr
    {
        protected DBMgr() // protected constructor
        {

        }

        public static Database DatabaseFactory(DatabaseType type = DatabaseType.SqlServer2008) // Factory pattern, default to SqlServer2008
        {
            switch (type) // switch by enum type
            {
                case DatabaseType.SqlServer2008: // if sql server 2008
                    return SqlServer2008.Instance(); // return the instance ref (singelton in the class)
                case DatabaseType.MySQL:
                    throw new Exception("Unhandled database type."); // Throw not handled exception
                case DatabaseType.OracleDB:
                    throw new Exception("Unhandled database type."); // Throw not handled exception
                default:
                    return null;
            }
        }

    }
}