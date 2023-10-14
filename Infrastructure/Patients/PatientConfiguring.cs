using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PitochokPlague.Infrastructure.Patients;

internal sealed class PatientConfiguring : IEntityTypeConfiguration<PatientModel>
{
    public void Configure(EntityTypeBuilder<PatientModel> builder)
    {
        builder.HasKey(entity => entity.Isu);
        builder.HasIndex(entity => entity.Isu);
    }
}