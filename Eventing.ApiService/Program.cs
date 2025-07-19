using System.Text.Json.Serialization;
using Eventing.ApiService.Data;
using Eventing.ApiService.Data.Seeders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

// https://github.com/dotnet/aspnetcore/issues/57891
var jsonStringEnumConverter = new JsonStringEnumConverter();
builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(jsonStringEnumConverter);
});
builder.Services.ConfigureHttpJsonOptions(options => // For OpenApi
{
    options.SerializerOptions.Converters.Add(jsonStringEnumConverter);
});

builder.AddNpgsqlDbContext<EventingDbContext>(connectionName: "eventing-db",
    configureSettings: settings =>
    {
        if (builder.Environment.IsDevelopment())
        {
            settings.ConnectionString += ";Include Error Detail=true";
        }
    },
    configureDbContextOptions: options =>
    {
        if (builder.Environment.IsDevelopment())
        {
            options.EnableDetailedErrors()
                .EnableSensitiveDataLogging();
        }

        options.UseAsyncSeeding(async (context, _, ct) =>
        {
            await UserSeeder.SeedAsync(context, ct);
            await EventSeeder.SeedAsync(context, ct);
        });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();

    app.MapPost("/eventing-db-migrate", (EventingDbContext dbContext) => dbContext.Database.MigrateAsync());

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