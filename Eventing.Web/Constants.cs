namespace Eventing.Web;

public static class Constants
{
    public static class HttpClients
    {
        public static class EventingApi
        {
            public const string Name = nameof(EventingApi);
        }
    }

    public static class ErrorMessages
    {
        public const string SomethingWentWrong = "Something went wrong.";
    }

    public static class Format
    {
        public static class DateTime
        {
            public const string MonthDayYearHourMinute = "MMM dd, yyyy hh:mm tt";
            public const string HourMinute12 = "hh:mm tt";
            public const string MonthDayYear = "MMM dd, yyyy"; 
        }
    }
}