namespace LogSearch.Utilities;

public static class Util
{
    public static int SkipCount(int page, int pageSize) => (page - 1) * pageSize;
}