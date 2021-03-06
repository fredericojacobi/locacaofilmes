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
    
    public async Task<Movie?> ReadMovieByIdAsync(Guid id) => await ReadByIdAsync(id);

    public async Task<IList<Movie>> ReadMovieByTitleAsync(string title) => await ReadByConditionAsync(x => x.Title.Contains(title));

    public async Task<IList<Movie>> ReadMoviesNotInIdsAsync(List<Guid> ids) => await ReadByConditionAsync(x => !ids.Contains(x.Id));

    public async Task<Movie> CreateMovieAsync(Movie movie) => await CreateAsync(movie);

    public async Task<Movie> UpdateMovieAsync(Movie movie) => await UpdateAsync(movie);

    public async Task<bool> DeleteMovieAsync(Guid id)
    {
        var movie = await ReadMovieByIdAsync(id);
        return movie is not null && await DeleteAsync(movie);
    }
}