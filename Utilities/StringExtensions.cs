namespace StarWarsPlanet.StringExtensions;

public static class StringExtensions
{
    public static int? ToIntOrNull(this string? input)
    {
        return int.TryParse(input, out int inputParsed) ?
            inputParsed :
            null;
    }

    public static long? ToLongOrNull(this string? input)
    {
        return long.TryParse(input, out long inputParsed) ?
            inputParsed :
            null;
    }
}