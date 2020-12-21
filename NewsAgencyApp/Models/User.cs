using System;
using System.Data;
using System.Data.SqlClient;

using System.Collections.Generic;

namespace NewsAgencyApp.Models
{
    /**
     * Class model for user
    */ 
    class User : Model
    {

        private int id;
        private string username;
        private string fullName;
        private string email;

        public User()
        {
        }

        #region Getter/Setter
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
        #endregion

        public static User UserFactory(string roleName)
        {
            switch (roleName)
            {
                case "Administrator":
                    return new SuperUser();
                default:
                    throw new NotImplementedException("Unhandled user type");
            }
        }

        public static List<User> FindAll()
        {
            List<User> users = new List<User>();

            SqlCommand query = new SqlCommand
            {
                CommandText = @"SELECT u.Id, u.FullName, u.Username, u.Email, r.Name AS RoleName
                                FROM [User] AS u

                                INNER JOIN [Role] AS r
                                    ON u.RoleId = r.Id;",
                Connection = DBMgr.DatabaseFactory().Connection(),
                CommandType = CommandType.Text,
            };

            SqlDataReader sdr = query.ExecuteReader();

            while (sdr.Read())
            {
                User user = User.UserFactory(sdr["RoleName"].ToString());

                user.Id = Int32.Parse(sdr["Id"].ToString());
                user.FullName = sdr["FullName"].ToString();
                user.Username = sdr["Username"].ToString();
                user.Email = sdr["Email"].ToString() ?? null;

                users.Add(user);
            }

            sdr.Close(); // Close SqlDataReader

            return users;
        }

        public override bool Create()
        {
            throw new NotImplementedException();
        }

        public override bool Update()
        {
            throw new NotImplementedException();
        }

        public override bool Remove()
        {
            throw new NotImplementedException();
        }
    }
}
