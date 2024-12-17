namespace WebShop.Notifications
{
    // En konkret observatör som skickar e-postmeddelanden
    public class EmailNotification : INotificationObserver
    {

        public void Remove(int id)
        {
            Console.WriteLine($"Email Notification: Product removed.");
        }

        public void Add(Product product)
        {
            Console.WriteLine($"Email Notification: New product added - {product.Name}");
        }
    }
}
