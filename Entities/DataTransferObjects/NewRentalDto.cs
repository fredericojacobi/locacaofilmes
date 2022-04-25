namespace Entities.DataTransferObjects;

public class NewRentalDto
{
    public Guid Id { get; set; }
    
    public string RentDate { get; set; }
    
    public string ReturnDate { get; set; }
    
    public string ClientName { get; set; }
    
    public string MovieTitle { get; set; }
    
    public List<MovieDto> Movies { get; set; }
    
    public List<ClientDto> Clients { get; set; }
}