namespace Sas.UserService.Common.interfaces.Authentication;

public class JwtSettings
{
    public required string Secret {get; set;}
    public required string Issuer {get; set;}
    public required string Audience {get; set;}

    public int ExpiryMinutes {get; set;}
}