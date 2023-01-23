using System.Linq.Expressions;
using LogSearch.Log.Abstractions;

namespace LogSearch.LogManager.Request;

public class GetByFilterRequest : BaseRequest
{
    public Expression<Func<ILogEntry, bool>>? Filter { get; set; }

    public string GetFilterAsString() => Filter != null ? Filter.ToString() : string.Empty;
}