using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Entities.MapProfiles;

public class RentalProfile : Profile
{
    public RentalProfile()
    {
        CreateMap<PostRentalDto, Rental>()
            .ReverseMap();
        
        CreateMap<Rental, RentalDto>()
            .ReverseMap();
    }
}