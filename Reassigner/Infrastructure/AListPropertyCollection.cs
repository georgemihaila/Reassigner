using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure
{
    /// <summary>
    /// Represents an abstract implementation of the <see cref="IListPropertyCollection{T}"/>, basing the <see cref="Properties"/> collection on the type <see cref="T"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Reassigner.Infrastructure.IListPropertyCollection{T}" />
    public abstract class AListPropertyCollection<T> : IListPropertyCollection<T>
    {
        private readonly PropertyInfo[] _properties = typeof(T).GetProperties();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>

        public IEnumerable<T> Collection { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return Collection.GetEnumerator();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Collection.GetEnumerator();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>

        public IEnumerable<PropertyInfo> Properties => _properties;
    }
}
