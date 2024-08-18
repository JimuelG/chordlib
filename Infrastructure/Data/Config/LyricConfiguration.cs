using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class LyricsConfiguration : IEntityTypeConfiguration<Lyric>
{
    public void Configure(EntityTypeBuilder<Lyric> builder)
    {
        builder.HasMany(c => c.Songs)
            .WithOne(u => u.Lyric)
            .HasForeignKey(c => c.LyricId);
    }
}
