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
            if (!(state is UnauthenticatedState)) // If the current auth state if already not unauthenticated, return null
                return null;

            var connection = DBMgr.DatabaseFactory().Connection(); // Get connection instance

            
            SqlCommand query = new SqlCommand
            {
                CommandType = CommandType.Text,  // Make the command as text (query)
                CommandText = @"SELECT r.Name as RoleName, u.Id, u.FullName, u.Username, u.Email
                                                FROM [User] AS u

                                                INNER JOIN [Role] as r
                                                    ON u.RoleId = r.Id

                                                WHERE Username = @username AND Password = HashBytes('MD5', @password);", // Query to lookup the user and role name by username/password (password encrypted using MD5 hash)
                Connection = connection // Attach the connection to the command
            }; 

            query.Parameters.AddWithValue("@username", username); // Add username paramter
            query.Parameters.Add("@password", SqlDbType.NVarChar, 100).Value = password; // Add password maanager, this should be of type NVarChar to avoid issue with diffrenet encoding

            SqlDataReader sdr = query.ExecuteReader(); // Execute the query
            Models.User user = null; // Initlize the user with null

            if (sdr.HasRows == true && sdr.Read()) // If there is row returned and we could read it
            {
                user = Models.User.UserFactory(sdr["RoleName"].ToString()); // Use the factory pattern in the User model to initlize the right type of user

                user.Id = Int32.Parse(sdr["Id"].ToString()); // Parse the id from string to int and store in the user model
                user.FullName = sdr["FullName"].ToString(); // Store full name to model
                user.Username = sdr["Username"].ToString(); // Store username to the model
                user.Email = sdr["Email"].ToString(); // Store email to the model

                ((UnauthenticatedState)state).Authenticated(user); // Update the unauthenictated state that we have authenticted user
            }

            sdr.Close(); // Close SqlDataReader

            return user; // return the user we constructed
        }

        /// <summary>Logout method</summary>
        public void Logout()
        {
            if (!(state is AuthenticatedState)) // if the user is already unauthenticted 
                return; // exit

            ((AuthenticatedState)state).Deauthenticated(); // Infrom the autheitnated state that we have deatuhenticated
        }
    }
}