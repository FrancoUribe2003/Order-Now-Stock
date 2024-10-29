using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/Products")]
public class ProductController : ControllerBase 
{
    private readonly IProductService _productService;


    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll()
    {
        var products = await _productService.GetAllAsync() ?? new List<Product>();
        return Ok(products);
    }
    [HttpPost]
    public async Task<ActionResult<Product>> NewProduct([FromBody] ProductDTO productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newProduct = await _productService.CreateAsync(productDto);
        return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound("Product not found");
        }
        return Ok(product);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _productService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound("There is no product with that ID");
        }
        return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductDTO productDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProduct = await _productService.UpdateAsync(id, productDto);
        if (updatedProduct == null)
        {
            return NotFound("Prodcut not found");
        }

        return NoContent();
    }
}
