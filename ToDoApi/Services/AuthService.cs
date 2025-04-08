using ToDoApi.DTO;
using ToDoApi.DTO.Results;
using ToDoApi.Models;
using ToDoApi.Repositories;

namespace ToDoApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        private readonly IJwtTokenGenerator _tokenGenerator;
        public AuthService(IAuthRepository repository, IJwtTokenGenerator tokenGenerator)
        {
            _repository = repository;
            _tokenGenerator = tokenGenerator;
        }
        public async Task<string> LoginAsync(UserLoginDTO user)
        {
            var authUser = await _repository.LoginAsync(user.Username);

            // Проверка существования пользователя
            if (authUser == null)
            {
                return null; 
            }

            // Верификация пароля
            var password = BCrypt.Net.BCrypt.Verify(user.Password, authUser.PasswordHash);
            if (!password)
            {
                return null; 
            }

            // Генерация токена
            var token = _tokenGenerator.GenerateToken(authUser);
            return token;
        }

        public async Task<RegistrationResult> RegisterAsync(RegisterDTO user)
        {
            // Проверка существования пользователя (для ошибки, что пользователь существует)
            var isUserExists = await _repository.UserExistsAsync(user.Username);
            if(isUserExists == true)
            {
                // Если существует, возвращаем ошибку
                return new RegistrationResult { IsSucces = false, Message = "Пользователь с таким именем уже существует!" };
            }

            // Создаем нового пользователя
            var newUser = new User
            {
                Username = user.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password) // Хешируем пароль
            };

            // Передаем нового пользователя в репозиторий (для добавления в БД)
            var result = await _repository.RegisterAsync(newUser);

            // Возвращаем в контроллер результат регистрации
            return new RegistrationResult { IsSucces = true, Message = $"{user.Username}, теперь вы зарегистрированы!" };
        }
    }
}
