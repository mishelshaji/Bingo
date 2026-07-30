namespace Bingo.Core.Domains;

public class State : DomainBase
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string IsoCode { get; set; }
    public long CountryId { get; set; }
    public Country Country { get; set; }
}