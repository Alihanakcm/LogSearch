using LogSearch.Log.Abstractions;

namespace LogSearch.Filter.DateFilter;

public static class LogEntryDateFilter
{
    public static IQueryable<ILogEntry> FilterByYear(this IQueryable<ILogEntry> logEntries, int? year)
    {
        return !year.HasValue ? logEntries : logEntries.Where(x => x.Timestamp.Year == year);
    }

    public static IQueryable<ILogEntry> FilterByMonth(this IQueryable<ILogEntry> logEntries, int? month)
    {
        return !month.HasValue ? logEntries : logEntries.Where(x => x.Timestamp.Month == month);
    }

    public static IQueryable<ILogEntry> FilterByDay(this IQueryable<ILogEntry> logEntries, int? day)
    {
        return !day.HasValue ? logEntries : logEntries.Where(x => x.Timestamp.Day == day);
    }

    public static IQueryable<ILogEntry> FilterByHour(this IQueryable<ILogEntry> logEntries, int? hour)
    {
        return !hour.HasValue ? logEntries : logEntries.Where(x => x.Timestamp.Hour == hour);
    }

    public static IQueryable<ILogEntry> FilterByMinute(this IQueryable<ILogEntry> logEntries, int? minute)
    {
        return !minute.HasValue ? logEntries : logEntries.Where(x => x.Timestamp.Minute == minute);
    }

    public static IQueryable<ILogEntry> FilterBySecond(this IQueryable<ILogEntry> logEntries, int? second)
    {
        return !second.HasValue ? logEntries : logEntries.Where(x => x.Timestamp.Second == second);
    }
}