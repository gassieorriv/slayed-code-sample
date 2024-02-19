namespace SlayedLifeCore.Social.Instagram
{
    public class InstagramQueries
    {
        public static string getInstagramAccountIds = "v10.0/me?fields=businesses{instagram_business_accounts,instagram_accounts}";
        public static string getInstagraAccountsWithFollowers = "v10.0/me?fields=businesses{owned_instagram_accounts{profile_pic,follow_count,followed_by_count,username,has_profile_picture}}";
        public static string getInstagramAccountPost = "v10.0/me?fields=businesses{instagram_business_accounts{media_count,media{caption,media_url}}}";
    }
}
