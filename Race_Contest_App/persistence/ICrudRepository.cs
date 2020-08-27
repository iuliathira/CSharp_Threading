using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace race.repository
{
    public interface ICrudRepository<ID,E>
    {
        E findOne(ID id);
        IEnumerable<E> findAll();
        void save(E entity);
        void update(E entity);
        void delete(E entity);

    }
}
