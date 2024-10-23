using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
    
[ApiController]
[Route("api/Products")]

public class ProductController: ControllBase 
{
    private readonly IProductService _ProductService;

    public ProductController(IProductService ProductService)
    {
        _ProductService = ProductService;
    }

    private Product GetById(int id) //Se encuentra aca para ser funcional dentro de la logica, no es un endpoint
    {
        return _ProductService.GetAll().FirstOrDefault(p => p.Id == id);
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
        return Created("", newProduct);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var p = _ProductService.GetById(p);

        if(p == null)
        {
            return NotFound("No existe ningun producto con ese ID")
        }

        _ProductService.Delete(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult<Product> Update(int id, ProductDTO p)
    {
        var Product = _ProductService.Update(id, p);

        if(Product is null)
        {
            return NotFound();
        }
        
        return Created("", newProduct);
    }
}