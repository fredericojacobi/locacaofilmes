namespace Entities.DataTransferObjects;

public class ClientDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Cpf { get; set; }
    
    public string Birthday{ get; set; }
}