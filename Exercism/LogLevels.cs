/*
    In this exercise you'll be processing log-lines.
    Each log line is a string formatted as follows: "[<LEVEL>]: <MESSAGE>".
    There are three different log levels:

    -   INFO
    -   WARNING
    -   ERROR
    
    You have three tasks, each of which will take a log line and ask you to do something with it.
*/
public class LogLevels
{
    /*
        Implement the (static) LogLine.Message() method to return a log line's message.
        Any leading or trailing white space should be removed.
    */
    public static string Message(string logLine)
    {
        int first = logLine.IndexOf(":") + 1;
        int last = logLine.Length;

        string trimmedSubString = logLine.Substring(first, last - first).Trim();

        return trimmedSubString;
    }

    /*
        Implement the (static) LogLine.LogLevel() method to return a log line's log level, which should be returned in lowercase:
    */
    public static string LogLevel(string logLine)
    {
        int first = 1;
        int last = logLine.IndexOf("]");

        string lowerCaseLogLevel = logLine.Substring(first, last - first).ToLower();

        return lowerCaseLogLevel;
    }

    /*
        Implement the (static) LogLine.Reformat() method that reformats the log line, putting the message first and the log level after it in parentheses:
    */
    public static string Reformat(string logLine)
    {
        string message = Message(logLine);
        string logLevel = LogLevel(logLine);
        string result = message + $" ({logLevel})";
        
        return result;
    }
}