using System;
using System.Text;
/*
    In this exercise you'll be working on an appointment scheduler for a beauty salon in New York that opened on September 15th in 2012.

    You have four tasks, which will all involve appointment dates. The dates and times will use one of the following three formats:

    -   "7/25/2019 13:45:00"
    -   "July 25, 2019 13:45:00"
    -   "Thursday, July 25, 2019 13:45:00"
    
    The tests will automatically set the culture to en-US - you don't have to set or specify the culture yourselves.
*/
static class Appointment1
{
    private static int day, month, year, hour, minute, second;

    /*
        Implement the (static) Appointment.Schedule() method to parse a textual representation of an appointment date into the corresponding DateTime format:
    */
    public static DateTime Schedule(string appointmentDateDescription)
    {
        DateTime? dateTime = null;
        string[] dateTimeArr;
        int format;
        
        try
        {
            dateTimeArr = appointmentDateDescription.Split(", ");
            format = dateTimeArr.Length;
        }
        catch(Exception)
        {
            format = 1;
        }

        switch (format)
        {
            case 1:     // "m/dd/yyyy hh:mm:ss"
                dateTime = appointmentDateDescription.SinglePartFormat();
                break;

            case 2:     // "Month dd, yyyy hh:mm:ss"
                dateTime = appointmentDateDescription.TwoPartFormat();
                break;

            case 3:     // "DoW, Month dd, yyyy hh:mm:ss"
                dateTime = appointmentDateDescription.ThreePartFormat();
                break;

            default:
                throw new FormatException("Invalid date format!");
        }
        return (DateTime) dateTime;
    }

    // "m/dd/yyyy hh:mm:ss"
    private static DateTime SinglePartFormat(this string appointmentDateDescription)
    {
        string[] dateTimeArr = appointmentDateDescription.Split(" ");
        string[] dateArr = dateTimeArr[0].Split("/");

        month = int.Parse(dateArr[0]);
        day = int.Parse(dateArr[1]);
        year = int.Parse(dateArr[2]);

        dateTimeArr[1].extract();

        return new DateTime(year, month, day, hour, minute, second);
    }

    // "Month dd, yyyy hh:mm:ss"
    private static DateTime TwoPartFormat(this string appointmentDateDescription)
    {
        string[] parts = appointmentDateDescription.Split(", ");    // {Monbth dd,yyyy hh:mm:ss}
        string[] left = parts[0].Split(" ");                        // {Month,dd}
        string[] right = parts[1].Split(" ");                       // {yyyy,hh:mm:ss}

        month = left[0].MonthToInt();
        day = int.Parse(left[1]);
        year = int.Parse(right[0]);

        right[1].extract();

        return new DateTime(year, month, day, hour, minute, second);
    }

    // "DoW, Month dd, yyyy hh:mm:ss"
    private static DateTime ThreePartFormat(this string appointmentDateDescription)
    {
        return appointmentDateDescription.TrimToTwoPartFormat().TwoPartFormat();
    }

    /*
        Three-part-format dateTime is similar to the two-part-format dateTime. This means that it could be trimmed to become two-part-format and we can reuse the TwoPartFormat() method.
    */
    private static string TrimToTwoPartFormat(this string appointmentDateDescription)
    {
        StringBuilder sb = new StringBuilder();
        int startIndex = appointmentDateDescription.IndexOf(", ") + 2;

        for (int i = startIndex; i < appointmentDateDescription.Length; i++)
            sb.Append(appointmentDateDescription[i]);

        return sb.ToString();
    }

    /*
        Extracts the time of the format hh:mm:ss and already asigns it to the static class variables.
    */
    private static void extract(this string time)
    {
        string[] timeArr = time.Split(":");
        hour = int.Parse(timeArr[0]);
        minute = int.Parse(timeArr[1]);;
        second = int.Parse(timeArr[2]);;
    }

    /*
        Converts given month string to its respective integer.
    */
    private static int MonthToInt(this string month)
    {
        string[] months = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};

        for (int i = 0; i < months.Length; i++)
            if (months[i] == month) return i + 1;

        return 0;
    }

    /*
        Implement the (static) Appointment.HasPassed() method that takes an appointment date and checks if the appointment was somewhere in the past:
    */
    public static bool HasPassed(DateTime appointmentDate)
    {
        DateTime now = DateTime.Now;
        return (appointmentDate < now);
    }

    /*
        Implement the (static) Appointment.IsAfternoonAppointment() method that takes an appointment date and checks if the appointment is in the afternoon (>= 12:00 and < 18:00):
    */
    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        int hour = appointmentDate.Hour;
        return (hour >= 12 && hour < 18);
    }

    /*
        Implement the (static) Appointment.Description() method that takes an appointment date and returns a description of that date and time: "You have an appointment on 3/29/2019 3:00:00 PM."
    */
    public static string Description(DateTime appointmentDate)
    {
        day = appointmentDate.Day;
        month = appointmentDate.Month;
        year = appointmentDate.Year;
        hour = appointmentDate.Hour;
        minute = appointmentDate.Minute;
        second = appointmentDate.Second;

        string dayTime = hour >= 0 && hour < 12 ? "AM" : "PM"; 
        if (dayTime == "PM") hour -= 12;

        return $"You have an appointment on {month}/{day}/{year} {hour}:{minute.formatToTwoDigits()}:{second.formatToTwoDigits()} {dayTime}.";
    }

    /*
        Reformat digit so that if we have single digit x, return 0x. Otherwise return number as it is as string.
    */
    private static string formatToTwoDigits(this int value)
    {
        string str = value.ToString();
        return str.Length < 2 ? "0"+str : str;
    }

    /*
        Implement the (static) Appointment.AnniversaryDate() method that returns this year's anniversary date, which is September 15th:
    */
    public static DateTime AnniversaryDate()
    {
        return new DateTime(DateTime.Today.Year, 9, 15);
    }
}