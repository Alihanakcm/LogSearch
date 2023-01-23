using LogSearch.Log.Abstractions;
using LogSearch.LogManager.Request;

namespace LogSearch.LogManager.Abstractions;

public interface ILogManager
{
    IEnumerable<ILogEntry> Get(GetByFilterRequest request);

    IEnumerable<ILogEntry> Get(GetByTimeRequest request);

    IEnumerable<ILogEntry> Get(GetByApplicationId request);
}