using Eventing.ApiService.Configuration;
using Eventing.ApiService.Services.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace Eventing.ApiService.Setup.Jwt;

public static class JwtExtension
{
    public static void AddXJwt(this IServiceCollection services)
    {
        services.AddOptionsWithValidateOnStart<JwtSettings>()
            .BindConfiguration(JwtSettings.SectionName)
            .ValidateDataAnnotations();
        
        services.AddSingleton<JwtTokenService>();
        
        services.AddSingleton<IConfigureOptions<JwtBearerOptions>, JwtBearerConfigureOptions>();
    }
}