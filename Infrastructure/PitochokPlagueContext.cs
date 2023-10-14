using Microsoft.EntityFrameworkCore;
using PitochokPlague.Infrastructure.Patients;

namespace PitochokPlague.Infrastructure;

public sealed class PitochokPlagueContext : DbContext
{
    public PitochokPlagueContext(DbContextOptions<PitochokPlagueContext> options) : base(options)
    {
    }

    public DbSet<PatientModel> Patients { get; set; }
    public DbSet<ResistantModel> Resistants { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSnakeCaseNamingConvention();

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PitochokPlagueContext).Assembly);
}