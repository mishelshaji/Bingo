namespace Bingo.Core.Domains;

/// <summary>
/// Represents a state or province within a country.
/// </summary>
public class State : DomainBase
{
    /// <summary>
    /// Gets or sets the unique identifier of the state.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the state or province.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the ISO code of the state or province (for example, "KL" or "CA").
    /// </summary>
    public string IsoCode { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the country to which this state belongs.
    /// </summary>
    public long CountryId { get; set; }

    /// <summary>
    /// Gets or sets the country to which this state belongs.
    /// </summary>
    public Country Country { get; set; }
}