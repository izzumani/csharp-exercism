using System;
using System.Text.RegularExpressions;

public static class LogAnalysis 
{
    

    public static string SubstringAfter(this string log, string delimeter)
    {
        int startIndex = log.IndexOf(delimeter);

        if (startIndex == -1)
            return log;

        string stringAfter = log.Substring(startIndex + delimeter.Length);
        return log.Substring(startIndex + delimeter.Length);
        

    }

    public static string SubstringBetween(this string log, string openDelimeter,string closeDelimeter )
    {
        string pattern = @$"\{openDelimeter}(\w+)\{closeDelimeter}";
        Match matchEnum = Regex.Match(log, pattern,RegexOptions.IgnoreCase);
        string logLevel = string.Empty;
        if (matchEnum.Success )
        {
            logLevel = matchEnum.Groups[1].Value.Trim();
        }
        return logLevel;
    }
    public static string Message(this string log)
    {
        
        return Regex.Replace(log, @"(\[\w+\]:)", "").Trim();
    }

    public static string LogLevel(this string log)
    {
        Match matchEnum = Regex.Match(log, @"\[(\w+)\]",RegexOptions.IgnoreCase);
        if (matchEnum.Success)
        {
            return matchEnum.Groups[1].Value;
        }
        return log;
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
}