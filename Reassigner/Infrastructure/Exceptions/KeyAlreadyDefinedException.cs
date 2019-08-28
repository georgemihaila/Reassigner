using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Exceptions
{
    /// <summary>
    /// The exception that is thrown when a key is already defined.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class KeyAlreadyDefinedException : Exception
    {
        private readonly string _key;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyAlreadyDefinedException"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        public KeyAlreadyDefinedException(string key)
        {
            _key = key;
        }

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public override string Message => string.Format("Key {0} is already defined.", _key);
    }
}
