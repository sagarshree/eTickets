using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services;

public class MoviesService:EntityBaseRepository<Movie>,IMoviesService
{

    private readonly AppDbContext _dbContext;
    public MoviesService(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Movie?> GetMovieById(int id)
    {
        var movie = _dbContext.Movies.
            Include(m=>m.Cinema).
            Include(m=>m.Producer)
            .Include(m=>m.Actors_Movies)!
            .ThenInclude(a=>a.Actor)
            .SingleOrDefaultAsync(m => m.Id == id);
        return movie;
    }
}