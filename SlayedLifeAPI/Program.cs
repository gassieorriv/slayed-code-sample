using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SlayedLifeAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).ConfigureLogging(logging => 
                {
                    logging.ClearProviders();
                    logging.AddApplicationInsights();
                })
                  .ConfigureServices(service => service.AddAutofac())
                  .UseStartup<Startup>();
    }
}
