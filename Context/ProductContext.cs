using Microsoft.EntityFrameworkCore;

public class ProductContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ProductContext(DbContextOptions<ProductContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(a => a.Name).IsRequired();  
            entity.Property(a => a.Price).IsRequired(); 
            entity.Property(a => a.Stock).IsRequired();             
        });
    }
}
