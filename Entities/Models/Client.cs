using System.ComponentModel.DataAnnotations.Schema;
using Entities.Models.Generics;

namespace Entities.Models;

public class Client : ObjectBase
{
    [Column(TypeName = "varchar(200)")]
    public string Name { get; set; }
    
    [Column(TypeName = "varchar(11)")]
    public string Cpf { get; set; }
    
    public DateTime Birthday { get; set; }
}