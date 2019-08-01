using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Entities
{
    /// <summary>
    /// Represents a ticket.
    /// </summary>
    public interface ITicket : IUnique
    {
        /// <summary>
        /// Gets or sets the state of the ticket.
        /// </summary>
        State State { get; set; }
    }
}
