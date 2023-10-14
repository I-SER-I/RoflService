using Microsoft.EntityFrameworkCore;
using PitochokPlague.Infrastructure.ConfigureOptions;
using PitochokPlague.Infrastructure.Patients;
using PitochokPlague.Infrastructure.Settings;

namespace PitochokPlague.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, InfrastructureSettings? settings)
    {
        services
            .ConfigureOptions<PitochokPlagueContextConfigureOptions>()
            .AddDbContext<PitochokPlagueContext>(builder => builder.UseNpgsql(settings.ConnectionStrings));

        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
}