using Moq;
using WebShop.Entities;
using WebShop.Notifications;

namespace WebShop.Tests
{
    public class UnitOfWorkTests
    {
        [Fact]
        public void NotifyProductAdded_CallsObserverUpdate()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Test" };

            // Skapar en mock av INotificationObserver
            var mockObserver = new Mock<INotificationObserver>();

            // Skapar en instans av ProductSubject och l�gger till mock-observat�ren
            var productSubject = new ProductSubject();
            productSubject.Attach(mockObserver.Object);

            // Injicerar v�rt eget ProductSubject i UnitOfWork

            // varf�r tas UnitOfWork som typ innan metod?
            var unitOfWork = new UnitOfWork.UnitOfWork(productSubject);

            // Act
            unitOfWork.NotifyProductAdded(product);

            // Assert
            // Verifierar att Update-metoden kallades p� v�r mock-observat�r
            mockObserver.Verify(o => o.AddProduct(product), Times.Once);
        }

        [Fact]
        public void NotifyProductRemoved_CallsObserver()
        {
            // Arrange
            var productId = 1;

            var mockObserver = new Mock<INotificationObserver>();

            var prodSubject = new ProductSubject();
            prodSubject.Attach(mockObserver.Object);

            var unitOfWork = new UnitOfWork.UnitOfWork(prodSubject);

            // Act
            unitOfWork.NotifyProductRemoved(productId);

            // Assert
            mockObserver.Verify(o => o.RemoveProduct(productId), Times.Once);
        }
    }
}
