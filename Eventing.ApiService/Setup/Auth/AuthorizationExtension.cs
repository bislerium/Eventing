namespace Eventing.ApiService.Setup.Auth;

public static class AuthorizationExtension
{
    public static void AddXAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization();
    } 
}