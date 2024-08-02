using System;
using System.Globalization;

public class Clock : IEquatable<Clock>
{
    private DateTime _date;
    public Clock(int hours, int minutes)
    {
      _date = new DateTime(2024, 08, 01, 0, 0, 0);
      _date = _date.AddHours(hours);
      _date = _date.AddMinutes(minutes);
    }

    public Clock Add(int minutesToAdd)
    {
        _date = _date.AddMinutes(minutesToAdd);
      
        return this;
    }

    public Clock Subtract(int minutesToSubtract)
    {
        _date = _date.AddMinutes(Math.Abs(minutesToSubtract) *-1);
        return this;
    }

    public bool Equals(Clock otherClock)
    {
        if (otherClock == null)
            return false;
        else if (Object.ReferenceEquals(this, otherClock) == true)
            return false;
        else return _date.Hour == otherClock._date.Hour && _date.Minute == otherClock._date.Minute;
    }

    public override string ToString() => $@"{_date.Hour.ToString().PadLeft(2,'0')}:{_date.Minute.ToString().PadLeft(2,'0')}";

}
