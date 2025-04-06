using ToDoApi.DTO;
using ToDoApi.Models;
using ToDoApi.Repositories;

namespace ToDoApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        private readonly IJwtTokenGenerator _tokenGenerator;
        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> LoginAsync(UserAuthDTO user)
        {
            var authUser = await _repository.LoginAsync(user.Username, user.Password);

            if(authUser == null)
            {
                return null; 
            }

            // Generate JWT token
            var token = _tokenGenerator.GenerateToken(authUser);
            return token;
        }

        public async Task<bool> RegisterAsync(RegisterDTO user)
        {
            if (user == null)  return false;

            var newUser = new User
            {
                Username = user.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password.ToString())
            };

            var result = await _repository.RegisterAsync(newUser, user.Password.ToString());

            return true;
        }
    }
}
