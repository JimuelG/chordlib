namespace Core.Entities;

public class LyricChord : BaseEntity
{
    public required int LyricId { get; set; }
    public required Lyric Lyric { get; set; }
    public required int ChordId { get; set; }
    public required Chord Chord { get; set; }

    public required int Position { get; set; }
}