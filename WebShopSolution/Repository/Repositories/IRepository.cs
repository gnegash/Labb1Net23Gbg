using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    //bas repo som alla andra repon kan ärva av pga generisk typ
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        void Add(T item);

        void Delete(int id);

        void Update(T item);
    }
}
