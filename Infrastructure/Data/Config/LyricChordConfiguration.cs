using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class LyricChordConfiguration : IEntityTypeConfiguration<LyricChord>
{
    public void Configure(EntityTypeBuilder<LyricChord> builder)
    {
        builder.HasOne(lc => lc.Chord)
           .WithMany(c => c.LyricChords)
           .HasForeignKey(lc => lc.ChordId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(lc => lc.Song)
           .WithMany(s => s.LyricChords)
           .HasForeignKey(lc => lc.SongId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.HasKey(lc => new { lc.SongId, lc.ChordId, lc.CharacterIndex });
    }
}
