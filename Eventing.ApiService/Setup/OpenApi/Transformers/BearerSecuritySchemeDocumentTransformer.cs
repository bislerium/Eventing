using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

namespace Eventing.ApiService.Setup.OpenApi.Transformers;

// Refer to:
// https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/customize-openapi?view=aspnetcore-9.0#use-document-transformers
// https://devblogs.microsoft.com/dotnet/dotnet9-openapi/#customize-your-documents
public sealed class BearerSecuritySchemeDocumentTransformer : IOpenApiDocumentTransformer
{
    public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context,
        CancellationToken cancellationToken)
    {
        // Add the security scheme at the document level
        var requirements = new Dictionary<string, OpenApiSecurityScheme>
        {
            ["Bearer"] = new()
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer", // "bearer" refers to the header name here
                In = ParameterLocation.Header,
                BearerFormat = "Json Web Token"
            }
        };
        document.Components ??= new OpenApiComponents();
        document.Components.SecuritySchemes = requirements;

        return Task.CompletedTask;
    }
}