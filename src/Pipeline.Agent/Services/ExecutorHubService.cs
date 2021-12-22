using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pipeline.Agent.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pipeline.Agent.Services
{
    internal class ExecutorHubService : IExecutorHubService
    {
        private readonly ILogger<ExecutorHubService> _logger;
        private readonly PipelineAgentOptions _pipelineAgentOptions;
        private readonly Dictionary<string, Executor> _executorRegistry = new();

        private bool initialized = false;

        public ExecutorHubService(
            IOptions<PipelineAgentOptions> pipelineAgentOptions,
            ILogger<ExecutorHubService> logger)
        {
            _pipelineAgentOptions = pipelineAgentOptions.Value;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                foreach (var executorOptions in _pipelineAgentOptions.Executors)
                {
                    _executorRegistry.Add(executorOptions.Name, new Executor(executorOptions.Name, executorOptions.Target));
                }

                initialized = true;

                _logger.LogDebug("ExecutorHub has been successfully initialized");
            }, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public bool IsReady() => initialized;

        public (bool result, string message, IList<string> output) ExecuteCommand(string executorName, IList<string> commands)
        {
            if (!_executorRegistry.TryGetValue(executorName, out Executor executor))
            {
                _logger.LogError("Executor {0} not found", executorName);
                return (false, "Executor not found", null);
            }

            var result = executor.ExecuteCommands(commands);
            if (!result.Result)
            {
                _logger.LogError("Executor {0} failed to execute one of the command: {2}", executorName, result.ErrorMessage);
                return (false, result.ErrorMessage, null);
            }

            _logger.LogDebug("Executor {0} has successfully completed all the commands {1}", executorName);

            return (true, string.Empty, result.Output);
        }

        public void Dispose()
        {
            foreach (var executorKeyValue in _executorRegistry)
            {
                executorKeyValue.Value.Dispose();
            }
        }
    }
}
