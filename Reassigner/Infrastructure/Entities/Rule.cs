using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Entities
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class Rule : IRule
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DateTime LastRan { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string Description { get; set; }
    }
}
