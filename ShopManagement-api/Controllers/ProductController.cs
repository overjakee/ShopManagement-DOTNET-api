using Microsoft.AspNetCore.Mvc;
using ShopManagement_api.DTOs.Product;
using ShopManagement_api.Interfaces.Services;

namespace ShopManagement_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequestDTO request)
        {
            var response = await _productService.AddProductAsync(request);
            return StatusCode(response.IsSuccess ? 201 : 400, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetProductListRequestDTO request)
        {
            var response = await _productService.GetAllProductsAsync(request);
            return Ok(response); // Always 200, response itself indicates success
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var response = await _productService.GetProductByIdAsync(id);
            return response.IsSuccess ? Ok(response) : NotFound(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductRequestDTO request)
        {
            var response = await _productService.UpdateProductAsync(id, request);
            return response.IsSuccess ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _productService.DeleteProductAsync(id);
            return response.IsSuccess ? Ok(response) : NotFound(response);
        }
    }
}
