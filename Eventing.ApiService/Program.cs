using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();

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

app.MapControllers();

app.Run();