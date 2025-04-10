using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context.Configurations;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    private readonly string _connectionString;
    
    public ApplicationDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public ApplicationDbContext()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string not found.");
    }

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;

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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
