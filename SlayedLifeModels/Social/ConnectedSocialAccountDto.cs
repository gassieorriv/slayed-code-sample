namespace SlayedLifeModels.Social
{
    public class ConnectedSocialAccountDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AccountId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public int Following { get; set; }
        public int Followers { get; set; }
        public bool Active { get; set; }
        public SocialAccountDto SocialAccount { get; set; }

    }
}
