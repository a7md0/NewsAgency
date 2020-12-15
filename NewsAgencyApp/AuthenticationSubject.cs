using System;
using System.Collections.Generic;

namespace NewsAgencyApp
{
    class AuthenticationSubject : IObservable<AuthenticationState>
    {
        private List<IObserver<AuthenticationState>> observers;

        public AuthenticationSubject()
        {

        }

        public IDisposable Subscribe(IObserver<AuthenticationState> observer)
        {

            return null;
        }
    }
}