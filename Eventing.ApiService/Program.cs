using Eventing.ApiService.Setup;
using Eventing.ApiService.Setup.Auth;
using Eventing.ApiService.Setup.DataProtection;
using Eventing.ApiService.Setup.DbContext;
using Eventing.ApiService.Setup.Emailing;
using Eventing.ApiService.Setup.Identity;
using Eventing.ApiService.Setup.JsonOptions;
using Eventing.ApiService.Setup.Jwt;
using Eventing.ApiService.Setup.OpenApi;
using Eventing.ApiService.Setup.Scalar;
using Eventing.ApiService.Setup.TickerQ;
using Eventing.ServiceDefaults;
using TickerQ.DependencyInjection;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddXOpenApi();

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

builder.Services.AddXJsonOptions();

builder.AddRedisDistributedCache("cache");

builder.AddXDbContext();

builder.Services.AddXIdentityCore();

builder.Services.AddXJwt();

builder.Services.AddXAuthentication();

builder.Services.AddXAuthorization();

// builder.Services.AddXDataProtection();

if (builder.Environment.IsDevelopment())
{
    builder.AddXTestEmailing();
}
else
{
    builder.AddXEmailing();
}

builder.Services.AddXTickerQ();

builder.Services.AddXMiscServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();
    app.UseXScalar();
}

//app.MapIdentityApi<>()

app.UseTickerQ();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapDefaultEndpoints();

app.Run();