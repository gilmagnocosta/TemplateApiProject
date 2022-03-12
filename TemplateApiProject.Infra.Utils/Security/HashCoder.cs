using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TemplateApiProject.Infra.Utils.Security
{
    internal static class HashCoder
    {
        internal static string GenerateRandom()
        {
            string input = Guid.NewGuid().ToString();

            return GetMd5Hash(input);
        }

        internal static string Generate(string input)
        {
            return GetMd5Hash(input);
        }

        private static string GetMd5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
