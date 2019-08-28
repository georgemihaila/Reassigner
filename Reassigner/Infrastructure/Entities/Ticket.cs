using Reassigner.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Entities
{
    /// <summary>
    /// Represents a ticket.
    /// </summary>
    public class Ticket
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [NotDisplayable]
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public State State { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        public Priority Priority { get; set; }
    }
}
