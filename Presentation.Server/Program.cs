using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace UnderTheBrand.Presentation.Server
{
    public class Program
    {
        private const string AppSettingsJson = "appsettings.json";

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging((context, logging) => { logging.AddFile(); })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls(GetUrls());
                    webBuilder.UseStartup<Startup>();
                });
        }

        private static string GetUrls()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(AppSettingsJson, false, true)
                .Build();
            return configuration.GetValue<string>("launchSettings:componentBaseUrl");
        }
    }
}
