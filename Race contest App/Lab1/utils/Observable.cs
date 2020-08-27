using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.utils
{
    interface Observable<E> where E:Event
    {
        void addObserver();
        void removeObserver();
        void notifyObservers(E t);

    }
}
