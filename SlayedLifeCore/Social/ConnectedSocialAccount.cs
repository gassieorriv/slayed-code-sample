using SlayedLifeCore.Users;
using System;

namespace SlayedLifeCore.Social
{
    public class ConnectedSocialAccount
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AccountId { get; set; }
        public int SocialAccountId { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Secret { get; set; }
        public float? Expires { get; set; }
        public bool Active { get; set; }
        public int Following { get; set; }
        public int Followers { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual SocialAccount SocialAccount { get; set; }
    }
}
