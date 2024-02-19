using System;

namespace SlayedLifeCore.Users
{
    public class UserPaymentAccount
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string AccountId { get; set; }
        public bool? ChargesEnabled { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
