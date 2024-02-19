using System.Collections.Generic;

namespace SlayedLifeCore.Social
{
    public class InstagramAccount
    {
        public int id { get; set; }
    }

    public class InstagramBusiness
    {
        public InstagramBusinessData businesses { get; set; }
    }

    public class InstagramBusinessData
    {
        public InstagramBusinessAccountData[] data { get; set; }
    }

    public class InstagramBusinessAccountData
    {
        public instagram_business_accounts<instagram_account_values[]> instagram_business_accounts { get; set; }
        public instagram_accounts<instagram_account_values[]> instagram_accounts { get; set; }
        public owned_instagram_accounts<instagram_account_values[]> owned_instagram_accounts { get; set; }
    }

    public class instagram_business_accounts<T>
    {
        public T Data { get; set; }
    }

    public class owned_instagram_accounts<T>
    {
        public T Data { get; set; }
    }

    public class instagram_accounts<T>
    {
        public T Data { get; set; }
    }

    public class media<T>
    {
        public T Data { get; set; }
    }

    public class instagram_account_values
    {
        public string id { get; set; }
        public int followed_by_count { get; set; }
        public int follow_count { get; set; }
        public int follows_count { get; set; }
        public int followers_count { get; set; }
        public string name { get; set; }
        public string profile_pic { get; set; }
        public string profile_picture_url { get; set; }
        public string username { get; set; }
        public int media_count { get; set; }
        public media<List<InstagramMedia>> media { get; set; }

    }
}
