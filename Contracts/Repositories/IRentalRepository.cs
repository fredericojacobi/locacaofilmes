using Entities.Models;

namespace Contracts.Repositories;

public interface IRentalRepository : IRepositoryBase<Rental>
{
    Task<IList<Rental>> ReadAllRentalsAsync();

    Task<IList<Rental>> ReadOverdueRentalsAsync();
    
    Task<IList<Guid>> MostRentedMoviesIdLastYearAsync(int top);
    
    Task<IList<Guid>> HighestMoviesRentedClientIdAsync();
    
    Task<IList<Guid>> LessRentedMoviesIdLastWeekAsync(int top);

    Task<int> NumberOfMovieRentals(Guid movieId);
    
    Task<int> NumberOfClientRentals(Guid clientId);
    
    Task<Rental?> ReadRentalAsync(Guid id);
    
    Task<Rental> CreateRentalAsync(Rental rental);

    Task<Rental> UpdateRentalAsync(Rental rental);
    
    Task<bool> DeleteRentalAsync(Guid id);
}