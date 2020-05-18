using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace UnderTheBrand.Presentation.Web.Server
{
    public class Program
    {
        private const string appSettingsJson = "appsettings.json";

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging((context, logging) => { logging.AddFile(); })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls(GetUrls());
                    webBuilder.UseStartup<Startup>();
                });

        private static string GetUrls()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .AddJsonFile(appSettingsJson, false, true)
                .Build();
            return configuration.GetValue<string>("launchSettings:componentBaseUrl");
        }
    }
}