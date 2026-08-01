using Bingo.Core.Types;

namespace Bingo.Core.Domains;

/// <summary>
/// Represents a product that can be listed, managed, and sold.
/// </summary>
public class Product : DomainBase
{
    /// <summary>
    /// Gets or sets the unique identifier of the product.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the display name of the product.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the normalized version of the product name used for searching and comparisons.
    /// </summary>
    public string NormalizedName { get; set; }

    /// <summary>
    /// Gets or sets the URL-friendly slug of the product.
    /// </summary>
    public string? Slug { get; set; }

    /// <summary>
    /// Gets or sets a brief description of the product.
    /// </summary>
    public string? ShortDescription { get; set; }

    /// <summary>
    /// Gets or sets the detailed description of the product.
    /// </summary>
    public string? DetailedDescription { get; set; }

    /// <summary>
    /// Gets or sets the discounted or sale price of the product.
    /// </summary>
    public decimal? SalesPrice { get; set; }

    /// <summary>
    /// Gets or sets the regular selling price of the product.
    /// </summary>
    public decimal RegularPrice { get; set; }

    /// <summary>
    /// Gets or sets the height of the product.
    /// </summary>
    public double? Height { get; set; }

    /// <summary>
    /// Gets or sets the width of the product.
    /// </summary>
    public double? Width { get; set; }

    /// <summary>
    /// Gets or sets the weight of the product.
    /// </summary>
    public double? Weight { get; set; }

    /// <summary>
    /// Gets or sets the average customer rating of the product.
    /// </summary>
    public double AverageRating { get; set; }

    /// <summary>
    /// Gets or sets the available stock quantity of the product.
    /// </summary>
    public int Stock { get; set; }

    /// <summary>
    /// Gets or sets the current status of the product.
    /// </summary>
    public ProductStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the associated brand.
    /// </summary>
    public long? BrandId { get; set; }

    /// <summary>
    /// Gets or sets the brand associated with the product.
    /// </summary>
    public Brand? Brand { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the category to which the product belongs.
    /// </summary>
    public long? CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the category associated with the product.
    /// </summary>
    public Category? Category { get; set; }

    /// <summary>
    /// Gets or sets the collection of tags associated with the product.
    /// </summary>
    public ICollection<ProductTag>? ProductTags { get; set; } = new List<ProductTag>();
}