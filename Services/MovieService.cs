using System.Net;
using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.Models.Generics;

namespace Services;

public class MovieService : IMovieService
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public MovieService(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Return<MovieDto>> GetAsync()
    {
        var returnObj = new Return<MovieDto>();

        try
        {
            var result = await _repository.Movie.ReadAllMoviesAsync();
            returnObj.Records = _mapper.Map<List<MovieDto>>(result);
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }
        
        returnObj.SetMessage();
        return returnObj;
    }

    public async Task<Return<MovieDto>> GetAsync(Guid id)
    {
        var returnObj = new Return<MovieDto>();

        try
        {
            var result = await _repository.Movie.ReadMovieAsync(id);
            returnObj.Records.Add(_mapper.Map<MovieDto>(result));
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }
        
        returnObj.SetMessage();
        return returnObj;
    }

    public async Task<Return<MovieDto>> PostAsync(PostMovieDto postMovieDto)
    {
        var returnObj = new Return<MovieDto>();

        try
        {
            var movie = _mapper.Map<Movie>(postMovieDto);
            var result = await _repository.Movie.CreateMovieAsync(movie);
            returnObj.Records.Add(_mapper.Map<MovieDto>(result));
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }
        
        returnObj.SetMessage();
        return returnObj;    }

    public async Task<Return<MovieDto>> PutAsync(MovieDto movieDto)
    {
        var returnObj = new Return<MovieDto>();

        try
        {
            var movie = _mapper.Map<Movie>(movieDto);
            var result = await _repository.Movie.UpdateMovieAsync(movie);
            returnObj.Records.Add(_mapper.Map<MovieDto>(result));
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }

        returnObj.SetMessage();
        return returnObj;
    }

    public async Task<Return<MovieDto>> DeleteAsync(Guid id)
    {
        var returnObj = new Return<MovieDto>();
        
        try
        {
            returnObj.Ok = await _repository.Movie.DeleteMovieAsync(id);
        }
        catch
        {
            returnObj.SetMessage(HttpStatusCode.InternalServerError);
        }

        returnObj.SetMessage();
        return returnObj;
    }
}