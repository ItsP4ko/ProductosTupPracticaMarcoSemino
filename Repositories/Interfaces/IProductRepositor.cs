namespace Repositories.Interfaces;

using Entities;

public interface IProductRepositor
{
    List<Product> GetAllProducts();
    Product? GetProductById(int id);
    Product AddProduct(string name, decimal price);
    bool UpdateProduct(int id, string name, decimal price);
    bool DeleteProduct(int id);
}
