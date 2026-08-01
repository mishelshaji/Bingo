using Bingo.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bingo.Infrastructure.ModelConfigurations;

/// <summary>
/// Model configuration for <see cref="ProductTag"/>.
/// </summary>
public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
{
    /// <summary>
    /// Configures the ProductTag entity using the Entity Framework Core Fluent API.
    /// </summary>
    /// <param name="builder">
    /// Provides methods to configure the table, columns, keys, indexes and relationships.
    /// </param>
    public void Configure(EntityTypeBuilder<ProductTag> builder)
    {
        // Maps the ProductTag entity to the "ProductTags" table.
        builder.ToTable("ProductTags");

        // Configures the Id property as the primary key.
        builder.HasKey(x => x.Id);

        // Configures the Id property.
        builder.Property(x => x.Id)
            // Maps the property to the Id column.
            .HasColumnName("Id")
            // Indicates that the database generates the value when a new record is inserted.
            .ValueGeneratedOnAdd();

        // Configures the ProductId foreign key property.
        builder.Property(x => x.ProductId)
            // Maps the property to the ProductId column.
            .HasColumnName("ProductId")
            // Makes the ProductId column mandatory.
            .IsRequired();

        // Configures the TagId foreign key property.
        builder.Property(x => x.TagId)
            // Maps the property to the TagId column.
            .HasColumnName("TagId")
            // Makes the TagId column mandatory.
            .IsRequired();

        // Creates a composite index on ProductId and TagId.
        // This improves the performance of queries that search using both columns.
        builder.HasIndex(x => new { x.ProductId, x.TagId });

        // Configures the relationship between ProductTag and Product.
        // One Product can have many ProductTag records.
        // Each ProductTag belongs to one Product.
        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductTags)
            .HasForeignKey(x => x.ProductId);

        // Configures the relationship between ProductTag and Tag.
        // One Tag can have many ProductTag records.
        // Each ProductTag belongs to one Tag.
        builder.HasOne(x => x.Tag)
            .WithMany(x => x.ProductTags)
            .HasForeignKey(x => x.TagId);
    }
}