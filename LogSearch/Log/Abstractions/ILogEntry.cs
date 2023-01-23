using LogSearch.Log.Enum;

namespace LogSearch.Log.Abstractions;

public interface ILogEntry
{
    DateTime Timestamp { get; set; }

    LogEventLevel Level { get; set; }

    Guid AppId { get; set; }

    string Module { get; set; }

    string Message { get; set; }
}