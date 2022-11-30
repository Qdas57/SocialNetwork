using SocialNetwork.Core.Exceptions;
using SocialNetwork.Models.Output;
using SocialNetwork.Services.Repositories;
using System.IO;

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
                    OnService = OnServiceAsync(guid)
                };
            }
            catch (Exception ex)
            {
                string createText = ex + Environment.NewLine;
                File.WriteAllText("ErrInGetProfile.txt", createText);
                return null;
            }
        }
        //TODO: OnService нужно взять register date отнять DateTime.Now и посмотреть
        public async Task<ProfileOutput> OnServiceAsync(Guid guid)
        {
            try
            {
                {
                    var findedUser = await _userRepository.GetUserByIdAsync(guid);

                    if (findedUser is null)
                    {
                        throw new UserNotFoundException($"User with GUID - {guid} not found.");
                    }

                    var ageOnService = findedUser.RegisterDate.Year - DateTime.Now.Year;

                    string ageDeclination = string.Empty;

                    _commonService.DeclinationOfTheYear(ageOnService, out ageDeclination);
                }
            }
            catch (Exception ex)
            {
                // запись в файл ошибок
                // 
                string createText = ex + Environment.NewLine;
                File.WriteAllText("ErrInService.txt", createText);
                return null;
            }
        }
    }
}