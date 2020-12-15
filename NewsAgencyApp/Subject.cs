using System;
using System.Collections.Generic;

namespace NewsAgencyApp
{
    /*
     * https://docs.microsoft.com/en-us/dotnet/standard/events/observer-design-pattern
     * https://docs.microsoft.com/en-us/dotnet/api/system.iobservable-1.subscribe?view=net-5.0 
     */
    class Subject<T> : IObservable<T>
    {
        private List<IObserver<T>> observers;

        public Subject()
        {
            this.observers = new List<IObserver<T>>();
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber<T>(observers, observer);
        }

        public void Notify(T str)
        {
            foreach (var observer in observers)
                observer.OnNext(str);
        }

        class Unsubscriber<K> : IDisposable
        {
            private List<IObserver<K>> _observers;
            private IObserver<K> _observer;

            public Unsubscriber(List<IObserver<K>> observers, IObserver<K> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
    }
}