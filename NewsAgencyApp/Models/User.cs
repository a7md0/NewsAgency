using System;

namespace NewsAgencyApp
{
    class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

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
