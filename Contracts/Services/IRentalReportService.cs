using Entities.DataTransferObjects;
using Entities.Models.Generics;

namespace Contracts.Services;

public interface IRentalReportService
{
    Task<Return<ClientDto>> OverdueClients();
    
    Task<Return<MovieDto>> NeverRentedMovies();

    Task<Return<MovieDto>> MostRentedMoviesLastYear(int listSize);

    Task<Return<MovieDto>> LessRentedMoviesLastWeek(int listSize);

    Task<Return<ClientDto>> HighestMoviesRentedClient(int position);

}