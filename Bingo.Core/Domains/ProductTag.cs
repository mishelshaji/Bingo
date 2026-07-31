namespace Bingo.Core.Domains;

public class ProductTag: DomainBase
{
    public long Id { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
    public long TagId { get; set; }
    public Tag Tag { get; set; }
}