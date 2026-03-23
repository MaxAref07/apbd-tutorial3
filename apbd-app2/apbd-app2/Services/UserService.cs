using apbd_app2.Domain.Models;

namespace apbd_app2.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = new List<User>();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public List<User> GetAll()
    {
        return _users;
    }

    public User? GetById(Guid id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }
}