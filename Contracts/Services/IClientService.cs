using Entities.DataTransferObjects;
using Entities.Models.Generics;

namespace Contracts.Services;

public interface IClientService
{
    Task<Return<ClientDto>> GetAsync();
    
    Task<Return<ClientDto>> GetAsync(Guid id);
    
    Task<Return<ClientDto>> PostAsync(PostClientDto postClientDto);
    
    Task<Return<ClientDto>> PutAsync(ClientDto clientDto);
    
    Task<Return<ClientDto>> DeleteAsync(Guid id);
}