using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace Pipeline.Agent.Services
{
    internal interface IExecutorHubService: IHostedService, IHealthCheckService, IDisposable
    {
        (bool result, string message, IList<string> output) ExecuteCommand(string executorName, IList<string> commands);
    }
}
