namespace Repository
{
    //implementation av vårat grund repo + övrig funktionalitet
    public class ProductRepository : IProductRepository
    {
        public void Add(Product item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Product item)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStock(Product product, int q)
        {
            throw new NotImplementedException();
        }
    }
}