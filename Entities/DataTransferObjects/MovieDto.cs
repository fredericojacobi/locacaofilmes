using Entities.Enums;

namespace Entities.DataTransferObjects;

public class MovieDto
{
    public Guid Id { get; set; }
    
    public string Title { get; set; }
    
    public MotionPictureRating MotionPictureRating { get; set; }
    
    public bool Release { get; set; }
}