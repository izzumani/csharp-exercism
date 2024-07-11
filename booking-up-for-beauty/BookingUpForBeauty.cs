using System;
using System.Globalization;


static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        var cultureInfo = new CultureInfo("en-US");
        var _appointmentDate = DateTime.Parse(appointmentDateDescription,cultureInfo);
        return new DateTime(_appointmentDate.Year,
                        _appointmentDate.Month,
                        _appointmentDate.Day,
                        _appointmentDate.Hour,
                        _appointmentDate.Minute,
                         _appointmentDate.Second
                       );
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        int result = DateTime.Compare(DateTime.Now,appointmentDate);
        return result >0;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        
        return appointmentDate.Hour>=12 && appointmentDate.Hour<18 ? true : false;
    }

    public static string Description(DateTime appointmentDate)
    {
        return $"You have an appointment on {appointmentDate.ToString("M/d/yyyy h:mm:ss tt" ,CultureInfo.CreateSpecificCulture("en-US"))}.";
        
        
    }

    public static DateTime AnniversaryDate()
    {
        return new DateTime(DateTime.Now.Year,9,15,0,0,0);
    }
}
