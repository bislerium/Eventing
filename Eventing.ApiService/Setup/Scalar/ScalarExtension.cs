using Scalar.AspNetCore;

namespace Eventing.ApiService.Setup.Scalar;

public static class ScalarExtension
{
    public static void UseXScalar(this WebApplication app)
    {
        const string scalarUiPath = "/api-reference";
        app.MapScalarApiReference(scalarUiPath,
            options => options
                .WithTitle("Eventing Api Reference")
                .WithFavicon("https://scalar.com/logo-light.svg")
                .WithTheme(ScalarTheme.DeepSpace)
                .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient));
        app.MapGet("/", () => Results.Redirect(scalarUiPath, permanent: true))
            .ExcludeFromDescription();
    }
}