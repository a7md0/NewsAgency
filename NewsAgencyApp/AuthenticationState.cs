namespace NewsAgencyApp
{
    abstract class AuthenticationState
    {
        protected User currentUser;

        protected AuthenticationState()
        {

        }

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