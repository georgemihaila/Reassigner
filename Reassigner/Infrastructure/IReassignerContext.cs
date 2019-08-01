using System;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Reassigner.Infrastructure.Entities;

namespace Reassigner.Infrastructure
{
    /// <summary>
    /// Represents an application context.
    /// </summary>
    public interface IReassignerContext<TTicket, TAgent, TRule, TEntry> where TTicket : class, ITicket where TAgent : class, IAgent where TRule : class, IRule where TEntry: class, IReassignmentEntry<TTicket, TAgent, TRule>
    {
        /// <summary>
        /// Gets or sets the tickets.
        /// </summary>
        DbSet<TTicket> Tickets { get; set; }

        /// <summary>
        /// Gets or sets the agents
        /// </summary>
        DbSet<TAgent> Agents { get; set; }

        /// <summary>
        /// Gets or sets the rules.
        /// </summary>
        DbSet<TRule> Rules { get; set; }

        /// <summary>
        /// Gets or sets the reassignment entries.
        /// </summary>
        DbSet<TEntry> ReassignmentEntries { get; set; }
    }
}
