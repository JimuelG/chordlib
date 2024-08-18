using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChordsController(IChordRepository repo) : ControllerBase
{
    
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Chord>>> GetChords()
    {

        return Ok(await repo.GetChordsAsync());
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<Chord>> GetChords(int id)
    {
        var chords = await repo.GetChordByIdAsync(id);

        if(chords == null) return NotFound();

        return chords;
    }

    // [HttpPost]
    // public async Task<ActionResult<Lyric>> CreateLyricWithChords(Lyric lyric, List<LyricChord> lyricChords)
    // {
    //     context.Lyrics.Add(lyric);

    //     foreach (var lyricChord in lyricChords)
    //     {
    //         context.LyricChords.Add(lyricChord);
    //     }
    //     await context.SaveChangesAsync();

    //     return lyric;
    // }
}