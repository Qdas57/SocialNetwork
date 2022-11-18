namespace SocialNetwork.Models.Output
{
    public class LoginResult
    {
        /// <summary>
        /// Токен доступа.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Рефреш токен.
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
