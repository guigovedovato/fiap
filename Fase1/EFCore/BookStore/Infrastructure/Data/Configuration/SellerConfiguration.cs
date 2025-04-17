using BookStore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Data.Configuration;

public class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.ToTable("Sellers");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .HasColumnType("UniqueIdentifier");
        builder.Property(s => s.CreatedAt)
            .HasColumnType("DATETIME")
            .IsRequired();
        builder.Property(s => s.UpdatedAt)
            .HasColumnType("DATETIME")
            .IsRequired();

        builder.Property(s => s.Name)
            .IsRequired()
            .HasColumnType("VARCHAR(100)");
        builder.Property(s => s.Email)
            .IsRequired()
            .HasColumnType("VARCHAR(100)");
        builder.Property(s => s.Phone)
            .IsRequired()
            .HasColumnType("VARCHAR(20)");

        // Relationships
       builder.HasOne(c => c.Address)
            .WithOne(c => c.Seller)
            .HasForeignKey<Address>(a => a.CustomerId)
            .IsRequired();
    }
}