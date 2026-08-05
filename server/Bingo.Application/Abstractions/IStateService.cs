using Bingo.Application.Dtos.State;
using Bingo.Application.Types;

namespace Bingo.Application.Abstractions;

/// <summary>
/// Defines the operations for managing states.
/// </summary>
public interface IStateService
{
    /// <summary>
    /// Retrieves all states.
    /// </summary>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result containing the list of states.
    /// </returns>
    Task<ServiceResult<IEnumerable<StateViewDto>>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a state by its unique identifier.
    /// </summary>
    /// <param name="id">
    /// The identifier of the state to retrieve.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result containing the requested state.
    /// </returns>
    Task<ServiceResult<StateViewDto?>> GetByIdAsync(long id, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new state.
    /// </summary>
    /// <param name="dto">
    /// Contains the information required to create a state.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result containing the newly created state.
    /// </returns>
    Task<ServiceResult<StateViewDto?>> CreateAsync(StateCreateDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing state.
    /// </summary>
    /// <param name="id">
    /// The identifier of the state to update.
    /// </param>
    /// <param name="dto">
    /// Contains the updated state information.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result containing the updated state.
    /// </returns>
    Task<ServiceResult<StateViewDto?>> UpdateAsync(long id, StateCreateDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a state.
    /// </summary>
    /// <param name="id">
    /// The identifier of the state to delete.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result indicating whether the state was deleted successfully.
    /// </returns>
    Task<ServiceResult<bool>> DeleteAsync(long id, CancellationToken cancellationToken);
}