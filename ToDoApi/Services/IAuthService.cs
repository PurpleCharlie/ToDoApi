using ToDoApi.DTO;
using ToDoApi.DTO.Results;

namespace ToDoApi.Services
{
    public interface IAuthService
    {
        Task<string> LoginAsync(UserLoginDTO user);
        Task<RegistrationResult> RegisterAsync(RegisterDTO user);
    }
}
