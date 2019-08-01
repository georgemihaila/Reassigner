using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Entities
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    /// <seealso cref="Reassigner.Infrastructure.Entities.ITicket" />
    public class Ticket : ITicket
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public State State { get; set; }
    }
}
