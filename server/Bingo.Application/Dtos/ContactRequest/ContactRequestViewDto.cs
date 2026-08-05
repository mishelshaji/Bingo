namespace Bingo.Application.Dtos.ContactRequest;

public class ContactRequestViewDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string Message { get; set; }
}