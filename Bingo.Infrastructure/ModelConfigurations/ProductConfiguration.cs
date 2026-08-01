using Bingo.Core.Domains;
using Bingo.Core.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bingo.Infrastructure.ModelConfigurations;

/// <summary>
/// Model configuration for <see cref="Product"/>.
/// </summary>
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    /// <summary>
    /// Configures the Product entity using the Entity Framework Core Fluent API.
    /// </summary>
    /// <param name="builder">
    /// Provides methods to configure the table, columns, keys, indexes and relationships.
    /// </param>
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Maps the Product entity to the "Products" table.
        builder.ToTable("Products");

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
            // Maps the property to the Name column.
            .HasColumnName("Name")
            // Makes the Name column mandatory.
            .IsRequired()
            // Restricts the maximum length to 150 characters.
            .HasMaxLength(150);

        // Configures the NormalizedName property.
        builder.Property(x => x.NormalizedName)
            // Maps the property to the NormalizedName column.
            .HasColumnName("NormalizedName")
            // Makes the column mandatory.
            .IsRequired()
            // Restricts the maximum length to 150 characters.
            .HasMaxLength(150);

        // Configures the Slug property.
        builder.Property(x => x.Slug)
            // Maps the property to the Slug column.
            .HasColumnName("Slug")
            // Allows NULL values because the slug is optional.
            .IsRequired(false)
            // Restricts the maximum length to 50 characters.
            .HasMaxLength(50);

        // Configures the ShortDescription property.
        builder.Property(x => x.ShortDescription)
            // Maps the property to the ShortDescription column.
            .HasColumnName("ShortDescription")
            // Allows NULL values because the short description is optional.
            .IsRequired(false)
            // Restricts the maximum length to 500 characters.
            .HasMaxLength(500);

        // Configures the DetailedDescription property.
        builder.Property(x => x.DetailedDescription)
            // Maps the property to the DetailedDescription column.
            .HasColumnName("DetailedDescription")
            // Allows NULL values because the detailed description is optional.
            .IsRequired(false);

        // Configures the SalesPrice property.
        builder.Property(x => x.SalesPrice)
            // Maps the property to the SalesPrice column.
            .HasColumnName("SalesPrice")
            // Stores the value as a decimal with 18 digits and 2 decimal places.
            .HasColumnType("decimal(18,2)")
            // Allows NULL values because the sales price is optional.
            .IsRequired(false);

        // Configures the RegularPrice property.
        builder.Property(x => x.RegularPrice)
            // Maps the property to the RegularPrice column.
            .HasColumnName("RegularPrice")
            // Stores the value as a decimal with 18 digits and 2 decimal places.
            .HasColumnType("decimal(18,2)")
            // Uses 0 as the default value if no value is provided.
            .HasDefaultValue(0)
            // Makes the column mandatory.
            .IsRequired();

        // Configures the Height property.
        builder.Property(x => x.Height)
            // Maps the property to the Height column.
            .HasColumnName("Height")
            // Uses NULL as the default value.
            .HasDefaultValue(null)
            // Allows NULL values because the height is optional.
            .IsRequired(false);

        // Configures the Width property.
        builder.Property(x => x.Width)
            // Maps the property to the Width column.
            .HasColumnName("Width")
            // Uses NULL as the default value.
            .HasDefaultValue(null)
            // Allows NULL values because the width is optional.
            .IsRequired(false);

        // Configures the Weight property.
        builder.Property(x => x.Weight)
            // Maps the property to the Weight column.
            .HasColumnName("Weight")
            // Uses NULL as the default value.
            .HasDefaultValue(null)
            // Allows NULL values because the weight is optional.
            .IsRequired(false);

        // Configures the AverageRating property.
        builder.Property(x => x.AverageRating)
            // Maps the property to the AverageRating column.
            .HasColumnName("AverageRating")
            // Uses 0 as the default value.
            .HasDefaultValue(0)
            // Makes the column mandatory.
            .IsRequired();

        // Configures the Stock property.
        builder.Property(x => x.Stock)
            // Maps the property to the Stock column.
            .HasColumnName("Stock")
            // Uses 0 as the default value.
            .HasDefaultValue(0)
            // Makes the column mandatory.
            .IsRequired();

        // Configures the Status property.
        builder.Property(x => x.Status)
            // Maps the property to the Status column.
            .HasColumnName("Status")
            // Uses Draft as the default product status.
            .HasDefaultValue(ProductStatus.Draft)
            // Makes the column mandatory.
            .IsRequired();

        // Configures the BrandId foreign key property.
        builder.Property(x => x.BrandId)
            // Maps the property to the BrandId column.
            .HasColumnName("BrandId")
            // Allows products without a brand.
            .IsRequired(false);

        // Configures the CategoryId foreign key property.
        builder.Property(x => x.CategoryId)
            // Maps the property to the CategoryId column.
            .HasColumnName("CategoryId")
            // Allows products without a category.
            .IsRequired(false);

        // Creates an index on the NormalizedName column.
        // This improves the performance of searches using the normalized name.
        builder.HasIndex(x => x.NormalizedName);

        // Creates a unique index on the Slug column.
        // This prevents duplicate slugs.
        builder.HasIndex(x => x.Slug)
            .IsUnique();

        // Configures the relationship between Product and Brand.
        // One Brand can have many Products.
        // Each Product belongs to one Brand.
        builder.HasOne(x => x.Brand)
            .WithMany(b => b.Products)
            .HasForeignKey(x => x.BrandId);

        // Configures the relationship between Product and Category.
        // One Category can have many Products.
        // Each Product belongs to one Category.
        builder.HasOne(x => x.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(x => x.CategoryId);
    }
}