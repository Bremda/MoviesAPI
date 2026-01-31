using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.DTOs
{
    public class CreateMovieDto
    {
        [Required(ErrorMessage = "The movie title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "The movie genre is required")]
        [StringLength(50, ErrorMessage = "The genre length must not exceed 50 characters")]
        public string Genre { get; set; } = string.Empty;

        [Required]
        [Range(70, 600, ErrorMessage = "The duration must be between 70 and 600 minutes")]
        public int Duration { get; set; }
    }
}