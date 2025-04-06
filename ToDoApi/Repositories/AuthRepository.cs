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

        public async Task<User> LoginAsync(string username, string password)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                return null; // User not found
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            return isPasswordValid ? user : null;
        }

        public async Task<bool> RegisterAsync(User user)
        {
            // Check if the user already exists
            var existingUser = await _db.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
            if (existingUser != null)
            {
                return false; // User already exists
            }

            // Add the user to the database
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return true;
        }


    }
}
