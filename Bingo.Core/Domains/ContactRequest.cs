namespace Bingo.Core.Domains;

/// <summary>
/// Represents a contact request submitted by a user through the website or application.
/// </summary>
public class ContactRequest : DomainBase
{
    /// <summary>
    /// Gets or sets the unique identifier of the contact request.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the first name of the person submitting the request.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the person submitting the request.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// Gets or sets the email address of the person submitting the request.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the person submitting the request.
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the message or inquiry submitted by the user.
    /// </summary>
    public string Message { get; set; }
}