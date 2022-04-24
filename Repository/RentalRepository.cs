using AutoMapper;
using Contracts.Repositories;
using Entities.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RentalRepository : RepositoryBase<Rental>, IRentalRepository
{
    private readonly AppDbContext _context;

    public RentalRepository(AppDbContext context) : base(context) => _context = context;

    public async Task<IList<Rental>> ReadAllRentalsAsync() => await ReadAllAsync(x => x.Client, x => x.Movie);

    public async Task<IList<Rental>> ReadOverdueRentalsAsync() =>
        await ReadByConditionAsync(x => x.ReturnDate < DateTime.Today, x => x.Client, x => x.Movie);

    public async Task<IList<Guid>> MostRentedMoviesIdLastYearAsync(int top) =>
        await _context.Rentals
            .Where(x => x.RentDate >= DateTime.Today.AddYears(-1))
            .GroupBy(x => x.MovieId)
            .Select(y => y.Key)
            .Take(top)
            .ToListAsync();

    public async Task<IList<Guid>> HighestMoviesRentedClientIdAsync() =>
        await _context.Rentals
            .GroupBy(x => x.ClientId)
            .Select(y => y.Key)
            .ToListAsync();

    public async Task<IList<Guid>> LessRentedMoviesIdLastWeekAsync(int top)
    {
        var mostRentedLastWeek = await _context.Rentals
            .Where(x => x.RentDate >= DateTime.Today.AddDays(-7))
            .GroupBy(x => x.MovieId)
            .Select(y => y.Key)
            .Take(top)
            .ToListAsync();
        mostRentedLastWeek.Reverse();
        return mostRentedLastWeek;
    }

    public async Task<int> NumberOfMovieRentals(Guid movieId)
    {
        var number = await ReadByConditionAsync(x => x.MovieId.Equals(movieId));
        return number.Count;
    }

    public async Task<int> NumberOfClientRentals(Guid movieId)
    {
        var number = await ReadByConditionAsync(x => x.ClientId.Equals(movieId));
        return number.Count;
    }

    public async Task<Rental?> ReadRentalAsync(Guid id) => await ReadByIdAsync(id, x => x.Client, x => x.Movie);

    public async Task<Rental> CreateRentalAsync(Rental rental) => await CreateAsync(rental);

    public async Task<Rental> UpdateRentalAsync(Rental rental) => await UpdateAsync(rental);

    public async Task<bool> DeleteRentalAsync(Guid id)
    {
        var rental = await ReadRentalAsync(id);
        return rental is not null && await DeleteAsync(rental);
    }
}