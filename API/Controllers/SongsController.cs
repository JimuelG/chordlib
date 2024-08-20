using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SongsController(ISongRepository repo) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Song>>> GetSongs()
    {
        return Ok(await repo.GetSongsAync());
    }

    [HttpGet("{id:int}")]
    public async Task<Song> GetSong(int id)
    {
        return await repo.GetSongByIdAsync(id);
    }

    // [HttpPost]
    // public async Task<ActionResult<Song>> CreateUser(Song song)
    // {
    //     context.Songs.Add(song);

    //     await context.SaveChangesAsync();

    //     return song;
    // }
}