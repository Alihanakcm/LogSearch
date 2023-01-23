using LogSearch.Constants;

namespace LogSearch.LogManager.Request;

public class GetByTimeRequest : BaseRequest
{
    private int? _year;

    private int? _month;

    private int? _day;

    private int? _hour;

    private int? _minute;

    private int? _second;

    /// <summary>
    /// Parameter required and should be higher than 2000
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public int? Year
    {
        get => _year;
        set
        {
            if (!value.HasValue || value < LogConstants.SearchQuery.MinYear || value > DateTime.Now.Year)
            {
                throw new ArgumentException("Invalid year");
            }

            _year = value;
        }
    }

    /// <summary>
    /// Parameter should be between 1 and 12
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public int? Month
    {
        get => _month;
        set
        {
            if (!_year.HasValue && _month.HasValue)
            {
                throw new ArgumentException("To filter by month you must enter year first");
            }

            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Invalid month");
            }

            _month = value;
        }
    }

    /// <summary>
    /// Parameter should be between 1 and 32
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public int? Day
    {
        get => _day;
        set
        {
            if (!_month.HasValue && _day.HasValue)
            {
                throw new ArgumentException("To filter by day you must enter month first");
            }

            if (value < 1 || value > 32)
            {
                throw new ArgumentException("Invalid day");
            }

            _day = value;
        }
    }

    /// <summary>
    /// Parameter should be between 1 and 24
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public int? Hour
    {
        get => _hour;
        set
        {
            if (!_day.HasValue && _hour.HasValue)
            {
                throw new ArgumentException("To filter by hour you must enter day first");
            }

            if (value < 1 || value > 24)
            {
                throw new ArgumentException("Invalid hour");
            }

            _hour = value;
        }
    }

    /// <summary>
    /// Parameter should be between 1 and 60
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public int? Minute
    {
        get => _minute;
        set
        {
            if (!_day.HasValue && _minute.HasValue)
            {
                throw new ArgumentException("To filter by minute you must enter hour first");
            }

            if (value < 1 || value > 60)
            {
                throw new ArgumentException("Invalid minute");
            }

            _minute = value;
        }
    }

    /// <summary>
    /// Parameter should be between 1 and 60
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public int? Second
    {
        get => _second;
        set
        {
            if (!_minute.HasValue && _second.HasValue)
            {
                throw new ArgumentException("To filter by second you must enter minute first");
            }

            if (value < 1 || value > 60)
            {
                throw new ArgumentException("Invalid second");
            }

            _second = value;
        }
    }
}