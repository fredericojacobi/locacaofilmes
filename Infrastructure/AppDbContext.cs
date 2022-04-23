using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Client> Clients { get; set; }

    public DbSet<Rental> Rentals { get; set; }

    public DbSet<Movie> Movies { get; set; }
}