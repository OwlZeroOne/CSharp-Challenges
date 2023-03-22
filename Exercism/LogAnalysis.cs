/*
    In this exercise you'll be processing log-lines.
    Each log line is a string formatted as follows: "[<LEVEL>]: <MESSAGE>".
    There are three different log levels:

    -   INFO
    -   WARNING
    -   ERROR

    You have several tasks, each of which will take a log line and ask you to do something with it.
*/

public static class LogAnalysis 
{
    /*
        Looking at the logs of the last month, you see that the test message is always located after a specific substring. As you're anticipating having to extract the test message sometime in the near future, you decide to create a helper method to help you with that.

        Implement the (static) LogAnalysis.SubstringAfter() extension method, that takes in some string delimiter and returns the substring after the delimiter.
    */
    public static string SubstringAfter(this string str, string delimiter)
    {
        int first = str.IndexOf(delimiter) + delimiter.Length;
        int last = str.Length;

        return str.Substring(first, last - first);
    }

    /*
        On further inspection, you see that the log level is always located between square brackets ([ and ]). As you're also anticipating having to extract the log level sometime in the near future, you decide to create another helper method to help you with that.

        Implement the (static) LogAnalysis.SubstringBetween() extension method that takes in two string delimiters, and returns the substring that lies between the two delimiters.
    */
    public static string SubstringBetween(this string str, string d1, string d2)
    {
        int first = str.IndexOf(d1) + d1.Length;
        int last = str.IndexOf(d2);

        return str.Substring(first, last - first);
    }

    /*
        Implement the (static) LogAnalysis.Message() extension method to return the message contained in a log.
    */
    public static string Message(this string str)
    {
        return str.SubstringAfter(": ");
    }

    /*
        Implement the (static) LogAnalysis.LogLevel() extension method to return the log level of a log.
    */
    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");
    }
}