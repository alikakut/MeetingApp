using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace MeetingApp.Api
{
    public static class DependencyContainer
    {
        public static WebApplicationBuilder AddPresentationServices(this WebApplicationBuilder builder)
        {
            ConfigureLogging();
            builder.Host.UseSerilog();

            void ConfigureLogging()
            {
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile(
                        $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                        optional: true)
                    .Build();
            }

            ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string environment)
            {
                return new ElasticsearchSinkOptions(new Uri(configuration["MeetingApp:ElasticSettings:Uri"]))
                {
                    AutoRegisterTemplate = true,
                    IndexFormat = configuration["MeetingApp:ElasticSettings:Uri"],
                    NumberOfShards = 1,
                    NumberOfReplicas = 1,
                    ModifyConnectionSettings = x => x.BasicAuthentication(configuration["MeetingApp:ElasticSettings:Uri"], configuration["MeetingApp:ElasticSettings:Uri"]).ServerCertificateValidationCallback(
                        (o, certificate, arg3, arg4) => { return true; })
                };
            }

            return builder;
        }
    }
}
