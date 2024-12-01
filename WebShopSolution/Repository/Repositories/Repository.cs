using Microsoft.EntityFrameworkCore;

namespace Repository
{
    //generisk klass
    public class Repository<T> : IRepository<T> where T : class
    {
        //dra in (readonly priv) databas context här
        //använd även dbset för alla listor
        //båda läggs till i parameter i konstruktor
        private readonly DatabaseContext _context;

        //här är den generiska listan
        private readonly DbSet<T> _dbSet;

        public Repository(DatabaseContext context, DbSet<T> dbSet)
        {
            //instansieras
            _context = context;
            _dbSet = context.Set<T>(); // få dbset från context
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Add(T item)
        {
            //med denna kod sker koppling till respektive db lista, funktionen tar emot vilken typ(T) som helst
            _dbSet.Add(item);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }
    }
}
