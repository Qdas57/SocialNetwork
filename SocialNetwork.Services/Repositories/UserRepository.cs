using Microsoft.EntityFrameworkCore;
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
                string createText = ex + Environment.NewLine;
                File.WriteAllText("ErrInCreateAsync.txt", createText);
                return null;
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
                string createText = ex + Environment.NewLine;
                File.WriteAllText("ErrInGetUserById.txt", createText);
                return null; 
            }
        }
    }
}
