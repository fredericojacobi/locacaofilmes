namespace Extensions;

public static class StringExtensions
{
    public static bool HasValue(this string str) => !string.IsNullOrWhiteSpace(str);
    
    public static bool IsNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);
}