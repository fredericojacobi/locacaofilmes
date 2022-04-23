using Entities.DataTransferObjects;
using Entities.Models.Generics;

namespace Contracts.Services;

public interface IMovieService
{
    Task<Return<MovieDto>> Get();
    
    Task<Return<MovieDto>> Get(Guid id);
    
    Task<Return<MovieDto>> Post(PostMovieDto postMovieDto);
    
    Task<Return<MovieDto>> Put(MovieDto movieDto);
    
    Task<Return<MovieDto>> Delete(Guid id);
}