using System.Net;
using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities.Constants;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.Models.Generics;

namespace Services;

public class RentalService : IRentalService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public RentalService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<Return<RentalDto>> GetAsync()
    {
        var returnObj = new Return<RentalDto>();

        try
        {
            var result = await _repository.Rental.ReadAllRentalsAsync();
            returnObj.Records = _mapper.Map<List<RentalDto>>(result);
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }
        
        returnObj.SetMessage();
        return returnObj;
    }

    public async Task<Return<RentalDto>> GetAsync(Guid id)
    {
        var returnObj = new Return<RentalDto>();

        try
        {
            var result = await _repository.Rental.ReadRentalAsync(id);
            returnObj.Records.Add(_mapper.Map<RentalDto>(result));
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }
        
        returnObj.SetMessage();
        return returnObj;
    }

    public async Task<Return<RentalDto>> PostAsync(PostRentalDto postRentalDto)
    {
        var returnObj = new Return<RentalDto>();

        try
        {
            var rental = _mapper.Map<Rental>(postRentalDto);
            var client = await _repository.Client.ReadClientAsync(rental.ClientId);
            if (client is null)
            {
                returnObj.SetMessage(Message.CLIENT_NOT_FOUND, false, HttpStatusCode.NotFound);
                return returnObj;
            }
            
            var movie = await _repository.Movie.ReadMovieAsync(rental.MovieId);
            if (movie is not null)
                rental.ReturnDate = movie.Release ? rental.RentDate.AddDays(2) : rental.ReturnDate.AddDays(3);
            else
            {
                returnObj.SetMessage(Message.MOVIE_NOT_FOUND, false, HttpStatusCode.NotFound);
                return returnObj;
            }
            
            var result = await _repository.Rental.CreateRentalAsync(rental);
            returnObj.Records.Add(_mapper.Map<RentalDto>(result));
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }
        
        returnObj.SetMessage();
        return returnObj;
    }

    public async Task<Return<RentalDto>> PutAsync(PostRentalDto postRentalDto)
    {
        var returnObj = new Return<RentalDto>();

        try
        {
            var rental = _mapper.Map<Rental>(postRentalDto);
            if (!await _repository.Client.ClientExistsAsync(rental.ClientId))
            {
                returnObj.SetMessage(Message.CLIENT_NOT_FOUND, false, HttpStatusCode.NotFound);
                return returnObj;
            }
            
            var movie = await _repository.Movie.ReadMovieAsync(rental.MovieId);
            if (movie is not null)
                rental.ReturnDate = movie.Release ? rental.RentDate.AddDays(2) : rental.ReturnDate.AddDays(3);
            else
            {
                returnObj.SetMessage(Message.MOVIE_NOT_FOUND, false, HttpStatusCode.NotFound);
                return returnObj;
            }
            
            var result = await _repository.Rental.CreateRentalAsync(rental);
            returnObj.Records.Add(_mapper.Map<RentalDto>(result));
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }
        
        returnObj.SetMessage();
        return returnObj;
    }

    public async Task<Return<RentalDto>> DeleteAsync(Guid id)
    {
        var returnObj = new Return<RentalDto>();
        
        try
        {
            returnObj.Ok = await _repository.Rental.DeleteRentalAsync(id);
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }

        returnObj.SetMessage();
        return returnObj;
    }
}