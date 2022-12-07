namespace SocialNetwork.Models.Output
{
    public class UserOutput
    {
        public Guid UserId { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public DateTime BirthDate { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Avatar { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
