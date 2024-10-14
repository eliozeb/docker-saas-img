namespace Sas.UserService.Dtos;

public record AuthenticationRsponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);