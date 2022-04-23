using Contracts.Repositories;
using Entities.Models;
using Infrastructure;

namespace Repository;

public class ClientRepository : RepositoryBase<Client>, IClientRepository
{
    public ClientRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IList<Client>> ReadAllClientsAsync() => await ReadAllAsync();
    
    public async Task<Client?> ReadClientAsync(Guid id) => await ReadByIdAsync(id);

    public async Task<Client> CreateClientAsync(Client client) => await CreateAsync(client);

    public async Task<Client> UpdateClientAsync(Client client) => await UpdateAsync(client);

    public async Task<bool> DeleteClientAsync(Guid id)
    {
        var client = await ReadClientAsync(id);
        return client is not null && await DeleteAsync(client);
    }
    
    public async Task<bool> ClientExistsAsync(Guid id)
    {
        var client = await ReadClientAsync(id);
        return client is not null;
    }
}