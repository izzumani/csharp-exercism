using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

// TODO: define the 'LogLevel' enum

static class LogLine
{
    private static Dictionary<string, LogLevel> logLevelDic = new Dictionary<string, LogLevel>() { {"TRC",LogLevel.Trace },
                                                                                                   {"DBG",LogLevel.Debug },
                                                                                                   {"INF",LogLevel.Info },
                                                                                                   {"WRN",LogLevel.Warning },
                                                                                                   {"ERR",LogLevel.Error },
                                                                                                   {"FTL",LogLevel.Fatal },
                                                                                                   
                                                                                                  };


    public static LogLevel ParseLogLevel(string logLine)
    {

        string pattern = @"(\[\w+\]:)";
        Match matchEnum = Regex.Match(logLine, pattern,RegexOptions.IgnoreCase);
        
        if(matchEnum.Success)
        {
            string matchValue = Regex.Replace(matchEnum.Value,@"[\[\]:]","");
            if(logLevelDic.TryGetValue(matchValue, out LogLevel logLevel))
            {
                return logLevel;
            }
        }

        return LogLevel.Unknown;

    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        return $"{(int)logLevel}:{message}";
    }

    
}

enum LogLevel
{
    
    Trace=1, 
    
    Debug=2,
    
    Info=4,
    
    Warning=5,
    
    Error=6,
    
    Fatal=42,
    Unknown = 0
}
