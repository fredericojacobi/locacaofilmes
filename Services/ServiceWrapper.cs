using AutoMapper;
using Contracts.Repositories;
using Contracts.Services;

namespace Services;

public class ServiceWrapper : IServiceWrapper
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;
    
    public IRentalReportService _rentalReport;
    public IClientService _client;
    public IMovieService _movie;
    public IRentalService _rental;

    public ServiceWrapper(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IRentalReportService RentalReport => _rentalReport ??= new RentalReportService(_repository, _mapper);
    public IClientService Client => _client ??= new ClientService(_repository, _mapper);
    public IMovieService Movie => _movie ??= new MovieService(_repository, _mapper);
    public IRentalService Rental => _rental ??= new RentalService(_repository, _mapper);

}