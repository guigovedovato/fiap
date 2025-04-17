using BookStore.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Infrastructure.Data.Configuration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .HasColumnType("UniqueIdentifier");
        builder.Property(a => a.CreatedAt)
            .HasColumnType("DATETIME")
            .IsRequired();
        builder.Property(a => a.UpdatedAt)
            .HasColumnType("DATETIME")
            .IsRequired();

        builder.Property(a => a.Street)
            .IsRequired()
            .HasColumnType("VARCHAR(100)");
        builder.Property(a => a.City)
            .IsRequired()
            .HasColumnType("VARCHAR(50)");
        builder.Property(a => a.State)
            .IsRequired()
            .HasColumnType("VARCHAR(50)");
        builder.Property(a => a.ZipCode)
            .IsRequired()
            .HasColumnType("VARCHAR(20)");
        builder.Property(a => a.Country)
            .IsRequired()
            .HasColumnType("VARCHAR(50)");
    }
}