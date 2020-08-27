using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendanceSystem.Utils
{
    public interface Observer<E> where E:Event
    {
        void UpdateTaskTable(E e);
        void UpdatePresentEmployees(E e);
        void EmployeeLogout(Observer<Event> o);
        void ManagerLogout(Observer<Event> o);
        void UpdateManagerTaskTable();
    }
}
