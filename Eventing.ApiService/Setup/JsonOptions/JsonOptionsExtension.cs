using System.Text.Json.Serialization;

namespace Eventing.ApiService.Setup.JsonOptions;

public static class JsonOptionsExtension
{
    public static void AddXJsonOptions(this IServiceCollection services)
    {
        // https://github.com/dotnet/aspnetcore/issues/57891
        var jsonStringEnumConverter = new JsonStringEnumConverter();
        services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
        {
            options.JsonSerializerOptions.Converters.Add(jsonStringEnumConverter);
        });
        services.ConfigureHttpJsonOptions(options => // For OpenApi
        {
            options.SerializerOptions.Converters.Add(jsonStringEnumConverter);
        });
    }
}