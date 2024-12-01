using Microsoft.EntityFrameworkCore;
using Repository;
using WebShop.Notifications;

namespace WebShop.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DatabaseContext _context;
        private readonly DbSet<Product> _dbSet;

        public IProductRepository Products { get; set; }
        public UnitOfWork(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Products = new ProductRepository(_context, _dbSet);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

       
    

