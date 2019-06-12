using System;
using System.Security.Cryptography;
using System.Text;

namespace JalapenoCloud.Common.Security
{
    public static class PasswordHelper
    {
        public static bool CheckPassword(string accountPassword, string accountSalt, string password)
        {
            string hashedPassword = EncodePassword(password, accountSalt);
            bool response = accountPassword == hashedPassword;
            return response;
        }

        public static string EncodePassword(string password, string salt)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] src = Convert.FromBase64String(salt);
            byte[] dst = new byte[src.Length + bytes.Length];

            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] encoded = algorithm.ComputeHash(dst);
            string response = Convert.ToBase64String(encoded);

            return response;
        }

        public static string GenerateSalt()
        {
            byte[] buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            string response = Convert.ToBase64String(buf);
            return response;
        }
    }
}