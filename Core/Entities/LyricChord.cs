namespace Core.Entities;

public class LyricChord
{
    public required int SongId { get; set; }
    public Song Song { get; set; }
    public required int ChordId { get; set; }
    public Chord Chord { get; set; }

    public required int CharacterIndex { get; set; }
}