using Microsoft.AspNetCore.Mvc;
using Moq;
using WebShop;
using WebShop.Controllers;
using WebShop.Repositories;
using WebShop.UnitOfWork;

//public class ProductControllerTests
//{
//    private readonly Mock<IProductRepository> _mockProductRepository;
//    private readonly ProductController _controller;
//    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

//    public ProductControllerTests()
//    {
//        _mockProductRepository = new Mock<IProductRepository>();
//        // Ställ in mock av Products-egenskapen
//        _mockUnitOfWork = new Mock<IUnitOfWork>();

//        // Mock the unit of work to return the mocked product repository
//        _mockUnitOfWork.Setup(uow => uow.Products).Returns(_mockProductRepository.Object);

//        // Initialize the controller with the mocked UnitOfWork
//        //_controller = new ProductController(_mockUnitOfWork.Object);
//    }

//    [Fact]
//    public void GetProducts_ReturnsAListOfProducts()
//    {
//        // Arrange
//        var products = new List<Product>
//        {
//            new Product { Id = 1, Name = "Bread" },
//            new Product { Id = 2, Name = "Car" }
//        };

        _mockProductRepository.Setup(repo => repo.GetAll()).Returns(products);

//        // Act
//        var result = _controller.GetProducts();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result); // Check if the result is OkObjectResult
        var returnedProducts = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value); // Get the list of products from the OkObjectResult
        Assert.Equal(2, returnedProducts.Count());

    }

//    [Fact]
//    public void AddProduct_ReturnsOkResult()
//    {
//        // Arrange
//        var product = new Product { Id = 1, Name = "Test Product" };


//        // Act
//        var result = _controller.AddProduct(product);


//        // Assert
//        var okResult = Assert.IsType<OkResult>(result); // Assert that the result is OkResult
//        _mockProductRepository.Verify(repo => repo.Add(It.IsAny<Product>()), Times.Once); // Ensure Add was called once

//        //_mockUnitOfWork.Verify(uow => uow.NotifyProductAdded(product), Times.Once);

//    }

//    [Fact]
//    public void RemoveProduct_ReturnsOkResult()
//    {
//        // Arrange
//        var productId = 1;


//        // Act
//        var result = _controller.DeleteProduct(productId);


//        // Assert
//        var okResult = Assert.IsType<OkResult>(result); // Assert that the result is OkResult
//        _mockProductRepository.Verify(repo => repo.Delete(productId), Times.Once);

        // Ensure the notification about product removal is triggered once
        _mockUnitOfWork.Verify(uow => uow.NotifyProductRemoved(productId), Times.Once);
    }
}