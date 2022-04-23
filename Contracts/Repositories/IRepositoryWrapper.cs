
namespace Contracts.Repositories;

public interface IRepositoryWrapper
{
    IRentalRepository Rental { get; }
    
    IClientRepository Client { get; }
    
    IMovieRepository Movie { get; }
}