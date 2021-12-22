using Microsoft.Extensions.Logging;
using Pipeline.Agent.Models;
using System.Collections.Generic;
using APipeline = Pipeline.Agent.Models.Pipeline;

namespace Pipeline.Agent.Services
{
    internal sealed class PipelineExecutor : IPipelineExecutor
    {
        private readonly IExecutorHubService _executorHubService;
        private readonly ILogger<PipelineExecutor> _logger;

        public PipelineExecutor(
            IExecutorHubService executorHubService,
            ILogger<PipelineExecutor> logger)
        {
            _executorHubService = executorHubService;
            _logger = logger;
        }

        public PipelineExecutionResult Execute(APipeline pipeline)
        {
            var output = new Dictionary<string, IList<string>>();
            int step = 1;

            foreach (var command in pipeline.Commands)
            {
                var result = _executorHubService.ExecuteCommand(command.ExecutorName, command.CommandLines);
                if (!result.result)
                {
                    var message = string.Format("Executor {0} failed to execute the command: {1}", command.ExecutorName, result.message);
                    _logger.LogError(message);

                    return new PipelineExecutionResult
                    {
                        Result = false,
                        Message = message
                    };
                }

                output.Add($"{step++}:{command.ExecutorName}", result.output);
            }

            return new PipelineExecutionResult { Result = true, Output = output };
        }
    }
}
