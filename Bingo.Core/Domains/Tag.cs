namespace Bingo.Core.Domains;

public class Tag : DomainBase
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public IEnumerable<ProductTag> ProductTags { get; set; }
}