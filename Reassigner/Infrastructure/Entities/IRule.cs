using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Entities
{
    /// <summary>
    /// Represents a rule.
    /// </summary>
    public interface IRule : IUnique
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IRule"/> is enabled.
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the time the rule was last ran.
        /// </summary>
        DateTime LastRan { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        string Description { get; set; }
    }
}
