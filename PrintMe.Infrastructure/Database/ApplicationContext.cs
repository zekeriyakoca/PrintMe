using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using PrintMe.Application.Entities;
using PrintMe.Application.Enums;

namespace PrintMe.Infrastructure.Database;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration) : base(options)
    {
    }

    public DbSet<CatalogItem> CatalogItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new EntitiesCofiguration());
    }
}

public class EntitiesCofiguration : IEntityTypeConfiguration<CatalogItem>
{
    public void Configure(EntityTypeBuilder<CatalogItem> builder)
    {
        builder.HasIndex(ci => ci.Name);
        builder.Property(b => b.Price)
            .HasPrecision(18, 2);
    }
}