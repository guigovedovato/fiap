using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
            .HasColumnType("INT")
            .UseIdentityColumn();
        builder.Property(o => o.CreatedAt)
            .HasColumnType("DATETIME")
            .IsRequired();
        builder.Property(o => o.ClientId)
            .HasColumnType("INT")
            .IsRequired();
        builder.Property(o => o.BookId)
            .HasColumnType("INT")
            .IsRequired();


        builder.HasOne(o => o.Client)
            .WithMany(c => c.Orders)
            .HasPrincipalKey(o => o.Id);
        builder.HasOne(o => o.Book)
            .WithMany(b => b.Orders)
            .HasPrincipalKey(o => o.Id);
    }
}