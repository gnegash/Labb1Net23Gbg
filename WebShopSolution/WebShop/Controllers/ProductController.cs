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

        // Constructor now takes IUnitOfWork as a parameter ist f�r att injecta repot
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;  // Set the UnitOfWork
        }

        // Endpoint f�r att h�mta alla produkter
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            // Beh�ver anv�nda repository via Unit of Work f�r att h�mta produkter
            var products = _unitOfWork.Products.GetAll();

            //returnera de
            return Ok(products);
        }

        // Endpoint f�r att l�gga till en ny produkt
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            // L�gger till produkten via repository
            _unitOfWork.Products.Add(product);

            // Notifierar observat�rer om att en ny produkt har lagts till
            //_unitOfWork.NotifyProductAdded(product);

            // Sparar f�r�ndringar

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
