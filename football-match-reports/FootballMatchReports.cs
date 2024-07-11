using System;
using System.Reflection;

public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case 1:
                return "goalie";
            case 2:
                return "left back";
            case 3:
            case 4:
                return "center back";
            case 5:
                return "right back";
            case 6:
            case 7:
            case 8:
                return "midfielder";
            case 9:
                return "left wing";
            case 10:
                return "striker";
            case 11:
                return "right wing";

            default:
                throw new ArgumentOutOfRangeException();
                
        }
    }

    public static string AnalyzeOffField(object report)
    {
        var classType = report.GetType();


        if (report.GetType()==typeof(int) || report.GetType() == typeof(Int32))
        {
            
            return $"There are {(int)report} supporters at the match.";
        }
        else if (report.GetType() == typeof(string))
        {
            return $"{report.ToString()}";
        }
        else if (report.GetType() == typeof(Incident))
        {
            Incident incident = (Incident)report;
            return incident.GetDescription();

        }
        else if (report.GetType()== typeof(Foul))
         {
            Foul foul = (Foul)report;
            return foul.GetDescription();
        }

        else if (report.GetType() == typeof(Injury))
        {
            Injury injury = (Injury)report;

            /*
            FieldInfo[] fields = typeof(Injury).GetFields(
                       BindingFlags.NonPublic |
                       BindingFlags.Instance);
            */
            FieldInfo field = typeof(Injury).GetField("player", BindingFlags.NonPublic | BindingFlags.Instance);

            return $"Oh no! Player {field.GetValue(injury)} is injured. Medics are on the field.";
        }

        else if (report.GetType() == typeof(Manager))
        {
            Manager manager = (Manager)report;
            string _club = string.IsNullOrEmpty(manager.Club) ? "" : $" ({manager.Club})";
            return $"{manager.Name}" + _club;
        }
        else
        {
            throw new ArgumentException();
        }
    }
}
