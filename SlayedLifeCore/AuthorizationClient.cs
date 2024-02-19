namespace SlayedLifeCore.Global
{
    public class AuthorizationClient
    {
        public AuthorizeTypeEnum AuthorizationType { get; set; }
        public string UserId { get; set; }
        public string AccessToken { get; set; }
        public string ApiToken { get; set; }
    }
}
