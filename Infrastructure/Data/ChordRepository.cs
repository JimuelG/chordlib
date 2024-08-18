using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ChordRepository(ChordContext context) : IChordRepository
{

    public void AddChord(Chord chord)
    {
        context.Chords.Add(chord);
    }

    public void DeleteChord(Chord chord)
    {
        context.Chords.Remove(chord);
    }

    public async Task<Chord?> GetChordByIdAsync(int id)
    {
        return await context.Chords.FindAsync(id);
    }

    public async Task<IReadOnlyList<Chord>> GetChordsAsync()
    {
        return await context.Chords.ToListAsync();
    }

    public bool ChordExists(int id)
    {
        return context.Chords.Any(x => x.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void UpdateChord(Chord chord)
    {
        context.Entry(chord).State = EntityState.Modified;
    }
}