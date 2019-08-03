using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Dependencies
{
    /// <summary>
    /// Represents application dependencies.
    /// </summary>
    public interface IApplicationDependencies
    {
        /// <summary>
        /// Gets or sets the required type implementations.
        /// </summary>
        Dictionary<Type, Type> TypeImplementations { get; }
    }
}
