namespace NewsAgencyApp
{
    class AuthenticationStateContext
    {
        private AuthenticationState state;
        private static AuthenticationStateContext instance;
        private AuthenticationSubject subject;

        protected AuthenticationStateContext(AuthenticationState state)
        {

            this.state = state;
        }

        public AuthenticationState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        public void Request()
        {

            state.Handle(this);
        }

        public static AuthenticationStateContext Instance
        {
            get;
            set;
        }

        public AuthenticationObserver AuthenticationObserverInstance()
        {

            return null;
        }

    }
}