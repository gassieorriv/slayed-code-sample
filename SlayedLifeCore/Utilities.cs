using System;
using System.Security.Cryptography;
using System.Text;

namespace SlayedLifeCore
{
    public class Utilities
    {
        private static readonly string key = "SP038NaZ112j8HLY";
        public static string Encrypt(string input)
        {
            byte[] inputArray = Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string input)
        {
            byte[] inputArray = Convert.FromBase64String(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        public static LevelsEnum GetCurrentLevel(int totalFollowing)
        {
           if(totalFollowing <= 100000)
           {
             return LevelsEnum.Bronze;
           } 
           else if(totalFollowing <= 500000)
           {
              return LevelsEnum.Silver;
           }
            else if (totalFollowing <= 1000000)
            {
                return LevelsEnum.Gold;
            }
            else if (totalFollowing <= 10000000 )
            {
                return LevelsEnum.Diamond;
            }
            else if (totalFollowing <= 500000)
            {
                return LevelsEnum.Titanium;
            }
            else if (totalFollowing <= 500000)
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
