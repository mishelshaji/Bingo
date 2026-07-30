namespace Bingo.Core.Domains;

public class ContactRequest: DomainBase
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string Message { get; set; }
    
    // public ContactRequest(long id, string firstName, string? lastName, string? email, string? phoneNumber, string message)
    // {
    //     if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(phoneNumber))
    //     {
    //         throw new ArgumentException("Email or Phone number are required");
    //     }
    //     
    //     Id = id;
    //     FirstName = firstName;
    //     LastName = lastName;
    //     Email = email;
    //     PhoneNumber = phoneNumber;
    //     Message = message;
    // }
}