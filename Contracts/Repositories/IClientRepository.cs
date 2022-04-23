using Entities.Models;

namespace Contracts.Repositories;

public interface IClientRepository : IRepositoryBase<Client>
{
    Task<IList<Client>> ReadAllClientsAsync();
    
    Task<Client?> ReadClientAsync(Guid id);
    
    Task<Client> CreateClientAsync(Client client);

    Task<Client> UpdateClientAsync(Client client);
    
    Task<bool> DeleteClientAsync(Guid id);
    
    Task<bool> ClientExistsAsync(Guid id);
}