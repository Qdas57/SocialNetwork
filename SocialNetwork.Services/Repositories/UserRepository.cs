using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;
using SocialNetwork.Data.Entities;
using SocialNetwork.Services.Services;

namespace SocialNetwork.Services.Repositories
{
    public class UserRepository
    {
        private readonly UserContext _db;

        private readonly CommonService _commonService;

        public UserRepository(UserContext db, CommonService commonService)
        {
            _db = db;
            _commonService = commonService;
        }

        public async Task<bool> RegisterUserAsync(string firstName, string lastName, string email, string password,
                                                  string? phone, string? avatar, DateTime birthDate)
        {
            string hashPass = _commonService.GetHash(password);

            var user = new UserEntity
            {
                UserId = Guid.NewGuid(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = hashPass,
                Phone = phone,
                Avatar = avatar,
                BirthDate = birthDate,
                RegisterDate = DateTime.UtcNow
            };

            await _db.Users.AddAsync(user);

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IsUserExistAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Email == email) != null;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            string hashPass = _commonService.GetHash(password);

            var findedUser = await _db.Users.FirstOrDefaultAsync(u=>u.Email == email && u.Password == hashPass);

            if (findedUser is null)
            {
                return false;
            }

            return true;
        }
    }
}
