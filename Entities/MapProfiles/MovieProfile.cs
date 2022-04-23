using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Entities.MapProfiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, MovieDto>()
            .ReverseMap();
    }
}