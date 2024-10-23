public interface IProductoService
{
    public IEnumerable<Producto> GetAll();
    
    public Producto Create(ProductoDTO p);
    public bool Delete(int id);
    public Producto Update(int id, Producto p);
}