using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace PrashantEle.API.PrashantEle.Infrastructure.Connection
{
    public class Config
    {
        private readonly IConfiguration _config;
        private string encryptedUser { get; set; }
        private static string encryptedKey { get; set; }
        private string encryptedPass { get; set; }
        public Config(IConfiguration config)
        {
            _config = config;
            encryptedUser = _config["EmailSettings:eUser"];
            encryptedPass = _config["EmailSettings:ePass"];
            encryptedKey = _config["EmailSettings:eKey"];
        }
        public string GetHangfireConnection()
        {
            //return new SqlConnection(ConfigurationManager.ConnectionStrings[EvaluationCS].ConnectionString);

            // Get the connection string template
            string connectionStringTemplate = _config.GetConnectionString("hangfireConnectionString");

            string connectionString = connectionStringTemplate.Replace("User Id=USER_ID", $"User Id={Decrypt(encryptedUser)}");

            return connectionString.Replace("password=ACPL_PASSWORD", $"password={Decrypt(encryptedPass)}");
        }
        private static string GetKey()
        {
            return encryptedKey;
        }
        public static string Decrypt(string encryptedText)
        {
            byte[] key = Convert.FromBase64String(GetKey());
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = new byte[16];

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream(encryptedBytes))
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                using (var reader = new StreamReader(cs))
                    return reader.ReadToEnd();
            }
        }
    }
}
