using Contracts.Repositories;
using Entities.Models;
using Infrastructure;

namespace Repository;

public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
{
    public MovieRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IList<Movie>> ReadAllMoviesAsync() => await ReadAllAsync();
    
    public async Task<Movie?> ReadMovieAsync(Guid id) => await ReadByIdAsync(id);

    public async Task<Movie> CreateMovieAsync(Movie movie) => await CreateAsync(movie);

    public async Task<Movie> UpdateMovieAsync(Movie movie) => await UpdateAsync(movie);

    public async Task<bool> DeleteMovieAsync(Guid id)
    {
        var movie = await ReadMovieAsync(id);
        return movie is not null && await DeleteAsync(movie);
    }
}