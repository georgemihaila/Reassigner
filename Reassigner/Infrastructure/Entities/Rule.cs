using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Entities
{
    /// <summary>
    /// Represents a rule.
    /// </summary>
    public class Rule : ISqlConvertible
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public DateTime LastRan { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets the SQL code.
        /// </summary>
        public string Sql
        {
            get
            {
                string result = "SELECT * FROM Rules WHERE (";
                Dictionary<string, string> operations = new Dictionary<string, string>()
                {
                    { "is", "==" },
                    { "is not", "!=" },
                };
                for (int i = 0; i < Parameters.Count(); i++)
                {
                    result += string.Format("{0} {1} {2}");
                    if (i != Parameters.Count() - 1)
                        result += " and ";
                }
                return result + ")";
            }
        }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        IEnumerable<FieldMethodValue> Parameters { get; set; }


    }
}
