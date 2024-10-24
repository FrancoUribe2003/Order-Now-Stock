using Microsoft.EntityFrameworkCore;

public class ProductDbService: IProductService
{
    private readonly ProductContext _context;

    public ProductDbService(ProductContext context)
    {
        _context = context;
    }

    public Product Create(ProductDTO p)
    {
        var product = new Product
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Description = p.Description,
            Stock = p.Stock
        };

        foreach(int idProduct in p.ProductIds)
        {
            product.Product.Add(_context.Products.Find(idProduct));
        }

        _context.Add(product);
        _context.SaveChanges();
        return product;
    }

    public bool Delete(int id)
    {
        Product? p = _context.Products.Find(id);
        if (p is null) 
        {
            return false;
        }
        _context.Products.Remove(p);
        _context.SaveChanges();
        return true;
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products;
    }

    public Product Update(int id, ProductDTO p)
    {
        // Busca el producto a actualizar
        var act = _context.Products.FirstOrDefault(prod => prod.Id == id);
        
        if (act == null)
        {
            // Manejo de error en caso de que no se encuentre el producto
            return null;
        }

        // Actualiza las propiedades del producto
        act.Name = p.Name;
        act.Description = p.Description;
        act.Price = p.Price;
        act.Stock = p.Stock;
        // Marca el producto como modificado en el contexto
        _context.Entry(act).State = EntityState.Modified;
        _context.SaveChanges();
        return act;
    }

}