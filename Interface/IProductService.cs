
public interface IProductService
{
    public IEnumerable<Product> GetAll();
    public Product GetById(int id);
    public Product Create(ProductDTO p);
    public bool Delete(int id);
    public Product Update(int id, ProductDTO p);
}