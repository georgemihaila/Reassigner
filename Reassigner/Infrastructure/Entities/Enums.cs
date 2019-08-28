using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reassigner.Infrastructure.Entities
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum State { Assigned, Unassigned }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Priority { Low, Medium, High }
}
