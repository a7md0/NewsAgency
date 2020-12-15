using System;
using System.Data;
using System.Data.SqlClient;

namespace NewsAgencyApp
{
    class AuthenticationContext
    {
        private static AuthenticationContext instance;
        private AuthenticationState state;
        private Subject<AuthenticationState> subject;

        protected AuthenticationContext(AuthenticationState state)
        {
            this.State = state;
            this.subject = new Subject<AuthenticationState>();
        }

        internal AuthenticationState State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
                this.subject.Notify(value);
            }
        }

        public static AuthenticationContext Instance()
        {
            if (instance == null)
            {
                instance = new AuthenticationContext(new UnauthenticatedState());
            }

            return instance;
        }

        public Observer<AuthenticationState> AuthenticationObserverInstance()
        {
            Observer<AuthenticationState> observer = new Observer<AuthenticationState>();
            observer.Subscribe(subject);

            return observer;
        }

        public User Login(string username, string password)
        {
            if (!(state is UnauthenticatedState))
                return null;

            var connection = DBMgr.DatabaseFactory().Connection();

            SqlCommand query = new SqlCommand("SELECT RoleId, Id, FullName, Username, Email FROM [User] WHERE Username = @username AND Password = HashBytes('MD5', @password);", connection); // 
            query.CommandType = CommandType.Text;

            query.Parameters.AddWithValue("@username", username);
            query.Parameters.Add("@password", SqlDbType.NVarChar, 100).Value = password;

            SqlDataReader sdr = query.ExecuteReader();
            User user = null;

            Console.WriteLine(sdr.HasRows);

            if (sdr.HasRows == true && sdr.Read())
            {
                int roleId = Int32.Parse(sdr["RoleId"].ToString());

                user = User.UserFactory(Int32.Parse(sdr["RoleId"].ToString()));

                user.Id = Int32.Parse(sdr["Id"].ToString());
                user.FullName = sdr["FullName"].ToString();
                user.Username = sdr["Username"].ToString();
                user.Email = sdr["Email"].ToString();

                ((UnauthenticatedState)state).Authenticated(user);
            }

            return user;
        }

        public void Logout()
        {
            if (!(state is AuthenticatedState))
                return;

            ((AuthenticatedState)state).Deauthenticated();
        }
    }
}