namespace Bingo.Application.Types;

/// <summary>
/// Represents the result returned from an application service.
/// </summary>
/// <typeparam name="TData">
/// The type of data returned by the service.
/// </typeparam>
public class ServiceResult<TData>
{
    /// <summary>
    /// Indicates whether the operation completed successfully.
    /// </summary>
    public bool Success { get; set; } = true;

    /// <summary>
    /// Stores a message describing the outcome of the operation.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Stores one or more validation or processing errors.
    /// </summary>
    public string[] Errors { get; set; } = [];

    /// <summary>
    /// Represents the type of result returned by the service.
    /// </summary>
    public ResultType ResultType { get; set; } = ResultType.Success;

    /// <summary>
    /// Stores the data returned by the operation.
    /// </summary>
    public TData Data { get; set; }

    /// <summary>
    /// Creates a successful service result.
    /// </summary>
    /// <param name="data">
    /// The data returned by the operation.
    /// </param>
    /// <param name="message">
    /// An optional success message.
    /// </param>
    /// <returns>
    /// A successful <see cref="ServiceResult{TData}"/>.
    /// </returns>
    public static ServiceResult<TData> SuccessResult(TData data, string? message = null)
    {
        // Creates and returns a successful result.
        return new ServiceResult<TData>
        {
            Success = true,
            Message = message,
            ResultType = ResultType.Success,
            Data = data
        };
    }

    /// <summary>
    /// Creates a result indicating that the requested resource was not found.
    /// </summary>
    /// <param name="message">
    /// An optional message describing the error.
    /// </param>
    /// <returns>
    /// A not found <see cref="ServiceResult{TData}"/>.
    /// </returns>
    public static ServiceResult<TData> NotFoundResult(string? message = null)
    {
        // Creates and returns a not found result.
        return new ServiceResult<TData>
        {
            Success = false,
            Message = message,
            ResultType = ResultType.NotFound,
            Data = default
        };
    }

    /// <summary>
    /// Creates a result indicating that a resource was successfully created.
    /// </summary>
    /// <param name="data">
    /// The created resource.
    /// </param>
    /// <param name="message">
    /// An optional success message.
    /// </param>
    /// <returns>
    /// A created <see cref="ServiceResult{TData}"/>.
    /// </returns>
    public static ServiceResult<TData> CreatedResult(TData data, string? message = null)
    {
        // Creates and returns a created result.
        return new ServiceResult<TData>
        {
            Success = true,
            Message = message,
            ResultType = ResultType.Created,
            Data = data
        };
    }

    /// <summary>
    /// Creates a result indicating that a resource was successfully updated.
    /// </summary>
    /// <param name="data">
    /// The updated resource.
    /// </param>
    /// <param name="message">
    /// An optional success message.
    /// </param>
    /// <returns>
    /// An updated <see cref="ServiceResult{TData}"/>.
    /// </returns>
    public static ServiceResult<TData> UpdatedResult(TData data, string? message = null)
    {
        // Creates and returns an updated result.
        return new ServiceResult<TData>
        {
            Success = true,
            Message = message,
            ResultType = ResultType.Updated,
            Data = data
        };
    }

    /// <summary>
    /// Creates a validation error result.
    /// </summary>
    /// <param name="errors">
    /// The validation errors.
    /// </param>
    /// <param name="message">
    /// An optional message describing the validation failure.
    /// </param>
    /// <returns>
    /// A validation error <see cref="ServiceResult{TData}"/>.
    /// </returns>
    public static ServiceResult<TData> ValidationErrorResult(IEnumerable<string> errors, string? message = null)
    {
        // Creates and returns a validation error result.
        return new ServiceResult<TData>
        {
            Success = false,
            Message = message,
            ResultType = ResultType.ValidationError,
            Errors = errors.ToArray(),
            Data = default
        };
    }

    /// <summary>
    /// Creates a result indicating that a resource was successfully deleted.
    /// </summary>
    /// <param name="data">
    /// The deleted resource or related data.
    /// </param>
    /// <param name="message">
    /// An optional success message.
    /// </param>
    /// <returns>
    /// A deleted <see cref="ServiceResult{TData}"/>.
    /// </returns>
    public static ServiceResult<TData> DeletedResult(TData data, string? message = null)
    {
        // Creates and returns a deleted result.
        return new ServiceResult<TData>
        {
            Success = true,
            Message = message,
            ResultType = ResultType.Deleted,
            Data = data
        };
    }
    
    /// <summary>
    /// Creates a result indicating that the request was unauthorized.
    /// </summary>
    /// <param name="message">
    /// An optional success message.
    /// </param>
    /// <returns>
    /// A deleted <see cref="ServiceResult{TData}"/>.
    /// </returns>
    public static ServiceResult<TData> UnauthorizedResult(string? message = null)
    {
        // Creates and returns a deleted result.
        return new ServiceResult<TData>
        {
            Success = true,
            Message = message,
            ResultType = ResultType.Unauthorized,
        };
    }
}