using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasColumnType("INT")
            .ValueGeneratedNever()
            .UseIdentityColumn();
        builder.Property(c => c.CreatedAt)
            .HasColumnType("DATETIME")
            .IsRequired();
        builder.Property(c => c.Name)
            .IsRequired()
            .HasColumnType("VARCHAR(100)");
        builder.Property(c => c.BirthDate)
            .HasColumnType("DATETIME");
        builder.Property(c => c.Email)
            .HasColumnType("VARCHAR(100)");
    }
}