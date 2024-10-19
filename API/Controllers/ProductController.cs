// using Application.Products.Models;
// using Application.Products.Requests;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;
//
// namespace API.Controllers;
//
// [ApiController]
// [Route("api/[controller]")]
// public class ProductController(ISender sender) : ControllerBase
// {
//     [HttpGet]
//     public async Task<IActionResult> GetProducts()
//     {
//         var products = await sender.Send(new GetProductsRequest());
//         return Ok(products);
//     }
//     
//     [HttpGet("{id}")]
//     public async Task<IActionResult> GetProductById(Guid id)
//     {
//         var product = await sender.Send(new GetProductByIdRequest
//         {
//             Id = id
//         });
//         return Ok(product);
//     }
//
//     [HttpPost]
//     public async Task<IActionResult> AddProduct([FromBody] AddProductPro pro)
//     {
//         var productId = await sender.Send(new AddProductRequest
//         {
//             Name = pro.Name,
//             Price = pro.Price
//         });
//         return Ok(productId);
//     }
//
//     // [HttpPut("{id}")]
//     // public async Task<IActionResult> UpdateProduct(Guid id, decimal newPrice)
//     // {
//     //     await productService.UpdateProductAsync(id, newPrice);
//     //     return Ok();
//     // }
// }