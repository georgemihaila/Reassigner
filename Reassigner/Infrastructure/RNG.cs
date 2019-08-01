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
        private static RNGCryptoServiceProvider _instance;

        private RNG(RNGCryptoServiceProvider provider)
        {
            _instance = provider;
        }

        /// <summary>
        /// Gets an instance of the current class.
        /// </summary>
        public static RNG GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RNGCryptoServiceProvider();
            }
            return new RNG(_instance);
        }

        /// <summary>
        /// Gets a random string.
        /// </summary>
        public string GetRandomString(int length = 7)
        {
            const string valid = "ABCDEF0123456789";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();
        }
    }
}
