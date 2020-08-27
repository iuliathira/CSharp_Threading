using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendanceSystem.Services
{
    class ServiceException : Exception
    {
        //String Message { get; set; }
        public ServiceException(String m) : base(m) {
          //  Message = m;
        }  
    }
}
