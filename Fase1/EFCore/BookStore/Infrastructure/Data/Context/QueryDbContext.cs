using BookStore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using BookStore.Infrastructure.Data.Configuration;
using Microsoft.Extensions.Configuration;

namespace BookStore.Infrastructure.Data.Context;

public class QueryDbContext : DbContext
{
    private readonly string _connectionString;

    public QueryDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public QueryDbContext()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        _connectionString = configuration.GetConnectionString("QueryConnection") 
                ?? throw new InvalidOperationException("Connection string not found.");
    }

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Seller> Sellers { get; set; } = null!;
    public DbSet<Stock> Stocks { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(QueryDbContext).Assembly);
    }
}