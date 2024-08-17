using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class LyricChordConfiguration : IEntityTypeConfiguration<LyricChord>
{
    public void Configure(EntityTypeBuilder<LyricChord> builder)
    {
        builder.HasKey(lc => new { lc.LyricId, lc.ChordId, lc.Position });

        builder.HasOne(lc => lc.Lyric)
            .WithMany(l => l.LyricChords)
            .HasForeignKey(lc => lc.LyricId);

        builder.HasOne(lc => lc.Chord)
            .WithMany(c => c.LyricChords)
            .HasForeignKey(lc => lc.ChordId);
    }
}
