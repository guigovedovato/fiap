using MarketPlaceService.Model;
using Microsoft.EntityFrameworkCore;

namespace MarketPlaceService.Repository;

public class ProductRepository(DbContextOptions<ProductRepository> options) : DbContext(options)
{
    public DbSet<ProductModel> Products => Set<ProductModel>();
}
