using Sas.Database.Entities;
namespace Sas.UserService.Common.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u=> u.Email == email);
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}