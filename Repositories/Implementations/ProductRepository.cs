namespace Repositories.Implementations;

using Entities;
using Interfaces;

public class ProductRepositor : IProductRepositor
{
    private static List<Product> _products = new()
    {
        new Product(id: 1, name: "Mouse inalámbrico", price: 3999.99m),
        new Product(id: 2, name: "Teclado mecánico", price: 8299.50m),
        new Product(id: 3, name: "Monitor 24 pulgadas", price: 52499.00m),
        new Product(id: 4, name: "Notebook Dell Inspiron", price: 185000.00m),
        new Product(id: 5, name: "Auriculares Bluetooth", price: 10499.90m),
        new Product(id: 6, name: "Webcam HD", price: 7999.00m),
        new Product(id: 7, name: "Silla ergonómica", price: 61200.00m),
        new Product(id: 8, name: "Disco SSD 1TB", price: 44999.99m),
        new Product(id: 9, name: "Tablet Samsung Galaxy", price: 93499.00m),
        new Product(id: 10, name: "Impresora multifunción", price: 73900.00m)
    };

    public List<Product> GetAllProducts()
    {
        return _products;
    }

    public Product? GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public Product AddProduct(string name, decimal price)
    {
        int newId = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;

        var newProduct = new Product(newId, name, price);
        _products.Add(newProduct);

        return newProduct;
    }

    public bool UpdateProduct(int id, string name, decimal price)
    {
        var producto = _products.FirstOrDefault(p => p.Id == id);

        if (producto is null)
            return false;

        producto.SetName(name);
        producto.SetPrice(price);

        return true;
    }

    public bool DeleteProduct(int id)
    {
        var producto = _products.FirstOrDefault(p => p.Id == id);

        if (producto is null)
            return false;

        _products.Remove(producto);
        return true;
    }
}
