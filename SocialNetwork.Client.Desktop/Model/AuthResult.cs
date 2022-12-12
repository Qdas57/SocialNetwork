namespace SocialNetwork.Client.Desktop.Model
{
    public class AuthResult
    {
        public bool Status { get; set; }

        public string Role { get; set; }

        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
