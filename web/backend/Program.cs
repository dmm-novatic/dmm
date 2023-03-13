using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using A2F;
using Novatic.Repository;
using Novatic.Util;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Novatic
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build();

            // Create a new scope
            using (var scope = webHost.Services.CreateScope())
            {
                // Get the DbContext instance
                var systemConfigRepository = scope.ServiceProvider.GetRequiredService<ISystemConfigRepository>();
                var cacheHelper = scope.ServiceProvider.GetRequiredService<ICacheHelper>();

                //Do the migration asynchronously
                var systemConfigs = await systemConfigRepository.List();
                cacheHelper.SetSystemConfig(systemConfigs);
            }

            // Run the WebHost, and start accepting requests
            // There's an async overload, so we may as well use it
            JobScheduler.Start();
            await webHost.RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var basePath = $"{currentDirectory}\\ConfigurationFiles";
            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                //.UseIISIntegration()
                .UseStartup<Startup>();
        }
    }
}
