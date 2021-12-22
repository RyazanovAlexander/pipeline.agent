using Pipeline.Agent.Models;
using APipeline = Pipeline.Agent.Models.Pipeline;

namespace Pipeline.Agent.Services
{
    public interface IPipelineExecutor
    {
        PipelineExecutionResult Execute(APipeline pipeline);
    }
}
