using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Entities
{
    /// <summary>
    /// Represents a unique entity.
    /// </summary>
    public interface IUnique
    {
        /// <summary>
        /// Gets or sets the entity ID.
        /// </summary>
        [Key]
        string ID { get; set; }
    }
}
