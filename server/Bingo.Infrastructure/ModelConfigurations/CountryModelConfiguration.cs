using Bingo.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bingo.Infrastructure.ModelConfigurations;

/// <summary>
/// Model configuration for <see cref="Country"/>.
/// </summary>
public class CountryModelConfiguration : IEntityTypeConfiguration<Country>
{
    /// <summary>
    /// Configures the Country entity using the Entity Framework Core Fluent API.
    /// </summary>
    /// <param name="builder">
    /// Provides methods to configure the table, columns, keys, indexes and relationships.
    /// </param>
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        // Maps the Country entity to the "Countries" table.
        builder.ToTable("Countries");

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

        // Starts configuring the IsoCode property.
        builder.Property(x => x.IsoCode)
            // Restricts the maximum length to 10 characters.
            .HasMaxLength(10)
            // Makes the ISO code mandatory.
            .IsRequired()
            // Maps the property to the ISOCode column.
            .HasColumnName("ISOCode");

        // Starts configuring the PhoneCode property.
        builder.Property(x => x.PhoneCode)
            // Restricts the maximum length to 10 characters.
            .HasMaxLength(10)
            // Makes the phone code mandatory.
            .IsRequired()
            // Maps the property to the PhoneCode column.
            .HasColumnName("PhoneCode");

        // Creates a unique index on the Name column.
        // This prevents duplicate country names.
        builder.HasIndex(x => x.Name)
            .IsUnique();

        // Creates a unique index on the IsoCode column.
        // This ensures every country has a unique ISO code.
        builder.HasIndex(x => x.IsoCode)
            .IsUnique();

        builder.HasData([
            new Country { Id = 1, Name = "India", IsoCode = "IN", PhoneCode = "+91"}
        ]);
    }
}