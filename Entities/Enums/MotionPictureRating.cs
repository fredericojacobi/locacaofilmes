using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Entities.Enums;

public enum MotionPictureRating
{
    [Display(Name = "Todas as idades")]
    General,
    [Display(Name = "Acompanhado dos pais")]
    ParentalGuidance,
    [Display(Name = "Acompanhado dos pais até os 13 anos")]
    ParentalGuidanceUnder13,
    [Display(Name = "Maior de 15 anos")] 
    Restricted,
    [Display(Name = "Maior de 17 anos")]
    NoOneUnder17
}

public static class EnumerationExtensions
{
    public static string GetEnumDisplayName(this Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

        if (attributes.Length > 0)
            return attributes[0].Name;

        return value.ToString();
    }
}