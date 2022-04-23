using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Generics;

namespace Entities.Models;

public class Rental : ObjectBase
{
    public Guid ClientId { get; set; }
    
    public Guid MovieId { get; set; }
    
    public DateTime RentDate { get; set; }
    
    public DateTime ReturnDate { get; set; }
    
    [ForeignKey(nameof(ClientId))]
    public Client Client { get; set; }
    
    [ForeignKey(nameof(MovieId))]
    public Movie Movie { get; set; }
}