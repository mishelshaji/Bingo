namespace Bingo.Core.Domains;

/// <summary>
/// Represents a tag that can be assigned to one or more products for classification and filtering.
/// </summary>
public class Tag : DomainBase
{
    /// <summary>
    /// Gets or sets the unique identifier of the tag.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the display name of the tag.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets an optional description of the tag.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the collection of product-tag relationships associated with this tag.
    /// </summary>
    public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
}