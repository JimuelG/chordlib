using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ChordContext context;

    public UsersController(ChordContext context)
    {
        this.context = context;
    }


    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        context.Users.Add(user);

        await context.SaveChangesAsync();

        return user;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await context.Users.ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await context.Users.FindAsync(id);

        return Ok(user);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateUser(int id, User user)
    {
        if (user.Id != id || !UserExists(id))
            return BadRequest("Cannot update this User");
        
        context.Entry(user).State = EntityState.Modified;

        await context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        var user = await context.Users.FindAsync(id);

        if (user == null) return NotFound();

        context.Users.Remove(user);

        await context.SaveChangesAsync();

        return NoContent();
    }


    private bool UserExists(int id)
    {
        return context.Users.Any(x => x.Id == id);
    }
}