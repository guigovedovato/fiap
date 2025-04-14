using BookStore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Data.Configuration;

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ToTable("Stock");
        builder.HasKey(a => a.Id);
        builder.Property(s => s.Id)
            .HasColumnType("UniqueIdentifier");
        builder.Property(o => o.CreatedAt)
            .HasColumnType("DATETIME")
            .IsRequired();
        builder.Property(s => s.UpdatedAt)
            .HasColumnType("DATETIME")
            .IsRequired();

        builder.Property(s => s.Quantity)
            .HasColumnType("INT")
            .IsRequired();
        builder.Property(s => s.BookId)
            .HasColumnType("UniqueIdentifier")
            .IsRequired();
        builder.Property(s => s.SellerId)
            .HasColumnType("UniqueIdentifier")
            .IsRequired();

        // Relationships
        builder.HasOne(s => s.Book)
            .WithOne()
            .HasPrincipalKey("Id");
        builder.HasOne(s => s.Seller)
            .WithMany(s => s.Stocks)
            .HasPrincipalKey(o => o.Id);
    }
}