namespace SlayedLifeCore
{
    public enum AuthorizeTypeEnum
    {
        Facebook = 1,
        Google = 2,
    }

    public enum InstagramAccountConnectResponse
    {
        NoInstagramAccount = 0,
        NoBusinessInstagramAccount = 100,
        NeitherAccount = 200,
        AtLeastOneFailedAccount = 250,
        AllAccounts = 300
    }

    public enum SocialAccontEnum
    {
        Facebook = 1,
        Google = 2,
        Instagram = 3,
        InstagramBusiness = 4,
        Twitter = 5,
        Youtube = 6,
        Pintrest = 7
    }

    public enum PreferencesEnum
    {
        UpdateInfoDuringLogin = 1,
        PhoneNotification = 2,
        EmailNotification = 3,
        SharePersonalInformation = 4
    }

    public enum LevelsEnum
    {
        Bronze = 1,
        Silver = 2,
        Gold = 3,
        Diamond = 4,
        Platinum = 5,
        Titanium = 6,
        Rhodium = 7
    }
}
