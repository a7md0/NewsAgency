using System;
using System.Data;
using System.Data.SqlClient;

namespace NewsAgencyApp
{
    /// <summary>Class <c>AuthenticationContext</c> handle the whole app authentication in term of login/login funcionility, state and observer patterns</summary>
    class AuthenticationContext
    {
        private static AuthenticationContext instance;
        private AuthenticationState state;
        private Subject<AuthenticationState> subject;

        protected AuthenticationContext(AuthenticationState state) // Protected constructor
        {
            this.subject = new Subject<AuthenticationState>(); // Create new subject for the observer
            this.State = state; // set the state to the initilized one
        }

        public AuthenticationState State // public getter/setter for the state
        {
            get
            {
                return state;
            }

            set
            {
                state = value; // update the state
                this.subject.Notify(value); // Notify the subject to publish updates to observers
            }
        }

        public static AuthenticationContext Instance() // Get singelton instance
        {
            if (instance == null)
            {
                instance = new AuthenticationContext(new UnauthenticatedState());  // Create new instance with default to unatuhenticated state
            }

            return instance;
        }

        /// <summary>This will return new observer for auth updates which is subscribed to the subject</summary>
        public Observer<AuthenticationState> AuthenticationObserverInstance()
        {
            Observer<AuthenticationState> observer = new Observer<AuthenticationState>();
            observer.Subscribe(subject);

            return observer;
        }

        /// <summary>Login method by username/password, it would change the state and publish the changes. Finally return the user</summary>
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