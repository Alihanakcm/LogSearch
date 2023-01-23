using LogSearch.Log.Abstractions;
using LogSearch.Log.Enum;

namespace LogSearch.Log;

public class LogEntry : ILogEntry
{
    public DateTime Timestamp { get; set; }

    public virtual LogEventLevel Level { get; set; }

    public Guid AppId { get; set; }

    public string Module { get; set; }

    public string Message { get; set; }
}