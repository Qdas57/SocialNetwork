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

                string ageDeclination = _commonService.DeclinationOfTheYear(age);

                string onservice = await _commonService.OnServiceAsync(findedUser.RegisterDate);

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
                    OnService = onservice
                };
            }
            catch (Exception ex)
            {
                string createText = ex + Environment.NewLine;
                File.WriteAllText("ErrInGetProfile.txt", createText);
                return null;
            }
        }
                
    }
}