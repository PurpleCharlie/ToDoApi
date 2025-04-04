using ToDoApi.DTO;

namespace ToDoApi.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(UserAuthDTO user);
        Task<bool> RegisterAsync(UserAuthDTO user);
    }
}
