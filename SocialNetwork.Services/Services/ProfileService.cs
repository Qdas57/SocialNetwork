using SocialNetwork.Core.Exceptions;
using SocialNetwork.Models.Output;
using SocialNetwork.Services.Repositories;

namespace SocialNetwork.Services.Services
{
    public class ProfileService
    {
        private readonly UserRepository _userRepository;
        
        private readonly CommonService _commonService;

        public ProfileService(UserRepository userRepository, CommonService commonService)
        {
            _userRepository = userRepository;
            _commonService = commonService;
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

                var age = DateTime.Now.Year - findedUser.BirthDate.Year;

                string ageDeclination = string.Empty;

                _commonService.DeclinationOfTheYear(age, out ageDeclination);
                
                //TODO: OnService нужно взять register date отнять DateTime.Now и посмотреть

                return new ProfileOutput
                {
                    Email = findedUser.Email,
                    FirstName = findedUser.FirstName,
                    LastName = findedUser.LastName,
                    Phone = findedUser.Phone,
                    Avatar = findedUser.Avatar,
                    BirthDate = findedUser.BirthDate,
                    Age = age,
                    AgeDeclination = ageDeclination,
                    OnService = "TODO: сделать это"
                };
            }
            catch (Exception)
            {
                //TODO: LOg
                throw;
            }
        }
    }
}
