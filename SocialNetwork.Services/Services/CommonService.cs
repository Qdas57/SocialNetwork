using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

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
        // методы в пару строк?
        
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {

                    var idn = new IdnMapping();

                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        
        public bool IsValidPassword(string password)
        {
            char[] symbols = { };

            return !password.Contains(" ") || password.Contains("'") || password.Contains("\"") || password.Contains("/") || password.Contains(";") || password.Contains(":") || password.Contains(",") || password.Contains(".") || password.Contains("?") || password.Contains("") || password.Contains("|") || password.Contains("&") || password.Length < 5 || password.Length > 30;
        } // регулярка
        
        public void DeclinationOfTheYear(int year, out string yearString)
        {
            //TODO: вместо out -> return
            //TODO: написать тесты
            int lastNumber = year % 10;

            if (lastNumber == 1)
            {
                yearString = "год";
            }
            else if (lastNumber >= 2 && lastNumber <= 4)
            {
                yearString = "года";
            }
            else
            {
                yearString = "лет";
            }
        }
        
        public void DeclinationOfTheMonth(int month, out string monthString)
        {
            int lastNumber = month % 10;

            if (lastNumber == 1)
            {
                monthString = "месяц";
            }
            else if (lastNumber >= 2 && lastNumber <= 4)
            {
                monthString = "месяца";
            }
            else
            {
                monthString = "месяцев";
            }

        }
        
        public void DeclinationOfTheDay(int day, out string dayString)
        {
            int lastNumber = day % 10;

            if (lastNumber == 1)
            {
                dayString = "день";
            }
            else if (lastNumber >= 2 && lastNumber <= 4)
            {
                dayString = "дня";
            }
            else
            {
                dayString = "дней";
            }
            
        }
    }

}
