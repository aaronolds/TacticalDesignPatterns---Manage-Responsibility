using System;
using System.Collections.Generic;

namespace ObserverDemo
{
    public class MulticastNotifier<T>
    {
        private IList<IObserver<T>> _invocationList;

        public MulticastNotifier(IEnumerable<IObserver<T>> observers)
        {
            _invocationList = new List<IObserver<T>>(observers);
        }

        public void Notify(object sender, T data)
        {
            foreach (var observer in _invocationList)
            {
                observer.Update(sender, data);
            }
        }
    }
}