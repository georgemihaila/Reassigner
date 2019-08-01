using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Authentication
{
    /// <summary>
    /// Represents an Active Directory authentication service.
    /// </summary>
    public interface IActiveDirectoryAuthenticationService
    {
        /// <summary>
        /// Validates user credentials against Active Directory.
        /// </summary>
        bool ValidateCredentials(string domain, string username, string password);

        /// <summary>
        /// Validates user credentials against Active Directory.
        /// </summary>
        bool ValidateCredentials(string domainUsername, string password);
    }
}
