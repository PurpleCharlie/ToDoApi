using ToDoApi.Models;
using ToDoApi.DTO;

namespace ToDoApi.Repositories
{
    public interface IAuthRepository
    {
        public Task<bool> RegisterAsync(User user);
        public Task<User> LoginAsync(string username);
        Task<bool> UserExistsAsync(string username);
    }
}
