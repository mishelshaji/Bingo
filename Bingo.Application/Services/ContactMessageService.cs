using Bingo.Application.Abstractions;
using Bingo.Application.Dtos.ContactMessage;
using Bingo.Application.Dtos.ContactRequest;
using Bingo.Application.Types;
using Bingo.Core.Domains;
using Bingo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bingo.Application.Services;

public class ContactMessageService(ApplicationDbContext db): IContactMessageService
{
    private readonly IQueryable<ContactMessage> _baseQuery = db.ContactMessages
        .Where(c => c.DeletedAt == null);
    
    public async Task<ServiceResult<ContactMessageViewDto[]>> GetAllAsync(CancellationToken cancellationToken)
    {
        return default;
    }

    public async Task<ServiceResult<ContactMessageViewDto?>> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        return default;
    }

    public async Task<ServiceResult<ContactMessageViewDto?>> CreateAsync(ContactMessageCreateDto dto, CancellationToken cancellationToken)
    {
        // STEP 1: Validating dato.
        List<string> errors = [];
        if(string.IsNullOrWhiteSpace(dto.FirstName))
            errors.Add("First name is required");
        
        if (string.IsNullOrWhiteSpace(dto.Message))
            errors.Add("Message is required");
        
        if (string.IsNullOrWhiteSpace(dto.Email) && string.IsNullOrWhiteSpace(dto.PhoneNumber))
            errors.Add("Email or Phone is required");
        
        if(errors.Any())
            return ServiceResult<ContactMessageViewDto?>.ValidationErrorResult(errors);
        
        var hasContactRequests = await _baseQuery
            .AnyAsync(c=>c.Email == dto.Email || c.PhoneNumber == dto.PhoneNumber, cancellationToken);
        
        if(!hasContactRequests)
            return ServiceResult<ContactMessageViewDto?>.ValidationErrorResult(["A request already exists."]);

        var contact = new ContactMessage()
        {
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Message = dto.Message,
        };
        
        await db.ContactMessages.AddAsync(contact, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
        
        return ServiceResult<ContactMessageViewDto?>.CreatedResult(new()
        {
            Id = contact.Id,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Email = contact.Email,
            PhoneNumber = contact.PhoneNumber,
            Message = contact.Message,
        });
    }
    
    public async Task<ServiceResult<bool>> UpdateAsync(long id, ContactMessageCreateDto dto, CancellationToken cancellationToken)
    {
        return default;
    }

    public async Task<ServiceResult<bool>> DeleteAsync(long id, CancellationToken cancellationToken)
    {
        return default;
    }
}