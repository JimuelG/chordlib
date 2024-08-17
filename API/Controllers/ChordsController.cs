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
    public async Task<ActionResult<Chord>> CreateChords(Chord chord)
    {
        context.Chords.Add(chord);

        await context.SaveChangesAsync();

        return chord;
    }
}