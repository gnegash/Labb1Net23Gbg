using Microsoft.EntityFrameworkCore;

namespace Repository
{
    //implementation av vårat grund repo + övrig funktionalitet
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<Product> _dbSet;
        public ProductRepository(DatabaseContext context, DbSet<Product> dbSet) : base(context, dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        public void Add(Product item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _dbSet.Add(item);
        }

        public void Delete(int id)
        {
            var product = _dbSet.Find(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {id} not found.");

            _dbSet.Remove(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public void Update(Product item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _dbSet.Update(item);
        }

        public bool UpdateStock(Product product, int q)
        {
            if(product == null)
                throw new ArgumentNullException(nameof(product));

            product.Stock += q;

            _dbSet.Update(product);
            return true;
        }

    }
}