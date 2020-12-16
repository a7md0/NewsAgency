using System;

namespace NewsAgencyApp
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
    }
}
