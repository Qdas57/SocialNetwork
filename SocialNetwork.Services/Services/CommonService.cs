using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services
{
    /// <summary>
    /// Класс содержит общие методы для остальных сервисов
    /// </summary>
    public class CommonService
    {
        public string GetHash(string input)
        {
            using SHA256 sha256Hash = SHA256.Create();
            
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
  
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
