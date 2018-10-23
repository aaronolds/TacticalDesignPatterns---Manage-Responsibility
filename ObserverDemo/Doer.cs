using System;

namespace ObserverDemo
{
    public class Doer
    {
        public MulticastNotifier<string> AfterDoSomthingWith;
        public MulticastNotifier<Tuple<string, string>> AfterDoMore;
        private string _data;

        public void DoSomethingWith(string data)
        {
            _data = data;
            OnAfterDoSomethingWith(_data);
        }

        public void DoMore(string appendData)
        {
            _data += appendData;
            OnAfterDoMore(_data, appendData);
        }
        private void OnAfterDoSomethingWith(string data)
        {
            AfterDoSomthingWith?.Notify(this, data);
        }

        private void OnAfterDoMore(string data, string appendData)
        {
            AfterDoMore?.Notify(this, Tuple.Create(data, appendData));
        }
    }
}
