using LogSearch.Constants;
using LogSearch.Log.Abstractions;

namespace LogSearch.LogManager;

public static class HashedLogCollection
{
    private static readonly Dictionary<string, List<ILogEntry>> _hashedLogs =
        new(LogConstants.MaxHashedLogCount);

    public static List<ILogEntry> GetHashed(string filter)
    {
        if (!_hashedLogs.ContainsKey(filter)) return new List<ILogEntry>();

        var hashedLog = _hashedLogs.FirstOrDefault(x => x.Key == filter);
        return hashedLog.Value.ToList();
    }

    public static void SetHashedLogs(string filter, List<ILogEntry> logs)
    {
        if (_hashedLogs.Count < LogConstants.MaxHashedLogCount)
        {
            _hashedLogs.Add(filter, logs);
            return;
        }

        MinifyHashedLogs();
        _hashedLogs.Add(filter, logs);
    }

    //Total 396 log exist and 100 queries hashed. Removed half of the queries when it fulled to prevent out of memory
    private static void MinifyHashedLogs()
    {
        var keys = _hashedLogs.Keys.ToList();
        for (var i = 0; i < LogConstants.MaxHashedLogCount / 2; i++)
        {
            _hashedLogs.Remove(keys[i]);
        }
    }
}