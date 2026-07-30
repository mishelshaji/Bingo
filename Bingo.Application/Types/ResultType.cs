namespace Bingo.Application.Types;

public enum ResultType
{
    Success = 0,
    Created = 1,
    Updated = 2,
    Deleted = 3,
    NotFound = 4,
    ValidationError = 5,
    PermissionDenied = 6,
    Error = 7
}