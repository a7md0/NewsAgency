using System;

namespace NewsAgencyApp
{
    class AuthenticationObserver : IObserver<AuthenticationState> {
        private IDisposable unsubscriber;
        //private AuthenticationListener delegator;

        public AuthenticationObserver() {

        }

        public void Subscribe(AuthenticationSubject subject) {

        }

        public void Unsubscribe() {
            unsubscriber.Dispose();
        }

        public virtual void OnCompleted() {

        }

        public virtual void OnError(Exception error) {

        }


        public virtual void OnNext(AuthenticationState value) {

        }

        /*public AuthenticationListener delegator {
            get {
                return delegator;
            }
            set {
                delegator = value;
            }
        }*/

    }
}