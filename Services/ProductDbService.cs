using Microsoft.EntityFrameworkCore;

public class ProductDbService : IProductService
{
    private readonly ProductContext _context;
    public ProductDbService(ProductContext context)
    {
        _context = context;
    }

    public async Task<Product> CreateAsync(ProductDTO productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price,
            Stock = productDto.Stock
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<Product> UpdateAsync(int id, ProductDTO productDto)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.Stock = productDto.Stock;
            await _context.SaveChangesAsync();
        }
        return product;
    }

    async Task<bool> IProductService.DeleteAsync(int id) {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
