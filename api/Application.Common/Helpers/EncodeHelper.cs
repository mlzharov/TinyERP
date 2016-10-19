using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace App.Common.Helpers
{
    public class EncodeHelper
    {
        public static string EncodePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                return string.Empty;
            }
            return Md5Encode(password);
        }
        public static string Md5Encode(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Generate random string which contains only characters following: A->Z, a->z, 0->9
        /// </summary>
        /// <param name="length">length of ouput string</param>
        /// <returns></returns>
        public static string GenerateRandomString(int length) {

            Random random = new Random();
            Dictionary<int, StringBuilder> stringBuilders = new Dictionary<int, StringBuilder>();
            string seedCharacters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            StringBuilder result;
            if (!stringBuilders.TryGetValue(length, out result))
            {
                result = new StringBuilder();
                stringBuilders[length] = result;
            }

            result.Clear();

            for (int i = 0; i < length; i++)
            {
                result.Append(seedCharacters[random.Next(seedCharacters.Length)]);
            }

            return result.ToString();

        }
    }

    /// <summary>
    /// Move class Md5Crypt from Omega.Web.Lib to here use in Omega.Services.Impl
    /// </summary>
    public static class Md5Crypt
    {
        private const string Senha = "Norpost$";

        public static string Encrypt(string password)
        {
            byte[] results;
            var utf8 = new UTF8Encoding();
            var hashProvider = new MD5CryptoServiceProvider();
            var tdesKey = hashProvider.ComputeHash(utf8.GetBytes(Senha));
            var tdesAlgorithm = new TripleDESCryptoServiceProvider
            {
                Key = tdesKey,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            var dataToEncrypt = utf8.GetBytes(password);
            try
            {
                var encryptor = tdesAlgorithm.CreateEncryptor();
                results = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
            }
            finally
            {
                tdesAlgorithm.Clear();
                hashProvider.Clear();
            }
            return Convert.ToBase64String(results);
        }

        public static string Descrypt(string password)
        {
            byte[] results;
            var utf8 = new UTF8Encoding();
            var hashProvider = new MD5CryptoServiceProvider();
            var tdesKey = hashProvider.ComputeHash(utf8.GetBytes(Senha));
            var tdesAlgorithm = new TripleDESCryptoServiceProvider
            {
                Key = tdesKey,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            var dataToDecrypt = Convert.FromBase64String(password);
            try
            {
                var decryptor = tdesAlgorithm.CreateDecryptor();
                results = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
            }
            finally
            {
                tdesAlgorithm.Clear();
                hashProvider.Clear();
            }
            return utf8.GetString(results);
        }
    }
}
