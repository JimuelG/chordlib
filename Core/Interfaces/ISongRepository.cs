using Core.Entities;

namespace Core.Interfaces;

public interface ISongRepository
{
    Task<IReadOnlyList<Song>> GetSongsAync();
    Task<Song> GetSongByIdAsync(int id);
    Task<IReadOnlyList<LyricChord>> GetLyricChordsAsync();
    Task<IReadOnlyList<Lyric>> GetLyricsAsync();
    void AddSong(Song song);
    void UpdateSong(Song song);
    void DeleteSong(Song song);
    Task<bool> SaveChangesAsync();
    
}