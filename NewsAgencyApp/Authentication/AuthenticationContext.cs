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
            this.subject = new Subject<AuthenticationState>();
            this.State = state;
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

        public Models.User Login(string username, string password)
        {
            if (!(state is UnauthenticatedState))
                return null;

            var connection = DBMgr.DatabaseFactory().Connection();

            SqlCommand query = new SqlCommand(@"SELECT r.Name as RoleName, u.Id, u.FullName, u.Username, u.Email
                                                FROM [User] AS u

                                                INNER JOIN [Role] as r
                                                    ON u.RoleId = r.Id

                                                WHERE Username = @username AND Password = HashBytes('MD5', @password);", connection); // 
            query.CommandType = CommandType.Text;

            query.Parameters.AddWithValue("@username", username);
            query.Parameters.Add("@password", SqlDbType.NVarChar, 100).Value = password;

            SqlDataReader sdr = query.ExecuteReader();
            Models.User user = null;

            if (sdr.HasRows == true && sdr.Read())
            {
                user = Models.User.UserFactory(sdr["RoleName"].ToString());

                user.Id = Int32.Parse(sdr["Id"].ToString());
                user.FullName = sdr["FullName"].ToString();
                user.Username = sdr["Username"].ToString();
                user.Email = sdr["Email"].ToString();

                ((UnauthenticatedState)state).Authenticated(user);
            }

            sdr.Close(); // Close SqlDataReader

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