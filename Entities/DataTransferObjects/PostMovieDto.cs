using Entities.Enums;

namespace Entities.DataTransferObjects;

public class PostMovieDto
{
    public string Title { get; set; }
    
    public MotionPictureRating MotionPictureRating { get; set; }
    
    public bool Release { get; set; }
}