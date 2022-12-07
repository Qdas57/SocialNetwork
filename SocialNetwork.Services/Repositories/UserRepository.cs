using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SocialNetwork.Core.Exceptions;
using SocialNetwork.Data;
using SocialNetwork.Data.Entities;
using SocialNetwork.Models.Output;
using SocialNetwork.Services.Services;

namespace SocialNetwork.Services.Repositories
{
    public class UserRepository
    {
        private readonly UserContext _db;

        private readonly CommonService _commonService;

        private ILogger<UserRepository> _logger;

        public UserRepository(UserContext db, CommonService commonService, ILogger<UserRepository> logger)
        {
            _db = db;
            _commonService = commonService;
            _logger = logger;
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

        public async Task<bool> CheckEmailAsync(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Email == email) != null;
        }

        public async Task<UserOutput> IdentityUserAsync(string email, string password)
        {
            try
            {
                string hashPass = _commonService.GetHash(password);

                UserEntity? findedUser = await _db.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == hashPass);

                if (findedUser is null)
                {
                    throw new Exception("Login failed");
                }

                return new UserOutput
                {
                    UserId = findedUser.UserId,
                    Email = findedUser.Email,
                    FirstName = findedUser.FirstName,
                    LastName = findedUser.LastName,
                    Phone = findedUser.Phone,
                    Avatar = findedUser.Avatar,
                    BirthDate = findedUser.BirthDate,
                    RegisterDate = findedUser.RegisterDate
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<UserOutput> GetUserByIdAsync(Guid guid)
        {
            try
            {
                var findedUser = await _db.Users.FirstOrDefaultAsync(u => u.UserId == guid);

                if (findedUser is null)
                {
                    throw new UserNotFoundException($"User with GUID - {guid} not found.");
                }

                return new UserOutput
                {
                    UserId = findedUser.UserId,
                    Email = findedUser.Email,
                    FirstName = findedUser.FirstName,
                    LastName = findedUser.LastName,
                    Phone = findedUser.Phone,
                    Avatar = findedUser.Avatar,
                    BirthDate = findedUser.BirthDate,
                    RegisterDate = findedUser.RegisterDate
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<List<UserOutput>> GetUsersAsync()
        {

            try
            {
                var users = await _db.Users
                                .Select(u => new UserOutput
                                {
                                    UserId = u.UserId,
                                    Email = u.Email,
                                    FirstName = u.FirstName,
                                    LastName = u.LastName,
                                    Phone = u.Phone,
                                    Avatar = u.Avatar,
                                    BirthDate = u.BirthDate,
                                    RegisterDate = u.RegisterDate
                                })
                                .ToListAsync();

                return users;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
    }
}
