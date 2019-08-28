using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Reassigner.Infrastructure//TODO: add Extensions ns
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

        /// <summary>
        /// Determines whether this <see cref="PropertyInfo"/> has an attribute of type <typeparamref name="T"/>.
        /// </summary>
        public static bool HasAttribute<T>(this PropertyInfo info) where T : Attribute => Attribute.IsDefined(info, typeof(T));

        /// <summary>
        /// Determines whether the specified type is numeric.
        /// </summary>
        public static bool IsNumeric(this Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }
    }
}
