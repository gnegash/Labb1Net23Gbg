using Repository.Interfaces;

namespace Repository
{
    //implementation av vårat grund repo
    public class ProductRepository<T> : IRepository<T> where T : class
    {

        //dra in (readonly priv) databas context här
        //använd även dbset för listor
        // båda läggs till i parameter i konstruktor

        private readonly DbContext _context;

        public ProductRepository(DbContext context)
        {
            _context = context;
        }

        // Asynchronous version of GetAll
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }
    }
}