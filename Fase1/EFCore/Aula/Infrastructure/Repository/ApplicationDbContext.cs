using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repository.Configurations;

namespace Infrastructure.Repository;

public class ApplicationDbContext : DbContext
{
    private readonly string _connectionString;
    public ApplicationDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    public ApplicationDbContext(){}

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
