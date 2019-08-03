using Reassigner.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Dependencies
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>

    public class ApplicationDependencies : IApplicationDependencyProvider
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// 
        public Dictionary<Type, Type> TypeImplementations { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDependencies"/> class.
        /// </summary>
        public ApplicationDependencies()
        {
            TypeImplementations = new Dictionary<Type, Type>();
            TypeImplementations.Add(typeof(ITicket), typeof(Ticket));
            TypeImplementations.Add(typeof(IRule), typeof(Rule));
            TypeImplementations.Add(typeof(IAgent), typeof(Agent));
            TypeImplementations.Add(typeof(IReassignmentEntry<ITicket, IAgent, IRule>), typeof(ReassignmentEntry));
        }

    }
}
