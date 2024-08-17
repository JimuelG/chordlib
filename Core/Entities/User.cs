namespace Core.Entities;

public class User : BaseEntity
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }

    public ICollection<Chord> Chords { get; set; } = [];
}