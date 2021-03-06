using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Entities.MapProfiles;

public class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<Client, ClientDto>()
            .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => src.Birthday.ToString("dd/MM/yyyy")))
            .ReverseMap();
        
        CreateMap<PostClientDto, Client>()
            .ForMember(dest => dest.Birthday, opt => opt.MapFrom(src => DateTime.Parse(src.Birthday)))
            .ReverseMap();
        
        CreateMap<Rental, OverdueClientDto>()
            .ForMember(dest => dest.ReturnDate, opt => opt.MapFrom(src => src.ReturnDate.ToString("dd/MM/yyyy")))
            .AfterMap((src, dest) =>
            {
                dest.Client.Id = src.ClientId;
                dest.Client.Name = src.Client.Name;
                dest.Client.Cpf = src.Client.Cpf;
                dest.Client.Birthday = src.Client.Birthday.ToString("dd/MM/yyyy");
                dest.Movie.Id = src.MovieId;
                dest.Movie.Title = src.Movie.Title;
                dest.Movie.Release = src.Movie.Release;
                dest.Movie.MotionPictureRating = src.Movie.MotionPictureRating;
            })
            .ReverseMap();
    }
}