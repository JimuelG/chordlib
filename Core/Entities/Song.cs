namespace Core.Entities;

public class Song : BaseEntity
{
    public required string Title { get; set; }
    public required string Artist { get; set; }
    public required int LyricId { get; set; }
    public Lyric Lyric { get; set; }
    public required int UserId { get; set; }
    public User User { get; set; }
    public ICollection<LyricChord> LyricChords { get; set; } = [];
}