using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Enums;
using Entities.Models;

namespace Entities.MapProfiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, MovieDto>()
            .ReverseMap();
        
        CreateMap<PostMovieDto, Movie>()
            .ForMember(dest => dest.MotionPictureRating, opt => opt.MapFrom(src => Enum.Parse(typeof(MotionPictureRating), src.MotionPictureRating.ToString())))
            .ReverseMap();
    }
}