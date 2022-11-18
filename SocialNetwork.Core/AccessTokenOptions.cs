using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SocialNetwork.Core
{
    public class AccessTokenOptions
    {
        public const string ISSUER = "SocialNetworkApi"; // издатель токена

        public const string AUDIENCE = "SocialNetworkClient"; // потребитель токена

        const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации

        public const double LIFETIME = 5; // время жизни токена в минутах

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
