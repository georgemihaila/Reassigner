using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Reassigner.Infrastructure;
using Reassigner.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Reassigner
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class ApplicationDbContext : DbContext, IReassignerContext<Ticket, Agent, Rule, ReassignmentEntry>, INotifyDbContextChanged
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>

        public event EventHandler DbContextChanged;

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

        /// <summary>
        /// <inheritdoc/>
        /// </summary>

        public override int SaveChanges()
        {
            var result = base.SaveChanges();
            DbContextChanged?.Invoke(this, new EventArgs());
            return result;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            var result = base.SaveChanges(acceptAllChangesOnSuccess);
            DbContextChanged?.Invoke(this, new EventArgs());
            return result;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var result = base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            DbContextChanged?.Invoke(this, new EventArgs());
            return result;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = base.SaveChangesAsync(cancellationToken);
            DbContextChanged?.Invoke(this, new EventArgs());
            return result;
        }
    }
}
