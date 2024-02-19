namespace SlayedLifeCore.Social
{
    public class FacebookUser
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string dob { get; set; }
        public string email { get; set; }
        public FacebookPicture<FacebookPictureData> picture { get; set; }
    }
}
