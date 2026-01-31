using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.DTOs
{
    public class UpdateMovieDto
    {
        [StringLength(50, ErrorMessage = "The genre length must not exceed 50 characters")]
        public string? Genre { get; init; }

        [Range(70, 600, ErrorMessage = "The duration must be between 70 and 600 minutes")]
        public int? Duration { get; init; }
    }
}