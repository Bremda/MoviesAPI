using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly static List<Movie> movies = new();

    [HttpPost]
    public void AddMovie([FromBody] Movie movie)
    {
       movies.Add(movie);

       Console.WriteLine($"Movie added: {movie.Title}");
       Console.WriteLine($"Duration: {movie.Duration}");
    }
}