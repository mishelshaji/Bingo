using Bingo.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bingo.Infrastructure.ModelConfigurations;

/// <summary>
/// Configures the database mapping for the <see cref="Brand"/> entity.
/// </summary>
public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    /// <summary>
    /// Configures the Brand entity using the Entity Framework Core Fluent API.
    /// </summary>
    /// <param name="builder">
    /// Provides methods to configure the table, columns, keys, indexes and relationships.
    /// </param>
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        // Maps the Brand entity to the "Brands" table in the database.
        builder.ToTable("Brands");

        // Configures the Id property as the primary key.
        builder.HasKey(x => x.Id);

        // Starts configuring the Id property.
        builder.Property(x => x.Id)
            // Indicates that the database generates the value when a new record is inserted.
            .ValueGeneratedOnAdd();

        // Starts configuring the Name property.
        builder.Property(x => x.Name)
            // Restricts the maximum length of the column to 100 characters.
            .HasMaxLength(100)
            // Makes the Name column mandatory (NOT NULL).
            .IsRequired();

        // Configures the WebsiteUrl property.
        builder.Property(x => x.WebsiteUrl)
            // Restricts the maximum length to 250 characters.
            .HasMaxLength(250);

        // Configures the LogoUrl property.
        builder.Property(x => x.LogoUrl)
            // Restricts the maximum length to 250 characters.
            .HasMaxLength(250);

        // Configures the SupportEmail property.
        builder.Property(x => x.SupportEmail)
            // Restricts the maximum length to 250 characters.
            .HasMaxLength(250);

        // Creates a unique index on the Name column.
        // This improves search performance and prevents duplicate brand names.
        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}