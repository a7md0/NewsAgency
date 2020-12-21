using System;
using System.Collections.Generic;

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
            SqlCommand query = new SqlCommand
            {
                CommandText = "INSERT INTO [Category] (Name) VALUES (@name);",
                Connection = DBMgr.DatabaseFactory().Connection(),
                CommandType = CommandType.Text,
            };

            query.Parameters.AddWithValue("@name", name);

            int affectedRows = query.ExecuteNonQuery();

            return affectedRows > 0;
        }

        public override bool Update()
        {
            SqlCommand query = new SqlCommand
            {
                CommandText = "UPDATE [Category] SET Name = @name WHERE Id = @id;",
                Connection = DBMgr.DatabaseFactory().Connection(),
                CommandType = CommandType.Text,
            };

            query.Parameters.AddWithValue("@id", id);
            query.Parameters.AddWithValue("@name", name);

            int affectedRows = query.ExecuteNonQuery();

            return affectedRows > 0;
        }

        public override bool Remove()
        {
            SqlCommand query = new SqlCommand
            {
                CommandText = @"DELETE FROM [Category] WHERE Id = @id;",
                Connection = DBMgr.DatabaseFactory().Connection(),
                CommandType = CommandType.Text,
            };

            query.Parameters.AddWithValue("@id", id);

            int affectedRows = query.ExecuteNonQuery();

            return affectedRows > 0;
        }
    }
}
