using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/Products")]
public class ProductController : ControllerBase 
{
    private readonly IProductService _ProductService;

    public ProductController(IProductService ProductService)
    {
        _ProductService = ProductService;
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        Product? p = _ProductService.GetById(id);
        if (p == null)
        {
            return NotFound("Producto no encontrado");
        }
        return Ok(p);
    }

    [HttpGet]
    public ActionResult<List<Product>> GetAll()
    {
        return Ok(_ProductService.GetAll());
    }

    [HttpPost]
    public ActionResult<Product> NewProduct(ProductDTO p)
    {
        Product _p = _ProductService.Create(p);
        return Created("", _p); // Cambiado a _p
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var p = _ProductService.GetById(id); // Cambiado a id

        if (p == null)
        {
            return NotFound("No existe ningun producto con ese ID");
        }

        _ProductService.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult<Product> Update(int id, ProductDTO p)
    {
        var Product = _ProductService.Update(id, p);

        if (Product is null)
        {
            return NotFound();
        }

        return Ok(Product); // Cambiado a Product
    }
}