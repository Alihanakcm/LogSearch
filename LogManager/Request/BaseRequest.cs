using LogSearch.Utilities;

namespace LogSearch.LogManager.Request;

public class BaseRequest
{
    public int Page { get; set; } = 1;

    public int PageSize { get; set; } = 25;

    public int GetSkipCount() => Util.SkipCount(Page, PageSize);
}