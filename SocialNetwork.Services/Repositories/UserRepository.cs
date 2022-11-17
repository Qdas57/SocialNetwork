using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;
using SocialNetwork.Data.Entities;

namespace SocialNetwork.Services.Repositories
{
    public class UserRepository
    {
        private readonly UserContext _db;

        public UserRepository(UserContext db)
        {
            _db = db;
        }

        public async Task<bool> RegisterUserAsync(string firstName, string lastName, string email, string password,
        string? phone, string? avatar, DateTime birthDate)
        {
            {

                var user = new UserEntity
                {
                    UserId = Guid.NewGuid(),
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Password = password,
                    Phone = phone,
                    Avatar = avatar,
                    BirthDate = birthDate
                };

                await _db.Users.AddAsync(user);
                await _db.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> IsUserExistAsync(string email)
        {
            if (await _db.Users.FirstOrDefaultAsync(u => u.Email == email) != null)
            {
                return true;
            }
            return false;
        }
    }
}
