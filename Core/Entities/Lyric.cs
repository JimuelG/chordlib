namespace Core.Entities;

public class Lyric : BaseEntity
{
    public required string Content { get; set; }

    public ICollection<LyricChord> LyricChords { get; set; } = [];
}