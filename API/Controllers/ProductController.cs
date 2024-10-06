using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await productService.GetProductsAsync();
        return Ok(products);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(string name, decimal price)
    {
        await productService.AddProductAsync(name, price);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id, decimal newPrice)
    {
        await productService.UpdateProductAsync(id, newPrice);
        return Ok();
    }
}