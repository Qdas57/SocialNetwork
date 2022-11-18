namespace SocialNetwork.Models.Output
{
    public class ProfileOutput
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string? Phone { get; set; }

        public string? Avatar { get; set; }

        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Строка в формате: "На сервисе 5 лет, 1 месяц, 3 дня." или "На сервисе 1 месяц, 3 дня." или "На сервисе 3 дня." или "Зарегистрировался сегодня"
        /// </summary>
        public string OnService { get; set; }
    }
}
