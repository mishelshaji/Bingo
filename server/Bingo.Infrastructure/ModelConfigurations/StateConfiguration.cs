using Bingo.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bingo.Infrastructure.ModelConfigurations;

/// <summary>
/// Model configuration for <see cref="State"/>.
/// </summary>
public class StateConfiguration : IEntityTypeConfiguration<State>
{
    /// <summary>
    /// Configures the State entity using the Entity Framework Core Fluent API.
    /// </summary>
    /// <param name="builder">
    /// Provides methods to configure the table, columns, keys, indexes and relationships.
    /// </param>
    public void Configure(EntityTypeBuilder<State> builder)
    {
        // Maps the State entity to the "States" table.
        builder.ToTable("States");

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

        // Configures the IsoCode property.
        builder.Property(x => x.IsoCode)
            // Restricts the maximum length to 10 characters.
            .HasMaxLength(10)
            // Makes the IsoCode column mandatory.
            .IsRequired()
            // Maps the property to the IsoCode column.
            .HasColumnName("IsoCode");

        // Creates a composite unique index on Name and CountryId.
        // This allows different countries to have states with the same name,
        // but prevents duplicate state names within the same country.
        builder.HasIndex(x => new { x.Name, x.CountryId })
            .IsUnique();

        // Creates a unique index on the IsoCode column.
        // This prevents duplicate ISO codes.
        builder.HasIndex(x => x.IsoCode)
            .IsUnique();

        // Configures the relationship between State and Country.
        // One Country can have many States.
        // Each State belongs to one Country.
        builder.HasOne(x => x.Country)
            .WithMany(x => x.States)
            .HasForeignKey(x => x.CountryId);

        builder.HasData([
            new State() { Id = 1, Name = "Kerala", IsoCode = "IN-KL", CountryId = 1 },
            new State() { Id = 2, Name = "Tamil Nadu", IsoCode = "IN-TN", CountryId = 1 }
        ]);
    }
}
