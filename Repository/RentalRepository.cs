using AutoMapper;
using Contracts.Repositories;
using Entities.Models;
using Infrastructure;

namespace Repository;

public class RentalRepository : RepositoryBase<Rental>, IRentalRepository
{
    public RentalRepository(AppDbContext context, IMapper mapper) : base(context)
    {
    }

    public async Task<IList<Rental>> ReadAllRentalsAsync() => await ReadAllAsync(x => x.Client, x => x.Movie);
    public async Task<IList<Rental>> ReadOverdueRentalsAsync() => await ReadByConditionAsync(x => x.ReturnDate < DateTime.Today, x => x.Client);

    public async Task<Rental?> ReadRentalAsync(Guid id) => await ReadByIdAsync(id, x => x.Client, x => x.Movie);

    public async Task<Rental> CreateRentalAsync(Rental rental) => await CreateAsync(rental);

    public async Task<Rental> UpdateRentalAsync(Rental rental) => await UpdateAsync(rental);

    public async Task<bool> DeleteRentalAsync(Guid id)
    {
        var rental = await ReadRentalAsync(id);
        return rental is not null && await DeleteAsync(rental);
    }
}