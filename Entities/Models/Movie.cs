using System.ComponentModel.DataAnnotations.Schema;
using Entities.Enums;
using Entities.Models.Generics;

namespace Entities.Models;

public class Movie : ObjectBase
{
    [Column(TypeName = "varchar(100)")]
    public string Title { get; set; }
    
    public MotionPictureRating MotionPictureRating { get; set; }
    
    public bool Release { get; set; }
}