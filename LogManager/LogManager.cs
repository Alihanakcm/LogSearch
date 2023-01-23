using System.Linq.Expressions;
using System.Text.Json;
using LogSearch.Filter.DateFilter;
using LogSearch.Log;
using LogSearch.Log.Abstractions;
using LogSearch.LogManager.Abstractions;
using LogSearch.LogManager.Request;

namespace LogSearch.LogManager;

public class LogManager : ILogManager
{
    private readonly IQueryable<ILogEntry> _logs;
    private readonly string _logFileResource = "/home/alihan/RiderProjects/Unitfly/LogSearch/Log/LogFile/log-file.json";

    public LogManager()
    {
        if (_logs != null) return;

        var logFile = File.ReadAllText(_logFileResource);
        var serializedLogs = JsonSerializer.Deserialize<IEnumerable<LogEntry>>(logFile);
        _logs = new EnumerableQuery<ILogEntry>(serializedLogs);
    }
    
    public IEnumerable<ILogEntry> Get(GetByFilterRequest request)
    {
        var skipCount = request.GetSkipCount();
        if (request.Filter == null)
        {
            return _logs.Skip(skipCount).Take(request.PageSize);
        }

        var hashedLogs =
            HashedLogCollection.GetHashed(request.Filter
                .ToString()); // I used hash to prevent run same query repeatedly and normally could be used caching instead of hash    
        if (hashedLogs.Any())
        {
            return hashedLogs;
        }

        var logs = GetLogs(request.Filter, skipCount, request.PageSize);
        HashedLogCollection.SetHashedLogs(request.GetFilterAsString(), logs);

        return logs;
    }

    public IEnumerable<ILogEntry> Get(GetByTimeRequest request)
    {
        var filteredLogs = _logs.FilterByYear(request.Year);
        filteredLogs = filteredLogs.FilterByMonth(request.Month);
        filteredLogs = filteredLogs.FilterByDay(request.Day);
        filteredLogs = filteredLogs.FilterByHour(request.Hour);
        filteredLogs = filteredLogs.FilterByMinute(request.Minute);
        filteredLogs = filteredLogs.FilterBySecond(request.Second);

        var skipCount = request.GetSkipCount();
        var logs = filteredLogs.Skip(skipCount).Take(request.PageSize);

        return logs;
    }

    public IEnumerable<ILogEntry> Get(GetByApplicationId request)
    {
        if (!Guid.TryParse(request.ApplicationId, out var appId))
            throw new ArgumentException("Invalid application Id");

        var filteredLogs = _logs.Where(x => x.AppId == appId);

        var skipCount = request.GetSkipCount();
        var logs = filteredLogs.Skip(skipCount).Take(request.PageSize);

        return logs;
    }


    private List<ILogEntry> GetLogs(Expression<Func<ILogEntry, bool>> filter, int skipCount = 0,
        int pageSize = 25)
    {
        return _logs.Where(filter).Skip(skipCount).Take(pageSize).ToList();
    }
}