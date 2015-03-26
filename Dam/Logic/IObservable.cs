using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dam.Logic
{
    public interface IObservable
    {
        void register(IObserver pObserver);
        void unregister(IObserver pObserver);
        void notifyObservers();
    }
}
