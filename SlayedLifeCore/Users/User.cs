using SlayedLifeCore.Shop;
using SlayedLifeCore.Social;
using System;
using System.Collections.Generic;

namespace SlayedLifeCore.Users
{
    public class User
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public DateTime? dob { get; set; }
        public string phone { get; set; }
        public string photo { get; set; }
        public DateTime createdDate { get; set; }
        public string createdBy { get; set; }
        public DateTime? modifiedDate { get; set; }
        public string modifiedBy { get; set; }
        public virtual List<UserPreference> userPreferences { get; set; }

        public virtual List<ConnectedSocialAccount> ConnectedSocialAccounts { get; set; }

        public virtual UserPaymentAccount userPaymentAccount { get; set; }

        public virtual List<Product> userProducts { get; set; }
        public virtual List<Service> userServices { get; set; }
    }
}
