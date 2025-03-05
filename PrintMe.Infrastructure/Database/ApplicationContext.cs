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
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CatalogItemConfiguration());
        // builder.Entity<CatalogItem>(builder =>
        // {
        //     builder.OwnsMany(c => c.ProductImages);
        // });
    }
}

public class CatalogItemConfiguration : IEntityTypeConfiguration<CatalogItem>
{
    public void Configure(EntityTypeBuilder<CatalogItem> builder)
    {
        builder.HasIndex(p => p.Category);
        builder.HasIndex(p => p.AvailableStock);
        builder.HasIndex(p => p.Price);
        builder.HasIndex(p => p.Tags);

        builder
            .HasIndex(p => p.Name)
            .HasDatabaseName("idx_catalog_name");
        
        builder
            .HasIndex(p => p.Description)
            .HasDatabaseName("idx_catalog_description");
        
        builder
            .HasIndex(p => p.Motto)
            .HasDatabaseName("idx_catalog_motto");
        
        builder.Property(b => b.Price)
            .HasPrecision(18, 2);
    }
}