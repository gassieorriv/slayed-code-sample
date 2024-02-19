namespace SlayedLifeCore.Social.Google
{
    public class GoogleTokenResponse
    {
        public string accessToken { get; set; }
        public long expiresIn { get; set; }
        public string idToken { get; set; }
        public string refreshToken { get; set; }
        public string scope { get; set; }
        public string tokenType { get; set; }
    }
}
