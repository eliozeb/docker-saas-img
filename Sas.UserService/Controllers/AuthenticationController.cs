using Sas.UserService.Common.EmailValidation;
using Sas.UserService.Services.Authentication;
using Sas.UserService.Dtos;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
namespace Sas.UserService.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("Register")]
    public IActionResult Register(RegisterRequest request)
    {
        Result<AuthenticationResult>  registerResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

            if(registerResult.IsSuccess)
            {
                return Ok(MapAuthResult(registerResult.Value));
            }
        var firstError = registerResult.Errors[0];
        if(firstError is DuplicateEmailError)
        {
            return Problem(statusCode: StatusCodes.Status409Conflict, detail: firstError.Message);
        }

        return Problem();
    }

    private static AuthenticationRsponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationRsponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token
        );
    }

    [HttpPost("Login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationService.Login(
    request.Email,
    request.Password);

        AuthenticationRsponse ressponse = MapAuthResult(authResult);
        return Ok(ressponse);
    }

}