using Microsoft.AspNetCore.Mvc;
using WebShop.Repositories;
using WebShop.UnitOfWork;

namespace WebShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;  // Inject UnitOfWork here

        // Constructor now takes IUnitOfWork as a parameter ist för att injecta repot
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;  // Set the UnitOfWork
        }

        // Endpoint för att hämta alla produkter
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            // Behöver använda repository via Unit of Work för att hämta produkter
            var products = _unitOfWork.Products.GetAll();

            //returnera de
            return Ok(products);
        }

        // Endpoint för att lägga till en ny produkt
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            // Lägger till produkten via repository
            _unitOfWork.Products.Add(product);

            // Notifierar observatörer om att en ny produkt har lagts till
            //_unitOfWork.NotifyProductAdded(product);

            // Sparar förändringar

            return Ok();
        }

        public ActionResult DeleteProduct(int id)
        {
            _unitOfWork.Products.Delete(id);

            //_unitOfWork.NotifyProductRemoved(id);

            return Ok();
        }
    }
}
