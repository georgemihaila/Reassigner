using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reassigner.Infrastructure
{
    /// <summary>
    /// Provides type methods based on the <see cref="System.Reflection"/> namespace.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Dictionary for storing properties of generic type arguments.
        /// </summary>
        private static Dictionary<(Type, int), IEnumerable<PropertyInfo>> _genericPropsDictionary = new Dictionary<(Type, int), IEnumerable<PropertyInfo>>();

        /// <summary>
        /// Gets the properties from the generic arguments of a type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="genericIndex">The index of the generic type.</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public static IEnumerable<PropertyInfo> GetPropertiesOfGenericArgument(this Type type, int genericIndex)
        {
            var args = type.GetGenericArguments();
            if (args.Length == 0)
                throw new InvalidOperationException(string.Format("Type {0} has no generic arguments.", type));
            if (args.Length < genericIndex - 1)
                throw new IndexOutOfRangeException(string.Format("Type {0} has only {1} generic argument{2}.", type, args.Length, (args.Length != 1) ? "s" : string.Empty));
            if (!_genericPropsDictionary.Keys.Contains((type, genericIndex)))
                _genericPropsDictionary[(type, genericIndex)] = args[genericIndex].GetProperties().ToList();
            return _genericPropsDictionary[(type, genericIndex)];
        }
    }
}
