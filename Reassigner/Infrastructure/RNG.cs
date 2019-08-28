using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure
{
    /// <summary>
    /// Represents a random number generator based on the <see cref="RNGCryptoServiceProvider"/> class.
    /// </summary>
    public class RNG
    {
        private static RNGCryptoServiceProvider _instance = new RNGCryptoServiceProvider();

        /// <summary>
        /// Gets a random string.
        /// </summary>
        public static string GetRandomString(int length = 6)
        {
            const string valid = "ABCDEF0123456789";
            StringBuilder res = new StringBuilder();
            byte[] uintBuffer = new byte[sizeof(uint)];
            while (length-- > 0)
            {
                _instance.GetBytes(uintBuffer);
                uint num = BitConverter.ToUInt32(uintBuffer, 0);
                res.Append(valid[(int)(num % (uint)valid.Length)]);
            }
            return res.ToString();
        }
    }
}
