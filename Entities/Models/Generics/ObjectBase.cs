using System.ComponentModel.DataAnnotations;

namespace Entities.Models.Generics;

public class ObjectBase
{
    [Key]
    public Guid Id { get; set; }
}