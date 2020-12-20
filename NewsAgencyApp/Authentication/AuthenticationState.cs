namespace NewsAgencyApp
{
    abstract class AuthenticationState
    {
        protected Models.User currentUser;

        protected AuthenticationState(Models.User user)
        {
            currentUser = user;
        }

        public abstract bool CanActivateAdminPortal();

        public abstract bool CanManageArticle();

        public abstract bool CanViewArticle();

        public abstract bool CanManageDatabase();

        public Models.User CurrentUser
        {
            get
            {
                return this.currentUser;
            }
        }

        public abstract bool CanManageCategory();

    }
}