using eTickets.Data;
using eTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers;

public class MoviesController : Controller
{
    // GET
    private readonly IMoviesService _service;

    public MoviesController(IMoviesService service)
    {
        _service = service;
    }
   
    public async Task<ActionResult> Index()
    {
        var movies = await _service.GetAllAsync(m=>m.Cinema);
        return View(movies);
    }
    
    public async Task<ActionResult> Details(int id)
    {
        var movie = await _service.GetMovieById(id);
        return View(movie);
    }
}