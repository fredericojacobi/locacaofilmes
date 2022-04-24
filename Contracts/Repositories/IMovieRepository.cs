using Entities.Models;

namespace Contracts.Repositories;

public interface IMovieRepository : IRepositoryBase<Movie>
{
    Task<IList<Movie>> ReadAllMoviesAsync();
    
    Task<Movie?> ReadMovieAsync(Guid id);
    
    Task<IList<Movie>> ReadMoviesNotInIdsAsync(List<Guid> ids);
    
    Task<Movie> CreateMovieAsync(Movie movie);
    
    Task<Movie> UpdateMovieAsync(Movie movie);
    
    Task<bool> DeleteMovieAsync(Guid id);
}