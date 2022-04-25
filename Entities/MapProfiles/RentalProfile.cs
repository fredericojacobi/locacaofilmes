using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Entities.MapProfiles;

public class RentalProfile : Profile
{
    public RentalProfile()
    {
        CreateMap<PostRentalDto, Rental>()
            .ForMember(dest => dest.RentDate, opt => opt.MapFrom(src => DateTime.Parse(src.RentDate)))
            .ReverseMap();
        
        CreateMap<Rental, RentalDto>()
            .ForMember(dest => dest.RentDate, opt => opt.MapFrom(src => src.RentDate.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.ReturnDate, opt => opt.MapFrom(src => src.ReturnDate.ToString("dd/MM/yyyy")))
            .ReverseMap();
        CreateMap<Rental, NewRentalDto>()
            .ForMember(dest => dest.RentDate, opt => opt.MapFrom(src => src.RentDate.ToString("dd/MM/yyyy")))
            .ForMember(dest => dest.ReturnDate, opt => opt.MapFrom(src => src.ReturnDate.ToString("dd/MM/yyyy")))
            .ReverseMap();
    }
}