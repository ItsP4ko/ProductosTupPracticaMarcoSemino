namespace Services.Interfaces;

using Models.DTOs.Requests;
using Models.DTOs.Responses;

public interface IProductService
{
    List<ProductReadDto> GetAllProducts();
    ProductReadDto? GetProductById(int id);
    ProductReadDto CreateProduct(ProductCreateDto dto);
    bool UpdateProduct(int id, ProductUpdateDto dto);
    bool DeleteProduct(int id);
}
