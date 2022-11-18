namespace SocialNetwork.Models.Output
{
    public class RefreshTokenOutput
    {
        public long RefreshTokenId { get; set; }

        public string RefreshToken { get; set; }

        public Guid UserId { get; set; }
    }
}
