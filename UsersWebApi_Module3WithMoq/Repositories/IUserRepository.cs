using System.Collections.Generic;
using System.Threading.Tasks;
using UsersWebApi_Module3WithMoq.Models;

public interface IUserRepository
{
    Task<List<User>> ListAsync();
    Task<User> GetByIdAsync(int id);
    Task<User> GetByUsernameAsync(string username);
    Task AddAsync(User user);
    // New method
    Task<User> LoginAsync(string username, string password);
}