using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Infrastructure.Command.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EShop.Product.Service;

namespace Product.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct([FromQuery] string productID)
        {
            var product = await _productService.GetProduct(productID);

            if (product is null)
                return NotFound();
               
            return Ok(product);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProduct createProduct)
        {
            var productCreated = await _productService.AddProduct(createProduct);

            return StatusCode((int) HttpStatusCode.Created);
        }
    }
}
