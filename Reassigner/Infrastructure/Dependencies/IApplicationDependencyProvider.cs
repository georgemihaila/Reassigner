using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Dependencies
{
    /// <summary>
    /// Represents a dependency provider.
    /// </summary>
    public interface IApplicationDependencyProvider
    {
        /// <summary>
        /// Gets or sets the required type implementations.
        /// </summary>
        Dictionary<Type, Type> TypeImplementations { get; }
    }
}
