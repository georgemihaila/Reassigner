using Reassigner.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Reassigner.Models
{
    /// <summary>
    /// Represents the model used for displaying the rules page.
    /// </summary>
    public class RulesViewModel
    {
        /// <summary>
        /// Gets or sets the rules.
        /// </summary>
        public IEnumerable<IRule> Rules { get; set; }

        /// <summary>
        /// Gets or sets the properties of the concrete type of ticket.
        /// </summary>
        public IEnumerable<PropertyInfo> Properties { get; set; }
    }
}
