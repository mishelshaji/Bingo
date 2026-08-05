using Bingo.Application.Dtos.Country;
using Bingo.Application.Types;

namespace Bingo.Application.Abstractions;

/// <summary>
/// Defines the operations for managing countries.
/// </summary>
public interface ICountryService
{
    /// <summary>
    /// Retrieves all countries.
    /// </summary>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result containing the list of countries.
    /// </returns>
    Task<ServiceResult<IEnumerable<CountryViewDto>>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a country by its unique identifier.
    /// </summary>
    /// <param name="id">
    /// The identifier of the country to retrieve.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result containing the requested country.
    /// </returns>
    Task<ServiceResult<CountryViewDto?>> GetByIdAsync(long id, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new country.
    /// </summary>
    /// <param name="dto">
    /// Contains the information required to create a country.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result containing the newly created country.
    /// </returns>
    Task<ServiceResult<CountryViewDto?>> CreateAsync(CountryCreateDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing country.
    /// </summary>
    /// <param name="id">
    /// The identifier of the country to update.
    /// </param>
    /// <param name="dto">
    /// Contains the updated country information.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result containing the updated country.
    /// </returns>
    Task<ServiceResult<CountryViewDto?>> UpdateAsync(long id, CountryCreateDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a country.
    /// </summary>
    /// <param name="id">
    /// The identifier of the country to delete.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result indicating whether the country was deleted successfully.
    /// </returns>
    Task<ServiceResult<bool>> DeleteAsync(long id, CancellationToken cancellationToken);
}