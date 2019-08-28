using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure
{
    /// <summary>
    /// Represents an entity which can be converted to an SQL query.
    /// </summary>
    public interface ISqlConvertible
    {
        /// <summary>
        /// Gets the SQL code.
        /// </summary>
        string Sql { get; }
    }
}
