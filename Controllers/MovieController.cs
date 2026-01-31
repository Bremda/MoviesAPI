using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Models;
using MoviesAPI.DTOs;
using AutoMapper;

namespace MoviesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public MovieController(AppDbContext context, IMapper mapper)
    {
        _context = context;
         _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddMovie([FromBody] CreateMovieDto movieDto)
    {
         if (movieDto == null)
            return BadRequest();

        var movie = _mapper.Map<Movie>(movieDto);
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMovie),
                               new { id = movie.Id });
    }
[HttpGet("{id}")]
public async Task<ActionResult<ReadMovieDto>> GetMovie(int id)
{
    var movie = await _context.Movies.FindAsync(id);
    if (movie == null)
        return NotFound();

    var movieDto = _mapper.Map<ReadMovieDto>(movie);
    return Ok(movieDto);
}

[HttpGet]
public async Task<ActionResult<IEnumerable<ReadMovieDto>>> GetMovies([FromQuery] int skip = 0, [FromQuery] int take = 10)
{
    var movies = await _context.Movies
                               .Skip(skip)
                               .Take(take)
                               .ToListAsync();

    var movieDtos = _mapper.Map<IEnumerable<ReadMovieDto>>(movies);
    return Ok(movieDtos);
}


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
    {
        if (movieDto == null)
            return BadRequest();

        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
            return NotFound();

        _mapper.Map(movieDto, movie);

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchMovie(int id, [FromBody] JsonPatchDocument<UpdateMovieDto> patchDoc)
    {
        if (patchDoc == null)
            return BadRequest();

        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
            return NotFound();

        var movieDto = _mapper.Map<UpdateMovieDto>(movie);
        patchDoc.ApplyTo(movieDto, ModelState);

        if (!TryValidateModel(movieDto))
            return ValidationProblem(ModelState);

        _mapper.Map(movieDto, movie);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie == null)
            return NotFound();

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}