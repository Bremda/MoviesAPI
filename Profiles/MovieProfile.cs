using AutoMapper;
using MoviesAPI.DTOs;
using MoviesAPI.Models;

namespace MoviesAPI.Mappings
{
    public class MovieProfile : Profile
    {
        public MovieProfile() => CreateMap<CreateMovieDto, Movie>();
    }
}
