using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PortalAPI.Services
{
    public class PasswordService
    {
        private readonly IConfiguration _configuration;

        public PasswordService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string PasswordEncrypt(string password)
        {
            string secretKey = _configuration.GetValue<string>("PasswordKey");
            byte[] secretKeyBytes = Encoding.ASCII.GetBytes(secretKey);
            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
            byte[] encryptedPassword;

            using (HMACSHA256 hash = new HMACSHA256(secretKeyBytes))
            {
                encryptedPassword = hash.ComputeHash(passwordBytes);
            }

            return BitConverter.ToString(encryptedPassword).ToLower().Replace("-", "");
        }

        public bool PasswordValidate(string password, string passwordDb)
        {
            string passwordEncrypted = PasswordEncrypt(password);
            return (passwordEncrypted == passwordDb) ? true : false;
        }

        public string KeyGenerator(int size)
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

            byte[] data = new byte[size];

            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }

            return result.ToString();
        }
    }
}
