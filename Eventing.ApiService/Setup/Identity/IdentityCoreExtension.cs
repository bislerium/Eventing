using Eventing.ApiService.Data;
using Microsoft.AspNetCore.Identity;

namespace Eventing.ApiService.Setup.Identity;

public static class IdentityCoreExtension
{
    public static void AddXIdentityCore(this IServiceCollection services)
    {
        services.AddIdentityCore<IdentityUser<Guid>>()
            .AddSignInManager()
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<EventingDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            options.User.RequireUniqueEmail = true;

            options.SignIn.RequireConfirmedAccount = true;
            options.SignIn.RequireConfirmedEmail = false;

            options.Password.RequireDigit = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 10;
            options.Password.RequiredUniqueChars = 2;

            // Default Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;
        });
    }
}