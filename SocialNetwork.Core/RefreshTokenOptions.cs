using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SocialNetwork.Core
{
    public class RefreshTokenOptions
    {
        public const string ISSUER = "SocialNetworkApi"; // издатель токена

        public const string AUDIENCE = "SocialNetworkClient"; // потребитель токена

        const string KEY = "Assupion#cret_6Jk8lLkey!321";   // ключ для шифрации

        public const int LIFETIME = 131400; // время жизни токена в минутах
       
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
