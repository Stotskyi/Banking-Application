using Microsoft.Extensions.Configuration;

namespace BankAccountSimulator.DAL.Infrastructures;

public static  class Configuration
{
    public static IConfiguration BuildConfig()
    {
        IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile(
                $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json",
                optional: true)
            .AddEnvironmentVariables().Build();

        return config;

    }
}