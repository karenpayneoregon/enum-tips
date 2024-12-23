namespace EnumComparisionApp.Classes;

internal static class DateOnlyExtensions
{
    public static bool IsWeekend(this DateOnly sender)
        => sender.DayOfWeek is DayOfWeek.Sunday or DayOfWeek.Saturday;
}