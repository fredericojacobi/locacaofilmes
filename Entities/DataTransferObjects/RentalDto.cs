
namespace Entities.DataTransferObjects;

public class RentalDto
{
    public Guid Id { get; set; }
    
    public DateTime RentDate { get; set; }
    
    public DateTime ReturnDate { get; set; }
    
    public ClientDto Client { get; set; }
    
    public MovieDto Movie { get; set; }
}