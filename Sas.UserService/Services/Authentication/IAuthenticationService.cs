using FluentResults;
using Sas.UserService.Common.EmailValidation;
namespace Sas.UserService.Services.Authentication;

public interface IAuthenticationService
{
    Result<AuthenticationResult> Register(string firstName, string lastName, string email, string password);

    AuthenticationResult Login(string email, string password);
}
