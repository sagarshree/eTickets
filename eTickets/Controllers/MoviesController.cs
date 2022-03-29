using eTickets.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Controllers;

public class MoviesController : Controller
{
    // GET
    private readonly AppDbContext _context;

    public MoviesController(AppDbContext context)
    {
        _context = context;
    }
   
    public async Task<ActionResult> Index()
    {
        var movies = await _context.Movies.Include(n=>n.Cinema).OrderBy(m=>m.Name).ToListAsync();
        return View(movies);
    }
}