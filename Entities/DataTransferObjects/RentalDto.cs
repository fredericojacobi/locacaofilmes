
namespace Entities.DataTransferObjects;

public class RentalDto
{
    public Guid Id { get; set; }
    
    public string RentDate { get; set; }
    
    public string ReturnDate { get; set; }
    
    public string ClientName { get; set; }
    
    public string MovieTitle { get; set; }
}