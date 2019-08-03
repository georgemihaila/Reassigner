using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Authentication
{
    /// <summary>
    /// Represents an Active Directory authentication service.
    /// </summary>
    public class ActiveDirectoryAuthenticationService : ICustomAuthenticationService
    {
        /// <summary>
        /// Validates user credentials against Active Directory.
        /// </summary>
        /// <returns>A value indicating whether the validation was successful.</returns>
        /// <exception cref="ArgumentNullException">Thrown if an argument is null or empty.</exception>
        public bool ValidateCredentials(string domain, string username, string password)
        {
            if (domain is null || domain.Trim().Length == 0)
                throw new ArgumentNullException(nameof(domain));
            if (username is null || username.Trim().Length == 0)
                throw new ArgumentNullException(nameof(username));
            if (password is null || password.Trim().Length == 0)
                throw new ArgumentNullException(nameof(password));

            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain))
            {
                return pc.ValidateCredentials(username, password);
            }
        }

        /// <summary>
        /// Validates user credentials against Active Directory.
        /// </summary>
        /// <returns>A value indicating whether the validation was successful.</returns>
        /// <exception cref="ArgumentNullException">Thrown if an argument is null or empty.</exception>
        /// <exception cref="ArgumentException">Thrown if the <paramref name="domainUsername"/> parameter does not contain excatly one '\' domain-username separation character.</exception>
        public bool ValidateCredentials(string domainUsername, string password)
        {
            if (domainUsername is null || domainUsername.Trim().Length == 0)
                throw new ArgumentNullException(nameof(domainUsername));
            if (domainUsername.Count(c => c == '\\') != 1)
                throw new ArgumentException(nameof(domainUsername));
            if (password is null || password.Trim().Length == 0)
                throw new ArgumentNullException(nameof(password));

            string[] args = domainUsername.Split("\\");
            return ValidateCredentials(args[0], args[1], password);
        }
    }
}
