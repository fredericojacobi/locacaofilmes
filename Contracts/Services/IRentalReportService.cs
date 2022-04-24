using Entities.DataTransferObjects;
using Entities.Models.Generics;

namespace Contracts.Services;

public interface IRentalReportService
{
    Task<Return<OverdueClientDto>> OverdueClientsAsync();
    
    Task<Return<MovieDto>> NeverRentedMoviesAsync();

    Task<Return<RentedMoviesDto>> MostRentedMoviesLastYearAsync(int top);

    Task<Return<RentedMoviesDto>> LessRentedMoviesLastWeekAsync(int top);

    Task<Return<ClientRentalDto>> HighestMoviesRentedClientAsync(int position);

}