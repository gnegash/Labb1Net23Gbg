using WebShop.Notifications;
using WebShop.UnitOfWork;

public class ProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ProductSubject _productSubject;

    public ProductService(IUnitOfWork unitOfWork, ProductSubject productSubject)
    {
        _unitOfWork = unitOfWork;
        _productSubject = productSubject;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        var products = _unitOfWork.Products.GetAll();
        return products.ToList();
    }

    public async Task AddProductAsync(Product product)
    {
        _unitOfWork.Products.Add(product);
        await _unitOfWork.CommitAsync();

        _productSubject.NotifyProductAdded(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        _unitOfWork.Products.Delete(id);
        await _unitOfWork.CommitAsync();

        _productSubject.NotifyProductRemoved(id);
    }
    public async Task UpdateProductAsync(Product product)
    {
        _unitOfWork.Products.Update(product);
        await _unitOfWork.CommitAsync();
        _productSubject.NotifyProductUpdated(product);
    }
}
