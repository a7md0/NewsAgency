namespace NewsAgencyApp
{
    class UnauthenticatedState : AuthenticationState
    {

        public UnauthenticatedState() : base(null)
        {

        }

        public void Authenticated(Models.User user)
        {
            AuthenticationContext.Instance().State = new AuthenticatedState(user);
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