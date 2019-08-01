using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Reassigner.Infrastructure;
using Reassigner.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class ApplicationDbContext : DbContext, IReassignerContext<Ticket, Agent, Rule, ReassignmentEntry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

#if DEBUG   //Only for EF migrations.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=ReassignerDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
#endif

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DbSet<Ticket> Tickets { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DbSet<Agent> Agents { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DbSet<Rule> Rules { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DbSet<ReassignmentEntry> ReassignmentEntries { get; set; }
    }
}
