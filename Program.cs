using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnet_api_backend_skeleton.Logic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace dotnet_api_backend_skeleton
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // MQTTMessageLogic.TestMQTTConnectionWithPublicBroker();
            // This starts the Kestrel Server
            BuildWebHost(args).Run();
            // Environment.Exit(0);
        }


        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*:5050")
                .Build();
    }
}
