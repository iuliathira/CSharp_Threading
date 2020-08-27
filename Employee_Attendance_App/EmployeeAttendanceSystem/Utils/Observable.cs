using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendanceSystem.Utils
{
    public interface Observable<E> where E:Event
    {
        void addObserver(Observer<E> e);
        void removeObserver(Observer<E> e);
        void notifyLogOutEmployee(E t, Observer<Event> obs);
        void notifyLogIn(E t);
        void notifyLogOutManager(Observer<Event> obs);
        void notifyManagerTasks();
    }

}
