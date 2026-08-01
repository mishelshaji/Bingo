namespace Bingo.Core.Domains;

/// <summary>
/// Represents a country.
/// </summary>
public class Country : DomainBase
{
    /// <summary>
    /// Gets or sets the unique identifier of the country.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the official name of the country.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the ISO country code (for example, "IN" or "US").
    /// </summary>
    public string IsoCode { get; set; }

    /// <summary>
    /// Gets or sets the international dialing code of the country (for example, "+91").
    /// </summary>
    public string PhoneCode { get; set; }

    /// <summary>
    /// Gets or sets the collection of states or provinces that belong to this country.
    /// </summary>
    public IEnumerable<State> States { get; set; }
}