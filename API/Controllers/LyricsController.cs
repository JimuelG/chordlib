using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LyricsController(ChordContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IReadOnlyList<Lyric>> GetLyrics()
    {
        return await context.Lyrics.ToListAsync();
    }
}