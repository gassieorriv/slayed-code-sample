namespace SlayedLifeModels
{
    public class Utilities
    {
        public static LevelsEnum GetCurrentLevel(int totalFollowing)
        {
            if (totalFollowing <= 100000)
            {
                return LevelsEnum.Bronze;
            }
            else if (totalFollowing <= 500000)
            {
                return LevelsEnum.Silver;
            }
            else if (totalFollowing <= 1000000)
            {
                return LevelsEnum.Gold;
            }
            else if (totalFollowing <= 10000000)
            {
                return LevelsEnum.Diamond;
            }
            else if (totalFollowing <= 100000000)
            {
                return LevelsEnum.Platinum;
            }
            else if (totalFollowing <= 200000000)
            {
                return LevelsEnum.Rhodium;
            }
            else
            {
                return LevelsEnum.Bronze;
            }
        }
    }
}
