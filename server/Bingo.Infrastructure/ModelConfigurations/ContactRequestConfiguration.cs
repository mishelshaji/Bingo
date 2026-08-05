using Bingo.Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bingo.Infrastructure.ModelConfigurations;

/// <summary>
/// Model configuration for <see cref="ContactRequest"/>.
/// </summary>
public class ContactRequestConfiguration : IEntityTypeConfiguration<ContactRequest>
{
    /// <summary>
    /// Configures the ContactRequest entity using the Entity Framework Core Fluent API.
    /// </summary>
    /// <param name="builder">
    /// Provides methods to configure the table, columns, keys and relationships.
    /// </param>
    public void Configure(EntityTypeBuilder<ContactRequest> builder)
    {
        // Maps the ContactRequest entity to the "ContactRequests" table.
        builder.ToTable("ContactRequests");

        // Configures the Id property as the primary key.
        builder.HasKey(x => x.Id);

        // Starts configuring the Id property.
        builder.Property(x => x.Id)
            // Maps the property to the Id column.
            .HasColumnName("Id")
            // Indicates that the database generates the value when a new record is inserted.
            .ValueGeneratedOnAdd();

        // Starts configuring the FirstName property.
        builder.Property(x => x.FirstName)
            // Maps the property to the FirstName column.
            .HasColumnName("FirstName")
            // Restricts the maximum length to 50 characters.
            .HasMaxLength(50)
            // Makes the FirstName column mandatory.
            .IsRequired();

        // Starts configuring the LastName property.
        builder.Property(x => x.LastName)
            // Maps the property to the LastName column.
            .HasColumnName("LastName")
            // Restricts the maximum length to 50 characters.
            .HasMaxLength(50)
            // Allows NULL values because the last name is optional.
            .IsRequired(false);

        // Starts configuring the Email property.
        builder.Property(x => x.Email)
            // Maps the property to the Email column.
            .HasColumnName("Email")
            // Restricts the maximum length to 250 characters.
            .HasMaxLength(250)
            // Allows NULL values because the email is optional.
            .IsRequired(false);

        // Starts configuring the PhoneNumber property.
        builder.Property(x => x.PhoneNumber)
            // Maps the property to the PhoneNumber column.
            .HasColumnName("PhoneNumber")
            // Restricts the maximum length to 20 characters.
            .HasMaxLength(20)
            // Allows NULL values because the phone number is optional.
            .IsRequired(false);

        // Starts configuring the Message property.
        builder.Property(x => x.Message)
            // Maps the property to the Message column.
            .HasColumnName("Message")
            // Restricts the maximum length to 500 characters.
            .HasMaxLength(500)
            // Allows NULL values because the message is optional.
            .IsRequired(false);
    }
}