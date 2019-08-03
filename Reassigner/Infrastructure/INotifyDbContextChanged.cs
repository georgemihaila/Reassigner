using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure
{
    /// <summary>
    /// Notifies clients that <see cref="DbContext"/> data has changed.
    /// </summary>
    public interface INotifyDbContextChanged
    {
        /// <summary>
        /// Occurs when <see cref="DbContext"/> data changes.
        /// </summary>
        event EventHandler DbContextChanged;
    }
}
