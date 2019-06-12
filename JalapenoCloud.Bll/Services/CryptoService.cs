using System.Security.Cryptography;
using JalapenoCloud.Dal.Domain.Entities;
using JalapenoCloud.Dal.Domain.Enums;

namespace JalapenoCloud.Bll.Services
{
    public static class CryptoService
    {
        public static void GenerateNewKeyPair()
        {
            var service = new SettingService();
            int keySize = service.GetDbSetting<int>(DbSettingKey.KeySize);

            using (var rsa = new RSACryptoServiceProvider(keySize))
            {
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);

                Setting publicKeySetting = service.GetByKey(DbSettingKey.PublicKey);
                Setting privateKeySetting = service.GetByKey(DbSettingKey.PrivateKey);
                publicKeySetting.Value = publicKey;
                privateKeySetting.Value = privateKey;

                service.Save(publicKeySetting);
                service.Save(privateKeySetting);
            }
        }

        public static string PublicKey()
        {
            var service = new SettingService();
            string response = service.GetDbSetting<string>(DbSettingKey.PublicKey);

            return response;
        }

        public static string PrivateKey()
        {
            var service = new SettingService();
            string response = service.GetDbSetting<string>(DbSettingKey.PrivateKey);

            return response;
        }

        public static byte[] Decode(byte[] encryptedData)
        {
            var service = new SettingService();
            int keySize = service.GetDbSetting<int>(DbSettingKey.KeySize);

            using (var rsa = new RSACryptoServiceProvider(keySize))
            {
                string privateKey = PrivateKey();
                rsa.FromXmlString(privateKey);
                byte[] decryptedData = rsa.Decrypt(encryptedData, false);

                return decryptedData;
            }
        }
    }
}