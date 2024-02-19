namespace SlayedLifeCore.Social
{
    public class FacebookQueries
    {
        public static string mybasicProfile = "/me?fields=id,email,first_name,last_name,birthday,picture";
        public static string getOwnedInstagramAccount = "me?fields=businesses{owned_instagram_accounts{profile_pic,follow_count,followed_by_count,username,has_profile_picture}}";
        public static string getPost = "me?fields=posts";
    }
}
