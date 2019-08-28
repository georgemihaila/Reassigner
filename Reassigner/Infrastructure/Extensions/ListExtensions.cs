using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Extensions
{
    /// <summary>
    /// Represents list extensions.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Returns distinct elements from a sequence based on a single field.
        /// </summary>
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> property)
        {
            return items.GroupBy(property).Select(x => x.First());
        }
    }
}
