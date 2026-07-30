namespace Bingo.Core.Domains;

public class Brand : DomainBase
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? LogoUrl { get; set; }
    public string? SupportEmail { get; set; }
}
