using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly AppDbContext _context;

    public MovieController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddMovie([FromBody] Movie movie)
    {
        if (movie == null)
            return BadRequest();

        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMovie),
                               new { id = movie.Id },
                               movie);
    }

    // GET: /Movie/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id);

        if (movie == null)
            return NotFound();

        return movie;
    }

    [HttpGet]
    public async Task<IEnumerable<Movie>> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return await _context.Movies
                             .Skip(skip)
                             .Take(take)
                             .ToListAsync();
    }
}
