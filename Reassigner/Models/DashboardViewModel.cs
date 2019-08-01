using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Models
{
    /// <summary>
    /// Represents the model used for displaying statistics on the dashboard.
    /// </summary>
    public class DashboardViewModel
    {
        /// <summary>
        /// Gets or sets the number of rules.
        /// </summary>
        public int Rules{ get; set; }

        /// <summary>
        /// Gets the total number of tickets.
        /// </summary>
        public int Total => Assigned + Unassigned;

        /// <summary>
        /// Gets or sets the number of assigned tickets.
        /// </summary>
        public int Assigned { get; set; }

        /// <summary>
        /// Gets or sets the number of unassigned tickets.
        /// </summary>
        public int Unassigned { get; set; }

        /// <summary>
        /// Gets or sets the number of queued tickets.
        /// </summary>
        public int Queued { get; set; }
    }
}
