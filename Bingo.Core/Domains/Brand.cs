namespace Bingo.Core.Domains;

/// <summary>
/// Represents a product brand or manufacturer.
/// </summary>
public class Brand : DomainBase
{
    /// <summary>
    /// Gets or sets the unique identifier of the brand.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the brand.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the official website URL of the brand.
    /// </summary>
    public string? WebsiteUrl { get; set; }

    /// <summary>
    /// Gets or sets the URL of the brand's logo image.
    /// </summary>
    public string? LogoUrl { get; set; }

    /// <summary>
    /// Gets or sets the support or contact email address of the brand.
    /// </summary>
    public string? SupportEmail { get; set; }

    /// <summary>
    /// Gets or sets the collection of products associated with this brand.
    /// </summary>
    public IEnumerable<Product> Products { get; set; }
}