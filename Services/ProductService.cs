using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public List<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }

    public Product? GetProductById(int id)
    {
        return _context.Products.FirstOrDefault(x => x.Id == id);
    }

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }
}