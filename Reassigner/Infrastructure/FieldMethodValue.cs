using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure
{
    /// <summary>
    /// Represents a field-method-value pair.
    /// </summary>
    public class FieldMethodValue
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the field.
        /// </summary>
        public string Value { get; set; }
    }
}
