namespace Contracts.Services;

public interface IServiceWrapper
{
    IRentalReportService RentalReport { get; }
    
    IClientService Client { get; }
    
    IMovieService Movie { get; }
    
    IRentalService Rental { get; }
}