namespace Bingo.Core.Domains;

/// <summary>
/// Represents a category used to organize and classify related entities.
/// </summary>
public class Category : DomainBase
{
    /// <summary>
    /// Gets or sets the unique identifier for the category.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the display name of the category.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the URL-friendly unique slug for the category.
    /// </summary>
    public string Slug { get; set; }

    /// <summary>
    /// Gets or sets an optional description that provides additional details about the category.
    /// </summary>
    public string? Description { get; set; }
}
