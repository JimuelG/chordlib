using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SongsController(ChordContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<Song>> GetSongs()
    {
        return Ok(await context.Songs.ToListAsync());
    }
}