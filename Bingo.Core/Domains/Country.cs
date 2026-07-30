namespace Bingo.Core.Domains;

public class Country : DomainBase
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string IsoCode { get; set; }
    public string PhoneCode { get; set; }
    public IEnumerable<State> States { get; set; }
}
