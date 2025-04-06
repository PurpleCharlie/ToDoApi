using ToDoApi.Models;

namespace ToDoApi.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}