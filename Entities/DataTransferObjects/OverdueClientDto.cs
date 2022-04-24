namespace Entities.DataTransferObjects;

public class OverdueClientDto
{
    public ClientDto Client { get; set; }
    
    public MovieDto Movie { get; set; }
    
    public DateTime ReturnDate { get; set; }
}