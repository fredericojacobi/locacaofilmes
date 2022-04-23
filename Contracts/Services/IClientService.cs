using Entities.DataTransferObjects;
using Entities.Models.Generics;

namespace Contracts.Services;

public interface IClientService
{
    Task<Return<ClientDto>> Get();
    
    Task<Return<ClientDto>> Get(Guid id);
    
    Task<Return<ClientDto>> Post(PostClientDto postClientDto);
    
    Task<Return<ClientDto>> Put(ClientDto clientDto);
    
    Task<Return<ClientDto>> Delete(Guid id);
}