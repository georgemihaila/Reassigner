using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Entities
{
    /// <summary>
    /// Represents a reassignment entry.
    /// </summary>
    public interface IReassignmentEntry<ITicket, IAgent, IRule>
    {
        /// <summary>
        /// Gets or sets the ticket.
        /// </summary>
        ITicket Ticket { get; set; }

        /// <summary>
        /// Gets or sets the agent.
        /// </summary>
        IAgent Agent { get; set; }

        /// <summary>
        /// Gets or sets the rule.
        /// </summary>
        IRule Rule { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ReassignmentEntry"/> is completed.
        /// </summary>
        DateTime CompletedTime { get; set; }
    }
}
