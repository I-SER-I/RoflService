using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql;

namespace PitochokPlague.Infrastructure;

[UsedImplicitly]
public sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PitochokPlagueContext>
{
    public PitochokPlagueContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<PitochokPlagueContext>()
            .UseNpgsql(new NpgsqlConnection())
            .Options;
        return new PitochokPlagueContext(options);
    }
}