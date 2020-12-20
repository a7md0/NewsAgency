namespace NewsAgencyApp
{
    class AuthenticatedState : AuthenticationState
    {

        public AuthenticatedState(Models.User user) : base(user)
        {

        }

        public void Deauthenticated()
        {
            AuthenticationContext.Instance().State = new UnauthenticatedState();
        }

        public override bool CanActivateAdminPortal()
        {

            return false;
        }

        public override bool CanManageArticle()
        {

            return false;
        }

        public override bool CanViewArticle()
        {

            return false;
        }

        public override bool CanManageDatabase()
        {

            return false;
        }

        public override bool CanManageCategory()
        {

            return false;
        }

    }
}