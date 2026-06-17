using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private static List<Product> products =
    [
        new Product
        {
            Id = 1,
            Name = "Laptop",
            Price = 15000000
        },

        new Product
        {
            Id = 2,
            Name = "Mouse",
            Price = 200000
        }
    ];

    // GET: api/product
    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(products);
    }

    // GET: api/product/{id}
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = products.FirstOrDefault(x => x.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    // POST: api/product
    [HttpPost]
    public IActionResult PostProduct(Product product)
    {
        products.Add(product);

        return CreatedAtAction(
            nameof(GetProduct),
            new { id = product.Id },
            product);
    }

    // PUT: api/product/{id}
    [HttpPut("{id}")]
    public IActionResult PutProduct(int id, Product product)
    {
        var existingProduct = products.FirstOrDefault(x => x.Id == id);

        if (existingProduct == null)
        {
            return NotFound();
        }

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;

        return NoContent();
    }

    // DELETE: api/product/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = products.FirstOrDefault(x => x.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        products.Remove(product);

        return NoContent();
    }
}
