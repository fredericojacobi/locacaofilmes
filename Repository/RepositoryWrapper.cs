using AutoMapper;
using Contracts.Repositories;
using Infrastructure;

namespace Repository;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private IRentalRepository _rental;
    private IClientRepository _client;
    private IMovieRepository _movie;

    public RepositoryWrapper(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IRentalRepository Rental => _rental ??= new RentalRepository(_context);
    
    public IClientRepository Client => _client ??= new ClientRepository(_context);
    
    public IMovieRepository Movie => _movie ??= new MovieRepository(_context);
}