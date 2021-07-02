using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebJobsTemplate
{
    //https://dotnetcoretutorials.com/2018/10/09/azure-webjobs-in-net-core-part-1/
    class Program
    {
        static async Task Main()
        {
            var builder = new HostBuilder();
          
            builder.ConfigureWebJobs((configurationBuilder, b) =>
            {
                b.AddAzureStorageCoreServices();                
                b.AddAzureStorage();
                //Trabalhar com service bus
                b.AddServiceBus(sbOptions =>
                {
                    sbOptions.ConnectionString = configurationBuilder.Configuration["ConnectionStrings:AzureWebJobsServiceBus"];
                    sbOptions.MessageHandlerOptions.AutoComplete = false;
                    sbOptions.MessageHandlerOptions.MaxConcurrentCalls = int.Parse(configurationBuilder.Configuration["MaxConcurrentCalls"]);
                });
            });

            builder.ConfigureLogging((context, b) =>
            {
                b.AddConsole();
                string instrumentationKey = context.Configuration["APPINSIGHTS_INSTRUMENTATIONKEY"];
                if (!string.IsNullOrEmpty(instrumentationKey))
                {
                    b.AddApplicationInsightsWebJobs(o => o.InstrumentationKey = instrumentationKey);
                }
            });

            var host = builder.Build();
            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}
