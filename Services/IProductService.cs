using ProductApi.Models;

namespace ProductApi.Services;

public interface IProductService
{
    List<Product> GetAllProducts();

    Product? GetProductById(int id);

    void AddProduct(Product product);

    bool UpdateProduct(int id, Product product);

    bool DeleteProduct(int id);
}