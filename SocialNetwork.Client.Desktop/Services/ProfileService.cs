using RestSharp;
using SocialNetwork.Client.Desktop.Configuration;

namespace SocialNetwork.Client.Desktop.Services
{
    public class ProfileService
    {
        public async Task<int> GetCountProfilesAsync()
        {
            var client = new RestClient(AppConfiguration.Host);

            var request = new RestRequest("profile/count");

            var count = await client.GetAsync<int>(request);

            return count;
        }
    }
}
