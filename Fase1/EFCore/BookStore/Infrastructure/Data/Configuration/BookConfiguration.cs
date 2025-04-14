using BookStore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Data.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .HasColumnType("UniqueIdentifier")
            .UseIdentityColumn();
        builder.Property(b => b.CreatedAt)
            .HasColumnType("DATETIME")
            .IsRequired();
        builder.Property(b => b.UpdatedAt)
            .HasColumnType("DATETIME")
            .IsRequired();

        builder.Property(b => b.Title)
            .IsRequired()
            .HasColumnType("VARCHAR(100)");
        builder.Property(b => b.Author)
            .IsRequired()
            .HasColumnType("VARCHAR(100)");
        builder.Property(b => b.ISBN)
            .IsRequired()
            .HasColumnType("VARCHAR(20)");
        builder.Property(b => b.Price)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();

        // Relationships
        builder.HasOne(b => b.Stock)
            .WithOne()
            .HasPrincipalKey("Id");
        builder.HasOne(b => b.Seller)
            .WithOne()
            .HasPrincipalKey("Id");
    }
}