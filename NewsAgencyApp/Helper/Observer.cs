using System;

namespace NewsAgencyApp
{
    /**
     * https://docs.microsoft.com/en-us/dotnet/standard/events/observer-design-pattern
     * https://docs.microsoft.com/en-us/dotnet/api/system.iobserver-1?view=net-5.0
     */
    class Observer<T> : IObserver<T> {
        private IDisposable unsubscriber;

        public Action completeDelegate;
        public Action<Exception> errorDelegate;
        public Action<T> nextDelegate;

        public void Subscribe(Subject<T> subject) {
            unsubscriber = subject.Subscribe(this);
        }

        public void Unsubscribe() {
            unsubscriber.Dispose();
        }

        public virtual void OnCompleted() {
            completeDelegate?.Invoke();
        }

        public virtual void OnError(Exception error) {
            errorDelegate?.Invoke(error);
        }


        public virtual void OnNext(T value) {
            nextDelegate?.Invoke(value);
        }
    }
}