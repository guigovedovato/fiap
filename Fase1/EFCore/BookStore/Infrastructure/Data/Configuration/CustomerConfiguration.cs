using BookStore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Data.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnType("UniqueIdentifier")
            .UseIdentityColumn();
        builder.Property(c => c.CreatedAt)
            .HasColumnType("DATETIME")
            .IsRequired();
        builder.Property(c => c.UpdatedAt)
            .HasColumnType("DATETIME")
            .IsRequired();

        builder.Property(c => c.Name)
            .IsRequired()
            .HasColumnType("VARCHAR(100)");
        builder.Property(c => c.Email)
            .IsRequired()
            .HasColumnType("VARCHAR(100)");
        builder.Property(c => c.Phone)
            .IsRequired()
            .HasColumnType("VARCHAR(20)");

        // Relationships
        builder.HasOne(c => c.Address)
            .WithOne()
            .HasForeignKey("AddressId");
    }
}