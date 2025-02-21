namespace Business.Utilities;

public class DateParser
{
    // Github Copilot suggested the code in order to parse the date correctly.
    public static bool TryParseDate(string input, out DateTime date)
    {
        return DateTime.TryParseExact(input, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date);
    }
}