namespace Entities.DataTransferObjects;

public class PostRentalDto
{
    public Guid ClientId { get; set; }
    
    public Guid MovieId { get; set; }
    
    public string RentDate { get; set; }
}