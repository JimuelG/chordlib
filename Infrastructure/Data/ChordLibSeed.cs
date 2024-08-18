using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class ChordLibSeed
    {
        public static async Task SeedAsync(ChordContext context)
        {
            if(!context.Users.Any())
            {
                var userData = File.ReadAllText("../Infrastructure/Data/SeedData/users.json");
                var users = JsonSerializer.Deserialize<List<User>>(userData);
                if (users == null) return;
                context.Users.AddRange(users);
            }
            if(!context.Chords.Any())
            {
                var chordData = File.ReadAllText("../Infrastructure/Data/SeedData/chords.json");
                var chords = JsonSerializer.Deserialize<List<Chord>>(chordData);
                if (chords == null) return;
                context.Chords.AddRange(chords);
            }
            if(!context.Lyrics.Any())
            {
                var lyricData = File.ReadAllText("../Infrastructure/Data/SeedData/lyrics.json");
                var lyrics = JsonSerializer.Deserialize<List<Lyric>>(lyricData);
                if (lyrics == null) return;
                context.Lyrics.AddRange(lyrics);
            }
            if(!context.Songs.Any())
            {
                var songData = File.ReadAllText("../Infrastructure/Data/SeedData/songs.json");
                var songs = JsonSerializer.Deserialize<List<Song>>(songData);
                if (songs == null) return;
                context.Songs.AddRange(songs);
            }
            if(!context.LyricChords.Any())
            {
                var lyricChordData = File.ReadAllText("../Infrastructure/Data/SeedData/lyricChords.json");
                var lyricChords = JsonSerializer.Deserialize<List<LyricChord>>(lyricChordData);
                if (lyricChords == null) return;
                context.LyricChords.AddRange(lyricChords);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}