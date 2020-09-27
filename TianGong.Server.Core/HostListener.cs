using Microsoft.Extensions.Hosting;
using SuperSocket;
using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace TianGong.Server.Core
{
    public class HostListener
    {
        IHost host;
        public void SetUp()
        {
            host = SuperSocketHostBuilder
                .Create<StringPackageInfo, CommandLinePipelineFilter>()
                .ConfigureLogging((hostCtx, loggingBuilder) =>
                {
                    loggingBuilder.AddConsole();
                })
                .Build();
            
            
        }

        public void Start()
        {
            host.RunAsync();
        }
    }
}
