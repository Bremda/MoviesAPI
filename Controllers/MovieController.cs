using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly static List<Movie> movies = new();

    [HttpPost]
    public IActionResult AddMovie([FromBody] Movie movie)
    {
       movies.Add(movie);

       return CreatedAtAction(nameof(GetMovie),
                              new { id = movie.Id },
                              movie);
    }

    [HttpGet("{id}")]
    public Movie? GetMovie(int id) => movies.FirstOrDefault(movie => movie.Id == id);

    [HttpGet]
    public IEnumerable<Movie> GetMovies(int skip, int take) => movies.Skip(skip).Take(take);
}