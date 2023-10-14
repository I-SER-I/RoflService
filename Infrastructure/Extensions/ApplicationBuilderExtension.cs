using Microsoft.EntityFrameworkCore;

namespace PitochokPlague.Infrastructure.Extensions;

public static class ApplicationBuilderExtension
{
    public static async Task ApplyMigrationsAsync(this IApplicationBuilder builder)
    {
        using var scope = builder.ApplicationServices.CreateScope();

        var pitochokPlagueContext = scope.ServiceProvider.GetRequiredService<PitochokPlagueContext>();
        await pitochokPlagueContext.Database.MigrateAsync();
    }
}