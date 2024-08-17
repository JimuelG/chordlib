using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChordsController : ControllerBase
{
    private readonly ChordContext context;

    public ChordsController(ChordContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Chord>>> GetChords()
    {

        return await context.Chords.ToListAsync();;
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<Chord>> GetChords(int id)
    {
        var chords = await context.Chords.FindAsync(id);

        if(chords == null) return NotFound();

        return chords;
    }

    [HttpPost]
    public async Task<ActionResult<Lyric>> CreateLyricWithChords(Lyric lyric, List<LyricChord> lyricChords)
    {
        context.Lyrics.Add(lyric);

        foreach (var lyricChord in lyricChords)
        {
            context.LyricChords.Add(lyricChord);
        }
        await context.SaveChangesAsync();

        return lyric;
    }
}