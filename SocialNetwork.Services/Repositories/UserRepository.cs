using SocialNetwork.Data;

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
            //TODO: реализоавть добавление пользователя

            return true;
        }
    }
}
