namespace Entities.DataTransferObjects;

public class RentedMoviesDto
{
    public int Position { get; set; }
    
    public int NumberOfRentals { get; set; }
 
    public MovieDto Movie { get; set; }

    public RentedMoviesDto(int position, int numberOfRentals, MovieDto movie)
    {
        Position = position;
        NumberOfRentals = numberOfRentals;
        Movie = movie;
    }
}