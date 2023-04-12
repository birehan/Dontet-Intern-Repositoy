using Microsoft.AspNetCore.Mvc;
using CrudWithDotNet.Models;
using CrudWithDotNet.Data;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace CrudWithDotNet.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamsController : ControllerBase
{
    private static ApiDbContext _context;
    public TeamsController(ApiDbContext context){
        _context = context;
    }

    
    [HttpGet]
    public async Task<IActionResult> Get(){
        var teams  = await  _context.Teams.ToListAsync();
        return Ok(teams);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id){
        var team = await _context.Teams.FirstOrDefaultAsync(team => team.Id == id);
        if(team == null){
            return BadRequest("Invalid id");
        }
        return Ok(team);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Team team){
       await _context.Teams.AddAsync(team);
       await _context.SaveChangesAsync();
        return CreatedAtAction("Get", team.Id, team);
    }

     [HttpPatch]
    public async Task<IActionResult> Patch(int id, string country){
        var team = await _context.Teams.FirstOrDefaultAsync(team => team.Id == id);
         if(team == null){
            return BadRequest("Invalid id");
        }
        team.Country = country;
         await _context.SaveChangesAsync();

        return NoContent();
    }


     [HttpDelete]
    public async Task<IActionResult> Delete(int id){
        var team = await _context.Teams.FirstOrDefaultAsync(team => team.Id == id);
         if(team == null){
            return BadRequest("Invalid id");
        }
         _context.Teams.Remove(team);
         await _context.SaveChangesAsync();
        return NoContent();
    }

}