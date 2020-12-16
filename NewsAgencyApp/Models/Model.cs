using System;
using System.Data;
using System.Data.SqlClient;

namespace NewsAgencyApp.Models
{
    abstract class Model
    {
        public abstract Boolean create();
        public abstract Boolean update();
        public abstract Boolean remove();
    }
}
