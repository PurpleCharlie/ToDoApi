using ToDoApi.Models;

namespace ToDoApi.Repositories
{
    public interface IAuthRepository
    {
        Task<User> GetByUsernameAsync(string username);
        Task AddUserAsync(User user);
    }
}
