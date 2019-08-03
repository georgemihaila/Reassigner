using Reassigner.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure
{
    /// <summary>
    /// Provides extensions for the <see cref="IReassignerContext{TTicket, TAgent, TRule, TEntry}"/> interface.
    /// </summary>
    public static class ReassignerContextExtensions
    {
        public static void Foo(this IReassignerContext<ITicket, IAgent, IRule, IReassignmentEntry<ITicket, IAgent, IRule>> context)
        {

        }
    }
}
