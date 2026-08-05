using Bingo.Application.Dtos.ContactRequest;
using Bingo.Application.Types;

namespace Bingo.Application.Abstractions;

/// <summary>
/// Defines the operations for managing contact requests.
/// </summary>
public interface IContactRequestService
{
    /// <summary>
    /// Retrieves all contact requests.
    /// </summary>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result containing the list of contact requests.
    /// </returns>
    Task<ServiceResult<ContactRequestViewDto[]>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a contact request by its unique identifier.
    /// </summary>
    /// <param name="id">
    /// The identifier of the contact request to retrieve.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result containing the requested contact request.
    /// </returns>
    Task<ServiceResult<ContactRequestViewDto?>> GetByIdAsync(long id, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new contact request.
    /// </summary>
    /// <param name="dto">
    /// Contains the information required to create a contact request.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result containing the newly created contact request.
    /// </returns>
    Task<ServiceResult<ContactRequestViewDto?>> CreateAsync(ContactRequestCreateDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing contact request.
    /// </summary>
    /// <param name="id">
    /// The identifier of the contact request to update.
    /// </param>
    /// <param name="dto">
    /// Contains the updated contact request information.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result indicating whether the contact request was updated successfully.
    /// </returns>
    Task<ServiceResult<bool>> UpdateAsync(long id, ContactRequestCreateDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a contact request.
    /// </summary>
    /// <param name="id">
    /// The identifier of the contact request to delete.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result indicating whether the contact request was deleted successfully.
    /// </returns>
    Task<ServiceResult<bool>> DeleteAsync(long id, CancellationToken cancellationToken);
}