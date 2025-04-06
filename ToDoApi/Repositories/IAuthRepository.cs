using ToDoApi.Models;
using ToDoApi.DTO;

namespace ToDoApi.Repositories
{
    public interface IAuthRepository
    {
        public Task<bool> RegisterAsync(User user, string password);
        public Task<User> LoginAsync(string username, string password);

    }
}
