using Bingo.Application.Abstractions;
using Bingo.Application.Dtos.ContactRequest;
using Bingo.Application.Types;
using Bingo.Core.Domains;
using Bingo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bingo.Application.Services;

public class ContactRequestService(ApplicationDbContext db): IContactRequestService
{
    private readonly IQueryable<ContactRequest>  _baseQuery = db.ContactRequests
        .Where(c=>c.DeletedAt == null);
    
    public async Task<ServiceResult<ContactRequestViewDto[]>> GetAllAsync(CancellationToken cancellationToken)
    {
        return default;
    }

    public async Task<ServiceResult<ContactRequestViewDto?>> GetByIdAsync(long id, CancellationToken cancellationToken)
    {
        return default;
    }

    public async Task<ServiceResult<ContactRequestViewDto?>> CreateAsync(ContactRequestCreateDto dto, CancellationToken cancellationToken)
    {
        // STEP 1: Data Validation.
        List<string> errors = [];
        if(string.IsNullOrWhiteSpace(dto.FirstName))
            errors.Add("First name is required");
        
        if(string.IsNullOrWhiteSpace(dto.Message))
            errors.Add("Message is required");
        
        if(string.IsNullOrWhiteSpace(dto.Email) && string.IsNullOrWhiteSpace(dto.PhoneNumber))
            errors.Add("Email or Phone number is required");
        
        if(errors.Any())
            return ServiceResult<ContactRequestViewDto?>.ValidationErrorResult(errors);
        
        var requestExists = await _baseQuery
            .AnyAsync(c=>c.Email == dto.Email || c.PhoneNumber == dto.PhoneNumber, cancellationToken);
        
        if(requestExists)
            return ServiceResult<ContactRequestViewDto?>.ValidationErrorResult(["A request already exists."]);

        var contactRequest = new ContactRequest()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            Message = dto.Message,
        };
        
        await db.ContactRequests.AddAsync(contactRequest, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);
        
        return ServiceResult<ContactRequestViewDto?>.CreatedResult(new ()
        {
            Id = contactRequest.Id,
            FirstName = contactRequest.FirstName,
            LastName = contactRequest.LastName,
            Email = contactRequest.Email,
            PhoneNumber = contactRequest.PhoneNumber,
            Message = contactRequest.Message,
        });
    }

    public async Task<ServiceResult<bool>> UpdateAsync(long id, ContactRequestCreateDto dto, CancellationToken cancellationToken)
    {
        return default;
    }

    public async Task<ServiceResult<bool>> DeleteAsync(long id, CancellationToken cancellationToken)
    {
        return default;
    }
}