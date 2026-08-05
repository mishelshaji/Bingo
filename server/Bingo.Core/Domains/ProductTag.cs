namespace Bingo.Core.Domains;

/// <summary>
/// Represents the association between a product and a tag.
/// </summary>
public class ProductTag : DomainBase
{
    /// <summary>
    /// Gets or sets the unique identifier of the product-tag association.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the associated product.
    /// </summary>
    public long ProductId { get; set; }

    /// <summary>
    /// Gets or sets the product associated with this relationship.
    /// </summary>
    public Product Product { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the associated tag.
    /// </summary>
    public long TagId { get; set; }

    /// <summary>
    /// Gets or sets the tag associated with this relationship.
    /// </summary>
    public Tag Tag { get; set; }
}