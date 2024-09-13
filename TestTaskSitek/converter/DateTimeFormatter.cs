using System.Globalization;
using static TestTaskSitek.utility.DateTimeFormats;

namespace TestTaskSitek.converter;

//Не уверен что стоит плодить статические классы, тут лучше бы подошло DI c синглетоном
public static class DateTimeFormatter
{
    public static string ToDateString(DateTime date)
    {
        return date.ToString(StandardDateTimeFormat, CultureInfo.InvariantCulture);
    }

    public static DateTime FromDateString(string dateString)
    {
        // Список форматов для попытки разбора даты
        string[] formats =
        {
            Iso8601DateTimeFormat,
            EuropeanDateTimeFormat,
            StandardDateTimeFormat
        };

        if (DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out var date)) return date;

        // Если не удалось разобрать дату с использованием указанных форматов, будет выброшено исключение
        throw new FormatException("Некорректный формат строки даты.");
    }
}