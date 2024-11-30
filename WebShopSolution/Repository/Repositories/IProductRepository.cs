using Repository.Interfaces;

namespace Repository
{
    // Gränssnitt för produktrepositoryt enligt Repository Pattern
    public interface IProductRepository : IRepository<Product> 
    {

        //vi kan nu ta bort metoderna eftersom att de redan finns i basklassen och implementeras direkt genom arv
        //genom att skicka in typen specifierar vi obj typ vi vill utföra 

        //IEnumerable<Product> GetAll(); // Hämtar alla produkter
        //void Add(Product product); // Lägger till en ny produkt

        //void Delete(int id);

        //void Update(Product product);
    }
}
