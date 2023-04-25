namespace Challenges.Exercism;

public enum LogLevel
{
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42,
    Unknown = 0
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        byte first = (byte)(logLine.IndexOf('[') + 1);
        string log = logLine.Substring(first, 3);

        switch (log)
        {
            case "TRC":
                return LogLevel.Trace;
            
            case "DBG":
                return LogLevel.Debug;
            
            case "INF":
                return LogLevel.Info;
            
            case "WRN":
                return LogLevel.Warning;
            
            case "ERR":
                return LogLevel.Error;
            
            case "FTL":
                return LogLevel.Fatal;
        }
        return LogLevel.Unknown;
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        return $"{(int)logLevel}:{message}";
    }
}