using Bingo.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bingo.Infrastructure.ModelConfigurations;

/// <summary>
/// Model configuration for <see cref="Tag"/>.
/// </summary>
public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    /// <summary>
    /// Configures the Tag entity using the Entity Framework Core Fluent API.
    /// </summary>
    /// <param name="builder">
    /// Provides methods to configure the table, columns, keys, indexes and relationships.
    /// </param>
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        // Maps the Tag entity to the "Tags" table.
        builder.ToTable("Tags");

        // Configures the Id property as the primary key.
        builder.HasKey(x => x.Id);

        // Configures the Id property.
        builder.Property(x => x.Id)
            // Maps the property to the Id column.
            .HasColumnName("Id")
            // Indicates that the database generates the value when a new record is inserted.
            .ValueGeneratedOnAdd();

        // Configures the Name property.
        builder.Property(x => x.Name)
            // Restricts the maximum length to 100 characters.
            .HasMaxLength(100)
            // Makes the Name column mandatory.
            .IsRequired()
            // Maps the property to the Name column.
            .HasColumnName("Name");

        // Configures the Description property.
        builder.Property(x => x.Description)
            // Restricts the maximum length to 500 characters.
            .HasMaxLength(500)
            // Allows NULL values because the description is optional.
            .IsRequired(false)
            // Maps the property to the Description column.
            .HasColumnName("Description");

        // Creates a unique index on the Name column.
        // This prevents duplicate tag names.
        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}