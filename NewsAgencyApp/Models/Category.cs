using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace NewsAgencyApp.Models
{
    class Category : Model
    {
        private int id;
        private string name;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public Category()
        {
        }

        public Category(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Category(string name)
        {
            this.name = name;
        }

        public static List<Category> FindAll()
        {
            List<Category> categories = new List<Category>();

            SqlCommand query = new SqlCommand
            {
                CommandText = "SELECT Id, Name FROM [Category];",
                Connection = DBMgr.DatabaseFactory().Connection(),
                CommandType = CommandType.Text,
            };

            SqlDataReader sdr = query.ExecuteReader();

            while (sdr.Read())
            {
                Category category = new Category
                {
                    Id = Int32.Parse(sdr["Id"].ToString()),
                    Name = sdr["Name"].ToString(),
                };

                categories.Add(category);
            }

            sdr.Close(); // Close SqlDataReader

            return categories;
        }

        public override bool Create()
        {

            return false;
        }

        public override bool Update()
        {

            return false;
        }

        public override bool Remove()
        {

            return false;
        }
    }
}
