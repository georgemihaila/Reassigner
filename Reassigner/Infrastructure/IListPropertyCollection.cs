using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure
{
    /// <summary>
    /// Encapsulates a list of items and their corresponding <see cref="PropertyInfo"/> items.
    /// </summary>
    public interface IListPropertyCollection<T> : IEnumerable<T>
    {
        /// <summary>
        /// Gets or sets the collection.
        /// </summary>
        IEnumerable<T> Collection { get; set; }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        IEnumerable<PropertyInfo> Properties { get; }
    }
}
