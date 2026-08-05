using Bingo.Application.Dtos.Category;
using Bingo.Application.Types;

namespace Bingo.Application.Abstractions;

/// <summary>
/// Defines the operations for managing categories.
/// </summary>
public interface ICategoryService
{
    /// <summary>
    /// Retrieves all categories.
    /// </summary>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result containing the list of categories.
    /// </returns>
    Task<ServiceResult<IEnumerable<CategoryViewDto>>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a category by its unique identifier.
    /// </summary>
    /// <param name="id">
    /// The identifier of the category to retrieve.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result containing the requested category.
    /// </returns>
    Task<ServiceResult<CategoryViewDto?>> GetByIdAsync(long id, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new category.
    /// </summary>
    /// <param name="dto">
    /// Contains the information required to create a category.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result containing the newly created category.
    /// </returns>
    Task<ServiceResult<CategoryViewDto?>> CreateAsync(CategoryCreateDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="id">
    /// The identifier of the category to update.
    /// </param>
    /// <param name="dto">
    /// Contains the updated category information.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result containing the updated category.
    /// </returns>
    Task<ServiceResult<CategoryViewDto?>> UpdateAsync(long id, CategoryCreateDto dto, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a category.
    /// </summary>
    /// <param name="id">
    /// The identifier of the category to delete.
    /// </param>
    /// <param name="cancellationToken">
    /// A token that can be used to cancel the operation.
    /// </param>
    /// <returns>
    /// A service result indicating whether the category was deleted successfully.
    /// </returns>
    Task<ServiceResult<bool>> DeleteAsync(long id, CancellationToken cancellationToken);
}