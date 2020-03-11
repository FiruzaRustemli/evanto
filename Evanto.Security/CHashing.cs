using PWDTK_DOTNET451;
using System.Security.Cryptography;
using System.Text;

namespace Evanto.Security
{
    public static class CHashing
    {
        public static byte[] RandomSalt()
        {
            return PWDTK.GetRandomSalt(64);
        }

        public static byte[] Hash(byte[] salt, string password)
        {
            return PWDTK.PasswordToHash(salt, password);
        }

        public static bool Equals(byte[] salt, string password, byte[] hash)
        {
            return PWDTK.ComparePasswordToHash(salt, password, hash);
        }

        public static string GetMd5HashData(string data)
        {
            MD5 md5 = MD5.Create();
            byte[] hashData = md5.ComputeHash(Encoding.UTF8.GetBytes(data));

            StringBuilder returnValue = new StringBuilder();
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString("x2"));
            }

            return returnValue.ToString();


        }
    }
}
