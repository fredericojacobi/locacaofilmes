namespace Entities.DataTransferObjects;

public class ClientRentalDto
{
    public int NumberOfRentals { get; set; }
    
    public ClientDto Client { get; set; }

    public ClientRentalDto(int numberOfRentals, ClientDto client)
    {
        NumberOfRentals = numberOfRentals;
        Client = client;
    }
}