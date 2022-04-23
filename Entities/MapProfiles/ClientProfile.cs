using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Entities.MapProfiles;

public class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<Client, ClientDto>()
            .ReverseMap();
        
        CreateMap<PostClientDto, Client>()
            .ReverseMap();
    }
}