using System;
using System.Globalization;


public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime.TryParse(appointmentDateDescription, out DateTime appointmentDate);

        string strLocalTimeZone = TimeZoneInfo.Local.IsDaylightSavingTime(appointmentDate) ? TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName;

        TimeZoneInfo localTimeZone = location switch
        {
            Location.NewYork => TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"),
            Location.London => TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"),
            Location.Paris => TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")

        };
        return TimeZoneInfo.ConvertTimeToUtc(appointmentDate, localTimeZone);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        return alertLevel switch
        {
            AlertLevel.Early => appointment.AddHours(-24),
            AlertLevel.Standard => appointment.AddMinutes(-105),
            AlertLevel.Late => appointment.AddMinutes(-30),
            _ => appointment
        };
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {

        TimeZoneInfo localTimeZone = location switch
        {
            Location.NewYork => TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"),
            Location.London => TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"),
            Location.Paris => TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time")
          

        };
        return (localTimeZone.IsDaylightSavingTime(dt) || localTimeZone.IsDaylightSavingTime(dt.AddDays(-7)));

    }
    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        DateTimeFormatInfo formatInfo = location switch 
        {
            Location.NewYork => new CultureInfo("en-US", false).DateTimeFormat,
            Location.London => new CultureInfo("en-GB", false).DateTimeFormat,
            Location.Paris => new CultureInfo("fr-FR", false).DateTimeFormat
        };

        if (DateTime.TryParse(dtStr, formatInfo, out DateTime Result))
            return Result;
        else
            return new DateTime(1, 1, 1, 0, 0, 0);

    }
}
