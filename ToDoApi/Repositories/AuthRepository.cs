using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models;

namespace ToDoApi.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        AppDbContext _db;

        public AuthRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddUserAsync(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            var userByUsername = _db.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (userByUsername == null)
                return await Task.FromResult<User>(null);
        

            return await userByUsername;
        }
    }
}
