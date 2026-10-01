namespace Services.Implementations;

using Interfaces;
using Models.DTOs.Requests;
using Models.DTOs.Responses;
using Repositories.Entities;
using Repositories.Interfaces;

public class ProductService : IProductService
{
    private readonly IProductRepositor _repository;

    public ProductService(IProductRepositor repository)
    {
        _repository = repository;
    }

    public List<ProductReadDto> GetAllProducts()
    {
        return _repository.GetAllProducts().Select(ToDto).ToList();
    }

    public ProductReadDto? GetProductById(int id)
    {
        var product = _repository.GetProductById(id);
        return product is null ? null : ToDto(product);
    }

    public ProductReadDto CreateProduct(ProductCreateDto dto)
    {
        var product = _repository.AddProduct(dto.Name, dto.Price);
        return ToDto(product);
    }

    public bool UpdateProduct(int id, ProductUpdateDto dto)
    {
        return _repository.UpdateProduct(id, dto.Name, dto.Price);
    }

    public bool DeleteProduct(int id)
    {
        return _repository.DeleteProduct(id);
    }

    private static ProductReadDto ToDto(Product product)
    {
        return new ProductReadDto(product.Id, product.Name, product.Price);
    }
}
