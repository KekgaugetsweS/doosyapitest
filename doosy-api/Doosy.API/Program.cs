using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System;
using System.IO;

namespace Doosy.API
{
    public class Program
    {
        //public static IConfiguration configuration { get; } = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //    .AddEnvironmentVariables()
        //    .Build();
        public static void Main(string[] args)
        {
            ConfigureSerilogwithElasticSearch();
            CreateHostBuilder(args).Build().Run();
        }

        private static void ConfigureSerilogwithElasticSearch()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()

                .WriteTo.Debug()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"])) {
                    AutoRegisterTemplate = true,
                    NumberOfReplicas = 0,
                    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                    ModifyConnectionSettings = x => x.BasicAuthentication("elastic", "GXjNWYgJnOooPrj5MN4yAGpb"),
                    IndexFormat = $"doosyserverlog1_{DateTime.Now:yyyy.MM.dd}"
                })
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder
                    .UseSerilog()
                    .UseStartup<Startup>();
                });
    }
}
