using System;
using System.Data;
using System.Data.SqlClient;

using System.Collections.Generic;

namespace NewsAgencyApp.Models
{
    class User
    {

        private int id;
        private string username;
        private string fullName;
        private string email;

        public User()
        {
        }

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

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string FullName
        {
            get
            {
                return fullName;
            }

            set
            {
                fullName = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public static User UserFactory(int roleId)
        {
            switch (roleId)
            {
                case 1:
                    return new SuperUser();
                default:
                    throw new Exception("Unhandled user type");
            }
        }

        public static List<User> FindAll()
        {
            List<User> users = new List<User>();

            SqlCommand query = new SqlCommand
            {
                CommandText = "SELECT Id, FullName, Username, Email, RoleId FROM [User];",
                Connection = DBMgr.DatabaseFactory().Connection(),
                CommandType = CommandType.Text,
            };

            SqlDataReader sdr = query.ExecuteReader();

            while (sdr.Read())
            {
                int roleId = Int32.Parse(sdr["RoleId"].ToString());

                User user = Models.User.UserFactory(Int32.Parse(sdr["RoleId"].ToString()));

                user.Id = Int32.Parse(sdr["Id"].ToString());
                user.FullName = sdr["FullName"].ToString();
                user.Username = sdr["Username"].ToString();
                user.Email = sdr["Email"].ToString() ?? null;

                users.Add(user);
            }

            sdr.Close(); // Close SqlDataReader

            return users;
        }
    }
}
