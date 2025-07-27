using Business_Layer.Dtos;
using Business_Layer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Order_Management_System.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController(IProductService _productService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductAsync(id);
            return product is not null ? Ok(product) : BadRequest("Product not found");
        }

        [HttpPost]  
        public async Task<ActionResult> AddProduct(ProductDto dto)
        {
            var product = await _productService.AddProductAsync(dto);
            return product is not null ? Ok(product) : BadRequest("Invalid Input");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto dto)
        {
            var updatedProduct = await _productService.UpdateProductAsync(id, dto);
            if (updatedProduct == null)
                return NotFound("Product not found");

            return Ok(updatedProduct);
        }
    }
}
