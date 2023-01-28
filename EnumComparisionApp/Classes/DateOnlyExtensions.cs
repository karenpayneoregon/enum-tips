namespace EnumComparisionApp.Classes;

internal static class DateOnlyExtensions
{
    public static bool IsWeekend(this DateOnly sender)
        => (sender.DayOfWeek == DayOfWeek.Sunday || 
            sender.DayOfWeek == DayOfWeek.Saturday);
}