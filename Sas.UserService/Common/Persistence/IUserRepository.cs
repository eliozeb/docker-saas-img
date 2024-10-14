using Sas.Database.Entities;
namespace Sas.UserService.Common.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);

    void Add(User user);
}