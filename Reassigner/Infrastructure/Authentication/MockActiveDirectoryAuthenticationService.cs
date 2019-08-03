using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Authentication
{
    /// <summary>
    /// Represents a mock implementation for the <see cref="ICustomAuthenticationService"/> interface.
    /// </summary>
    /// <seealso cref="Reassigner.Infrastructure.Authentication.ICustomAuthenticationService" />
    public class MockActiveDirectoryAuthenticationService : ICustomAuthenticationService
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>

        public bool ValidateCredentials(string domain, string username, string password)
        {
            return true;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>

        public bool ValidateCredentials(string domainUsername, string password)
        {
            return true;
        }
    }
}
