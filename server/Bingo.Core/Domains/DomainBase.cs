namespace Bingo.Core.Domains;

/// <summary>
/// Serves as the base for all domain entities.
/// </summary>
public abstract class DomainBase
{
    /// <summary>
    /// The timestamp at which the record was created.
    /// </summary>
    public DateTime? CreatedAt { get; set; }
    
    /// <summary>
    /// The timestamp at which the record was updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
    
    /// <summary>
    /// The timestamp at which the record was deleted.
    /// </summary>
    public DateTime? DeletedAt { get; set; }
}
