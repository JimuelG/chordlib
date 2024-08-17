namespace Core.Entities;

public class Lyric : BaseEntity
{
    public required string Content { get; set; }

    public ICollection<Chord> Chords { get; set; } = [];
}