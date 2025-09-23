using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersWebApi_Module3WithMoq.Models;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new List<User>();
    private int _nextId = 1;

    public Task<List<User>> ListAsync()
    {
        return Task.FromResult(_users.ToList());
    }

    public Task<User> GetByIdAsync(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        return Task.FromResult(user);
    }

    public Task<User> GetByUsernameAsync(string username)
    {
        var user = _users.FirstOrDefault(u => u.Username == username);
        return Task.FromResult(user);
    }

    public Task AddAsync(User user)
    {
        user.Id = _nextId++;
        _users.Add(user);
        return Task.CompletedTask;
    }

   
    public Task<User> LoginAsync(string username, string password)
    {
        var user = _users.FirstOrDefault(u =>
            u.Username == username && u.Password == password);
        return Task.FromResult(user);
    }
}
