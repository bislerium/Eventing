using System.Text.Json.Serialization;
using Eventing.ApiService.Configuration;
using Eventing.ApiService.Data;
using Eventing.ApiService.Data.Seeders;
using Eventing.ApiService.Services.CurrentUser;
using Eventing.ApiService.Services.Jwt;
using Eventing.ApiService.Setup.OpenApi.Transformers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<BearerSecuritySchemeDocumentTransformer>();
    options.AddOperationTransformer<BearerSecuritySchemeOperationTransformer>();
});

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

builder.AddRedisDistributedCache("cache");

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

builder.Services.AddIdentityCore<IdentityUser<Guid>>()
    .AddSignInManager()
    .AddRoles<IdentityRole<Guid>>()
    .AddEntityFrameworkStores<EventingDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
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

builder.Services.AddOptionsWithValidateOnStart<JwtSettings>()
    .BindConfiguration(JwtSettings.SectionName)
    .ValidateDataAnnotations();

builder.Services.AddScoped<CurrentUserService>();
builder.Services.AddSingleton<JwtTokenService>();

builder.Services.AddSingleton<IConfigureOptions<JwtBearerOptions>, JwtBearerConfigureOptions>();
builder.Services.AddAuthentication().AddJwtBearer();


/*builder.Services.AddAuthentication()
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration
            .GetRequiredSection(JwtSettings.SectionName)
            .Get<JwtSettings>()!;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            RequireAudience = true,
            RequireSignedTokens = true,
            RequireExpirationTime = true,
            ValidateTokenReplay = true,
            TokenReplayCache = new cache();
            ClockSkew = TimeSpan.FromSeconds(200), // 2 minutes
            
            // Set both keys — for decrypting & validating
            TokenDecryptionKey = jwtSettings.EncryptingCredentials?.Key,
            IssuerSigningKey = jwtSettings.SigningCredentials.Key
        };
    });*/

builder.Services.AddAuthorization();

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

//app.MapIdentityApi<>()

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();