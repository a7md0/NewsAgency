namespace NewsAgencyApp
{
    abstract class AuthenticationState
    {
        protected User currentUser;

        public AuthenticationState()
        {

        }

        public abstract void Handle(AuthenticationStateContext context);

        public abstract bool CanActivateAdminPortal();

        public abstract bool CanManageArticle();

        public abstract bool CanViewArticle();

        public abstract bool CanManageDatabase();

        public User CurrentUser
        {
            get
            {
                return this.currentUser;
            }
        }

        public abstract bool CanManageCategory();

    }
}