using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using race.model;
namespace race.repository
{
    public interface IOfficePers : ICrudRepository<int,OfficePers>
    {
        OfficePers findByUserPass(string username, string password);
        
    }
}
