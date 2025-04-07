using MarketPlaceAPI.Product.Model;
using Microsoft.EntityFrameworkCore;

namespace MarketPlaceAPI.Product.Repository;

public class ProductRepository(DbContextOptions<ProductRepository> options) : DbContext(options)
{
    public DbSet<ProductModel> Products => Set<ProductModel>();
}
