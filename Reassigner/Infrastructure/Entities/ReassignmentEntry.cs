using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Entities
{
    /// <summary>
    /// Represents a reassignment entry.
    /// </summary>
    public class ReassignmentEntry
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the ticket.
        /// </summary>
        public Ticket Ticket { get; set; }

        /// <summary>
        /// Gets or sets the agent.
        /// </summary>
        public Agent Agent { get; set; }

        /// <summary>
        /// Gets or sets the rule.
        /// </summary>
        public Rule Rule { get; set; }

        /// <summary>
        /// Gets or sets the time the reassignment was completed.
        /// </summary>
        public DateTime? CompletedTime { get; set; }

    }
}
