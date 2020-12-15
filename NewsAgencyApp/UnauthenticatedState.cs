namespace NewsAgencyApp
{
    class UnauthenticatedState : AuthenticationState
    {

        public UnauthenticatedState()
        {

        }

        ~UnauthenticatedState()
        {

        }

        public override void Handle(AuthenticationStateContext context)
        {

            context.State = new AuthenticatedState();
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