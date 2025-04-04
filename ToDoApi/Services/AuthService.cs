using ToDoApi.DTO;
using ToDoApi.Repositories;

namespace ToDoApi.Services
{
    public class AuthService : IAuthService
    {
        IAuthRepository _repository;
        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> LoginAsync(UserAuthDTO user)
        {
            
        }

        public Task<bool> RegisterAsync(UserAuthDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
