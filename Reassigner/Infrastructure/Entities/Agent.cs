using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Entities
{
    public class Agent : IAgent
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string ID { get; set; }
    }
}
