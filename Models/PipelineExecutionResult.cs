using System.Collections.Generic;

namespace Pipeline.Agent.Models
{
    public sealed class PipelineExecutionResult
    {
        public bool Result { get; set; }

        public string Message { get; set; }

        public Dictionary<string, IList<string>> Output { get; set; }
    }
}