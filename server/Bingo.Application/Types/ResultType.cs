namespace Bingo.Application.Types;

/// <summary>
/// Represents the possible outcomes of an application service operation.
/// </summary>
public enum ResultType
{
    /// <summary>
    /// Indicates that the operation completed successfully.
    /// </summary>
    Success = 0,

    /// <summary>
    /// Indicates that a new resource was created successfully.
    /// </summary>
    Created = 1,

    /// <summary>
    /// Indicates that an existing resource was updated successfully.
    /// </summary>
    Updated = 2,

    /// <summary>
    /// Indicates that a resource was deleted successfully.
    /// </summary>
    Deleted = 3,

    /// <summary>
    /// Indicates that the requested resource could not be found.
    /// </summary>
    NotFound = 4,

    /// <summary>
    /// Indicates that the request failed validation.
    /// </summary>
    ValidationError = 5,

    /// <summary>
    /// Indicates that the current user does not have permission to perform the requested operation.
    /// </summary>
    PermissionDenied = 6,

    /// <summary>
    /// Indicates that the operation failed due to an unexpected error.
    /// </summary>
    Error = 7,
    
    /// <summary>
    /// Indicates that the request was unauthorized.
    /// </summary>
    Unauthorized = 8,
}