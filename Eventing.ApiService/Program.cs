using Eventing.ApiService.Data;
using Eventing.ApiService.Setup;
using Eventing.ApiService.Setup.Auth;
using Eventing.ApiService.Setup.Identity;
using Eventing.ApiService.Setup.JsonOptions;
using Eventing.ApiService.Setup.Jwt;
using Eventing.ApiService.Setup.NpgsqlDbContext;
using Eventing.ApiService.Setup.OpenApi;
using Eventing.ApiService.Setup.Scalar;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddXOpenApi();

builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

builder.Services.AddXJsonOptions();

builder.AddRedisDistributedCache("cache");

builder.AddXNpgSqlDbContextExtension();

builder.Services.AddXIdentityCore();

builder.Services.AddXJwt();

builder.Services.AddXAuthentication();

builder.Services.AddXAuthorization();

builder.Services.AddXMiscServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();
    app.UseXScalar();
    
    app.MapPost("/eventing-db-migrate", (EventingDbContext dbContext) => dbContext.Database.MigrateAsync());
}

//app.MapIdentityApi<>()

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();