using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .HasColumnType("INT")
            .UseIdentityColumn();
        builder.Property(b => b.CreatedAt)
            .HasColumnType("DATETIME")
            .IsRequired();
        builder.Property(b => b.Title)
            .IsRequired()
            .HasColumnType("VARCHAR(100)");
        builder.Property(b => b.Publisher)
            .IsRequired()
            .HasColumnType("VARCHAR(100)");
    }
}