using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.HasOne(s => s.Lyric)
                .WithMany(l => l.Songs)
                .HasForeignKey(s => s.LyricId);

        builder.HasMany(s => s.LyricChords)
            .WithOne(lc => lc.Song)
            .HasForeignKey(lc => lc.SongId);
    }
}
