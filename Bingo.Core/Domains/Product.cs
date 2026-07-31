using Bingo.Core.Types;

namespace Bingo.Core.Domains;

public class Product: DomainBase
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string NormalizedName { get; set; }
    public string? Slug { get; set; }
    public string? ShortDescription { get; set; }
    public string? DetailedDescription { get; set; }
    public decimal? SalesPrice { get; set; }
    public decimal RegularPrice { get; set; }
    public double? Height { get; set; }
    public double? Width { get; set; }
    public double? Weight { get; set; }
    public double AverageRating { get; set; }
    public int Stock { get; set; }
    public ProductStatus Status { get; set; }
    public long? BrandId { get; set; }
    public Brand? Brand { get; set; }
    public long? CategoryId { get; set; }
    public Category? Category { get; set; }
    public IEnumerable<ProductTag>? ProductTags { get; set; }
}