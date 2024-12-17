using WebShop.Entities;

namespace WebShop.Notifications
{
    // En konkret observatör som skickar e-postmeddelanden
    public class EmailNotification : INotificationObserver
    {
        //skippar notifikation för alla andra funktionaliteter
        public void AddProduct(Product product)
        {
            // Här skulle du implementera logik för att skicka ett e-postmeddelande
            // För enkelhetens skull skriver vi ut till konsolen
            Console.WriteLine($"Email Notification: New product added - {product.Name}");
        }

        public void RemoveProduct(int id)
        {
            Console.WriteLine($"Email Notification: Product removed.");
        }

        public void UpdateProduct(Product product)
        {
            Console.WriteLine($"Email Notification: A product has been updated!");
        }
    }
}
