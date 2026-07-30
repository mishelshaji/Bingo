namespace Bingo.Application.Types;

public class ServiceResult<TData>
{
    public bool Success { get; set; } = true;
    public string? Message { get; set; }
    public string[] Errors { get; set; } = [];
    public ResultType ResultType { get; set; } = ResultType.Success;
    public TData Data { get; set; }

    public static ServiceResult<TData> SuccessResult(TData data, string? message = null)
    {
        var result = new ServiceResult<TData>
        {
            Success = true,
            Message = message,
            ResultType = ResultType.Success,
            Data = data
        };
        return result;
    }
    
    public static ServiceResult<TData> NotFoundResult(string? message = null)
    {
        var result = new ServiceResult<TData>
        {
            Success = false,
            Message = message,
            ResultType = ResultType.NotFound,
            Data = default
        };
        return result;
    }
    
    public static ServiceResult<TData> CreatedResult(TData data, string? message = null)
    {
        var result = new ServiceResult<TData>
        {
            Success = true,
            Message = message,
            ResultType = ResultType.Created,
            Data = data
        };
        return result;
    }
    
    public static ServiceResult<TData> UpdatedResult(TData data, string? message = null)
    {
        var result = new ServiceResult<TData>
        {
            Success = true,
            Message = message,
            ResultType = ResultType.Updated,
            Data = data
        };
        return result;
    }

    public static ServiceResult<TData> ValidationErrorResult(IEnumerable<string> errors, string? message = null)
    {
        var result = new ServiceResult<TData>
        {
            Success = false,
            Message = message,
            ResultType = ResultType.ValidationError,
            Errors = errors.ToArray(),
            Data = default
        };
        return result;
    }
    
    public static ServiceResult<TData> DeletedResult(TData data, string? message = null)
    {
        var result = new ServiceResult<TData>
        {
            Success = true,
            Message = message,
            ResultType = ResultType.Deleted,
            Data = data
        };
        return result;
    }
}