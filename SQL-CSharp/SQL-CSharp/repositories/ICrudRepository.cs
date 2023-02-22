using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_CSharp.repositories
{
    public interface ICrudRepository<T, Id>
    {
        // Get All Customers
        IEnumerable<T> GetAll();
        // Get specific customer
        T GetById(Id id);
        // Adds new object
        void Add(T entity);
        //Update object
        void Update(T entity);
        void Delete(Id id);
    }
}
