namespace DxBlazorApp.Data;

public static class DateTimeUtils
{
    public static DateTime GetWeekStart(DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Sunday
                   ? ValidWeekStart(date.Date)
                   : ValidWeekStart(date.Date - CreateWeekOffset(date, DayOfWeek.Sunday));
    }

    public static DateTime GetBeginOfMonth(DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1);
    }

    static DateTime ValidWeekStart(DateTime date)
    {
        TimeSpan weekSpan = new TimeSpan(7, 0, 0, 0);
        DateTime baseDate = date.Date;
        if (DateTime.MaxValue - date < weekSpan)
            return baseDate - weekSpan;
        return baseDate;
    }

    static TimeSpan CreateWeekOffset(DateTime date, DayOfWeek firstDayOfWeek)
    {
        int offset = (date.DayOfWeek + 7 - firstDayOfWeek) % 7;
        TimeSpan result = TimeSpan.FromDays(offset);
        if (date.Ticks < result.Ticks)
            result = TimeSpan.FromDays(offset - 7);
        return result;
    }
}