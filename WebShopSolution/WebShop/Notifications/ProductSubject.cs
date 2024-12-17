using WebShop.Entities;

namespace WebShop.Notifications
{
    // Subject som håller reda på observatörer och notifierar dem
    public class ProductSubject
    {
        // Lista över registrerade observatörer
        private readonly List<INotificationObserver> _observers = new List<INotificationObserver>();

        public void Attach(INotificationObserver observer)
        {
            // Lägg till en observatör
            _observers.Add(observer);
        }

        // när används?
        public void Detach(INotificationObserver observer)
        {
            // Ta bort en observatör
            _observers.Remove(observer);
        }

        public void NotifyProductAdded(Product product)
        {
            // Notifiera alla observatörer om en ny produkt
            foreach (var observer in _observers)
            {
                observer.AddProduct(product);
            }
        }

        public void NotifyProductRemoved(int id)
        {
            foreach (var observer in _observers)
            {
                observer.RemoveProduct(id);  // Notify observers about product removal
            }
        }

        public void NotifyProductUpdated(Product product)
        {
            foreach (var observer in _observers)
            {
                observer.UpdateProduct(product);
            }
        }

    }
}
