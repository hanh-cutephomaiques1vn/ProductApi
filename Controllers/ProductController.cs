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

    [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(products);
    }

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
    [HttpPost]
    public IActionResult PostProduct(Product product)
    {
        products.Add(product);

        return CreatedAtAction(
            nameof(GetProduct),
            new { id = product.Id },
            product);
    }
}
    


