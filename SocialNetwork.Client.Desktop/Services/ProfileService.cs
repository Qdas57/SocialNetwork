using RestSharp;
using RestSharp.Authenticators;
using SocialNetwork.Client.Desktop.Configuration;
using SocialNetwork.Models.Output;

namespace SocialNetwork.Client.Desktop.Services
{
    public class ProfileService
    {
        public async Task<ProfileOutput> GetMyProfile()
        {
            //TODO: jwt аутентификация
            //https://restsharp.dev/authenticators.html#jwt

            var client = new RestClient(AppConfiguration.Host);

            //TODO: проверить актуален ли токен
            //1. написать класс(метод) для проверки токенов
            //1.1. посомтреть в токене, когда он истекает и сравнить с текущей датой
            //1.2. Если токен протух - обновить(для этого написать метод для обновления токенов)

            client.Authenticator = new JwtAuthenticator("token");

            //...


            throw new NotImplementedException();
        }

        public async Task<int> GetCountProfilesAsync()
        {
            try
            {
                var client = new RestClient(AppConfiguration.Host);

                var request = new RestRequest("profile/count");

                var count = await client.GetAsync<int>(request);

                return count;

            }
            catch (Exception e)
            {
                //TODO: log
                throw;
            }            
        }
    }
}
