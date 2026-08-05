using Bingo.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bingo.Infrastructure.ModelConfigurations;

/// <summary>
/// Model configuration for <see cref="Category"/>.
/// </summary>
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    /// <summary>
    /// Configures the Category entity using the Entity Framework Core Fluent API.
    /// </summary>
    /// <param name="builder">
    /// Provides methods to configure the table, columns, keys, indexes and relationships.
    /// </param>
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        // Maps the Category entity to the "Categories" table.
        builder.ToTable("Categories");

        // Configures the Id property as the primary key.
        builder.HasKey(x => x.Id);

        // Starts configuring the Id property.
        builder.Property(x => x.Id)
            // Maps the property to the Id column.
            .HasColumnName("Id")
            // Indicates that the database generates the value when a new record is inserted.
            .ValueGeneratedOnAdd();

        // Starts configuring the Name property.
        builder.Property(x => x.Name)
            // Restricts the maximum length to 100 characters.
            .HasMaxLength(100)
            // Makes the Name column mandatory (NOT NULL).
            .IsRequired()
            // Maps the property to the Name column.
            .HasColumnName("Name");

        // Starts configuring the Slug property.
        builder.Property(x => x.Slug)
            // Restricts the maximum length to 100 characters.
            .HasMaxLength(100)
            // Makes the Slug column mandatory (NOT NULL).
            .IsRequired()
            // Maps the property to the Slug column.
            .HasColumnName("Slug");

        // Starts configuring the Description property.
        builder.Property(x => x.Description)
            // Restricts the maximum length to 500 characters.
            .HasMaxLength(500)
            // Allows NULL values because the description is optional.
            .IsRequired(false)
            // Maps the property to the Description column.
            .HasColumnName("Description");

        // Creates a unique index on the Slug column.
        // This prevents duplicate slugs and improves search performance.
        builder.HasIndex(x => x.Slug)
            .IsUnique();
    }
}