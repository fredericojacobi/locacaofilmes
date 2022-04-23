using System.Net;
using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.Models.Generics;

namespace Services;

public class RentalReportService : IRentalReportService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public RentalReportService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Return<ClientDto>> OverdueClients()
    {
        var returnObj = new Return<ClientDto>();

        try
        {
            var overdueRentals = await _repository.Rental.ReadOverdueRentalsAsync();
            var overdueClients = overdueRentals.Select(x => x.Client);
            returnObj.Records.AddRange(_mapper.Map<List<ClientDto>>(overdueClients));
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }
        
        returnObj.SetMessage();
        return returnObj;
    }

    public Task<Return<MovieDto>> NeverRentedMovies()
    {
        throw new NotImplementedException();
    }

    public Task<Return<MovieDto>> MostRentedMoviesLastYear(int listSize)
    {
        throw new NotImplementedException();
    }

    public Task<Return<MovieDto>> LessRentedMoviesLastWeek(int listSize)
    {
        throw new NotImplementedException();
    }

    public Task<Return<ClientDto>> HighestMoviesRentedClient(int position)
    {
        throw new NotImplementedException();
    }
}