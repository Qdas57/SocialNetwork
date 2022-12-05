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
        }

        public string DeclinationOfTheYear(int year)
        {

            if (year < 0)
            {
                throw new ArgumentException($"{nameof(year)}can't be less than 0");
            }
            return (year % 10) switch
            {
                1 => "год",
                > 1 and < 5 => "года",
                _ => "лет"

            };
          }


        public string DeclinationOfTheMonth(int month)
        {
            if (month < 0)
            {
                throw new ArgumentException($"{nameof(month)} не может быть отрицательным");
            }
            return (month % 10) switch
            {
                1 => "месяц",
                >= 2 and <= 4 => "месяца",
                _ => "месяцев"
            };

        }

        public string DeclinationOfTheDay(int day)
        {
            if (day < 0)
            {
                throw new ArgumentException($"{nameof(day)} cannot be negative.", nameof(day));
            }

            return (day % 10) switch
            {
                1 => "день",
                >= 2 and <= 4 => "дня",
                _ => "дней",
            };
        }

        public string OnService(DateTime registerDate)
        {
            try
            {
                if (registerDate.Date == DateTime.Now.Date)
                {
                    return "Зарегистрировался сегодня.";
                }

                var timeSpanOnService = DateTime.Now.Date.Subtract(registerDate.Date);

                int years = timeSpanOnService.Days / 365;
                int months = (timeSpanOnService.Days % 365) / 30;
                int days = (timeSpanOnService.Days % 365) % 30;

                StringBuilder sb = new StringBuilder();

                sb.Append("На сервисе");

                if (years > 0)
                {
                    sb.Append($" {years} {DeclinationOfTheYear(years)},");
                }

                if (months > 0)
                {
                    sb.Append($" {months} {DeclinationOfTheMonth(months)},");
                }

                if (days > 0)
                {
                    sb.Append($" {days} {DeclinationOfTheDay(days)}.");
                }

                return sb.ToString();

            }
            catch (Exception ex)
            {
                string createText = ex + Environment.NewLine;
                File.WriteAllText("ErrInService.txt", createText);
                return null;
            }
        }
    }

}
