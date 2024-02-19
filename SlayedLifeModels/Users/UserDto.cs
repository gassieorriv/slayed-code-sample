using SlayedLifeModels.Social;
using System;
using System.Collections.Generic;
using System.Linq;
using SlayedLifeModels;
using SlayedLifeModels.Shop;

namespace SlayedLifeModels.Users
{
    public class UserDto
    {
        public string userName { get; set; }
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime? dob { get; set; }
        public string phone { get; set; }
        public string photo { get; set; }
        public string email { get; set; }
        public List<ConnectedSocialAccountDto> ConnectedSocialAccounts { get; set; }
        public int? TotalFollowers { get { return ConnectedSocialAccounts?.Where(x => x.Active).Sum(x => x.Followers); } }
        public int? TotalFollowing { get { return ConnectedSocialAccounts?.Where(x => x.Active).Sum(x => x.Following); } }
        public int Level
        { 
            get 
            {
                if (TotalFollowing.HasValue)
                {
                    return (int)Utilities.GetCurrentLevel(TotalFollowing.Value);
                }
                else
                {
                    return 1;
                }
            } 
        }

        public UserPaymentAccountDto userPaymentAccount { get; set; }

        public List<ServiceDto> userServices { get; set; }

        public List<ProductDto> userProducts { get; set; }
    }
}
