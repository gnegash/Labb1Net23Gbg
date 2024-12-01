using Repository;

namespace WebShop.Notifications
{
    // Gränssnitt för notifieringsobservatörer enligt Observer Pattern
    public interface INotificationObserver
    {
        void AddProduct(Product product); // Metod som kallas när en ny produkt läggs till

        void RemoveProduct(int id);

        void UpdateProduct(Product product);

    }
}
