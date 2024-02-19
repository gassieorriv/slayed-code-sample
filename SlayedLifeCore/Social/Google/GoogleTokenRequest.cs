namespace SlayedLifeCore.Social.Google
{
    public class GoogleTokenRequest
    {
        public string clientId { get; set; }
        public string clientSecret { get; set; }
        public string code { get; set; }
        public string codeVerifier { get; set; }
        public string grantType { get; set; }
        public string refreshToken { get; set; }
        public string redirectUri { get; set; }
        public string endpoint { get; set; }
    }
}
