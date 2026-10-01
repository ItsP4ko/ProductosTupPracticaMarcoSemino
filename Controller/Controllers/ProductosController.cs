using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Models.DTOs.Requests;
using Services.Models.DTOs.Responses;

namespace ProductosTUP.Controllers;

[ApiController]
[Route("products/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<List<ProductReadDto>> GetAllProducts()
    {
        return _productService.GetAllProducts();
    }

    [HttpGet("{id}")]
    public ActionResult<ProductReadDto> GetProductById([FromRoute] int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return product;
    }

    [HttpPost]
    public ActionResult<ProductReadDto> CreateProduct([FromBody] ProductCreateDto? dto)
    {
        if (dto == null)
        {
            return BadRequest();
        }
        if (dto.Price <= 0)
        {
            return BadRequest();
        }
        var created = _productService.CreateProduct(dto);
        if (created == null)
        {
            return BadRequest();
        }
        return created;
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct([FromRoute] int id, [FromBody] ProductUpdateDto dto)
    {
        if (dto == null)
        {
            return BadRequest();
        }

        return _productService.UpdateProduct(id, dto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct([FromRoute] int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }
        return _productService.DeleteProduct(id) ? NoContent() : NotFound();
    }

}