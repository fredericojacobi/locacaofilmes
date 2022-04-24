using Entities.DataTransferObjects;
using Entities.Models.Generics;

namespace Contracts.Services;

public interface IMovieService
{
    Task<Return<MovieDto>> GetAsync();
    
    Task<Return<MovieDto>> GetAsync(Guid id);
    
    Task<Return<MovieDto>> PostAsync(PostMovieDto postMovieDto);
    
    Task<Return<MovieDto>> PutAsync(MovieDto movieDto);
    
    Task<Return<MovieDto>> DeleteAsync(Guid id);
}