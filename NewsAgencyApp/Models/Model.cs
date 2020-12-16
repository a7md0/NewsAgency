using System;
using System.Data;
using System.Data.SqlClient;

namespace NewsAgencyApp.Models
{
    abstract class Model
    {
        public abstract bool Create();
        public abstract bool Update();
        public abstract bool Remove();
    }
}
