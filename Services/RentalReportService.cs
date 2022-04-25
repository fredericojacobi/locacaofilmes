using System.Net;
using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities.Constants;
using Entities.DataTransferObjects;
using Entities.MapProfiles;
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

    public async Task<Return<OverdueClientDto>> OverdueClientsAsync()
    {
        var returnObj = new Return<OverdueClientDto>();

        try
        {
            var overdueRentals = await _repository.Rental.ReadOverdueRentalsAsync();

            returnObj.Records.AddRange(_mapper.Map<List<OverdueClientDto>>(overdueRentals));
            if (!returnObj.Records.Any())
            {
                returnObj.SetMessage(Message.NO_OVERDUE_CLIENTS, true, HttpStatusCode.OK);
                return returnObj;
            }

            returnObj.SetMessage();
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }

        return returnObj;
    }

    public async Task<Return<MovieDto>> NeverRentedMoviesAsync()
    {
        var returnObj = new Return<MovieDto>();

        try
        {
            var overdueRentals = await _repository.Rental.ReadAllRentalsAsync();
            var neverRentedMovies = await _repository.Movie.ReadMoviesNotInIdsAsync(overdueRentals.Select(x => x.MovieId).ToList());
            returnObj.Records.AddRange(_mapper.Map<List<MovieDto>>(neverRentedMovies));
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }

        returnObj.SetMessage();
        return returnObj;
    }

    public async Task<Return<RentedMoviesDto>> MostRentedMoviesLastYearAsync(int top)
    {
        var returnObj = new Return<RentedMoviesDto>();

        try
        {
            var mostRentedMoviesIdLastYear = await _repository.Rental.MostRentedMoviesIdLastYearAsync(top);
            var rentedMoviesDto = await SetRentedMoviesDtoAsync(mostRentedMoviesIdLastYear);
            returnObj.Records.AddRange(rentedMoviesDto);
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }

        if (!returnObj.Records.Any())
            returnObj.SetMessage("Não há filmes alugados.", true, HttpStatusCode.OK);
            
        returnObj.SetMessage();
        return returnObj;
    }

    public async Task<Return<RentedMoviesDto>> LessRentedMoviesLastWeekAsync(int top)
    {
        var returnObj = new Return<RentedMoviesDto>();

        try
        {
            var lessRentedMoviesLastWeek = await _repository.Rental.LessRentedMoviesIdLastWeekAsync(top);
            var rentedMoviesDto = await SetRentedMoviesDtoAsync(lessRentedMoviesLastWeek);
            returnObj.Records.AddRange(rentedMoviesDto);
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }

        if (!returnObj.Records.Any())
            returnObj.SetMessage("Não há filmes alugados.", true, HttpStatusCode.OK);

        returnObj.SetMessage();
        return returnObj;
    }

    public async Task<Return<ClientRentalDto>> HighestMoviesRentedClientAsync(int position)
    {
        var returnObj = new Return<ClientRentalDto>();

        try
        {
            var highestMoviesRentedClientId = await _repository.Rental.HighestMoviesRentedClientIdAsync();
            
            if (position - 1 >= highestMoviesRentedClientId.Count)
                returnObj.SetMessage("Não há cliente nesta posição.", true, HttpStatusCode.OK);
            else
            {
                var clientPositionAt = highestMoviesRentedClientId.ElementAt(position - 1);
                var numberOfRentals = await _repository.Rental.NumberOfClientRentals(clientPositionAt);
                var client = await _repository.Client.ReadClientAsync(clientPositionAt);
                returnObj.Records.Add(
                    new ClientRentalDto(
                        numberOfRentals,
                        _mapper.Map<ClientDto>(client)
                    )
                );
            }
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }
        
        returnObj.SetMessage();
        return returnObj;
    }

    private async Task<IList<RentedMoviesDto>> SetRentedMoviesDtoAsync(IList<Guid> lessRentedMoviesLastWeek)
    {
        var movies = new List<RentedMoviesDto>();

        foreach (var movieId in lessRentedMoviesLastWeek)
        {
            var numberOfRentals = await _repository.Rental.NumberOfMovieRentals(movieId);
            var movie = await _repository.Movie.ReadMovieByIdAsync(movieId);
            movies.Add(
                new RentedMoviesDto(
                    lessRentedMoviesLastWeek.IndexOf(movieId) + 1,
                    numberOfRentals,
                    _mapper.Map<MovieDto>(movie)
                )
            );
        }

        return movies;
    }
}