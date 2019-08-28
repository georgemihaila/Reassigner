using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Attributes
{
    /// <summary>
    /// Specifies that a field or property should not be displayed.
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true)]
    public class NotDisplayableAttribute : Attribute
    {
        
    }
}
