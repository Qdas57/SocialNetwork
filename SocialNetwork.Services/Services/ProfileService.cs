using Microsoft.Extensions.Logging;
using SocialNetwork.Core.Exceptions;
using SocialNetwork.Models.Output;
using SocialNetwork.Services.Mapping;
using SocialNetwork.Services.Repositories;

namespace SocialNetwork.Services.Services
{
    public class ProfileService
    {
        private readonly UserRepository _userRepository;

        private ILogger<ProfileService> _logger;

        public ProfileService(UserRepository userRepository, ILogger<ProfileService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<ProfileOutput> GetProfileByIdAsync(Guid guid)
        {
            try
            {
                var findedUser = await _userRepository.GetUserByIdAsync(guid);

                if (findedUser is null)
                {
                    throw new UserNotFoundException($"User with GUID - {guid} not found.");
                }
                
                return findedUser.ToProfileOutput();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<List<ProfileOutput>> GetAllUsersAsync()
        {
            try
            {
                var result = await _userRepository.GetUsersAsync();

                return result.Select(x => x.ToProfileOutput()).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }
                
    }
}