using PitochokPlague.Infrastructure.Settings;

namespace PitochokPlague.Extensions;

public static class ConfigurationExtensions
{
    public static WebApplicationBuilder ConfigureStaticSettings(this WebApplicationBuilder builder)
    {
        var configurationManager = builder.Configuration;
        
        builder.Services.Configure<InfrastructureSettings>(configurationManager.GetSection("InfrastructureSettings"));

        return builder;
    }
}