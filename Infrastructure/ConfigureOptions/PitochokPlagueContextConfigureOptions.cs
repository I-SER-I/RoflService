using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PitochokPlague.Infrastructure.Settings;

namespace PitochokPlague.Infrastructure.ConfigureOptions;

public sealed class PitochokPlagueContextConfigureOptions : IConfigureNamedOptions<DbContextOptionsBuilder>
{
    private readonly InfrastructureSettings _infrastructureSettings;

    public PitochokPlagueContextConfigureOptions(IOptions<InfrastructureSettings> options)
    {
        _infrastructureSettings = options.Value;
    }

    public void Configure(DbContextOptionsBuilder options) =>
        Configure(nameof(PitochokPlagueContextConfigureOptions), options);

    public void Configure(string? name, DbContextOptionsBuilder options) =>
        options.UseNpgsql(_infrastructureSettings.ConnectionStrings);
}