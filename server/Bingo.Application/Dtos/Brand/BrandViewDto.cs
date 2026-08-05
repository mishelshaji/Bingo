namespace Bingo.Application.Dtos.Brand;

/// <summary>
/// Represents a brand returned by the application.
/// </summary>
public class BrandViewDto
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
    /// Gets or sets the URL of the brand's logo.
    /// </summary>
    public string? LogoUrl { get; set; }

    /// <summary>
    /// Gets or sets the support email address of the brand.
    /// </summary>
    public string? SupportEmail { get; set; }
}