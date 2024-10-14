using FluentResults;
using Sas.Database.Entities;
using Sas.UserService.Common.interfaces.Authentication;
using Sas.UserService.Common.Persistence;
using Sas.UserService.Common.EmailValidation;
using Sas.UserService.Errors;

namespace Sas.UserService.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public Result<AuthenticationResult> Register(

        string firstName,
        string lastName,
        string email,
        string password)
    {
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            return Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailError() });
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user.UsetId, firstName, lastName);
        return new AuthenticationResult(
            user.UsetId,
            firstName,
            lastName,
            email,
            token);
    }

    public AuthenticationResult Login(
        string email,
        string password)
    {
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email does not exist.");
        }

        if(user.Password !=password)
        {
            throw new Exception("Invalid password!");
        }

        var token = _jwtTokenGenerator.GenerateToken(user.UsetId, user.FirstName, user.LastName);

        return new AuthenticationResult(
            user.UsetId,
            user.FirstName,
            user.LastName,
            email,
            token);
    }
}