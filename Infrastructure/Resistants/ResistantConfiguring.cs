using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PitochokPlague.Infrastructure.Patients;

namespace PitochokPlague.Infrastructure.Resistants;

internal sealed class ResistantConfiguring : IEntityTypeConfiguration<ResistantModel>
{
    public void Configure(EntityTypeBuilder<ResistantModel> builder)
    {
        builder.HasKey(entity => entity.Isu);
        builder.HasIndex(entity => entity.Isu);
    }
}