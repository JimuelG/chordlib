using System.Reflection;
using Core.Entities;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ChordContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Lyric> Lyrics { get; set; }
    public DbSet<Chord> Chords { get; set; }
    public DbSet<LyricChord> LyricChords { get; set; }
    public DbSet<Song> Songs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChordConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LyricConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LyricChordConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SongConfiguration).Assembly);
    }
}