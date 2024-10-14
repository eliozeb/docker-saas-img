
using FluentResults;
namespace Sas.UserService.Common.EmailValidation;

public class DuplicateEmailError : IError
{
        public string Message => "A user with this email already exists.";

    public List<IError> Reasons => new List<IError>
    {
        new Error("Email already taken").WithMetadata("errorCode", "DUPLICATE_EMAIL")
    };

    public Dictionary<string, object> Metadata => new Dictionary<string, object>
    {
        { "errorCode", "DUPLICATE_EMAIL" },
        { "httpStatusCode", 409 }, // 409 Conflict
        { "timestamp", DateTime.UtcNow }
    };

}
