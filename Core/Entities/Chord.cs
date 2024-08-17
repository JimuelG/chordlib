namespace Core.Entities;

public class Chord : BaseEntity
{
    public required string Name { get; set; }
    public required string Diagram { get; set; }
    public required string AudioUrl { get; set; }
    public required string Key { get; set; }

    public required int UserId { get; set; }
    public required User User { get; set; }

    public required int LyricId { get; set; }
    public required Lyric Lyric { get; set; }
    
}