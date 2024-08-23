using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class SongRepository(ChordContext context) : ISongRepository
{
    public void AddSong(Song song)
    {
        context.Songs.Add(song);
    }

    public void DeleteSong(Song song)
    {
        context.Songs.Remove(song);
    }

    public async Task<IReadOnlyList<LyricChord>> GetLyricChordsAsync()
    {
        return await context.LyricChords.ToListAsync();
    }

    public async Task<Song> GetSongByIdAsync(int id)
    {
        return await context.Songs.FindAsync(id);
    }

    public async Task<IReadOnlyList<Song>> GetSongsAync()
    {
        return await context.Songs.ToListAsync();
    }

    public async Task<IReadOnlyList<Lyric>> GetLyricsAsync()
    {
        return await context.Lyrics.ToListAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void UpdateSong(Song song)
    {
        context.Entry(song).State = EntityState.Modified;
    }

}