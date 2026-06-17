using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: api/product
    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_productService.GetAllProducts());
    }

    // GET: api/product/{id}
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = _productService.GetProductById(id);

        if (product == null)
        {
            return NotFound(new { Message = $"Không tìm thấy sản phẩm với Id = {id}" });
        }

        return Ok(product);
    }

    // POST: api/product
    [HttpPost]
    public IActionResult PostProduct(Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _productService.AddProduct(product);

        return CreatedAtAction(
            nameof(GetProduct),
            new { id = product.Id },
            product);
    }

    // PUT: api/product/{id}
    [HttpPut("{id}")]
    public IActionResult PutProduct(int id, Product product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _productService.UpdateProduct(id, product);

        if (!result)
        {
            return NotFound(new { Message = $"Không tìm thấy sản phẩm với Id = {id}" });
        }

        return NoContent();
    }

    // DELETE: api/product/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var result = _productService.DeleteProduct(id);

        if (!result)
        {
            return NotFound(new { Message = $"Không tìm thấy sản phẩm với Id = {id}" });
        }

        return NoContent();
    }
}