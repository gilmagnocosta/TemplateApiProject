using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TemplateApiProject.Infra.Utils.Security
{
    public static class PasswordGenerator
    {
        public static string Generate(string password)
        {
            string result;
            var bytes = Encoding.Unicode.GetBytes(password);

            using (var stream = new MemoryStream())
            {
                stream.WriteByte(0);

                using (var sha256 = new SHA256Managed())
                {
                    var hash = sha256.ComputeHash(bytes);
                    stream.Write(hash, 0, hash.Length);

                    bytes = stream.ToArray();
                    result = Convert.ToBase64String(bytes);
                }

            }
            return result;
        }
    }
}