using apbd_app2.Domain.Models;

namespace apbd_app2.Services;

public interface IUserService
{
    public void AddUser(User user);
    public List<User> GetAll();
    public User? GetById(Guid id);
}