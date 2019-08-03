using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Entities
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class ReassignmentEntry : IReassignmentEntry<Ticket, Agent, Rule>
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Ticket Ticket { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Agent Agent { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Rule Rule { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DateTime CompletedTime { get; set; }

    }
}
