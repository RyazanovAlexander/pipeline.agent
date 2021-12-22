using System.Collections.Generic;

namespace Pipeline.Agent.Models
{
    public sealed class Command
    {
        public string ExecutorName { get; set; }

        public IList<string> CommandLines { get; set; }
    }
}
