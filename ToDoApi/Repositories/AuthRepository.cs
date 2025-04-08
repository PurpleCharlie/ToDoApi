using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models;
using ToDoApi.DTO;

namespace ToDoApi.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        AppDbContext _db;

        public AuthRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<User> LoginAsync(string username)
        {
            // Ищем пользователя по имени в БД
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);

            // Если пользователь не найден, возвращаем null
            if (user == null)
            {
                return null; 
            }

            // Иначе - возвращаем найденного пользователя
            return user;
        }

        public async Task<bool> RegisterAsync(User user)
        {
            // Проверяем, существует ли пользователь с таким именем
            var existingUser = await _db.Users.FirstOrDefaultAsync(u => u.Username == user.Username);

            // Если существует, возвращаем false
            if (existingUser != null)
            {
                return false; 
            }

            // Если не существует, добавляем нового пользователя в БД
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UserExistsAsync(string username)
        {
            // Проверяем, существует ли пользователь с таким именем
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);

            // Если не существует, то false
            if (user == null)
                return false;
            else
                return true;    // Иначе - true
        }


    }
}
