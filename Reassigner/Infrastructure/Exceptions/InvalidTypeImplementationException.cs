using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Exceptions
{
    /// <summary>
    /// The exception that is thrown when a type is incorrectly implemented.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class InvalidTypeImplementationException : Exception
    {
        private readonly Type _baseType;
        private readonly Type _expectedType;
        private readonly Type _actualType;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidTypeImplementationException"/> class.
        /// </summary>
        /// <param name="baseType">Type base type.</param>
        /// <param name="expectedType">The expected type.</param>
        /// <param name="actualType">The actual type.</param>
        public InvalidTypeImplementationException(Type baseType, Type expectedType, Type actualType) : base()
        {
            _baseType = baseType;
            _expectedType = expectedType;
            _actualType = actualType;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override string Message => string.Format("Type {0} was expected to have an implementation of type {1} but actually has an implementation of type {2}.", _baseType, _expectedType, _actualType);
    }
}
