using Reassigner.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Models
{
    /// <summary>
    /// Represents the model used for displaying detailed reports about a rule.
    /// </summary>
    public class DetailedReportViewModel
    {
        /// <summary>
        /// Gets or sets the rule.
        /// </summary>
        public IRule Rule { get; set; }

        /// <summary>
        /// Gets or sets the entries associated with this rule.
        /// </summary>
        public IEnumerable<ReassignmentEntry> Entries { get; set; }
    }
}
