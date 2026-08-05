namespace Bingo.Application.Dtos.ContactMessage;

public class ContactMessageViewDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string Message { get; set; }
}