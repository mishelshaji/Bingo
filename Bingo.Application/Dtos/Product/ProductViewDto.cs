using Bingo.Application.Dtos.Category;
using Bingo.Application.Dtos.Tag;
using Bingo.Core.Types;

namespace Bingo.Application.Dtos.Product;

public class ProductViewDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string? Slug { get; set; }
    public string? ShortDescription { get; set; }
    public string? DetailedDescription { get; set; }
    public decimal? SalesPrice { get; set; }
    public decimal RegularPrice { get; set; }
    public double? Height { get; set; }
    public double? Width { get; set; }
    public double? Weight { get; set; }
    public int Stock { get; set; }
    public ProductStatus Status { get; set; }
    public long? BrandId { get; set; }
    public CategoryViewDto? Category { get; set; }
    public IEnumerable<TagViewDto>? Tags { get; set; }
}