using Core.Entities;

namespace Core.Interfaces;

public interface IChordRepository
{
    Task<IReadOnlyList<Chord>> GetChordsAsync();
    Task<Chord> GetChordByIdAsync(int id);

    void AddChord(Chord chord);
    void UpdateChord(Chord chord);
    void DeleteChord(Chord chord);

    bool ChordExists(int id);
    Task<bool> SaveChangesAsync();
}