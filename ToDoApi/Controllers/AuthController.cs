using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Data;
using ToDoApi.DTO;
using ToDoApi.Repositories;
using ToDoApi.Services;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        IAuthService _authService;

        // DI
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO user)
        {
            // Проверяем, что пользователь существует
            if (user == null)
            {
                // Если не существует, возвращаем ошибку
                return BadRequest("Invalid client request");
            }

            // Если существует, генерируем токен
            var token = await _authService.LoginAsync(user);

            // Отправляем на клиент токен
            return Ok(new {token});
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO user)
        {
            // Проверяем, что верно переданы данные с клиента
            if (user == null)
            {
                // Если не пустые, возвращаем ошибку
                return BadRequest("Invalid client request");
            }

            // Если верные, регистрируем нового пользователя
            var result = await _authService.RegisterAsync(user);

            // Отправляем на клиент результат регистрации
            return Ok();
        }
    }
}
