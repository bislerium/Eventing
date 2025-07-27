namespace Eventing.ApiService.Setup.Auth;

public static class AuthenticationExtension
{
    public static void AddXAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication().AddJwtBearer();
    }
}