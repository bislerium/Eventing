namespace Eventing.Web;

public static class Constants
{
    public static class CustomHeaders
    {
        public const string FallBackHeader = "X-FallBack";
    }

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

    public enum UserContextKey
    {
        RememberMe,
        AccessToken,
        ExpiresIn
    }
}