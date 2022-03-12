using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemplateApiProject.Infra.Utils.Security;

namespace TemplateApiProject.Infra.Utils.Token
{
    public static class TokenGenerator
    {
        /// <summary>
        /// Generates random token
        /// </summary>
        /// <returns>Token generated</returns>
        public static string Generate(int? size = null)
        {
            var hash = HashCoder.GenerateRandom();
            
            if (size != null && size > 0)
            {
                hash = hash.Substring(0, size.Value);
            }

            return hash;
        }
    }
}
