using eTickets.Data;
using eTickets.Dto;
using eTickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers;

[Route("test")]
public class TestController : ControllerBase
{
    private readonly AppDbContext _context;
    
    public TestController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("movies")]
    public async Task<IActionResult> Movies()
    {
        var movies =  await _context.Movies.Select(x=>new 
            {
             x.Name,
              x.Description,
             CinemCount= x.Cinema.Movies!.Count,
              ProducerImageUrl= x.Producer.ProfilePictureURL,
              x.Price,
                
            }
            ).OrderBy(x=>x.Name).ToListAsync();
        return Ok(movies);
    }
}