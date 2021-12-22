using Exec;
using Grpc.Core;
using System;
using System.Collections.Generic;
using static Exec.ExecService;

namespace Pipeline.Agent.Models
{
    internal sealed class Executor: IDisposable
    {
        private readonly Channel _channel;
        private readonly ExecServiceClient _client;

        public string Name { get; }

        public Executor(string name, string target)
        {
            Name = name;

            _channel = new Channel(target, ChannelCredentials.Insecure);
            _client = new ExecServiceClient(_channel);
        }

        public ExecResult ExecuteCommands(IList<string> commands)
        {
            var execCommands = new ExecCommands();
            execCommands.Commands.AddRange(commands);

            return _client.ExecuteCommands(execCommands);
        }

        public void Dispose()
        {
            if (_channel.State != ChannelState.Shutdown)
            {
                _channel.ShutdownAsync().Wait();
            }
        }
    }
}
