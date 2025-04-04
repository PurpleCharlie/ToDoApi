using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.DTO;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDTO user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            return Ok(user);
        }
    }
}
