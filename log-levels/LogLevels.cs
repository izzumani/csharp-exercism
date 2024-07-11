using System;
using System.Text.RegularExpressions;

static class LogLine
{
    public static string Message(string logLine)
    {
        
        string pattern = @"(\[ERROR\]:|\[INFO\]:|\[WARNING\]:)";
        
         string result = Regex.Replace(logLine, pattern, "");
        
        return result.Trim();
    }

    public static string LogLevel(string logLine)
    {
         string pattern = @"(\[ERROR\]|\[INFO\]|\[WARNING\])";
         Match m = Regex.Match(logLine, pattern, RegexOptions.IgnoreCase);
            
            
        
         if (m.Success)
         {
            pattern = @"[\[?\]?]";    
            string result = Regex.Replace(m.Value,pattern,"");
            return result.ToLower();
         }
        else{
            return logLine;
        }

    }

    public static string Reformat(string logLine)
    {
        return $"{Message(logLine)} ({LogLevel(logLine)})";
    }
}
