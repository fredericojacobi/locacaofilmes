using Entities.Models;

namespace Contracts.Repositories;

public interface IRentalRepository : IRepositoryBase<Rental>
{
    Task<IList<Rental>> ReadAllRentalsAsync();

    Task<IList<Rental>> ReadOverdueRentalsAsync();

    Task<Rental?> ReadRentalAsync(Guid id);
    
    Task<Rental> CreateRentalAsync(Rental rental);

    Task<Rental> UpdateRentalAsync(Rental rental);
    
    Task<bool> DeleteRentalAsync(Guid id);
}