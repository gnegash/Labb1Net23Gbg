using Repository;

namespace WebShop.UnitOfWork

{
    // Gränssnitt för Unit of Work
    public interface IUnitOfWork : IDisposable //hanterar resursläckor genom att stänga ner kopplingen till externa resurs(db) och frigör minne
    {
        IProductRepository Products { get; }
        Task CommitAsync();

    }
}

