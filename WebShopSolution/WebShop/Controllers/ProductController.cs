using Microsoft.AspNetCore.Mvc;
using WebShop.Entities;
using WebShop.Repositories;
using WebShop.UnitOfWork;

//namespace WebShop.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class ProductController : ControllerBase
//    {
//        private readonly ProductService _productService;

//        public ProductController(ProductService productService)
//        {
//            _productService = productService;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetProducts()
//        {
//            var products = await _productService.GetProductsAsync();
//            return Ok(products);
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddProduct([FromBody] Product product)
//        {
//            await _productService.AddProductAsync(product);
//            return Ok("Product added successfully");
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteProduct(int id)
//        {
//            await _productService.DeleteProductAsync(id);
//            return Ok("Product deleted successfully");
//        }

//        [HttpPut]
//        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
//        {
//            await _productService.UpdateProductAsync(product);
//            return Ok("Product updated successfully");
//        }
//    }
//}
