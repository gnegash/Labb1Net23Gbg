using Microsoft.EntityFrameworkCore;
using WebShop.Entities;
using WebShop.Notifications;
using WebShop.Repositories;
using WebShop.Repository;

namespace WebShop.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _context;
        public IProductRepository Products { get; }


        public UnitOfWork(DbContext context, IProductRepository products)
        {
            _context = context;
            Products = products;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void NotifyProductAdded(Product product)
        {
            _productSubject.NotifyProductAdded(product);
        }

        public void NotifyProductRemoved(int id)
        {
            _productSubject.NotifyProductRemoved(id);
        }
    }
}

       
    

