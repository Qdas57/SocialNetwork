namespace SocialNetwork.Models.Output
{
    public class ProfileOutput
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Phone { get; set; }

        public string? Avatar { get; set; }

        public string BirthDate { get; set; }

        /// <summary>
        /// Строка в формате: "На сервисе 5 лет, 1 месяц, 3 дня." или "На сервисе 1 месяц, 3 дня." или "На сервисе 3 дня." или "Зарегистрировался сегодня"
        /// </summary>
        public string OnService { get; set; }
        public object Age { get; set; }
        public string AgeDeclination { get; set; }

        public static implicit operator string(ProfileOutput v)
        {
            throw new NotImplementedException();
        }
    }
}
