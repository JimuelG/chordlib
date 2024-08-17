using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class ChordConfiguration : IEntityTypeConfiguration<Chord>
{
    public void Configure(EntityTypeBuilder<Chord> builder)
    {
        builder.HasOne(c => c.User)
            .WithMany(u => u.Chords)
            .HasForeignKey(c => c.UserId);

        builder.HasOne(c => c.Lyric)
            .WithMany(u => u.Chords)
            .HasForeignKey(c => c.LyricId);
    }
}
